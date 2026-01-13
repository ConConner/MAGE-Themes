using mage.Actions.GraphicsEditor;
using mage.Bookmarks;
using mage.Controls;
using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mage.Editors.NewEditors;

public partial class FormGraphicsNew : Form
{
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

    [Flags]
    private enum FillRestrictions
    {
        Neighbouring = 1,
        Grid = 2
    }

    private bool init = false;

    // fields
    private FormMain main;
    private GFX loadedGFX;
    private Palette loadedPalette;
    private GraphicsUndoRedo UndoRedo = new GraphicsUndoRedo();

    private TileDisplay tileDisplay_palette;
    private DualColorBox colorDisplay;

    private GraphicsActionGroup? latestActionGroup;

    private Point LastPixel = Point.Empty;
    private Point? SelectionPivot = null;

    private Status Status;

    private FillRestrictions FillToolRestrictions = FillRestrictions.Neighbouring;

    // Drawables
    private static float[] DashPattern = new float[] { 2, 3 };
    private Pen DottedPenWhite = new Pen(Color.White, 1) { DashPattern = DashPattern };
    private Pen DottedPenBlack = new Pen(Color.Black, 1) { DashPattern = DashPattern, DashOffset = 2 };
    private Drawable Selection;

    private Pen ShapePen = new Pen(Color.Aqua, 1) { DashPattern = DashPattern };
    private Drawable ShapeDrawable;

    private Pen GridPen = new Pen(Color.White, 1);
    private Pen PixelGridPen = new Pen(Color.Gray, 1);

