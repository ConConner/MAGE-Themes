using mage.Actions.GraphicsEditor;
using mage.Bookmarks;
using mage.Controls;
using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;

namespace mage.Editors.NewEditors;

public partial class FormGraphicsNew : Form
{
    private struct ToolSettings
    {
        public ToolSettings() { }

        public Tool SelectedTool;
        public int BrushSize = 1;
        public int GridWidth = 8;
        public int GridHeight = 8;
        public int ColorLeftIndex = -1;
        public int ColorRightIndex = -1;
        public Shape Shape = Shape.Rectangle;
    }

    private enum Tool
    {
        Select,
        Pen,
        Fill,
        Eyedropper,
        Shape,
    }

    private enum Shape
    {
        Rectangle,
        Ellipse,
        Line,
    }

    private bool init = false;

    // fields
    private FormMain main;
    private GFX loadedGFX;
    private Palette loadedPalette;
    private ToolSettings settings = new ToolSettings();
    private GraphicsUndoRedo UndoRedo = new GraphicsUndoRedo();

    private TileDisplay tileDisplay_palette;
    private DualColorBox colorDisplay;

    private GraphicsActionGroup? latestActionGroup;

    private Point LastPixel = Point.Empty;
    private Point? SelectionPivot = null;

    private Status Status;

    // Drawables
    private static float[] DashPattern = new float[] { 2, 3 };
    private Pen DottedPenWhite = new Pen(Color.White, 1) { DashPattern = DashPattern };
    private Pen DottedPenBlack = new Pen(Color.Black, 1) { DashPattern = DashPattern, DashOffset = 2 };
    private Drawable Selection;

    private Pen ShapePen = new Pen(Color.Aqua, 1) { DashPattern = DashPattern };
    private Drawable ShapeDrawable;

    // Properties
    private Tool SelectedTool
    {
        get => settings.SelectedTool;
        set
        {
            if (settings.SelectedTool == value) return;
            settings.SelectedTool = value;

            UntoggleAllTools();
            switch (value)
            {
                case Tool.Select:
                    button_toolSelect.Checked = true;
                    break;
                case Tool.Pen:
                    button_toolPen.Checked = true;
                    break;
                case Tool.Fill:
                    button_toolFill.Checked = true;
                    break;
                case Tool.Shape:
                    button_toolShape.Checked = true;
                    break;
            }
        }
    }

    private int ColorLeft
    {
        get => settings.ColorLeftIndex;
        set
        {
            if (settings.ColorLeftIndex == value) return;
            settings.ColorLeftIndex = value;
            colorDisplay.ColorLeft = loadedPalette.GetOpaqueColor(0, value);
        }
    }
    private int ColorRight
    {
        get => settings.ColorRightIndex;
        set
        {
            if (settings.ColorRightIndex == value) return;
            settings.ColorRightIndex = value;
            colorDisplay.ColorRight = loadedPalette.GetOpaqueColor(0, value);
        }
    }

    private int SelectionDashOffset
    {
        get => (int)DottedPenWhite.DashOffset;
        set
        {
            DottedPenWhite.DashOffset = value;
            ShapePen.DashOffset = value;
            DottedPenBlack.DashOffset = value + 2;
        }
    }


