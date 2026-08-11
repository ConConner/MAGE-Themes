using mage.Actions;
using mage.Actions.PaletteEditor;
using mage.Controls;
using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace mage.Editors.NewEditors;

public partial class FormPaletteNew : Form
{
    public static void OpenPaletteEditor(bool tileset, byte value)
    {
        if (Program.ExperimentalFeaturesEnabled) new FormPaletteNew(tileset, value).Show();
        else new FormPalette(FormMain.Instance, tileset, value).Show();
    }
    public static void OpenPaletteEditor(int offset, int rows)
    {
        if (Program.ExperimentalFeaturesEnabled) new FormPaletteNew(offset, rows).Show();
        else new FormPalette(FormMain.Instance, offset, rows).Show();
    }

    private enum Tool
    {
        Select,
        Pen,
        Eyedropper
    }

    #region Fields
    // State
    private bool init = false;
    private bool ignoreColorSwatchUpdate = false;
    private Palette palette;
    private Status status;
    private GenericUndoRedo UndoRedo = new();
    private EditorGridActionGroup? latestActionGroup = null;
    private Point? SelectionPivot = null;
    private Point? MovingPivot = null;

    // Colors
    private ushort colorPrimary = 0;
    private ushort colorSecondary = ushort.MaxValue;

    // Undo Redo
    private GenericUndoRedo undoRedo = new();

    // Drawables
    private static float[] DashPattern = new float[] { 2, 3 };
    private Pen DottedPenWhite = new Pen(Color.White, 1) { DashPattern = DashPattern };
    private Pen DottedPenBlack = new Pen(Color.Black, 1) { DashPattern = DashPattern, DashOffset = 2 };
    private Drawable Selection;
    private int SelectionDashOffset
    {
        get => (int)DottedPenWhite.DashOffset;
        set
        {
            DottedPenWhite.DashOffset = value;
            DottedPenBlack.DashOffset = value + 2;
        }
    }
    private bool SelectionVisible
    {
        get => Selection.Visible;
        set
        {
            if (Selection.Visible == value) return;
            Selection.Visible = value;
        }
    }

    new private Drawable Cursor;
    private Pen CursorPen = new Pen(Color.Red, 1);


    // Selection
    private ushort[,]? selectedColors = null;
    private bool movingSelection = false;

    // Tools
    private Tool SelectedTool
    {
        get;
        set
        {
            if (field == value) return;
            field = value;

            Cursor.Visible = false;
            UntoggleAllTools();
            switch (value)
            {
                case Tool.Select:
                    button_toolSelect.Checked = true;
                    break;
                case Tool.Pen:
                    Cursor.Visible = true;
                    button_toolPen.Checked = true;
                    break;
                case Tool.Eyedropper:
                    Cursor.Visible = true;
                    button_eyeDropper.Checked = true;
                    break;
            }

            // Paste selection if still there
            if (selectedColors is not null) ; //PasteSelectedPixels()

            FinishToolAction();
        }
    } = Tool.Pen;
    #endregion