    #region Properties
    private Tool SelectedTool
    {
        get;
        set
        {
            if (field == value) return;
            field = value;

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
                    panel_fillSettings.Visible = true;
                    break;
                case Tool.Shape:
                    button_toolShape.Checked = true;
                    //panel_shapeSettings.Visible = true;
                    break;
                case Tool.Eyedropper:
                    button_eyeDropper.Checked = true;
                    break;
            }

            FinishToolAction();
        }
    }
    private Shape SelectedShape
    {
        get;
        set
        {
            if (field == value) return;
            field = value;
        }
    }

    private int ColorLeft
    {
        get;
        set
        {
            field = value;
            colorDisplay.ColorLeft = loadedPalette.GetOpaqueColor(0, value);
        }
    }
    private int ColorRight
    {
        get => field;
        set
        {
            field = value;
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

    private int GridSize
    {
        get;
        set
        {
            if (field == value) return;
            field = value;
            tileDisplay_gfx.GridCellHeight = value;
            tileDisplay_gfx.GridCellWidth = value;
        }
    } = 8;
    private bool ShowGrid
    {
        get;
        set
        {
            if (field == value) return;
            field = value;
            HandleShowGrid();
        }
    }
    #endregion

    #region Constructor
    public FormGraphicsNew(FormMain main, int gfxOffset, int width, int height, int palOffset)
    {
        InitializeComponent();
        // Theme Switching
        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        this.main = main;

        Status = new Status(statusLabel_changes, button_apply);

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

        ColorLeft = 1;
        ColorRight = 0;
        updateZoom(1);
    }
    #endregion

    #region Base Methods
    private void LoadData()
    {
        if (Status.UnsavedChanges && !CheckUnsaved()) return;
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

        numericUpDown_height.Value = Math.Min(loadedGFX.height, 32);

        DrawGFX();

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

    /// <summary>
    /// Prompts the user if they want to save the current changes or cancel.
    /// </summary>
    /// <returns>False if cancelled. True for other options. Saves if yes is clicked</returns>
    private bool CheckUnsaved()
    {
        DialogResult result = MessageBox.Show("Do you want to save changes to Graphics?",
            "Unsaved Changes", MessageBoxButtons.YesNoCancel);
        if (result == DialogResult.Cancel) return false;
        if (result == DialogResult.Yes) Save();
        return true;
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

    private bool IsInSelection(Point p)
    {
        // Return true if no selection, since everything is "in" the selection
        if (!Selection.Visible) return true;
        return Selection.Rectangle.Contains(p);
    }

    private void HandleShowGrid()
    {
        if (!ShowGrid)
        {
            tileDisplay_gfx.ShowGrid = false;
            return;
        }

        if (GridSize == 1 && tileDisplay_gfx.Zoom <= 1) tileDisplay_gfx.ShowGrid = false;
        else tileDisplay_gfx.ShowGrid = true;
    }
    #endregion

    #region General Events
    private void button_load_Click(object sender, EventArgs e) => LoadData();

    private void button_apply_Click(object sender, EventArgs e) => Save();

    private void FormGraphicsNew_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.B:
                button_toolPen_Click(this, e);
                break;

            case Keys.S:
                if (ModifierKeys == Keys.Control)
                {
                    Save();
                    break;
                }
                button_toolShape_Click(this, e);
                break;

            case Keys.C:
                button_eyeDropper_Click(this, e);
                break;

            case Keys.M:
                button_toolSelect_Click(this, e);
                break;

            case Keys.F:
                button_toolFill_Click(this, e);
                break;

            case Keys.Z:
                if (ModifierKeys == (Keys.Control | Keys.Shift))
                {
                    if (!UndoRedo.CanRedo) break;
                    Redo();
                    break;
                }
                else if (ModifierKeys == Keys.Control)
                {
                    if (!UndoRedo.CanUndo) break;
                    Undo();
                    break;
                }
                break;
        }
    }
    #endregion

    #region Tools
    private void button_toolSelect_Click(object sender, EventArgs e) => SelectedTool = Tool.Select;
    private void button_toolPen_Click(object sender, EventArgs e) => SelectedTool = Tool.Pen;
    private void button_toolFill_Click(object sender, EventArgs e) => SelectedTool = Tool.Fill;
    private void button_toolShape_Click(object sender, EventArgs e) => SelectedTool = Tool.Shape;
    private void button_eyeDropper_Click(object sender, EventArgs e) => SelectedTool = Tool.Eyedropper;

    private void UntoggleAllTools()
    {
        button_toolSelect.Checked = false;
        button_toolPen.Checked = false;
        button_toolFill.Checked = false;
        button_toolShape.Checked = false;
        button_eyeDropper.Checked = false;

        panel_fillSettings.Visible = false;
        panel_shapeSettings.Visible = false;
    }

    // Tool Settings
    private void checkBox_neighbouring_CheckedChanged(object sender, EventArgs e) => SetFillFlags();
    private void checkBox_gridFill_CheckedChanged(object sender, EventArgs e) => SetFillFlags();

    private void SetFillFlags()
    {
        FillToolRestrictions = 0;
        if (checkBox_neighbouring.Checked) FillToolRestrictions |= FillRestrictions.Neighbouring;
        if (checkBox_gridFill.Checked) FillToolRestrictions |= FillRestrictions.Grid;
    }
    #endregion

    #region Toolbar (other)
    private void button_grid_ButtonClick(object sender, EventArgs e)
    {
        ShowGrid = !ShowGrid;
        HandleShowGrid();
    }

    private void button_pixelGrid_Click(object sender, EventArgs e)
    {
        button_tileGrid.Checked = false;
        button_pixelGrid.Checked = true;
        GridSize = 1;
        tileDisplay_gfx.GridPen = PixelGridPen;
        HandleShowGrid();
    }

    private void button_tileGrid_Click(object sender, EventArgs e)
    {
        button_pixelGrid.Checked = false;
        button_tileGrid.Checked = true;
        GridSize = 8;
        tileDisplay_gfx.GridPen = GridPen;
        HandleShowGrid();
    }
    #endregion

    #region Undo Redo
    public void AddAction(GraphicsAction a)
    {
        UndoRedo.AddActionWithoutDo(a);
        setUndoRedoButtons();

        Status.ChangeMade();
    }

    private void Undo()
    {
        UndoRedo.Undo();
        setUndoRedoButtons();
        Status.ChangeMade();
    }

    private void Redo()
    {
        UndoRedo.Redo();
        setUndoRedoButtons();
        Status.ChangeMade();
    }

    private void PopulateUndoRedoList(ToolStripSplitButton button, DropOutStack<GraphicsAction> stack)
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
        DrawGFX();
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
        int width = (int)numericUpDown_width.Value;

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
        if (!IsInSelection(p)) return;
        var drawAction = new EditPixelAction(loadedGFX, p, palIndex);
        drawAction.Do();
        if (latestActionGroup != null) latestActionGroup.AddAction(drawAction);
        DrawGFX();
    }

    private void checkBox_compressed_CheckedChanged(object sender, EventArgs e)
    {
        numericUpDown_height.Enabled = !checkBox_compressed.Checked;
    }

    // Editing functions
    private void PickColor(TileDisplay.TileDisplayArgs e)
    {
        int pixel = loadedGFX.GetPixel(e.PixelPosition);
        if (pixel == -1) return;
        if (e.Button == MouseButtons.Left) ColorLeft = pixel;
        if (e.Button == MouseButtons.Right) ColorRight = pixel;
    }

    private void HandlePen(TileDisplay.TileDisplayArgs e)
    {
        if (e.Button == MouseButtons.Left) DoDrawPixel(e.PixelPosition, ColorLeft);
        if (e.Button == MouseButtons.Right) DoDrawPixel(e.PixelPosition, ColorRight);
    }

    private void FinishToolAction()
    {
        // Finalise Action Group
        if (latestActionGroup != null && latestActionGroup.ActionCount > 0) AddAction(latestActionGroup);
        latestActionGroup = null;

        // Clear variables
        SelectionPivot = null;
    }

    private void HandleFill(TileDisplay.TileDisplayArgs e)
    {
        var FillDictionary = new Dictionary<Point, int>();
        int oldPalIndex = loadedGFX.GetPixel(e.PixelPosition);
        int newPalIndex = e.Button == MouseButtons.Left ? ColorLeft : ColorRight;
        if (oldPalIndex == newPalIndex) return;

        bool neighbouring = FillToolRestrictions.HasFlag(FillRestrictions.Neighbouring);
        RunFloodFill(e.PixelPosition, FillDictionary, oldPalIndex, newPalIndex, neighbouring);

        if (FillDictionary.Count == 0) return;
        var fillAction = new FillAreaAction(loadedGFX, FillDictionary);
        fillAction.Do();
        AddAction(fillAction);
        DrawGFX();
    }

    private bool IsFillablePixel(Point p, Dictionary<Point, int> alreadyFilled, int oldPalIndex, Point tile, bool neighbouring)
    {
        if (p.X < 0 || p.Y < 0 || p.X >= loadedGFX.width * 8 || p.Y >= loadedGFX.height * 8) return false;
        if (!IsInSelection(p)) return false;
        if (alreadyFilled.ContainsKey(p)) return false;

        int currentIndex = loadedGFX.GetPixel(p);
        if (currentIndex == -1) return false;
        if (neighbouring && currentIndex != oldPalIndex) return false;

        if (FillToolRestrictions.HasFlag(FillRestrictions.Grid) && ShowGrid && GridSize == 8)
            if (p.X / 8 != tile.X || p.Y / 8 != tile.Y) return false;
        return true;
    }

    private void RunFloodFill(Point startPixel, Dictionary<Point, int> alreadyFilled, int oldPalIndex, int newPalIndex, bool neighbouring = true)
    {
        Queue<Point> pixels = new Queue<Point>();
        pixels.Enqueue(startPixel);
        Point tile = new(startPixel.X / 8, startPixel.Y / 8);

        while (pixels.Count > 0)
        {
            Point p = pixels.Dequeue();

            if (!IsFillablePixel(p, alreadyFilled, oldPalIndex, tile, neighbouring)) continue;

            // This is all code for a stupid workaround with global fill
            int oldColor = loadedGFX.GetPixel(p);
            if (loadedGFX.GetPixel(p) == oldPalIndex) alreadyFilled[p] = newPalIndex;
            else alreadyFilled[p] = oldColor;

            pixels.Enqueue(new Point(p.X + 1, p.Y));
            pixels.Enqueue(new Point(p.X - 1, p.Y));
            pixels.Enqueue(new Point(p.X, p.Y + 1));
            pixels.Enqueue(new Point(p.X, p.Y - 1));
        }
    }


    // Editing Events
    private void tileDisplay_gfx_TileMouseDown(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right) return;

        // Eyedropper quick pick
        if (ModifierKeys == Keys.Alt)
        {
            PickColor(e);
            return;
        }

        switch (SelectedTool)
        {
            case Tool.Pen:

                // Place Pixels
                latestActionGroup = new GraphicsActionGroup();
                HandlePen(e);
                break;

            case Tool.Select:

                SelectionPivot = e.PixelPosition;
                if (Selection.Visible) Selection.Visible = false; // Deselct Selection
                else Selection.Visible = true;
                Selection.Rectangle = new Rectangle(e.PixelPosition, new Size(1, 1));
                break;

            case Tool.Fill:
                HandleFill(e);
                break;

            case Tool.Shape:

                SelectionPivot = e.PixelPosition;
                ShapeDrawable.Visible = true;
                ShapeDrawable.Rectangle = new Rectangle(e.PixelPosition, new Size(1, 1));
                break;
            case Tool.Eyedropper:

                PickColor(e);
                break;
        }
    }

    private void tileDisplay_gfx_TileMouseMove(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        // Only Update if moved to a new pixel
        if (e.PixelPosition == LastPixel) return;
        LastPixel = e.PixelPosition;

        if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right) return;
        if (ModifierKeys == Keys.Alt) return;

        switch (SelectedTool)
        {
            case Tool.Pen:
                HandlePen(e);
                break;

            case Tool.Select:

                if (SelectionPivot == null) break;
                Selection.Visible = true;
                Selection.Rectangle = GetRectangleFromPoints(SelectionPivot.Value, e.PixelPosition);
                break;

            case Tool.Fill:
                break;

            case Tool.Shape:

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

                switch (SelectedShape)
                {
                    case Shape.Rectangle:
                        int _color = e.Button == MouseButtons.Left ? ColorLeft : ColorRight;

                        // Get intersecting area with selection
                        Rectangle area = ShapeDrawable.Rectangle;
                        if (Selection.Visible) area = Rectangle.Intersect(area, Selection.Rectangle);
                        if (area.IsEmpty) break;

                        var rectangleAction = new DrawAreaAction(loadedGFX, area, _color);
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

        FinishToolAction();
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
                init = true;
                textBox_palOffset.Text = Hex.ToString(offset);
                init = false;
            }

            loadedPalette = new Palette(ROM.Stream, offset, 1);
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }

    private void DrawPalette()
    {
        tileDisplay_palette.TileImage = loadedPalette.Draw(16, 0, 1, gridColorArgb: 0);
        ColorLeft = ColorLeft;
        ColorRight = ColorRight;
    }

    private void textBox_palOffset_TextChanged(object sender, EventArgs e)
    {
        if (init) return;
        if (LoadPalette(0))
        {
            DrawPalette();
            DrawGFX();
        }
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

        // Grid logic
        HandleShowGrid();
    }
    #endregion

    #region Import/Export

    private void ImportPalette(PalFileType type)
    {
        OpenFileDialog import = new OpenFileDialog();
        import.Filter = FormPalette.GetFileFilter(type);
        if (import.ShowDialog() == DialogResult.OK)
        {
            loadedPalette.Import(import.FileName, type);
            loadedPalette.Write(ROM.Stream);
            DrawPalette();
        }
    }

    private void ExportPalette(PalFileType type)
    {
        SaveFileDialog export = new SaveFileDialog();
        export.Filter = FormPalette.GetFileFilter(type);
        if (export.ShowDialog() == DialogResult.OK)
        {
            loadedPalette.Export(export.FileName, type);
        }
    }

    private void button_importGraphicsRaw_Click(object sender, EventArgs e)
    {
        OpenFileDialog openRaw = new OpenFileDialog();
        openRaw.Filter = "GFX files (*.gfx)|*.gfx|All files (*.*)|*.*";
        if (openRaw.ShowDialog() == DialogResult.OK)
        {
            byte[] data = File.ReadAllBytes(openRaw.FileName);

            loadedGFX = new GFX(loadedGFX, data);
            Save();
        }
    }

    private void button_importGraphicsImage_Click(object sender, EventArgs e)
    {
        OpenFileDialog openImg = new OpenFileDialog();
        openImg.Filter = "Bitmaps (*.png, *.bmp, *.gif, *.jpeg, *.jpg, *.tif, *.tiff)|*.png;*.bmp;*.gif;*.jpeg;*.jpg;*.tif;*.tiff";
        if (openImg.ShowDialog() == DialogResult.OK)
        {
            Bitmap inputImg = Draw.BitmapFromFile(openImg.FileName);

            try
            {
                PortImage pi = new PortImage(inputImg);
                pi.GetGfx(loadedPalette, false);
                loadedGFX = new GFX(loadedGFX, pi.gfxData);
                Save();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void button_importPaletteRaw_Click(object sender, EventArgs e) => ImportPalette(PalFileType.Raw);

    private void button_importPaletteTLP_Click(object sender, EventArgs e) => ImportPalette(PalFileType.TLP);

    private void button_importPaletteYYCHR_Click(object sender, EventArgs e) => ImportPalette(PalFileType.YYCHR);

    private void button_exportGraphicsRaw_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveRaw = new SaveFileDialog();
        saveRaw.Filter = "GFX files (*.gfx)|*.gfx|All files (*.*)|*.*";
        if (saveRaw.ShowDialog() == DialogResult.OK)
        {
            File.WriteAllBytes(saveRaw.FileName, loadedGFX.data);
        }
    }

    private void button_exportGraphicsImage_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveImg = new SaveFileDialog();
        saveImg.Filter = "PNG files (*.png)|*.png";
        if (saveImg.ShowDialog() == DialogResult.OK)
        {
            PixelFormat format = PixelFormat.Undefined;
            if (menuItem_4bitIndexed.Checked) { format = PixelFormat.Format4bppIndexed; }
            else if (menuItem_24bitRGB.Checked) { format = PixelFormat.Format24bppRgb; }
            else if (menuItem_32bitARGB.Checked) { format = PixelFormat.Format32bppArgb; }

            Bitmap output = PortImage.Export((Bitmap)tileDisplay_gfx.TileImage, format);
            output.Save(saveImg.FileName);
        }
    }

    private void menuItem_pixelFormat_Click(object sender, EventArgs e)
    {
        menuItem_4bitIndexed.Checked = false;
        menuItem_24bitRGB.Checked = false;
        menuItem_32bitARGB.Checked = false;

        ToolStripMenuItem item = sender as ToolStripMenuItem;
        item.Checked = true;
    }

    private void menuItem_palExport_raw_Click(object sender, EventArgs e) => ExportPalette(PalFileType.Raw);

    private void menuItem_palExport_tlp_Click(object sender, EventArgs e) => ExportPalette(PalFileType.TLP);

    private void menuItem_palExport_yychr_Click(object sender, EventArgs e) => ExportPalette(PalFileType.YYCHR);
    #endregion
}