    public FormGraphicsNew(FormMain main, int gfxOffset, int width, int height, int palOffset)
    {
        InitializeComponent();
        // Theme Switching
        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        this.main = main;

        init = true;
        textBox_imageOffset.Text = Hex.ToString(gfxOffset);
        textBox_palOffset.Text = Hex.ToString(palOffset);
        if (height == 0) checkBox_compressed.Checked = true;
        else
        {
            numericUpDown_width.Value = width;
            numericUpDown_height.Value = height;
        }
        init = false;

        // Intialize Drawables
        Selection = new Drawable(Rectangle.Empty, DottedPenWhite, 1) { Visible = false };
        Selection.DrawPens.Add(DottedPenBlack);
        tileDisplay_gfx.AddDrawable(Selection);
        ShapeDrawable = new Drawable(Rectangle.Empty, ShapePen, 1) { Visible = false };
        ShapeDrawable.DrawPens.Add(DottedPenBlack);
        tileDisplay_gfx.AddDrawable(ShapeDrawable);

        // Selection Animation
        Timer dashAnimationTimer = new Timer { Interval = 100 };
        dashAnimationTimer.Tick += (_, _) =>
        {
            SelectionDashOffset += 1;
            if (Selection.Visible) Selection.InvalidateDrawable(Selection);
            if (ShapeDrawable.Visible) ShapeDrawable.InvalidateDrawable(ShapeDrawable);
        };
        dashAnimationTimer.Start();

        //Populate toolstrip
        AddPaletteDisplay();
        SelectedTool = Tool.Pen;

        LoadData();
        Status = new Status(statusLabel_changes, button_apply);

        ColorLeft = 1;
        ColorRight = 0;
    }

    private void LoadData()
    {
        if (!LoadPalette(0)) return;
        if (!LoadNewGFX()) return;
        DrawPalette();
        DrawGFX();
    }