    #region Constructor
    private FormPaletteNew()
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);
        ThemeSwitcher.ThemeChanged += ThemeSwitcher_ThemeChanged;
        ThemeColorBar();

        textBox_hex_color.TextChanged += TextBox_hex_color_TextChanged;

        status = new(statusLabel_changes, button_apply);

        updateZoom(1);
        tileDisplay_pal.ShowGrid = true;

        // Intialize Drawables
        Selection = new Drawable(Rectangle.Empty, DottedPenWhite, 1) { Visible = false };
        Selection.DrawPens.Add(DottedPenBlack);
        tileDisplay_pal.AddDrawable(Selection);
        Cursor = new Drawable(Rectangle.Empty, CursorPen, 0) { Visible = false };
        tileDisplay_pal.AddDrawable(Cursor);

        Timer dashAnimationTimer = new Timer { Interval = 100 };
        dashAnimationTimer.Tick += (_, _) =>
        {
            SelectionDashOffset += 1;
            if (SelectionVisible) Selection.InvalidateDrawable(Selection);
        };
        dashAnimationTimer.Start();
    }

    public FormPaletteNew(bool tileset, byte value) : this()
    {
        if (tileset) LoadPaletteFromTileset(value);
        else LoadPaletteFromSprite(value);
    }

    public FormPaletteNew(int offset, int rows) : this()
    {
        textBox_offset.Text = Hex.ToString(offset);
        numericUpDown_rows.Value = rows;

        LoadPalette();
    }
    #endregion

    #region Generic Helpers
    private void ThemeColorBar()
    {
        colorBar_blue.MarkerColor = colorBar_green.MarkerColor = colorBar_red.MarkerColor = ThemeSwitcher.ProjectTheme.BackgroundColor;
        colorBar_blue.BorderColor = colorBar_green.BorderColor = colorBar_red.BorderColor = ThemeSwitcher.ProjectTheme.PrimaryOutline;

        colorPicker.MarkerColor = ThemeSwitcher.ProjectTheme.BackgroundColor;
        colorPicker.BorderColor = ThemeSwitcher.ProjectTheme.PrimaryOutline;

        colorSwatch.SwatchOutlineColor = ThemeSwitcher.ProjectTheme.SecondaryOutline;
        colorSwatch.SwapGlyphColor = ThemeSwitcher.ProjectTheme.PrimaryOutline;
        colorSwatch.SwapGlyphHotColor = ThemeSwitcher.ProjectTheme.AccentColor;
    }

    private void LoadPalette()
    {
        if (!CheckUnsaved()) return;

        try
        {
            int offset = Hex.ToInt(textBox_offset.Text);
            int rows = (int)numericUpDown_rows.Value;

            palette = new Palette(ROM.Stream, offset, rows);
            DrawPalette();
            status.LoadNew();
            UndoRedo = new();
            setUndoRedoButtons();
        }
        catch (Exception ex)
        {
            MessageBox.Show("The offset entered was not valid.\n\n" + ex.GetType().ToString() + '\n'
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadPaletteFromTileset(byte tileset)
    {
        int headerOffset = Version.TilesetOffset + tileset * 0x14;
        int BGpaletteOffset = ROM.Stream.ReadPtr(headerOffset + 0x4);

        textBox_offset.Text = Hex.ToString(BGpaletteOffset);
        numericUpDown_rows.Value = 14;
        LoadPalette();
    }

    private void LoadPaletteFromSprite(byte sprite)
    {
        if (sprite < 0x10) { return; }

        // TODO: reuse code
        int addVal = (sprite - 0x10) * 4;

        // get gfx rows
        int numGfxRows;
        if (Version.IsMF)
        {
            int offset = Version.SpriteGfxRowsOffset + addVal;
            numGfxRows = ROM.Stream.Read16(offset) / 0x800;
        }
        else
        {
            int offset = Version.SpriteGfxOffset + addVal;
            int gfxOffset = ROM.Stream.ReadPtr(offset);
            numGfxRows = Math.Max(ROM.Stream.Read16(gfxOffset + 1) / 0x800, 1);
        }

        // get palette
        int palPtr = Version.SpritePaletteOffset + addVal;
        int palOffset = ROM.Stream.ReadPtr(palPtr);
        // code to move ends here

        textBox_offset.Text = Hex.ToString(palOffset);
        numericUpDown_rows.Value = numGfxRows;
        LoadPalette();
    }

    private void Save()
    {
        palette.Write(ROM.Stream);
        status.Save();
        FormMain.UpdateEditors();
    }

    /// <summary>
    /// Prompts the user if they want to save the current changes or cancel.
    /// </summary>
    /// <returns>False if cancelled. True for other options. Saves if yes is clicked</returns>
    private bool CheckUnsaved()
    {
        if (!status.UnsavedChanges) return true;
        DialogResult result = MessageBox.Show("Do you want to save changes to Palette?",
            "Unsaved Changes", MessageBoxButtons.YesNoCancel);
        if (result == DialogResult.Cancel) return false;
        if (result == DialogResult.Yes) Save();
        return true;
    }

    private Color Rgb5ToColor(int r, int g, int b) => Color.FromArgb(r * 8, g * 8, b * 8);
    private void ColorToRgb5(Color c, out int r, out int g, out int b)
    {
        r = c.R / 8;
        g = c.G / 8;
        b = c.B / 8;
    }
    private ushort Rgb5ToArgb(int r, int g, int b, bool transparent = false)
    {
        ushort argb = (ushort)((r << 10) | (g << 5) | b);
        if (!transparent) argb |= 0x8000;
        return argb;
    }
    #endregion

    #region Generic Events
    private void ThemeSwitcher_ThemeChanged(object? sender, EventArgs e) => ThemeColorBar();

    private void button_load_Click(object sender, EventArgs e) => LoadPalette();

    private void button_minus_Click(object sender, EventArgs e)
    {
        textBox_offset.Text = Hex.ToString(Hex.ToInt(textBox_offset.Text) - 0x20);
        LoadPalette();
    }

    private void button_plus_Click(object sender, EventArgs e)
    {
        textBox_offset.Text = Hex.ToString(Hex.ToInt(textBox_offset.Text) + 0x20);
        LoadPalette();
    }

    private void button_grid_CheckStateChanged(object sender, EventArgs e) => tileDisplay_pal.ShowGrid = button_grid.Checked;

    private void FormPaletteNew_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (CheckUnsaved()) return;
        e.Cancel = true;
    }
    #endregion

    #region Tool Events
    private void UntoggleAllTools()
    {
        button_toolSelect.Checked = false;
        button_toolPen.Checked = false;
        button_eyeDropper.Checked = false;
    }

    private void button_toolSelect_Click(object sender, EventArgs e) => SelectedTool = Tool.Select;
    private void button_toolPen_Click(object sender, EventArgs e) => SelectedTool = Tool.Pen;
    private void button_eyeDropper_Click(object sender, EventArgs e) => SelectedTool = Tool.Eyedropper;
    #endregion

    #region Color Controls
    private void SetSelectedColors()
    {
        int r, g, b;
        ColorToRgb5(colorSwatch.PrimaryColor, out r, out g, out b);
        colorPrimary = Rgb5ToArgb(r, g, b);
        ColorToRgb5(colorSwatch.SecondaryColor, out r, out g, out b);
        colorSecondary = Rgb5ToArgb(r, g, b);
    }

    private void UpdateSelectedColor(int r, int g, int b, bool preventColorPickerUpdate = false, bool preventTextBoxUpdate = false)
    {
        init = true;

        Color current = Rgb5ToColor(r, g, b);

        colorBar_red.SetColor(r, g, b);
        colorBar_green.SetColor(r, g, b);
        colorBar_blue.SetColor(r, g, b);

        numericUpDown_red.Value = r;
        numericUpDown_green.Value = g;
        numericUpDown_blue.Value = b;

        if (!preventTextBoxUpdate) textBox_hex_color.Text = ColorOperations.ToHexString(current);
        if (!preventColorPickerUpdate) colorPicker.SetRgb5(r, g, b);

        ignoreColorSwatchUpdate = true;
        colorSwatch.PrimaryColor = current;
        ignoreColorSwatchUpdate = false;

        // Update actual color selection
        SetSelectedColors();

        init = false;
    }

    private void colorBars_ValueChanged(object sender, EventArgs e)
    {
        if (init) return;
        var bar = sender as ColorBar;
        if (bar is null) return;

        UpdateSelectedColor(bar.Red, bar.Green, bar.Blue);
    }

    private void colorPicker_ColorChanged(object sender, EventArgs e)
    {
        if (init) return;
        int red, green, blue;
        colorPicker.GetRgb5(out red, out green, out blue);
        UpdateSelectedColor(red, green, blue, true);
    }

    private void numericUpDown_red_ValueChanged(object sender, EventArgs e)
    {
        if (init) return;
        int r = (int)numericUpDown_red.Value;
        int g = (int)numericUpDown_green.Value;
        int b = (int)numericUpDown_blue.Value;
        UpdateSelectedColor(r, g, b);
    }

    private void TextBox_hex_color_TextChanged(object? sender, EventArgs e)
    {
        if (init) return;

        //Do a Regex check if value is actually a hex number
        string text = textBox_hex_color.Text;
        text = Regex.Match(text, @"[0-9a-fA-F]+").Value;
        if (text.Length != 6) return; //if 6 numbers are not given
        text = text.Insert(0, "#");
        Color c = ColorTranslator.FromHtml(text);

        int r, g, b;
        ColorToRgb5(c, out r, out g, out b);

        UpdateSelectedColor(r, g, b, false, true);
    }

    private void colorSwatch_ColorsChanged(object sender, EventArgs e)
    {
        if (ignoreColorSwatchUpdate) return;
        int r, g, b;
        ColorToRgb5(colorSwatch.PrimaryColor, out r, out g, out b);
        UpdateSelectedColor(r, g, b);
    }
    #endregion

    #region Palette Display
    private void DrawPalette()
    {
        tileDisplay_pal.TileImage = palette.Draw(16, 0, palette.Rows, noGrid: true);
    }

    private void PenDraw(ushort color, Point location)
    {
        EditPalettePixelAction a = new(palette, location, color);
        a.Do();
        if (latestActionGroup is not null) latestActionGroup.AddAction(a);
        else AddAction(a);
        DrawPalette();
    }

    private void FinishToolAction()
    {
        // Clear variables
        SelectionPivot = null;
        MovingPivot = null;
        movingSelection = false;
    }

    private void PickColor(Point location, bool rightClick)
    {
        Color pick = palette.GetOpaqueColor(location.Y, location.X);
        int r, g, b;
        ColorToRgb5(pick, out r, out g, out b);
        if (!rightClick) UpdateSelectedColor(r, g, b);
        else
        {
            colorSwatch.SecondaryColor = pick;
            SetSelectedColors();
        }
    }

    private void tileDisplay_pal_TileMouseDown(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        if (e.TileIndexPosition.X < 0 || e.TileIndexPosition.Y < 0 || e.PixelPosition.X > tileDisplay_pal.TileImage.Width || e.PixelPosition.Y > tileDisplay_pal.TileImage.Height) return;

        bool left = e.Button == MouseButtons.Left;
        bool right = e.Button == MouseButtons.Right;
        bool alt = ModifierKeys == Keys.Alt;

        if (!left && !right) return;

        switch (SelectedTool)
        {
            case Tool.Pen:
                if (alt)
                {
                    PickColor(e.TileIndexPosition, right);
                    break;
                }

                latestActionGroup = new();
                ushort color = left ? colorPrimary : colorSecondary;
                PenDraw(color, e.TileIndexPosition);
                break;

            case Tool.Select:
                break;

            case Tool.Eyedropper:
                PickColor(e.TileIndexPosition, right);
                break;
        }
    }

    private void tileDisplay_pal_TileMouseMove(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        if (e.TileIndexPosition.X == Cursor.X && e.TileIndexPosition.Y == Cursor.Y) return;
        if (e.TileIndexPosition.X < 0 || e.TileIndexPosition.Y < 0 || e.PixelPosition.X > tileDisplay_pal.TileImage.Width || e.PixelPosition.Y > tileDisplay_pal.TileImage.Height) return;
        Cursor.Rectangle = new Rectangle(e.TilePixelPosition.X, e.TilePixelPosition.Y, 16, 16);

        bool left = e.Button == MouseButtons.Left;
        bool right = e.Button == MouseButtons.Right;

        if (!left && !right) return;

        switch (SelectedTool)
        {
            case Tool.Pen:
                Cursor.Visible = true;
                ushort color = left ? colorPrimary : colorSecondary;
                PenDraw(color, e.TileIndexPosition);
                break;

            case Tool.Select:
                break;
        }
    }

    private void tileDisplay_pal_TileMouseUp(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        switch (SelectedTool)
        {
            case Tool.Pen:
                if (latestActionGroup is null) break;
                AddAction(latestActionGroup);
                latestActionGroup = null;
                break;

            case Tool.Select:
                break;
        }
    }
    #endregion

    #region Undo Redo
    public void AddAction(EditorGridAction a)
    {
        UndoRedo.AddActionWithoutDo(a);
        setUndoRedoButtons();

        status.ChangeMade();
    }

    private void DiscardSelection()
    {
        if (selectedColors is null) return;
        if (latestActionGroup?.ActionCount == 1) latestActionGroup.Undo();
        latestActionGroup = null;
        selectedColors = null;
        SelectionVisible = false;
    }

    private void Undo()
    {
        DiscardSelection();
        FinishToolAction();
        UndoRedo.Undo();
        setUndoRedoButtons();
        status.ChangeMade();
    }

    private void Redo()
    {
        DiscardSelection();
        FinishToolAction();
        UndoRedo.Redo();
        setUndoRedoButtons();
        status.ChangeMade();
    }

    private void PopulateUndoRedoList(ToolStripSplitButton button, DropOutStack<EditorGridAction> stack)
    {
        int count = Math.Min(16, stack.Count);
        int lastIndex = stack.Count - 1;

        button.DropDownItems.Clear();
        for (int i = 0; i < count; i++)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Tag = i + 1;
            item.Text = stack[lastIndex - i].ActionText;
            button.DropDownItems.Add(item);
        }
    }

    private void setUndoRedoButtons()
    {
        button_undo.Enabled = UndoRedo.CanUndo;
        button_redo.Enabled = UndoRedo.CanRedo;
        if (palette is not null) DrawPalette();
    }

    private void button_undo_ButtonClick(object sender, EventArgs e) => Undo();

    private void button_redo_ButtonClick(object sender, EventArgs e) => Redo();

    private void button_undo_DropDownOpening(object sender, EventArgs e) => PopulateUndoRedoList(button_undo, UndoRedo.UndoStack);

    private void button_redo_DropDownOpening(object sender, EventArgs e) => PopulateUndoRedoList(button_redo, UndoRedo.RedoStack);

    private void button_undo_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        int num = (int)e.ClickedItem.Tag;
        for (int i = 0; i < num; i++) Undo();
    }

    private void button_redo_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        int num = (int)e.ClickedItem.Tag;
        for (int i = 0; i < num; i++) Redo();
    }
    #endregion

    #region Zoom
    const int maxZoom = 4;

    private void button_imageZoomIn_Click(object sender, EventArgs e) => updateZoom(tileDisplay_pal.Zoom + 1);
    private void button_imageZoomOut_Click(object sender, EventArgs e) => updateZoom(tileDisplay_pal.Zoom - 1);

    private void tileDisplay_pal_Scrolled(object sender, MouseEventArgs e)
    {
        if ((ModifierKeys & Keys.Control) == Keys.Control)
        {
            if (e.Delta > 0) updateZoom(tileDisplay_pal.Zoom + 1);
            if (e.Delta < 0) updateZoom(tileDisplay_pal.Zoom - 1);
        }
    }

    private void updateZoom(int value)
    {
        tileDisplay_pal.Zoom = Math.Clamp(value, 0, maxZoom);
        button_ZoomIn.Enabled = tileDisplay_pal.Zoom < maxZoom;
        button_ZoomOut.Enabled = tileDisplay_pal.Zoom > 0;
        label_Zoom.Text = $"{1 << tileDisplay_pal.Zoom}00%";
    }
    #endregion
}