    private void Save()
    {
        int prevOffset = loadedGFX.Offset;
        loadedGFX.Write(ROM.Stream, false);

        FormMain.UpdateEditors();
        Status.Save();

        if (prevOffset != loadedGFX.Offset)
        {
            textBox_imageOffset.Text = Hex.ToString(loadedGFX.Offset);
            if (
                MessageBox.Show(
                    "The graphics need to be repointed.\n\nDo you want to save the new location as a Bookmark?",
                    "Repointing required", MessageBoxButtons.YesNo, MessageBoxIcon.Information
                )
                == DialogResult.Yes
                && BookmarkManager.RepointedDataCreateBookmark(prevOffset, loadedGFX.Offset)
            ) return;

            string message = "Graphics were repointed to " + Hex.ToString(loadedGFX.Offset);
            MessageBox.Show(message, "Repointed Graphics", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void AddPaletteDisplay()
    {
        tileDisplay_palette = new() { TileSize = 17 }; // Displays palette
        tileDisplay_palette.TileMouseDown += TileDisplay_palette_TileMouseDown;
        colorDisplay = new(); // Displays selected colors

        var paletteHost = new ToolStripControlHost(tileDisplay_palette)
        {
            AutoSize = false,
            Size = new Size(16 * 16 + 17, 22)
        };
        toolStrip_palette.Items.Insert(toolStrip_palette.Items.IndexOf(button_increasePalette), paletteHost);

        var colorHost = new ToolStripControlHost(colorDisplay);
        toolStrip_palette.Items.Insert(0, colorHost);
    }

    private Rectangle GetRectangleFromPoints(Point p1, Point p2)
    {
        int x = Math.Min(p1.X, p2.X);
        int y = Math.Min(p1.Y, p2.Y);
        int width = Math.Abs(p1.X - p2.X) + 1;
        int height = Math.Abs(p1.Y - p2.Y) + 1;
        return new Rectangle(x, y, width, height);
    }

    #region General Events
    private void button_load_Click(object sender, EventArgs e) => LoadData();

    private void button_apply_Click(object sender, EventArgs e) => Save();
    #endregion

    #region Tools
    private void button_toolSelect_Click(object sender, EventArgs e) => SelectedTool = Tool.Select;
    private void button_toolPen_Click(object sender, EventArgs e) => SelectedTool = Tool.Pen;
    private void button_toolFill_Click(object sender, EventArgs e) => SelectedTool = Tool.Fill;
    private void button_toolShape_Click(object sender, EventArgs e) => SelectedTool = Tool.Shape;

    private void UntoggleAllTools()
    {
        button_toolSelect.Checked = false;
        button_toolPen.Checked = false;
        button_toolFill.Checked = false;
        button_toolShape.Checked = false;
    }
    #endregion

    #region Undo Redo
    public void AddAction(GraphicsAction a)
    {
        UndoRedo.AddActionWithoutDo(a);
        setUndoRedoButtons();

        Status.ChangeMade();
    }

    private void setUndoRedoButtons()
    {
        button_undo.Enabled = UndoRedo.CanUndo;
        button_redo.Enabled = UndoRedo.CanRedo;
        DrawGFX();
    }

    private void button_undo_ButtonClick(object sender, EventArgs e)
    {
        UndoRedo.Undo();
        setUndoRedoButtons();
    }

    private void button_redo_ButtonClick(object sender, EventArgs e)
    {
        UndoRedo.Redo();
        setUndoRedoButtons();
    }
    #endregion

    #region GFX
    private bool LoadNewGFX()
    {
        int offset;
        try
        {
            offset = Hex.ToInt(textBox_imageOffset.Text);
        }
        catch (Exception ex)
        {
            MessageBox.Show("The offset entered was not valid.\n\n" + ex.GetType().ToString() + '\n'
                        + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        int width = (int)numericUpDown_height.Value;

        if (checkBox_compressed.Checked)
        {
            try
            {
                int len = ROM.Stream.Read32(offset) >> 8;
                if (ROM.Stream.Read8(offset) != 0x10 || len == 0)
                {
                    throw new FormatException();
                }
                loadedGFX = new GFX(ROM.Stream, offset, width);
                if (loadedGFX.origLen == 0)
                {
                    throw new FormatException();
                }
            }
            catch
            {
                MessageBox.Show("There are no compressed graphics at the given offset.",
                    "Compressed graphics error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        else
        {
            int height = (int)numericUpDown_height.Value;
            loadedGFX = new GFX(ROM.Stream, offset, width, height);
        }

        statusLabel_changes.Text = "";
        return true;
    }

    private void DrawGFX()
    {
        tileDisplay_gfx.TileImage = loadedGFX.Draw4bpp(loadedPalette, 0, true);
        statusLabel_size.Text = tileDisplay_gfx.TileImage.Width + " x " + tileDisplay_gfx.TileImage.Height;
    }

    private void DoDrawPixel(Point p, int palIndex)
    {
        var drawAction = new EditPixelAction(loadedGFX, p, palIndex);
        drawAction.Do();
        if (latestActionGroup != null) latestActionGroup.AddAction(drawAction);
        DrawGFX();
    }

    private void checkBox_compressed_CheckedChanged(object sender, EventArgs e)
    {
        numericUpDown_height.Enabled = !checkBox_compressed.Checked;
    }

    // Editing Events
    private void tileDisplay_gfx_TileMouseDown(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        switch (SelectedTool)
        {
            case Tool.Pen:
                if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right) break;

                // Place Pixels
                latestActionGroup = new GraphicsActionGroup();
                if (e.Button == MouseButtons.Left) DoDrawPixel(e.PixelPosition, ColorLeft);
                if (e.Button == MouseButtons.Right) DoDrawPixel(e.PixelPosition, ColorRight);
                break;

            case Tool.Select:
                if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right) break;

                SelectionPivot = e.PixelPosition;
                Selection.Visible = true;
                Selection.Rectangle = new Rectangle(e.PixelPosition, new Size(1, 1));
                break;
            case Tool.Fill:
                break;

            case Tool.Shape:
                if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right) break;

                SelectionPivot = e.PixelPosition;
                ShapeDrawable.Visible = true;
                ShapeDrawable.Rectangle = new Rectangle(e.PixelPosition, new Size(1, 1));
                break;
        }
    }

    private void tileDisplay_gfx_TileMouseMove(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        // Only Update if moved to a new pixel
        if (e.PixelPosition == LastPixel) return;
        LastPixel = e.PixelPosition;

        switch (SelectedTool)
        {
            case Tool.Pen:
                if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right) break;

                // Place Pixels
                if (e.Button == MouseButtons.Left) DoDrawPixel(e.PixelPosition, ColorLeft);
                if (e.Button == MouseButtons.Right) DoDrawPixel(e.PixelPosition, ColorRight);
                break;

            case Tool.Select:
                if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right) break;
                if (SelectionPivot == null) break;

                Selection.Rectangle = GetRectangleFromPoints(SelectionPivot.Value, e.PixelPosition);
                break;
            case Tool.Fill:
                break;

            case Tool.Shape:
                if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right) break;
                if (SelectionPivot == null) break;

                ShapeDrawable.Rectangle = GetRectangleFromPoints(SelectionPivot.Value, e.PixelPosition);
                break;
        }
    }

    private void tileDisplay_gfx_TileMouseUp(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        switch (SelectedTool)
        {
            case Tool.Pen:
                break;
            case Tool.Select:
                break;
            case Tool.Fill:
                break;
            case Tool.Shape:
                ShapeDrawable.Visible = false;

                switch (settings.Shape)
                {
                    case Shape.Rectangle:
                        int _color = e.Button == MouseButtons.Left ? settings.ColorLeftIndex : settings.ColorRightIndex;
                        var rectangleAction = new DrawAreaAction(loadedGFX, ShapeDrawable.Rectangle, _color);
                        AddAction(rectangleAction);
                        rectangleAction.Do();
                        DrawGFX();
                        break;

                    case Shape.Ellipse:
                        break;
                    case Shape.Line:
                        break;
                }
                break;
        }

        // Finalise Action Group
        if (latestActionGroup != null) AddAction(latestActionGroup);
        latestActionGroup = null;

        // Clear variables
        SelectionPivot = null;
    }
    #endregion

    #region Palette
    private bool LoadPalette(int diff)
    {
        try
        {
            int offset = Hex.ToInt(textBox_palOffset.Text);
            if (diff != 0)
            {
                offset += diff;
                textBox_palOffset.Text = Hex.ToString(offset);
            }

            loadedPalette = new Palette(ROM.Stream, offset, 1);
        }
        catch (Exception ex)
        {
            MessageBox.Show("The offset entered was not valid.\n\n" + ex.GetType().ToString() + '\n'
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }

    private void DrawPalette()
    {
        tileDisplay_palette.TileImage = loadedPalette.Draw(16, 0, 1, gridColorArgb: 0);
    }

    private void TileDisplay_palette_TileMouseDown(object? sender, TileDisplay.TileDisplayArgs e)
    {
        int palIndex = e.TileIndexPosition.X;
        if (e.Button == MouseButtons.Left) ColorLeft = palIndex;
        else if (e.Button == MouseButtons.Right) ColorRight = palIndex;
    }

    private void button_increasePalette_Click(object sender, EventArgs e)
    {
        LoadPalette(32);
        DrawPalette();
        DrawGFX();
    }

    private void button_decreasePalette_Click(object sender, EventArgs e)
    {
        LoadPalette(-32);
        DrawPalette();
        DrawGFX();
    }
    #endregion

    #region Zoom
    const int maxZoom = 4;

    private void button_imageZoomIn_Click(object sender, EventArgs e) => updateZoom(tileDisplay_gfx.Zoom + 1);
    private void button_imageZoomOut_Click(object sender, EventArgs e) => updateZoom(tileDisplay_gfx.Zoom - 1);

    private void tileDisplay_gfx_Scrolled(object sender, MouseEventArgs e)
    {
        if ((ModifierKeys & Keys.Control) == Keys.Control)
        {
            if (e.Delta > 0) updateZoom(tileDisplay_gfx.Zoom + 1);
            if (e.Delta < 0) updateZoom(tileDisplay_gfx.Zoom - 1);
        }
    }

    private void updateZoom(int value)
    {
        tileDisplay_gfx.Zoom = Math.Clamp(value, 0, maxZoom);
        button_imageZoomIn.Enabled = tileDisplay_gfx.Zoom < maxZoom;
        button_imageZoomOut.Enabled = tileDisplay_gfx.Zoom > 0;
        label_imageZoom.Text = $"{1 << tileDisplay_gfx.Zoom}00%";
    }
    #endregion
}
