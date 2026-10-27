using mage.Actions;
using mage.Actions.OamEditor;
using mage.Actions.SamusEditor;
using mage.Controls;
using mage.Editors.NewEditors;
using mage.Properties;
using mage.Theming;
using mage.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace mage;

/// <summary>
/// Editor for Samus' animations: the body OAM of every frame, the graphics of the top and bottom half
/// and the frame timing. Based on the <see cref="FormOam"/>, which shares the OAM editing.
/// </summary>
public partial class FormSamus : Form
{
    private enum Tool
    {
        Select,
        Pencil
    }

    // fields
    private SamusAnimation? anim;
    private OAM? oam => anim?.Oam;
    private Palette palette = new Palette(16);
    private byte[] vram = new byte[0x8000];
    private SamusTileSource?[] vramSources = new SamusTileSource?[SamusAnimation.VramRows * SamusAnimation.VramRowTiles];
    private Bitmap gfxImage;

    private List<GenericUndoRedo> UndoRedos = new();
    private GenericUndoRedo UndoRedo => UndoRedos[SelectedFrameIndex];
    private Status Status;
    private List<GenericEditorAction>? GroupedActions;

    private bool loading;
    private bool loadingPart;
    private bool loadingFrameData;

    private FormMain main;
    private ByteStream romStream;

    private Timer animationTimer;

    // Palette data that the edit button opens
    private int paletteEditOffset;
    private int paletteEditRows;

    // Pointer counts of data in the ROM, cleared whenever the ROM changes
    private Dictionary<int, int> pointerCounts = new();

    // Animation selection that was loaded, used to revert the selection if loading gets canceled
    private int loadedGroupIndex = -1;
    private int loadedAnimationIndex = -1;

    // Drawables
    Pen partOutline = new Pen(Color.Aqua, 1);
    Pen partOutlineHovered = new Pen(Color.Orange, 1) { Alignment = PenAlignment.Inset };
    Pen partOutlineSelected = new Pen(Color.Red, 1);
    Pen CursorPen = new Pen(Color.Red, 1);
    Pen SelectionPenWhite = new Pen(Color.White, 1) { DashPattern = new float[] { 2, 3 } };
    Pen SelectionPenBlack = new Pen(Color.Black, 1) { DashPattern = new float[] { 2, 3 }, DashOffset = 2 };
    Pen TopRegionPen = new Pen(Color.Lime, 1);
    Pen BottomRegionPen = new Pen(Color.Magenta, 1);
    List<Drawable> partOutlines = new List<Drawable>();
    Drawable MultiPartSelection;
    Drawable gfxSelection;
    Drawable gfxCursor;
    Drawable PaletteCursor;
    Drawable PaletteSelection;
    Drawable[] gfxRegions;

    // Context menu related
    Point ContextMenuOpenedAt = Point.Empty;

    // Moving related
    Point? PartsStartLocation = null;
    Point? MouseStartLocation = null;

    // Drawing related
    private SamusDrawAction? currentStroke;
    private Point? lastDrawPoint;

    // properties
    private bool PlayingAnimation
    {
        get => playingAnimation;
        set
        {
            playingAnimation = value;
            button_playAnimation.Image = playingAnimation ? Resources.control_pause_blue : Resources.toolbar_test;

            // Disable/enable controls
            groupBox_part.Enabled = !playingAnimation;
            groupBox_frameData.Enabled = !playingAnimation;
            comboBox_Frame.Enabled = !playingAnimation;
            label_OAMFrame.Enabled = !playingAnimation;
            textBox_duration.Enabled = !playingAnimation;
            label_frameDuration.Enabled = !playingAnimation;
            button_addFrame.Enabled = !playingAnimation;
            button_removeFrame.Enabled = !playingAnimation;
            button_frameDown.Enabled = !playingAnimation;
            button_frameUp.Enabled = !playingAnimation;
            button_duplicate.Enabled = !playingAnimation;
            UpdateClipboardButtons();

            // Stop timer if needed
            if (playingAnimation) return;
            if (animationTimer == null) return;
            animationTimer.Stop();
        }
    }
    private bool playingAnimation = false;

    private bool ViewOrigin
    {
        get => viewOrigin;
        set
        {
            viewOrigin = value;
            button_viewOrigin.Checked = value;
            Program.Config.SamusEditorViewOrigin = value;

            tileDisplay_oam.ShowOamOrigin = value;
            tileDisplay_oam.Invalidate();
        }
    }
    private bool viewOrigin = true;

    private bool ViewPartOutline
    {
        get => viewPartOutline;
        set
        {
            viewPartOutline = value;
            button_viewOutline.Checked = value;
            Program.Config.SamusEditorViewPartOutlines = value;

            foreach (Drawable d in partOutlines) d.Visible = value;
            tileDisplay_oam.Invalidate();
        }
    }
    private bool viewPartOutline = false;

    private bool ViewRegions
    {
        get => viewRegions;
        set
        {
            viewRegions = value;
            button_viewRegions.Checked = value;
            Program.Config.SamusEditorViewRegions = value;

            UpdateRegionDrawables();
        }
    }
    private bool viewRegions = true;

    private bool SnapParts
    {
        get => field;
        set
        {
            field = value;
            button_snap.Checked = value;
            Program.Config.SamusEditorSnapParts = value;
        }
    }

    private Tool CurrentTool
    {
        get => currentTool;
        set
        {
            FinishStroke();
            currentTool = value;
            button_toolSelect.Checked = value == Tool.Select;
            button_toolPencil.Checked = value == Tool.Pencil;

            HoveredPartIndex = -1;
            gfxCursor.Visible = false;
            Cursor = value == Tool.Pencil ? Cursors.Cross : Cursors.Default;
        }
    }
    private Tool currentTool = Tool.Select;

    private int HoveredPartIndex
    {
        get => HoveredPartIndices.Count == 1 ? HoveredPartIndices[0] : -1;
        set
        {
            if (value < 0)
            {
                HoveredPartIndices = new();
                return;
            }
            HoveredPartIndices = new() { value };
        }
    }
    private List<int> HoveredPartIndices
    {
        get => field;
        set
        {
            field = value;
            if (oam != null && SelectedFrameIndex >= 0) SetPartOutlines(SelectedFrame);
        }
    } = new();
    private bool HoveredParts => HoveredPartIndices?.Count > 0;

    private int SelectedPartIndex
    {
        get => SelectedPartIndices.Count == 1 ? SelectedPartIndices[0] : -1;
        set
        {
            if (value < 0)
            {
                SelectedPartIndices = new();
                return;
            }
            SelectedPartIndices = new() { value };
        }
    }
    private List<int> SelectedPartIndices
    {
        get => field;
        set
        {
            field = value;
            SelectedPartIndicesChanged();
        }
    } = new();
    private bool SelectedParts => SelectedPartIndices?.Count > 0;
    private void AddSelectedPart(int val)
    {
        if (SelectedPartIndices is null) return;
        SelectedPartIndices.Add(val);
        SelectedPartIndicesChanged();
    }
    private void SelectedPartIndicesChanged()
    {
        comboBox_part.SelectedIndex = SelectedPartIndices.Count == 1 ? SelectedPartIndices[0] : -1; // Set part selection combobox depending on amount of selected parts
        if (oam != null && SelectedFrameIndex >= 0) SetPartOutlines(SelectedFrame);

        button_removePart.Enabled = SelectedPartIndices.Count > 0;
        panel_partEditing.Enabled = SelectedPartIndices.Count > 0;
        UpdateClipboardButtons();
        HandleSelectedPartChanged(SelectedPartIndices);
    }

    private Point? MultiSelectPivot { get; set; } = null;
    private Point? OldMultiSelectPosition { get; set; } = null;

    /// <summary>
    /// The palette row the graphics are displayed with
    /// </summary>
    private int SelectedPaletteRow
    {
        get => selectedPaletteRow;
        set
        {
            selectedPaletteRow = Math.Clamp(value, 0, PaletteRows - 1);
            UpdatePaletteSelection();
            if (!loading) DrawImage();
        }
    }
    private int selectedPaletteRow = 0;

    /// <summary>
    /// The palette index the pencil draws with
    /// </summary>
    private int SelectedColor
    {
        get => selectedColor;
        set
        {
            selectedColor = Math.Clamp(value, 0, 15);
            UpdatePaletteSelection();
        }
    }
    private int selectedColor = 1;

    // Samus' palette is the first two rows of the sprite palette
    private const int PaletteRows = 2;
    private const int PaletteCellSize = 17;

    private int SelectedFrameIndex => comboBox_Frame.SelectedIndex;
    private OAM.Frame SelectedFrame => oam!.Frames[comboBox_Frame.SelectedIndex];
    private SamusFrame SelectedSamusFrame => anim!.Frames[comboBox_Frame.SelectedIndex];

    private Timer KeyMovementDebounceTimer;
    private bool KeyDebounceWindowActive => KeyMovementDebounceTimer.Enabled;

    // constructor
    public FormSamus(FormMain main)
    {
        InitializeComponent();

        //Theming
        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        this.main = main;
        this.romStream = ROM.Stream;

        loading = true;

        //Creating Drawables
        MultiPartSelection = new Drawable(Rectangle.Empty, SelectionPenWhite) { Visible = false };
        MultiPartSelection.DrawPens.Add(SelectionPenBlack);
        gfxRegions = new Drawable[4];
        for (int i = 0; i < gfxRegions.Length; i++)
        {
            gfxRegions[i] = new Drawable(Rectangle.Empty, i < 2 ? TopRegionPen : BottomRegionPen, 1) { Visible = false };
            gfxView_gfx.AddDrawable(gfxRegions[i]);
        }
        gfxSelection = new Drawable(Rectangle.Empty, SelectionPenWhite, 1) { Visible = false };
        gfxSelection.DrawPens.Add(SelectionPenBlack);
        gfxCursor = new Drawable(Rectangle.Empty, CursorPen, 1) { Visible = false };
        gfxView_gfx.AddDrawable(gfxSelection);
        gfxView_gfx.AddDrawable(gfxCursor);

        //Palette Drawables
        PaletteCursor = new Drawable(Rectangle.Empty, CursorPen, 1) { Visible = false };
        PaletteSelection = new Drawable(Rectangle.Empty, SelectionPenWhite, 1) { Visible = true };
        PaletteSelection.DrawPens.Add(SelectionPenBlack);
        paletteView.AddDrawable(PaletteCursor);
        paletteView.AddDrawable(PaletteSelection);

        // Load Settings
        ViewOrigin = Program.Config.SamusEditorViewOrigin;
        ViewPartOutline = Program.Config.SamusEditorViewPartOutlines;
        ViewRegions = Program.Config.SamusEditorViewRegions;
        SnapParts = Program.Config.SamusEditorSnapParts;
        UpdateGfxZoom(Program.Config.SamusEditorGfxZoom);
        UpdateOamZoom(Program.Config.SamusEditorOamZoom);
        CurrentTool = Tool.Select;

        //Event based
        textBox_duration.TextChanged += textBox_duration_TextChanged;
        textBox_tile.TextChanged += controlElements_changeMade;
        textBox_x.TextChanged += controlElements_changeMade;
        textBox_y.TextChanged += controlElements_changeMade;
        gfxView_gfx.TileMouseUp += gfxView_gfx_TileMouseUp;
        ((TextBox)textBox_animOffset).KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; button_go_Click(textBox_animOffset, e); } };
        ((TextBox)textBox_palOffset).KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; button_loadPalette_Click(textBox_palOffset, e); } };
        ((TextBox)textBox_topOffset).KeyDown += frameDataOffset_KeyDown;
        ((TextBox)textBox_bottomOffset).KeyDown += frameDataOffset_KeyDown;
        ((TextBox)textBox_oamOffset).KeyDown += frameDataOffset_KeyDown;
        ((TextBox)textBox_topOffset).Leave += (s, e) => UpdateFrameDataPanel();
        ((TextBox)textBox_bottomOffset).Leave += (s, e) => UpdateFrameDataPanel();
        ((TextBox)textBox_oamOffset).Leave += (s, e) => UpdateFrameDataPanel();
        Activated += (s, e) => { if (!loading && anim != null) ReloadPalette(true); };
        Shown += (s, e) => CenterOamView();

        animationTimer = new Timer();
        animationTimer.Tick += AnimationTimer_Tick;

        //Arrow key movement debounce timer
        KeyMovementDebounceTimer = new() { Interval = 600 };
        KeyMovementDebounceTimer.Tick += KeyMovementDebounceTimer_Tick;

        // Tooltips
        toolTip.SetToolTip(comboBox_group, "Animations are grouped by the pose they are used for");
        toolTip.SetToolTip(textBox_animOffset, "Offset of the animation's frame list. Any Samus animation can be loaded by entering its offset");
        toolTip.SetToolTip(textBox_palOffset, "Loads two palette rows from this offset");
        toolTip.SetToolTip(textBox_topOffset, "Graphics of the top half of Samus. Enter the offset of different graphics and press Enter to use them for this frame");
        toolTip.SetToolTip(textBox_bottomOffset, "Graphics of the bottom half of Samus. Enter the offset of different graphics and press Enter to use them for this frame");
        toolTip.SetToolTip(textBox_oamOffset, "Body OAM of this frame. Enter the offset of different OAM and press Enter to use it for this frame");
        toolTip.SetToolTip(numericUpDown_topRow0, "Tiles in the first row of the top graphics (VRAM tiles 0x00-0x13)");
        toolTip.SetToolTip(numericUpDown_topRow1, "Tiles in the second row of the top graphics (VRAM tiles 0x20-0x33)");
        toolTip.SetToolTip(numericUpDown_bottomRow0, "Tiles in the first row of the bottom graphics (VRAM tiles 0x14-0x1F)");
        toolTip.SetToolTip(numericUpDown_bottomRow1, "Tiles in the second row of the bottom graphics (VRAM tiles 0x34-0x3F)");
        string uniqueTip = "Data used by multiple frames or animations changes for all of them. This gives the current frame its own copy";
        toolTip.SetToolTip(button_topUnique, uniqueTip);
        toolTip.SetToolTip(button_bottomUnique, uniqueTip);
        toolTip.SetToolTip(button_oamUnique, uniqueTip);
        toolTip.SetToolTip(button_addFrame, "Adds a frame that uses the same graphics and OAM as the current frame");
        toolTip.SetToolTip(button_duplicate, "Adds a frame with its own copy of the current frame's graphics and OAM");

        Status = new Status(label_Status, button_save);

        // Animation and palette lists
        SamusAnimationList.Load();
        foreach (var preset in SamusAnimationList.Palettes) comboBox_palettePreset.Items.Add(preset);
        foreach (var group in SamusAnimationList.Groups) comboBox_group.Items.Add(group);

        loading = false;

        if (comboBox_palettePreset.Items.Count > 0) comboBox_palettePreset.SelectedIndex = 0;
        if (comboBox_group.Items.Count > 0) comboBox_group.SelectedIndex = 0;
        else UpdateEnabledControls();
    }

    #region general
    private void ChangePen(Drawable drawable, Pen pen)
    {
        drawable.DrawPens.Clear();
        drawable.DrawPens.Add(pen);
    }

    private void Save()
    {
        if (anim == null)
        {
            MessageBox.Show("No animation to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        FinishStroke();
        FinishModifyingActionGroup();

        int oldOffset = anim.Offset;
        try
        {
            anim.Save(romStream);
        }
        catch (Exception ex)
        {
            MessageBox.Show("The animation could not be saved.\n\n" + ex.GetType().ToString() + '\n' + ex.Message,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        pointerCounts.Clear();

        textBox_animOffset.Text = Hex.ToString(anim.Offset);
        if (anim.Offset != oldOffset)
        {
            MessageBox.Show($"The animation's frame list was moved to {Hex.ToString(anim.Offset)}.\nAll pointers to it were updated.",
                "Animation moved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        Status.Save();
        DrawFrame(SelectedFrameIndex);
    }

    private bool CheckUnsaved()
    {
        DialogResult result = MessageBox.Show("Do you want to save changes to the animation?",
            "Unsaved Changes", MessageBoxButtons.YesNoCancel);
        if (result == DialogResult.Cancel) return false;
        if (result == DialogResult.Yes) Save();
        return true;
    }

    private void KeyboardMoved(Keys key)
    {
        StartModifyingActionGroup();

        if (key == Keys.Left) MoveSelectedParts(-1, 0);
        if (key == Keys.Right) MoveSelectedParts(1, 0);
        if (key == Keys.Up) MoveSelectedParts(0, -1);
        if (key == Keys.Down) MoveSelectedParts(0, 1);

        KeyMovementDebounceTimer.Stop();
        KeyMovementDebounceTimer.Start();
    }

    private void KeyMovementDebounceTimer_Tick(object? sender, EventArgs e)
    {
        FinishModifyingActionGroup();
    }

    private void KeyPressed(object sender, KeyEventArgs e)
    {
        if (anim == null) return;

        switch (e.KeyCode)
        {
            case Keys.Left:
            case Keys.Right:
            case Keys.Up:
            case Keys.Down:
                KeyboardMoved(e.KeyCode);
                break;

            case Keys.X:
                if (ModifierKeys == Keys.Control)
                {
                    Cut();
                    break;
                }
                goto case Keys.H;

            case Keys.H:
                if (SelectedPartIndex == -1) break;
                checkBox_xFlip.Checked = !checkBox_xFlip.Checked;
                break;

            case Keys.C:
                if (ModifierKeys != Keys.Control) break;
                Copy();
                break;

            case Keys.V:
                if (ModifierKeys == Keys.Control)
                {
                    Paste(true);
                    break;
                }
                goto case Keys.Y;

            case Keys.Y:
                if (SelectedPartIndex == -1) break;
                checkBox_yFlip.Checked = !checkBox_yFlip.Checked;
                break;

            case Keys.P:
                ViewPartOutline = !ViewPartOutline;
                break;

            case Keys.O:
                ViewOrigin = !ViewOrigin;
                break;

            case Keys.B:
                if (!PlayingAnimation) CurrentTool = Tool.Pencil;
                break;

            case Keys.M:
            case Keys.Escape:
                CurrentTool = Tool.Select;
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

            case Keys.Delete:
            case Keys.Back:
                DeletePart();
                break;

            default:
                break;
        }
    }

    private void button_save_Click(object sender, EventArgs e) => Save();

    private void FormSamus_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!Status.UnsavedChanges) return;
        if (!CheckUnsaved()) e.Cancel = true;
    }

    private void UpdateEnabledControls()
    {
        bool loaded = anim != null;
        groupBox_oam.Enabled = loaded;
        groupBox_frameData.Enabled = loaded && !PlayingAnimation;
        groupBox_part.Enabled = loaded && !PlayingAnimation;
        button_export.Enabled = loaded;
        button_import.Enabled = loaded;
    }

    private int GetPointerCount(int offset)
    {
        if (offset < 0) return 0;
        if (!pointerCounts.TryGetValue(offset, out int count))
        {
            count = romStream.GetPointers(offset).Count;
            pointerCounts[offset] = count;
        }
        return count;
    }
    #endregion

    #region ANIMATION
    private void comboBox_group_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (loading || comboBox_group.SelectedIndex < 0) return;

        if (Status.UnsavedChanges && !CheckUnsaved())
        {
            RevertAnimationSelection();
            return;
        }

        var group = (SamusAnimationList.Group)comboBox_group.SelectedItem!;

        // Use the palette of the suit the group is for
        int separator = group.Name.IndexOf(':');
        if (separator > 0)
        {
            string suit = group.Name[..separator];
            int preset = SamusAnimationList.Palettes.FindIndex(p => p.Name == suit);
            if (preset >= 0 && preset != comboBox_palettePreset.SelectedIndex) comboBox_palettePreset.SelectedIndex = preset;
        }

        loading = true;
        comboBox_animation.Items.Clear();
        foreach (var animation in group.Animations) comboBox_animation.Items.Add(animation);
        loading = false;

        if (comboBox_animation.Items.Count > 0) comboBox_animation.SelectedIndex = 0;
    }

    private void comboBox_animation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (loading || comboBox_animation.SelectedIndex < 0) return;

        if (Status.UnsavedChanges && !CheckUnsaved())
        {
            RevertAnimationSelection();
            return;
        }

        var animation = (SamusAnimationList.Animation)comboBox_animation.SelectedItem!;
        int offset = romStream.ReadPtr(animation.PointerOffset);
        textBox_animOffset.Text = Hex.ToString(offset);
        LoadAnimation(offset);
    }

    private void RevertAnimationSelection()
    {
        loading = true;
        if (loadedGroupIndex >= 0 && comboBox_group.SelectedIndex != loadedGroupIndex)
        {
            comboBox_group.SelectedIndex = loadedGroupIndex;
            comboBox_animation.Items.Clear();
            foreach (var a in ((SamusAnimationList.Group)comboBox_group.SelectedItem!).Animations) comboBox_animation.Items.Add(a);
        }
        comboBox_animation.SelectedIndex = loadedAnimationIndex;
        loading = false;
    }

    private void button_go_Click(object sender, EventArgs e)
    {
        if (Status.UnsavedChanges && !CheckUnsaved()) return;

        int offset;
        try { offset = Hex.ToInt(textBox_animOffset.Text); }
        catch
        {
            MessageBox.Show("The offset entered was not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Select the animation in the lists, if it is a known one
        loading = true;
        comboBox_animation.SelectedIndex = -1;
        for (int g = 0; g < SamusAnimationList.Groups.Count; g++)
        {
            int a = SamusAnimationList.Groups[g].Animations.FindIndex(x => romStream.ReadPtr(x.PointerOffset) == offset);
            if (a < 0) continue;

            if (comboBox_group.SelectedIndex != g)
            {
                comboBox_group.SelectedIndex = g;
                comboBox_animation.Items.Clear();
                foreach (var animation in SamusAnimationList.Groups[g].Animations) comboBox_animation.Items.Add(animation);
            }
            comboBox_animation.SelectedIndex = a;
            break;
        }
        loading = false;

        LoadAnimation(offset);
    }

    private bool LoadAnimation(int offset)
    {
        SamusAnimation loaded;
        try
        {
            loaded = new SamusAnimation(offset);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"No valid Samus animation found at {Hex.ToString(offset)}.\n\n{ex.Message}", "Invalid Animation",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            RevertAnimationSelection();
            return false;
        }

        PlayingAnimation = false;
        FinishStroke();
        GroupedActions = null;

        anim = loaded;
        loadedGroupIndex = comboBox_group.SelectedIndex;
        loadedAnimationIndex = comboBox_animation.SelectedIndex;
        Status.LoadNew();

        PopulateUndoRedoForFrames();
        loading = true;
        SetFrameSelectionCombobox();
        loading = false;
        comboBox_Frame.SelectedIndex = -1;
        comboBox_Frame.SelectedIndex = 0;
        UpdateEnabledControls();
        CenterOamView();
        return true;
    }
    #endregion

    #region ZOOM
    int maxZoom = 4;

    private void button_gfxZoomIn_Click(object sender, EventArgs e) => UpdateGfxZoom(gfxView_gfx.Zoom + 1);
    private void button_gfxZoomOut_Click(object sender, EventArgs e) => UpdateGfxZoom(gfxView_gfx.Zoom - 1);

    private void button_oamZoomIn_Click(object sender, EventArgs e) => UpdateOamZoom(tileDisplay_oam.Zoom + 1);
    private void button_oamZoomOut_Click(object sender, EventArgs e) => UpdateOamZoom(tileDisplay_oam.Zoom - 1);

    #endregion

    #region GFX
    private void DrawImage()
    {
        if (anim == null) return;

        byte[] samusTiles = new byte[SamusAnimation.VramRows * SamusAnimation.VramRowTiles * SamusGfx.TileLength];
        Array.Copy(vram, samusTiles, samusTiles.Length);
        gfxImage = new GFX(samusTiles, SamusAnimation.VramRowTiles).Draw4bpp(palette, SelectedPaletteRow, true);
        gfxView_gfx.TileImage = gfxImage;
    }

    private void UpdateGfxZoom(int zoom)
    {
        zoom = Math.Clamp(zoom, 0, 4);
        gfxView_gfx.Zoom = zoom;
        Program.Config.SamusEditorGfxZoom = zoom;
        button_gfxZoomIn.Enabled = zoom < maxZoom;
        button_gfxZoomOut.Enabled = zoom > 0;
        label_gfxZoom.Text = $"{1 << zoom}00%";
    }

    private void button_viewRegions_Click(object sender, EventArgs e) => ViewRegions = !button_viewRegions.Checked;

    private void UpdateRegionDrawables()
    {
        if (gfxRegions == null) return;
        if (anim == null || SelectedFrameIndex < 0)
        {
            foreach (Drawable d in gfxRegions) d.Visible = false;
            return;
        }

        SamusFrame frame = SelectedSamusFrame;
        SetRegion(gfxRegions[0], frame.Top, 0, SamusAnimation.TopVramTile);
        SetRegion(gfxRegions[1], frame.Top, 1, SamusAnimation.TopVramTile);
        SetRegion(gfxRegions[2], frame.Bottom, 0, SamusAnimation.BottomVramTile);
        SetRegion(gfxRegions[3], frame.Bottom, 1, SamusAnimation.BottomVramTile);
    }

    private void SetRegion(Drawable region, SamusGfx gfx, int row, int startTile)
    {
        int tiles = Math.Min(gfx.RowTiles[row], SamusAnimation.VramRowTiles - startTile);
        region.Visible = ViewRegions && tiles > 0;
        region.Rectangle = new Rectangle(startTile * 8, row * 8, tiles * 8, 8);
    }

    private void gfxView_gfx_MouseMove(object sender, TileDisplay.TileDisplayArgs e)
    {
        if (anim == null) return;

        int tileNum = e.TileIndexPosition.X + e.TileIndexPosition.Y * SamusAnimation.VramRowTiles;
        statusLabel_coor.Text = Hex.ToString(tileNum);
        statusLabel_tileInfo.Text = DescribeTile(tileNum);

        if (CurrentTool == Tool.Pencil)
        {
            gfxCursor.Visible = true;
            gfxCursor.Rectangle = new Rectangle(e.PixelPosition, new Size(1, 1));
            if (currentStroke != null && e.Button == MouseButtons.Left) DrawLine(e.PixelPosition, VramPixelOf);
            return;
        }

        if (SelectedPartIndex == -1)
        {
            gfxCursor.Visible = false;
            return;
        }
        OAM.Part selectedPart = SelectedFrame.parts[SelectedPartIndex];

        // Set Cursor
        gfxCursor.Visible = true;
        gfxCursor.Rectangle = new Rectangle(
            e.TilePixelPosition.X,
            e.TilePixelPosition.Y,
            selectedPart.Dimensions.Width,
            selectedPart.Dimensions.Height
        );
    }

    private string DescribeTile(int tileNum)
    {
        if (tileNum < 0 || tileNum >= vramSources.Length) return string.Empty;
        SamusTileSource? source = vramSources[tileNum];
        if (source == null) return "Unused";

        string half = source.Value.Gfx == SelectedSamusFrame.Top ? "Top" : "Bottom";
        return $"{half} graphics, row {source.Value.Row + 1}, tile {source.Value.Tile + 1}";
    }

    private void gfxView_gfx_Scrolled(object sender, MouseEventArgs e)
    {
        if ((ModifierKeys & Keys.Control) == Keys.Control)
        {
            if (e.Delta > 0) UpdateGfxZoom(gfxView_gfx.Zoom + 1);
            if (e.Delta < 0) UpdateGfxZoom(gfxView_gfx.Zoom - 1);
        }
    }

    private void gfxView_gfx_TileMouseDown(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        if (anim == null || PlayingAnimation) return;

        if (CurrentTool == Tool.Pencil)
        {
            if (e.Button == MouseButtons.Right) PickColor(e.PixelPosition, VramPixelOf);
            if (e.Button == MouseButtons.Left) StartStroke(e.PixelPosition, VramPixelOf);
            return;
        }

        int tileNum = e.TileIndexPosition.X + e.TileIndexPosition.Y * SamusAnimation.VramRowTiles;

        if (SelectedPartIndex == -1) return;
        textBox_tile.Text = Hex.ToString(tileNum);
    }

    private void gfxView_gfx_TileMouseUp(object? sender, TileDisplay.TileDisplayArgs e) => FinishStroke();
    #endregion

    #region DRAWING
    private void button_toolSelect_Click(object sender, EventArgs e) => CurrentTool = Tool.Select;
    private void button_toolPencil_Click(object sender, EventArgs e) => CurrentTool = Tool.Pencil;

    // The graphics view shows the VRAM directly
    private Point? VramPixelOf(Point pixel) => pixel;

    /// <summary>
    /// Finds the VRAM pixel shown at a position of the OAM view. This is the pixel of the frontmost part
    /// that is not transparent there, or the frontmost part if all of them are transparent.
    /// </summary>
    private Point? OamPixelOf(Point pixel)
    {
        if (anim == null) return null;
        Point position = new Point(pixel.X - OAM.FrameOriginX, pixel.Y - OAM.FrameOriginY);

        Point? frontmost = null;
        foreach (OAM.Part part in SelectedFrame.parts)
        {
            if (!part.Area.Contains(position)) continue;

            Size size = part.Dimensions;
            int x = position.X - part.xPos;
            int y = position.Y - part.yPos;
            if (part.Xflip) x = size.Width - 1 - x;
            if (part.Yflip) y = size.Height - 1 - y;

            int tile = (part.tileNum + (y / 8) * 32 + x / 8) & 0x3FF;
            Point vramPixel = new Point(tile % 32 * 8 + x % 8, tile / 32 * 8 + y % 8);

            frontmost ??= vramPixel;
            if (GetVramPixel(vramPixel) > 0) return vramPixel;
        }
        return frontmost;
    }

    private int GetVramPixel(Point vramPixel)
    {
        int tile = vramPixel.Y / 8 * 32 + vramPixel.X / 8;
        int index = tile * SamusGfx.TileLength + (vramPixel.Y % 8) * 4 + (vramPixel.X % 8) / 2;
        if (index < 0 || index >= vram.Length) return -1;
        byte b = vram[index];
        return (vramPixel.X & 1) == 0 ? b & 0xF : b >> 4;
    }

    private bool PlotPixel(Point? vramPixel)
    {
        if (vramPixel == null || currentStroke == null) return false;
        Point p = vramPixel.Value;
        if (p.X < 0 || p.Y < 0) return false;

        int tile = p.Y / 8 * 32 + p.X / 8;
        if (tile >= vramSources.Length) return false;
        SamusTileSource? source = vramSources[tile];
        if (source == null) return false;

        return currentStroke.SetPixel(source.Value.Gfx, source.Value.Row, source.Value.Tile * 8 + p.X % 8, p.Y % 8, SelectedColor);
    }

    private void StartStroke(Point pixel, Func<Point, Point?> toVram)
    {
        FinishModifyingActionGroup();
        currentStroke = new SamusDrawAction();
        lastDrawPoint = pixel;
        if (PlotPixel(toVram(pixel))) DrawFrame(SelectedFrameIndex);
    }

    // Draws every pixel between the last and the current mouse position, so fast strokes have no gaps
    private void DrawLine(Point pixel, Func<Point, Point?> toVram)
    {
        if (currentStroke == null || lastDrawPoint == null) return;

        Point start = lastDrawPoint.Value;
        lastDrawPoint = pixel;

        int dx = Math.Abs(pixel.X - start.X), sx = start.X < pixel.X ? 1 : -1;
        int dy = -Math.Abs(pixel.Y - start.Y), sy = start.Y < pixel.Y ? 1 : -1;
        int err = dx + dy;
        int x = start.X, y = start.Y;
        bool changed = false;
        while (true)
        {
            changed |= PlotPixel(toVram(new Point(x, y)));
            if (x == pixel.X && y == pixel.Y) break;
            int e2 = 2 * err;
            if (e2 >= dy) { err += dy; x += sx; }
            if (e2 <= dx) { err += dx; y += sy; }
        }

        if (changed) DrawFrame(SelectedFrameIndex);
    }

    private void FinishStroke()
    {
        if (currentStroke == null) return;
        SamusDrawAction stroke = currentStroke;
        currentStroke = null;
        lastDrawPoint = null;
        if (stroke.Count > 0) AddAction(stroke);
    }

    private void PickColor(Point pixel, Func<Point, Point?> toVram)
    {
        Point? vramPixel = toVram(pixel);
        if (vramPixel == null) return;
        int color = GetVramPixel(vramPixel.Value);
        if (color >= 0) SelectedColor = color;
    }
    #endregion

    #region PAL
    private void DrawPalette()
    {
        paletteView.TileImage = palette.Draw(16, 0, PaletteRows);
        UpdatePaletteSelection();
    }

    private void UpdatePaletteSelection()
    {
        if (PaletteSelection == null) return;
        PaletteSelection.Rectangle = new Rectangle(SelectedColor * PaletteCellSize, SelectedPaletteRow * PaletteCellSize, PaletteCellSize + 1, PaletteCellSize + 1);
    }

    /// <param name="silent">Skips the error message, for reloading when the editor gets focused</param>
    private void LoadPalette(List<SamusAnimationList.PaletteRows> rows, bool silent = false)
    {
        try
        {
            Palette newPalette = new Palette(16);
            foreach (var part in rows)
            {
                Palette p = new Palette(romStream, part.Offset, part.Rows);
                newPalette.Copy(p, 0, part.DstRow, part.Rows);
            }
            palette = newPalette;
            paletteEditOffset = rows[0].Offset;
            paletteEditRows = rows[0].Rows;
            textBox_palOffset.Text = Hex.ToString(paletteEditOffset);
        }
        catch (Exception ex)
        {
            if (silent) return;
            MessageBox.Show("The palette could not be loaded.\n\n" + ex.GetType().ToString() + '\n'
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        DrawPalette();
        if (anim != null) DrawFrame(SelectedFrameIndex);
    }

    private void ReloadPalette(bool silent)
    {
        if (comboBox_palettePreset.SelectedItem is SamusAnimationList.PalettePreset preset) LoadPalette(preset.Rows, silent);
        else LoadPalette(new() { new(paletteEditOffset, 0, paletteEditRows) }, silent);
    }

    private void comboBox_palettePreset_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (loading || comboBox_palettePreset.SelectedItem is not SamusAnimationList.PalettePreset preset) return;
        LoadPalette(preset.Rows);
    }

    private void button_loadPalette_Click(object sender, EventArgs e)
    {
        int offset;
        try { offset = Hex.ToInt(textBox_palOffset.Text); }
        catch
        {
            MessageBox.Show("The offset entered was not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        loading = true;
        comboBox_palettePreset.SelectedIndex = -1;
        loading = false;
        LoadPalette(new() { new(offset, 0, PaletteRows) });
    }

    private void button_editPal_Click(object sender, EventArgs e)
    {
        FormPaletteNew.OpenPaletteEditor(paletteEditOffset, paletteEditRows);
    }

    private void paletteView_TileMouseMove(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        int col = e.PixelPosition.X / PaletteCellSize;
        int row = e.PixelPosition.Y / PaletteCellSize;
        if (col > 15 || row >= PaletteRows)
        {
            PaletteCursor.Visible = false;
            return;
        }
        PaletteCursor.Visible = true;
        PaletteCursor.Rectangle = new Rectangle(col * PaletteCellSize, row * PaletteCellSize, PaletteCellSize + 1, PaletteCellSize + 1);
    }

    private void paletteView_TileMouseDown(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        int col = e.PixelPosition.X / PaletteCellSize;
        int row = e.PixelPosition.Y / PaletteCellSize;
        if (col > 15 || row >= PaletteRows) return;

        PaletteCursor.Visible = false;
        selectedColor = col;
        SelectedPaletteRow = row;
    }

    #endregion

    #region OAM
    private void UpdateOamZoom(int zoom)
    {
        zoom = Math.Clamp(zoom, 0, 4);
        if (zoom == tileDisplay_oam.Zoom) return;

        tileDisplay_oam.Zoom = zoom;
        Program.Config.SamusEditorOamZoom = zoom;
        button_oamZoomIn.Enabled = zoom < maxZoom;
        button_oamZoomOut.Enabled = zoom > 0;
        label_oamZoom.Text = $"{1 << zoom}00%";

        //Update Pen Width
        switch (zoom)
        {
            case 0:
            case 1:
                partOutlineHovered.Width = 1;
                partOutlineSelected.Width = 2;
                break;
            case 2:
                partOutlineHovered.Width = 1;
                partOutlineSelected.Width = 3;
                break;
            case 3:
            case 4:
                partOutlineHovered.Width = 1;
                partOutlineSelected.Width = 4;
                break;
        }

        CenterOamView();
    }

    // Samus' position is at her feet, so the view is centered a bit above the origin
    private void CenterOamView()
    {
        int x = (OAM.FrameOriginX << tileDisplay_oam.Zoom) - panel_oam.ClientSize.Width / 2;
        int y = ((OAM.FrameOriginY - 20) << tileDisplay_oam.Zoom) - panel_oam.ClientSize.Height / 2;
        panel_oam.AutoScrollPosition = new Point(Math.Max(0, x), Math.Max(0, y));
    }

    private void DrawFrame(int frameNumber)
    {
        if (anim == null || frameNumber < 0 || frameNumber >= anim.NumFrames) return;

        anim.SyncPartCounts();
        vram = anim.BuildVram(frameNumber, out vramSources);
        Bitmap frame = anim.Oam.DrawReal(vram, palette, 0, frameNumber);
        tileDisplay_oam.TileImage = frame;
        DrawImage();

        // Display Part boxes
        SetPartOutlines(SelectedFrame);
        UpdateRegionDrawables();
        UpdateFrameDataPanel();
    }

    private void SetPartOutlines(OAM.Frame frame)
    {
        partOutlines.Clear();
        tileDisplay_oam.ResetDrawables();

        List<Drawable> hovered = new();
        List<Drawable> selected = new();

        // Register
        for (int i = frame.parts.Count - 1; i >= 0; i--)
        {
            OAM.Part p = frame.parts[i];
            Size s = p.Dimensions;
            Rectangle r = new Rectangle(p.xPos + OAM.FrameOriginX, p.yPos + OAM.FrameOriginY, s.Width, s.Height);

            Drawable outline = new(r, partOutline)
            {
                Visible = ViewPartOutline,
            };

            if (SelectedPartIndices.Contains(i))
            {
                ChangePen(outline, partOutlineSelected);
                outline.Visible = true;
                selected.Add(outline);
                continue;
            }
            if (HoveredPartIndices.Contains(i))
            {
                ChangePen(outline, partOutlineHovered);
                outline.Visible = true;
                hovered.Add(outline);
                continue;
            }

            partOutlines.Add(outline);
            tileDisplay_oam.AddDrawable(outline);
        }

        // Add hovered and selected now for proper Z ordering
        foreach (var d in hovered)
        {
            partOutlines.Add(d);
            tileDisplay_oam.AddDrawable(d);
        }
        foreach (var d in selected)
        {
            partOutlines.Add(d);
            tileDisplay_oam.AddDrawable(d);
        }

        tileDisplay_oam.AddDrawable(MultiPartSelection);
        tileDisplay_oam.Invalidate();
    }

    private void SetTimerInterval(int frame)
    {
        OAM.Frame f = oam!.Frames[frame];
        int timeInMs = (int)(16.67f * f.duration);
        animationTimer.Interval = Math.Max(1, timeInMs);
    }

    private void SetFrameSelectionCombobox()
    {
        int old = SelectedFrameIndex;

        comboBox_Frame.Items.Clear();
        for (int i = 0; i < oam!.NumFrames; i++) comboBox_Frame.Items.Add(i);
        if (old >= 0 && old < comboBox_Frame.Items.Count) comboBox_Frame.SelectedIndex = old;
        else comboBox_Frame.SelectedIndex = oam.NumFrames - 1;
    }

    private void PopulateUndoRedoForFrames()
    {
        UndoRedos.Clear();
        for (int i = 0; i < oam!.NumFrames; i++)
        {
            UndoRedos.Add(new());
        }
    }

    private void SetPartSelectionCombobox()
    {
        int old = SelectedPartIndex;

        comboBox_part.Items.Clear();
        for (int i = 0; i < oam!.Frames[comboBox_Frame.SelectedIndex].parts.Count; i++) comboBox_part.Items.Add(Hex.ToString(i));
        if (old >= 0 && old < comboBox_part.Items.Count) comboBox_part.SelectedIndex = old;
    }

    private void comboBox_Frame_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (loading || anim == null || SelectedFrameIndex < 0) return;
        FinishStroke();
        DrawFrame(comboBox_Frame.SelectedIndex);
        loading = true;
        textBox_duration.Text = Hex.ToString(oam!.Frames[comboBox_Frame.SelectedIndex].duration);
        loading = false;
        SelectedPartIndex = -1;

        // Enable/disable move buttons
        if (!playingAnimation)
        {
            button_frameDown.Enabled = oam.Frames.Count > 1 && SelectedFrameIndex != oam.Frames.Count - 1;
            button_frameUp.Enabled = oam.Frames.Count > 1 && SelectedFrameIndex != 0;
        }

        SetPartSelectionCombobox();

        if (UndoRedos.Count <= 0) return;
        setUndoRedoButtons();
    }

    private void button_playAnimation_Click(object sender, EventArgs e)
    {
        if (anim == null) return;
        FinishStroke();
        PlayingAnimation = !PlayingAnimation;
        setUndoRedoButtons();
        if (!PlayingAnimation) return;

        SetTimerInterval(comboBox_Frame.SelectedIndex);
        animationTimer.Start();
    }

    private void AnimationTimer_Tick(object? sender, EventArgs e)
    {
        comboBox_Frame.SelectedIndex = (comboBox_Frame.SelectedIndex + 1) % oam!.NumFrames;
        SetTimerInterval(comboBox_Frame.SelectedIndex);
    }

    private void button_viewOrigin_Click(object sender, EventArgs e) => ViewOrigin = !button_viewOrigin.Checked;

    private void button_viewOutline_Click(object sender, EventArgs e) => ViewPartOutline = !button_viewOutline.Checked;

    private void button_snap_Click(object sender, EventArgs e) => SnapParts = !button_snap.Checked;

    #region FRAME DATA
    private void UpdateFrameDataPanel()
    {
        if (anim == null || SelectedFrameIndex < 0) return;
        SamusFrame frame = SelectedSamusFrame;

        loadingFrameData = true;
        if (!((TextBox)textBox_topOffset).Focused) textBox_topOffset.Text = OffsetText(frame.Top.Offset);
        if (!((TextBox)textBox_bottomOffset).Focused) textBox_bottomOffset.Text = OffsetText(frame.Bottom.Offset);
        if (!((TextBox)textBox_oamOffset).Focused) textBox_oamOffset.Text = OffsetText(frame.Oam.Offset);
        SetTileCount(numericUpDown_topRow0, frame.Top.RowTiles[0]);
        SetTileCount(numericUpDown_topRow1, frame.Top.RowTiles[1]);
        SetTileCount(numericUpDown_bottomRow0, frame.Bottom.RowTiles[0]);
        SetTileCount(numericUpDown_bottomRow1, frame.Bottom.RowTiles[1]);
        label_topShared.Text = SharedText(frame.Top.Offset);
        label_bottomShared.Text = SharedText(frame.Bottom.Offset);
        label_oamShared.Text = frame.Oam.Offset < 0 ? "Not saved yet" : $"{SharedText(frame.Oam.Offset)}, {frame.Oam.Parts.Count} parts";
        loadingFrameData = false;
    }

    private static string OffsetText(int offset) => offset < 0 ? "New" : Hex.ToString(offset);

    private string SharedText(int offset)
    {
        int count = GetPointerCount(offset);
        return count <= 1 ? "Unique" : $"Used {count}x";
    }

    private static void SetTileCount(NumericUpDown numericUpDown, int tiles)
    {
        numericUpDown.Maximum = Math.Max(numericUpDown.Maximum, tiles);
        numericUpDown.Value = tiles;
    }

    private void numericUpDown_tiles_ValueChanged(object sender, EventArgs e)
    {
        if (loadingFrameData || anim == null || SelectedFrameIndex < 0) return;

        SamusFrame frame = SelectedSamusFrame;
        (SamusGfx gfx, int row) = sender switch
        {
            _ when sender == numericUpDown_topRow0 => (frame.Top, 0),
            _ when sender == numericUpDown_topRow1 => (frame.Top, 1),
            _ when sender == numericUpDown_bottomRow0 => (frame.Bottom, 0),
            _ => (frame.Bottom, 1),
        };

        int tiles = (int)((NumericUpDown)sender).Value;
        if (tiles == gfx.RowTiles[row]) return;

        FinishStroke();
        FinishModifyingActionGroup();
        SamusGfxRowAction action = new(gfx, row, tiles, SamusGfx.ResizeRowData(gfx.Rows[row], tiles));
        action.Do();
        AddAction(action);
        DrawFrame(SelectedFrameIndex);
    }

    private void frameDataOffset_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter || anim == null || SelectedFrameIndex < 0) return;
        e.SuppressKeyPress = true;

        SamusFrame frame = SelectedSamusFrame;
        int offset;
        try { offset = Hex.ToInt(((TextBox)sender!).Text); }
        catch
        {
            MessageBox.Show("The offset entered was not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (sender == (TextBox)textBox_oamOffset)
        {
            if (offset == frame.Oam.Offset) return;
            SamusOamData? oamData = FindLoadedOam(offset);
            if (oamData == null)
            {
                if (offset < 0 || offset + 2 > romStream.Length || offset + 2 + (romStream.Read16(offset) & 0xFF) * 6 > romStream.Length)
                {
                    MessageBox.Show("There is no valid OAM at the given offset.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                oamData = SamusOamData.Read(romStream, offset);
            }
            ChangeFrameData(frame.Top, frame.Bottom, oamData, "Changed OAM");
            return;
        }

        bool top = sender == (TextBox)textBox_topOffset;
        SamusGfx current = top ? frame.Top : frame.Bottom;
        if (offset == current.Offset) return;

        SamusGfx? gfx = FindLoadedGfx(offset);
        if (gfx == null)
        {
            int max = top ? SamusAnimation.MaxTopTiles : SamusAnimation.MaxBottomTiles;
            if (!SamusGfx.IsValid(romStream, offset) || romStream.Read8(offset) > max || romStream.Read8(offset + 1) > max)
            {
                MessageBox.Show($"There are no valid Samus graphics at the given offset.\nGraphics for the {(top ? "top" : "bottom")} half can have up to {max} tiles per row.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            gfx = new SamusGfx(romStream, offset);
        }

        if (top) ChangeFrameData(gfx, frame.Bottom, frame.Oam, "Changed Top Graphics");
        else ChangeFrameData(frame.Top, gfx, frame.Oam, "Changed Bottom Graphics");
    }

    // Data already used by the animation is reused, so changes to it stay in sync
    private SamusGfx? FindLoadedGfx(int offset) => offset < 0 ? null : anim!.Frames.SelectMany(f => new[] { f.Top, f.Bottom }).FirstOrDefault(g => g.Offset == offset);
    private SamusOamData? FindLoadedOam(int offset) => offset < 0 ? null : anim!.Frames.Select(f => f.Oam).FirstOrDefault(o => o.Offset == offset);

    private void ChangeFrameData(SamusGfx top, SamusGfx bottom, SamusOamData oamData, string actionText)
    {
        FinishStroke();
        FinishModifyingActionGroup();

        SamusFrameDataAction action = new(anim!, SelectedFrameIndex, top, bottom, oamData, actionText)
        {
            DoUndoRun = FrameDataChanged
        };
        action.Do();
        AddAction(action);
        DrawFrame(SelectedFrameIndex);
    }

    private void FrameDataChanged()
    {
        SelectedPartIndex = -1;
        SetPartSelectionCombobox();
    }

    private void button_topUnique_Click(object sender, EventArgs e)
    {
        if (anim == null) return;
        SamusFrame frame = SelectedSamusFrame;
        ChangeFrameData(frame.Top.Clone(), frame.Bottom, frame.Oam, "Made Top Graphics Unique");
    }

    private void button_bottomUnique_Click(object sender, EventArgs e)
    {
        if (anim == null) return;
        SamusFrame frame = SelectedSamusFrame;
        ChangeFrameData(frame.Top, frame.Bottom.Clone(), frame.Oam, "Made Bottom Graphics Unique");
    }

    private void button_oamUnique_Click(object sender, EventArgs e)
    {
        if (anim == null) return;
        SamusFrame frame = SelectedSamusFrame;
        ChangeFrameData(frame.Top, frame.Bottom, frame.Oam.Clone(), "Made OAM Unique");
    }
    #endregion

    #region FRAME EDITING
    private void AddFrame(SamusFrame frame, int duration)
    {
        FinishStroke();
        FinishModifyingActionGroup();

        anim!.InsertFrame(anim.NumFrames, frame, duration);
        UndoRedos.Add(new());
        SetFrameSelectionCombobox();
        comboBox_Frame.SelectedIndex = oam!.NumFrames - 1;
        Status.ChangeMade();
    }
    private void button_addFrame_Click(object sender, EventArgs e)
    {
        if (anim == null) return;
        if (anim.NumFrames >= SamusAnimation.MaxFrames) return;

        // Samus animations often show the same graphics for multiple frames
        SamusFrame current = SelectedSamusFrame;
        AddFrame(new SamusFrame(current.Top, current.Bottom, current.Oam), SelectedFrame.duration);
    }
    private void button_duplicate_Click(object sender, EventArgs e)
    {
        if (anim == null) return;
        if (anim.NumFrames >= SamusAnimation.MaxFrames) return;

        SamusFrame current = SelectedSamusFrame;
        AddFrame(new SamusFrame(current.Top.Clone(), current.Bottom.Clone(), current.Oam.Clone()), SelectedFrame.duration);
    }
    private void button_removeFrame_Click(object sender, EventArgs e)
    {
        if (anim == null || SelectedFrameIndex == -1) return;
        if (oam!.NumFrames <= 1)
        {
            MessageBox.Show("Cannot remove the last frame.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        FinishStroke();
        FinishModifyingActionGroup();

        int index = SelectedFrameIndex;
        anim.RemoveFrame(index);
        UndoRedos.RemoveAt(index);

        // The frames after the removed one moved down
        for (int i = index; i < UndoRedos.Count; i++)
        {
            UpdateActionStackFrameIndex(UndoRedos[i].UndoStack, i);
            UpdateActionStackFrameIndex(UndoRedos[i].RedoStack, i);
        }

        loading = true;
        comboBox_Frame.SelectedIndex = -1;
        loading = false;
        SetFrameSelectionCombobox();
        comboBox_Frame.SelectedIndex = Math.Min(index, oam.NumFrames - 1);
        Status.ChangeMade();
    }

    private void textBox_duration_TextChanged(object? sender, EventArgs e)
    {
        if (loading || anim == null || SelectedFrameIndex == -1) return;

        // Validate duration input
        try
        {
            int duration = Hex.ToByte(textBox_duration.Text);
            if (duration <= 0 || duration > 0xFF)
            {
                throw new ArgumentOutOfRangeException(nameof(duration), "Duration must be between 1 and 0xFF.");
            }

            OAM.Frame frame = SelectedFrame;
            frame.duration = duration;
            oam!.Frames[SelectedFrameIndex] = frame;
            Status.ChangeMade();
        }
        catch { }
    }

    private void SwapFrames(int oldIndex, int newIndex)
    {
        // Swap frames
        anim!.SwapFrames(oldIndex, newIndex);

        // Swap UndoRedos
        var undoNew = UndoRedos[oldIndex];
        var undoOld = UndoRedos[newIndex];
        UndoRedos[oldIndex] = undoOld;
        UndoRedos[newIndex] = undoNew;

        // Update UndoRedo frame indices
        UpdateActionStackFrameIndex(undoNew.UndoStack, newIndex);
        UpdateActionStackFrameIndex(undoNew.RedoStack, newIndex);
        UpdateActionStackFrameIndex(undoOld.UndoStack, oldIndex);
        UpdateActionStackFrameIndex(undoOld.RedoStack, oldIndex);

    }
    private void button_frameUp_Click(object sender, EventArgs e)
    {
        if (anim == null || SelectedFrameIndex <= 0) return;
        FinishStroke();
        FinishModifyingActionGroup();

        SwapFrames(SelectedFrameIndex, SelectedFrameIndex - 1);

        // Update selection
        comboBox_Frame.SelectedIndex--;
        Status.ChangeMade();
    }
    private void button_frameDown_Click(object sender, EventArgs e)
    {
        if (anim == null || SelectedFrameIndex >= oam!.NumFrames - 1) return;
        FinishStroke();
        FinishModifyingActionGroup();

        SwapFrames(SelectedFrameIndex, SelectedFrameIndex + 1);

        // Update selection
        comboBox_Frame.SelectedIndex++;
        Status.ChangeMade();
    }
    #endregion

    #region PART EDITING
    private int FindPart(OAM.Frame frame, int pixelX, int pixelY)
    {
        Point position = new Point(
            pixelX - OAM.FrameOriginX,
            pixelY - OAM.FrameOriginY
        );

        for (int i = 0; i < frame.parts.Count; i++)
        {
            OAM.Part p = frame.parts[i];
            if (p.Area.Contains(position)) return i;
        }

        return -1;
    }

    private List<int> FindParts(OAM.Frame frame, Rectangle region)
    {
        // Normalize rectangle
        region = new(
            region.X - OAM.FrameOriginX,
            region.Y - OAM.FrameOriginY,
            region.Width,
            region.Height
        );

        List<int> parts = new();
        for (int i = 0; i < frame.parts.Count; i++)
        {
            var p = frame.parts[i];
            if (region.Contains(p.Area)) parts.Add(i);
        }
        return parts;
    }

    #region Z-Ordering Parts
    private void ReorderPart(int oldIndex, int newIndex)
    {
        if (oldIndex < 0 || oldIndex >= SelectedFrame.parts.Count || newIndex < 0 || newIndex >= SelectedFrame.parts.Count)
            return;

        OAM.Part oldPart = SelectedFrame.parts[newIndex];
        OAM.Part newPart = SelectedFrame.parts[oldIndex];

        OamActionGroup group = new();
        group.AddAction(new ModifyOamPartAction(oam!, SelectedFrameIndex, newIndex, newPart, "Reordered Part"));
        group.AddAction(new ModifyOamPartAction(oam!, SelectedFrameIndex, oldIndex, oldPart, "Reordered Part"));
        group.Do();
        AddAction(group);

        SelectedPartIndex = newIndex;

        DrawFrame(SelectedFrameIndex);
        Status.ChangeMade();
    }

    private void contextMenu_oam_Opening(object sender, CancelEventArgs e)
    {
        if (!SelectedParts || CurrentTool != Tool.Select)
        {
            e.Cancel = true;
            return;
        }

        button_pasteCtx.Enabled = Clipboard.ContainsData(ClipboardFormat);

        // Enable/disable context menu items based on selected part
        int parts = SelectedFrame.parts.Count;
        bool multi = SelectedPartIndices.Count > 1;
        button_toFront.Enabled = SelectedPartIndex != 0 && !multi;
        button_toBack.Enabled = SelectedPartIndex != parts - 1 && !multi;
        button_layerDown.Enabled = SelectedPartIndex != parts - 1 && parts > 1 && !multi;
        button_layerUp.Enabled = SelectedPartIndex != 0 && parts > 1 && !multi;
    }
    private void button_toFront_Click(object sender, EventArgs e)
    {
        if (SelectedPartIndex == -1) return;
        ReorderPart(SelectedPartIndex, 0);
    }
    private void button_layerUp_Click(object sender, EventArgs e)
    {
        if (SelectedPartIndex == -1) return;
        ReorderPart(SelectedPartIndex, SelectedPartIndex - 1);
    }
    private void button_layerDown_Click(object sender, EventArgs e)
    {
        if (SelectedPartIndex == -1) return;
        ReorderPart(SelectedPartIndex, SelectedPartIndex + 1);
    }
    private void button_toBack_Click(object sender, EventArgs e)
    {
        if (SelectedPartIndex == -1) return;
        ReorderPart(SelectedPartIndex, SelectedFrame.parts.Count - 1);
    }
    #endregion

    #region Adding / Removing
    private void button_addPart_Click(object sender, EventArgs e) => AddPart(0, 0);
    private void button_addPartHere_Click(object sender, EventArgs e) => AddPart(ContextMenuOpenedAt.X - OAM.FrameOriginX, ContextMenuOpenedAt.Y - OAM.FrameOriginY);
    private void AddPart(int x, int y)
    {
        if (anim == null) return;
        if (SelectedFrame.parts.Count == 0xFF)
        {
            MessageBox.Show("Cannot add more parts to this frame, maximum reached (0xFF).", "Maximum Parts Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        OAM.Part p = OAM.Part.Empty;
        p.xPos = x;
        p.yPos = y;

        AddOamPartAction a = new(oam!, SelectedFrameIndex, p, 0)
        {
            DoUndoRun = AddedPart
        };
        a.Do();
        AddAction(a);

        DrawFrame(SelectedFrameIndex);
        SelectedPartIndex = 0;
    }
    private void AddedPart()
    {
        SelectedPartIndex = -1;
        SetPartSelectionCombobox();
    }

    private void button_removePart_Click(object sender, EventArgs e) => DeletePart();
    private void DeletePart(string? actionText = null)
    {
        if (!SelectedParts) return;

        // Single
        if (SelectedPartIndices.Count == 1 && actionText is null)
        {
            RemoveOamPartAction a = new(oam!, SelectedFrameIndex, SelectedPartIndex)
            {
                DoUndoRun = DeletedPart
            };
            a.Do();
            AddAction(a);
            DrawFrame(SelectedFrameIndex);
            return;
        }

        // Multi
        OamActionGroup group = new(actionText)
        {
            DoUndoRun = DeletedPart
        };
        foreach (int index in SelectedPartIndices.OrderByDescending(i => i))
        {
            RemoveOamPartAction a = new(oam!, SelectedFrameIndex, index);
            group.AddAction(a);
        }
        group.Do();
        AddAction(group);
        DrawFrame(SelectedFrameIndex);
    }
    private void DeletedPart()
    {
        SelectedPartIndex = -1;
        SetPartSelectionCombobox();
    }
    #endregion

    #region Copy/Paste
    // Same format as the OAM editor, so parts can be copied between both editors
    private const string ClipboardFormat = "MageOamEditor_Parts";

    // OAM.Part uses public fields, which System.Text.Json ignores, so parts are wrapped for the clipboard
    private class ClipboardPart
    {
        public ClipboardPart() { }
        public ClipboardPart(OAM.Part part)
        {
            XPos = part.xPos;
            YPos = part.yPos;
            Shape = part.shape;
            Flip = part.flip;
            Size = part.size;
            TileNum = part.tileNum;
            PalRow = part.palRow;
        }

        public int XPos { get; set; }
        public int YPos { get; set; }
        public int Shape { get; set; }
        public int Flip { get; set; }
        public int Size { get; set; }
        public int TileNum { get; set; }
        public int PalRow { get; set; }

        public OAM.Part Unpack()
        {
            OAM.Part part = OAM.Part.Empty;
            part.xPos = XPos;
            part.yPos = YPos;
            part.shape = Shape;
            part.flip = Flip;
            part.size = Size;
            part.tileNum = TileNum;
            part.palRow = PalRow;
            return part;
        }
    }

    private class ClipboardParts
    {
        public ClipboardParts() { }
        public ClipboardParts(List<OAM.Part> input) => Parts = input.Select(p => new ClipboardPart(p)).ToArray();

        public ClipboardPart[] Parts { get; set; } = [];

        public List<OAM.Part> Unpack() => Parts.Select(p => p.Unpack()).ToList();

        public static explicit operator ClipboardParts(List<OAM.Part> input) => new ClipboardParts(input);
        public static implicit operator List<OAM.Part>(ClipboardParts input) => input.Unpack();
    }

    private List<OAM.Part> CopyParts()
    {
        // Ascending index order keeps the Z order of the copied parts
        return SelectedPartIndices.Distinct().OrderBy(i => i).Select(i => SelectedFrame.parts[i]).ToList();
    }

    private void CopyPartsToClipboard(List<OAM.Part> parts)
    {
        try { Clipboard.SetDataAsJson(ClipboardFormat, (ClipboardParts)parts); }
        catch (ExternalException)
        {
            MessageBox.Show("Clipboard is busy. Please try copying again.");
        }
    }

    private List<OAM.Part>? PartsFromClipboard()
    {
        if (!Clipboard.ContainsData(ClipboardFormat)) return null;

        try
        {
            if (Clipboard.TryGetData(ClipboardFormat, out ClipboardParts pastedParts)) return pastedParts;
        }
        catch (ExternalException)
        {
            MessageBox.Show("Clipboard is busy. Please try pasting again.");
        }

        return null;
    }

    private static Rectangle GetPartsArea(List<OAM.Part> parts)
    {
        Rectangle area = parts[0].Area;
        foreach (OAM.Part p in parts) area = Rectangle.Union(area, p.Area);
        return area;
    }

    // Returns the top left of the pasted parts' area, in frame coordinates
    // `centerAt` is a position in the OAM view (as given by TileDisplayArgs.PixelPosition), which takes priority over the mouse
    private Point FindIdealPasteLocation(bool pressedButton, Size size, Point? centerAt = null)
    {
        if (centerAt is not null)
        {
            return new Point(
                centerAt.Value.X - OAM.FrameOriginX - size.Width / 2,
                centerAt.Value.Y - OAM.FrameOriginY - size.Height / 2
            );
        }

        Point mouseToPanel = panel_oam.PointToClient(System.Windows.Forms.Cursor.Position);

        // Center on the mouse if it is hovering over the view
        if (!pressedButton && panel_oam.ClientRectangle.Contains(mouseToPanel))
        {
            Point mouseToTileDisplay = tileDisplay_oam.PointToClient(System.Windows.Forms.Cursor.Position);
            return new Point(
                (mouseToTileDisplay.X >> tileDisplay_oam.Zoom) - OAM.FrameOriginX - size.Width / 2,
                (mouseToTileDisplay.Y >> tileDisplay_oam.Zoom) - OAM.FrameOriginY - size.Height / 2
            );
        }

        // Otherwise center in the visible part of the view
        int xCenter = (-panel_oam.AutoScrollPosition.X + panel_oam.ClientSize.Width / 2) >> tileDisplay_oam.Zoom;
        int yCenter = (-panel_oam.AutoScrollPosition.Y + panel_oam.ClientSize.Height / 2) >> tileDisplay_oam.Zoom;
        return new Point(
            xCenter - OAM.FrameOriginX - size.Width / 2,
            yCenter - OAM.FrameOriginY - size.Height / 2
        );
    }

    // Moves the parts by the offset, as far as the position ranges of OAM allow
    private static List<OAM.Part> OffsetParts(List<OAM.Part> parts, Point offset)
    {
        int xMin = parts.Min(p => p.xPos), xMax = parts.Max(p => p.xPos);
        int yMin = parts.Min(p => p.yPos), yMax = parts.Max(p => p.yPos);
        int dx = Math.Clamp(offset.X, -OAM.FrameOriginX - xMin, OAM.FrameOriginX - 1 - xMax);
        int dy = Math.Clamp(offset.Y, -OAM.FrameOriginY - yMin, OAM.FrameOriginY - 1 - yMax);

        List<OAM.Part> moved = new(parts.Count);
        foreach (OAM.Part p in parts)
        {
            OAM.Part part = p;
            part.xPos += dx;
            part.yPos += dy;
            moved.Add(part);
        }
        return moved;
    }

    private void Copy()
    {
        if (oam is null || PlayingAnimation || !SelectedParts) return;
        CopyPartsToClipboard(CopyParts());
    }

    private void Cut()
    {
        if (oam is null || PlayingAnimation || !SelectedParts) return;
        CopyPartsToClipboard(CopyParts());
        FinishModifyingActionGroup();
        DeletePart("Cut Parts");
    }

    private void Paste(bool throughShortcut = false, Point? at = null)
    {
        if (oam is null || PlayingAnimation) return;

        List<OAM.Part>? pasteParts = PartsFromClipboard();
        if (pasteParts is null || pasteParts.Count == 0) return;

        if (SelectedFrame.parts.Count + pasteParts.Count > 0xFF)
        {
            MessageBox.Show("Cannot paste, this would exceed the maximum amount of parts in a frame (0xFF).", "Maximum Parts Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        Rectangle area = GetPartsArea(pasteParts);
        Point pastePoint = FindIdealPasteLocation(!throughShortcut, area.Size, at);
        pasteParts = OffsetParts(pasteParts, new Point(pastePoint.X - area.X, pastePoint.Y - area.Y));

        FinishModifyingActionGroup();

        // Insert at the front, keeping the copied Z order
        OamActionGroup group = new("Paste Parts") { DoUndoRun = AddedPart };
        for (int i = 0; i < pasteParts.Count; i++)
            group.AddAction(new AddOamPartAction(oam, SelectedFrameIndex, pasteParts[i], i));
        group.Do();
        AddAction(group);

        DrawFrame(SelectedFrameIndex);
        SelectedPartIndices = Enumerable.Range(0, pasteParts.Count).ToList();
    }

    private void UpdateClipboardButtons()
    {
        button_cut.Enabled = SelectedParts && !PlayingAnimation;
        button_copy.Enabled = SelectedParts && !PlayingAnimation;
        button_paste.Enabled = !PlayingAnimation;
    }

    private void button_cut_Click(object sender, EventArgs e) => Cut();

    private void button_copy_Click(object sender, EventArgs e) => Copy();

    private void button_paste_Click(object sender, EventArgs e) => Paste();

    // Context menu paste, places the parts where the menu was opened
    private void button_pasteHere_Click(object sender, EventArgs e) => Paste(at: ContextMenuOpenedAt);

    private void contextMenu_oamNoSelection_Opening(object sender, CancelEventArgs e)
    {
        if (anim == null || CurrentTool != Tool.Select)
        {
            e.Cancel = true;
            return;
        }
        button_pasteHere.Enabled = Clipboard.ContainsData(ClipboardFormat);
    }
    #endregion

    private void ResetPartData()
    {
        textBox_tile.Text = string.Empty;
        comboBox_palette.SelectedIndex = -1;
        textBox_x.Text = string.Empty;
        textBox_y.Text = string.Empty;
        checkBox_xFlip.Checked = false;
        checkBox_yFlip.Checked = false;
        comboBox_size.SelectedIndex = -1;
    }

    private Rectangle GetMultiPartArea()
    {
        Rectangle? area = null;
        foreach (int index in SelectedPartIndices)
        {
            OAM.Part p = SelectedFrame.parts[index];
            if (area is null) area = p.Area;
            area = Rectangle.Union(area.Value, p.Area);
        }
        if (area is null) return Rectangle.Empty;
        return area.Value;
    }

    private List<Rectangle> UnselectedPartsAreas()
    {
        List<Rectangle> result = new();
        for (int i = 0; i < SelectedFrame.parts.Count; i++)
        {
            if (SelectedPartIndices.Contains(i)) continue;
            result.Add(SelectedFrame.parts[i].Area);
        }
        return result;
    }

    private Rectangle SnapRectangle(Rectangle current, IEnumerable<Rectangle> otherRectangles, int snapThreshold = 2, int proximityRadius = 5)
    {
        if (otherRectangles == null)
        {
            return current;
        }

        int? bestDeltaX = null;
        int? bestDeltaY = null;

        int currentCenterX = current.X + (current.Width / 2);
        int currentCenterY = current.Y + (current.Height / 2);

        int radiusSquared = proximityRadius * proximityRadius;

        foreach (var other in otherRectangles)
        {
            // 1. Proximity Check: Calculate squared edge-to-edge distance between the two boxes
            if (GetSquaredDistance(current, other) > radiusSquared)
            {
                continue; // Too far away — ignore this rectangle
            }

            int otherCenterX = other.X + (other.Width / 2);
            int otherCenterY = other.Y + (other.Height / 2);

            // 2. Evaluate X-axis alignment options
            int[] xOffsets = {
                other.Left - current.Left,       // Outer Left to Left
                other.Right - current.Right,     // Outer Right to Right
                other.Right - current.Left,      // Abut: Left to Right
                other.Left - current.Right,      // Abut: Right to Left
                otherCenterX - currentCenterX    // Center to Center
            };

            foreach (int dx in xOffsets)
            {
                if (Math.Abs(dx) <= snapThreshold)
                {
                    if (!bestDeltaX.HasValue || Math.Abs(dx) < Math.Abs(bestDeltaX.Value))
                    {
                        bestDeltaX = dx;
                    }
                }
            }

            // 3. Evaluate Y-axis alignment options
            int[] yOffsets = {
                other.Top - current.Top,         // Outer Top to Top
                other.Bottom - current.Bottom,   // Outer Bottom to Bottom
                other.Bottom - current.Top,      // Abut: Top to Bottom
                other.Top - current.Bottom,      // Abut: Bottom to Top
                otherCenterY - currentCenterY    // Center to Center
            };

            foreach (int dy in yOffsets)
            {
                if (Math.Abs(dy) <= snapThreshold)
                {
                    if (!bestDeltaY.HasValue || Math.Abs(dy) < Math.Abs(bestDeltaY.Value))
                    {
                        bestDeltaY = dy;
                    }
                }
            }
        }

        int snappedX = current.X + (bestDeltaX ?? 0);
        int snappedY = current.Y + (bestDeltaY ?? 0);

        return new Rectangle(snappedX, snappedY, current.Width, current.Height);
    }

    private int GetSquaredDistance(Rectangle a, Rectangle b)
    {
        int dx = Math.Max(0, Math.Max(b.Left - a.Right, a.Left - b.Right));
        int dy = Math.Max(0, Math.Max(b.Top - a.Bottom, a.Top - b.Bottom));

        return (dx * dx) + (dy * dy);
    }

    private int FindCommonPalette()
    {
        if (SelectedPartIndices.Count < 1) return -1;
        int common = SelectedFrame.parts[SelectedPartIndices[0]].palRow;
        foreach (int index in SelectedPartIndices)
            if (SelectedFrame.parts[index].palRow != common) return -1;
        return common;
    }

    private void DisplayPartData(OAM.Part p)
    {
        textBox_tile.Text = Hex.ToString(p.tileNum);
        comboBox_palette.SelectedIndex = p.palRow;
        int xVal = p.xPos;
        if (xVal < 0) xVal += 512;
        textBox_x.Text = Hex.ToString(xVal);
        int yVal = p.yPos;
        if (yVal < 0) yVal += 256;
        textBox_y.Text = Hex.ToString(yVal);
        checkBox_xFlip.Checked = p.Xflip;
        checkBox_yFlip.Checked = p.Yflip;
        comboBox_size.SelectedIndex = p.shape * 4 + p.size;
    }

    private void DisplayMultiplePartData()
    {
        textBox_tile.Text = string.Empty;
        comboBox_palette.SelectedIndex = FindCommonPalette();
        Point pos = GetMultiPartArea().Location;
        if (pos.X < 0) pos.X += 512;
        if (pos.Y < 0) pos.Y += 256;
        textBox_x.Text = Hex.ToString(pos.X);
        textBox_y.Text = Hex.ToString(pos.Y);
        checkBox_xFlip.Checked = false;
        checkBox_yFlip.Checked = false;
        comboBox_size.SelectedIndex = -1;
    }

    private void HighlightPartInGfx(OAM.Part part)
    {
        // Display Part on GFX View
        Point gfxPosition = new(part.tileNum % 32 * gfxView_gfx.TileSize, part.tileNum / 32 * gfxView_gfx.TileSize);
        gfxSelection.Rectangle = new Rectangle(gfxPosition, part.Dimensions);
        gfxSelection.Visible = true;
    }

    private void HandleSelectedPartChanged(List<int> partIndices)
    {
        if (partIndices.Count <= 0 || oam == null || SelectedFrameIndex < 0)
        {
            loadingPart = true;
            ResetPartData();
            loadingPart = false;
            gfxSelection.Visible = false;
            gfxCursor.Visible = false;
            return;
        }

        // Setting input enabled
        bool multiPart = partIndices.Count > 1;
        textBox_tile.Enabled =
        checkBox_xFlip.Enabled =
        checkBox_yFlip.Enabled =
        comboBox_size.Enabled =
            !multiPart;

        loadingPart = true;
        if (!multiPart)
        {
            OAM.Part part = SelectedFrame.parts[partIndices[0]];
            HighlightPartInGfx(part);

            DisplayPartData(part);
        }
        else DisplayMultiplePartData();

        loadingPart = false;
    }

    private void comboBox_part_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox_part.SelectedIndex == -1) return;
        SelectedPartIndex = comboBox_part.SelectedIndex;
    }


    #region Part Data Modification
    private void AddActionToGroup(GenericEditorAction a)
    {
        if (GroupedActions is null)
        {
            AddAction(a);
            return;
        }
        GroupedActions.Add(a);
    }

    private Point PointToSignedPosition(Point pos) =>
        new Point(
        pos.X < 256 ? pos.X : pos.X - 512,
        pos.Y < 128 ? pos.Y : pos.Y - 256
    );

    private void ModifySinglePart(int partIndex, Point position, int tileNum, int palRow, bool xFlip, bool yFlip, byte shape, byte size)
    {
        OAM.Part part = SelectedFrame.parts[partIndex];

        // Update Part
        part.tileNum = tileNum;
        part.xPos = position.X;
        part.yPos = position.Y;
        part.palRow = palRow;
        part.flip = (byte)((xFlip ? 0b01 : 0) | (yFlip ? 0b10 : 0));
        part.shape = shape;
        part.size = size;

        ModifyOamPartAction a = new(oam!, SelectedFrameIndex, SelectedPartIndex, part);
        a.Do();
        AddActionToGroup(a);

        HighlightPartInGfx(part);
    }

    private void ModifyMultiPart(Point position, int palRow)
    {
        Point oldPos = GetMultiPartArea().Location;
        Point diff = new(position.X - oldPos.X, position.Y - oldPos.Y);

        OamActionGroup multiModifyAction = new();

        foreach (int index in SelectedPartIndices)
        {
            OAM.Part p = SelectedFrame.parts[index];
            p.xPos += diff.X;
            p.yPos += diff.Y;
            if (palRow != -1) p.palRow = palRow;

            ModifyOamPartAction a = new(oam!, SelectedFrameIndex, index, p);
            multiModifyAction.AddAction(a);
        }

        multiModifyAction.Do();
        AddActionToGroup(multiModifyAction);
    }

    private void MoveSelectedParts(int diffX, int diffY)
    {
        if (!SelectedParts) return;
        try
        {
            int xPos = Hex.ToInt(textBox_x.Text);
            int yPos = Hex.ToInt(textBox_y.Text);

            // Convert to signed coordinates
            Point normalized = PointToSignedPosition(new(xPos, yPos));
            int newX = Math.Clamp(normalized.X + diffX, -256, 255);
            int newY = Math.Clamp(normalized.Y + diffY, -128, 127);

            // Convert back to unsigned
            int rawX = newX & 0x1FF;
            int rawY = newY & 0xFF;

            textBox_x.Text = Hex.ToString(rawX);
            textBox_y.Text = Hex.ToString(rawY);
        }
        catch { }
    }

    private void controlElements_changeMade(object? sender, EventArgs e)
    {
        if (loadingPart || !SelectedParts) return;

        //Validate values or throw error
        try
        {
            int temp_xPos = Hex.ToUshort(textBox_x.Text);
            if (temp_xPos < 0 || temp_xPos > 0x1FF) throw new ArgumentOutOfRangeException(nameof(temp_xPos), "X position must be between 0 and 0x1FF.");
            int temp_yPos = Hex.ToByte(textBox_y.Text);

            // Convert to signed int
            Point newPos = PointToSignedPosition(new(temp_xPos, temp_yPos));

            int palRow = comboBox_palette.SelectedIndex;
            bool xFlip = checkBox_xFlip.Checked;
            bool yFlip = checkBox_yFlip.Checked;
            byte shape = (byte)(comboBox_size.SelectedIndex / 4);
            byte size = (byte)(comboBox_size.SelectedIndex % 4);

            if (SelectedPartIndices.Count == 1)
            {
                int tileNum = Hex.ToInt(textBox_tile.Text);
                if (tileNum < 0 || tileNum > 0x3FF) throw new ArgumentOutOfRangeException(nameof(tileNum), "Tile number must be between 0 and 0x3FF.");

                ModifySinglePart(SelectedPartIndex, newPos, tileNum, palRow, xFlip, yFlip, shape, size);
            }
            else ModifyMultiPart(newPos, palRow);

            // Finishing change
            DrawFrame(SelectedFrameIndex);
            Status.ChangeMade();
        }
        catch { }
    }
    #endregion

    #endregion

    private void oamView_oam_Scrolled(object sender, MouseEventArgs e)
    {
        if ((ModifierKeys & Keys.Control) == Keys.Control)
        {
            if (e.Delta > 0) UpdateOamZoom(tileDisplay_oam.Zoom + 1);
            if (e.Delta < 0) UpdateOamZoom(tileDisplay_oam.Zoom - 1);
        }
    }

    private void SetOamCursor(int hoveredIndex, bool hoveringSelection)
    {
        if (CurrentTool == Tool.Pencil) Cursor = Cursors.Cross;
        else if (hoveringSelection) Cursor = Cursors.SizeAll;
        else if (hoveredIndex == -1) Cursor = Cursors.Default;
        else Cursor = Cursors.Hand;
    }

    public static Rectangle GetSelectionRectangle(Point pivot, Point current)
    {
        int left = Math.Min(pivot.X, current.X);
        int top = Math.Min(pivot.Y, current.Y);
        int right = Math.Max(pivot.X, current.X);
        int bottom = Math.Max(pivot.Y, current.Y);

        // +1 ensures the end pixel cell is fully contained
        return new Rectangle(left, top, right - left + 1, bottom - top + 1);
    }

    private bool IsMouseButtonPressed(TileDisplay.TileDisplayArgs e)
    {
        return e.Button == MouseButtons.Left || e.Button == MouseButtons.Right;
    }

    private bool HoveringOverSelection(Point point)
    {
        point = new Point(
            point.X - OAM.FrameOriginX,
            point.Y - OAM.FrameOriginY
        );

        foreach (int index in SelectedPartIndices)
        {
            var p = SelectedFrame.parts[index];
            if (p.Area.Contains(point)) return true;
        }
        return false;
    }

    private void StartModifyingActionGroup()
    {
        if (GroupedActions is null || GroupedActions?.Count <= 0) GroupedActions = new();
    }

    private void FinishModifyingActionGroup()
    {
        if (KeyDebounceWindowActive) KeyMovementDebounceTimer.Stop();
        if (GroupedActions is null || GroupedActions.Count < 1)
        {
            GroupedActions = null;
            return;
        }

        if (GroupedActions.Count == 1)
        {
            AddAction(GroupedActions[0]);
            GroupedActions = null;
            return;
        }

        OamActionGroup group = new();
        group.AddAction(GroupedActions[0]);
        group.AddAction(GroupedActions[GroupedActions.Count - 1]);
        AddAction(group);
        GroupedActions = null;
    }

    private void oamView_oam_TileMouseDown(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        if (oam == null) return;
        if (!IsMouseButtonPressed(e)) return;
        if (PlayingAnimation) return;

        if (CurrentTool == Tool.Pencil)
        {
            tileDisplay_oam.ContextMenuStrip = null;
            if (e.Button == MouseButtons.Right) PickColor(e.PixelPosition, OamPixelOf);
            if (e.Button == MouseButtons.Left) StartStroke(e.PixelPosition, OamPixelOf);
            return;
        }

        // General Part selection code
        int hoveredPart = FindPart(SelectedFrame, e.PixelPosition.X, e.PixelPosition.Y);
        bool hoveringOverSelection = HoveringOverSelection(e.PixelPosition);

        SetOamCursor(hoveredPart, hoveringOverSelection);

        // Deselect old selection if not hovering over anything and start multi-select
        if (hoveredPart == -1)
        {
            SelectedPartIndex = -1;
            MultiSelectPivot = e.PixelPosition;
        }
        // Select hovered, if it isnt already
        else if (!hoveringOverSelection)
        {
            // Check if new select or or additive select
            if (ModifierKeys == Keys.Control && !SelectedPartIndices.Contains(hoveredPart))
            {
                AddSelectedPart(hoveredPart);
                SetPartOutlines(SelectedFrame);
            }
            else SelectedPartIndex = hoveredPart;
        }

        // Context Menu
        if (e.Button == MouseButtons.Right)
        {
            ContextMenuOpenedAt = e.PixelPosition;
            if (SelectedParts) tileDisplay_oam.ContextMenuStrip = contextMenu_oam;
            else tileDisplay_oam.ContextMenuStrip = contextMenu_oamNoSelection;
        }


        // SPECIFIC EDITING CODE
        if (!SelectedParts) return;
        MouseStartLocation = e.PixelPosition;
        PartsStartLocation = GetMultiPartArea().Location;
    }

    private void oamView_oam_TileMouseMove(object sender, TileDisplay.TileDisplayArgs e)
    {
        if (oam == null) return;

        // General Part selection code
        if (PlayingAnimation) return;

        if (CurrentTool == Tool.Pencil)
        {
            Point? vramPixel = OamPixelOf(e.PixelPosition);
            statusLabel_tileInfo.Text = vramPixel == null ? string.Empty : DescribeTile(vramPixel.Value.Y / 8 * 32 + vramPixel.Value.X / 8);
            if (currentStroke != null && e.Button == MouseButtons.Left) DrawLine(e.PixelPosition, OamPixelOf);
            return;
        }

        // Multi Select
        if (MultiSelectPivot is not null && IsMouseButtonPressed(e))
        {
            MultiPartSelection.Rectangle = GetSelectionRectangle(MultiSelectPivot.Value, e.PixelPosition);
            MultiPartSelection.Visible = true;

            if (OldMultiSelectPosition is null || OldMultiSelectPosition.Value != e.PixelPosition)
            {
                OldMultiSelectPosition = e.PixelPosition;
                HoveredPartIndices = FindParts(SelectedFrame, MultiPartSelection.Rectangle);
            }
        }

        // Regular Moving
        else
        {
            int hovered = FindPart(SelectedFrame, e.PixelPosition.X, e.PixelPosition.Y);

            // Check if hovered part overlaps with selected
            bool hoveringOverSelection = HoveringOverSelection(e.PixelPosition);

            SetOamCursor(hovered, hoveringOverSelection);

            // Update hovered part
            if (hoveringOverSelection) HoveredPartIndex = -1;
            else if (hovered != HoveredPartIndex && MouseStartLocation is null) HoveredPartIndex = hovered;

        }


        // SPECIFIC EDITING CODE
        if (!SelectedParts) return;
        if (MouseStartLocation is null || PartsStartLocation is null || e.Button != MouseButtons.Left) return;

        // Check if arrow keys were used to move and finish that action group, if its still in debounce window
        if (KeyDebounceWindowActive) FinishModifyingActionGroup();

        // Initiates a new modifying action group, if it doesnt exist yet or has been finished before
        StartModifyingActionGroup();

        Point diff = new Point(
            e.PixelPosition.X - MouseStartLocation.Value.X,
            e.PixelPosition.Y - MouseStartLocation.Value.Y
        );
        Point newPartLocation = new Point(
            Math.Clamp(PartsStartLocation.Value.X + diff.X, -256, 255),
            Math.Clamp(PartsStartLocation.Value.Y + diff.Y, -128, 127)
        );

        // Snap to nearest unselected part
        if (ModifierKeys == Keys.Shift)
        {
            int roundX = newPartLocation.X / 8 * 8;
            int roundY = newPartLocation.Y / 8 * 8;
            newPartLocation = new(roundX, roundY);
        }
        else if (SnapParts && ModifierKeys != Keys.Alt)
        {
            Rectangle current = GetMultiPartArea();
            current.Location = newPartLocation;
            newPartLocation = SnapRectangle(current, UnselectedPartsAreas()).Location;
        }

        textBox_x.Text = Hex.ToString(newPartLocation.X < 0 ? newPartLocation.X + 512 : newPartLocation.X);
        textBox_y.Text = Hex.ToString(newPartLocation.Y < 0 ? newPartLocation.Y + 256 : newPartLocation.Y);
    }

    private void oamView_oam_TileMouseUp(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        FinishStroke();

        // Select multiselect parts
        if (MultiSelectPivot is not null && HoveredPartIndices.Count > 0)
        {
            SelectedPartIndices = HoveredPartIndices;
            HoveredPartIndices = new();
        }

        MultiSelectPivot = null;
        MultiPartSelection.Visible = false;
        MouseStartLocation = null;
        PartsStartLocation = null;
        FinishModifyingActionGroup();
    }
    #endregion

    #region Export / Import
    private void button_exportAnimation_Click(object sender, EventArgs e)
    {
        if (anim == null)
        {
            MessageBox.Show("No animation loaded", "Animation Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        SaveFileDialog saveAnimation = new SaveFileDialog();
        saveAnimation.Filter = "GIF files (*.gif)|*.gif";
        if (saveAnimation.ShowDialog() != DialogResult.OK) return;

        anim.SyncPartCounts();
        Rectangle oamBounds = anim.Oam.Bounds;
        oamBounds.X += OAM.FrameOriginX;
        oamBounds.Y += OAM.FrameOriginY;
        if (oamBounds.Width <= 0 || oamBounds.Height <= 0)
        {
            MessageBox.Show("The animation has no parts to export.", "Empty Animation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        using (GifWriter writer = new GifWriter(saveAnimation.FileName, 500, 0))
        {
            for (int i = 0; i < anim.NumFrames; i++)
            {
                OAM.Frame frame = anim.Oam.Frames[i];

                byte[] frameVram = anim.BuildVram(i, out _);
                Bitmap frameImage = anim.Oam.DrawReal(frameVram, palette, 0, i);
                frameImage = frameImage.Crop(oamBounds);

                int frameDurationInMs = (int)(16.67f * frame.duration);
                writer.WriteFrame(frameImage, frameDurationInMs);
            }
        }
    }

    private void button_exportFrameGfx_Click(object sender, EventArgs e)
    {
        if (anim == null || gfxImage == null) return;

        SaveFileDialog saveGfx = new SaveFileDialog();
        saveGfx.Filter = "PNG files (*.png)|*.png";
        saveGfx.FileName = $"samus_{Hex.ToString(anim.Offset)}_frame_{SelectedFrameIndex}.png";
        if (saveGfx.ShowDialog() != DialogResult.OK) return;

        // The graphics view is a 4bpp image with the palette row it is displayed with
        gfxImage.Save(saveGfx.FileName, ImageFormat.Png);
    }

    private void button_importFrameGfx_Click(object sender, EventArgs e)
    {
        if (anim == null || PlayingAnimation) return;

        OpenFileDialog openGfx = new OpenFileDialog();
        openGfx.Filter = "Image files (*.png;*.bmp;*.gif)|*.png;*.bmp;*.gif";
        if (openGfx.ShowDialog() != DialogResult.OK) return;

        int width = SamusAnimation.VramRowTiles * 8;
        int height = SamusAnimation.VramRows * 8;

        int[,] indices;
        try
        {
            using Bitmap image = new Bitmap(openGfx.FileName);
            if (image.Width != width || image.Height != height)
            {
                MessageBox.Show($"The image has to be {width}x{height} pixels, like the exported frame graphics.",
                    "Invalid Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            indices = GetPaletteIndices(image);
        }
        catch (Exception ex)
        {
            MessageBox.Show("The image could not be loaded.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Only tiles that are used by the frame's graphics are imported
        FinishStroke();
        FinishModifyingActionGroup();
        SamusDrawAction import = new SamusDrawAction();
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                SamusTileSource? source = vramSources[y / 8 * SamusAnimation.VramRowTiles + x / 8];
                if (source == null) continue;
                import.SetPixel(source.Value.Gfx, source.Value.Row, source.Value.Tile * 8 + x % 8, y % 8, indices[x, y]);
            }
        }

        if (import.Count > 0) AddAction(import);
        DrawFrame(SelectedFrameIndex);
    }

    /// <summary>
    /// Gets the palette index of every pixel. Indexed images keep their indices,
    /// other images use the closest color of the palette row the graphics are displayed with.
    /// </summary>
    private int[,] GetPaletteIndices(Bitmap image)
    {
        int[,] indices = new int[image.Width, image.Height];

        if (image.PixelFormat == PixelFormat.Format4bppIndexed || image.PixelFormat == PixelFormat.Format8bppIndexed)
        {
            bool fourBit = image.PixelFormat == PixelFormat.Format4bppIndexed;
            BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, image.PixelFormat);
            byte[] bytes = new byte[data.Stride * image.Height];
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
            image.UnlockBits(data);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    int value = fourBit
                        ? (bytes[y * data.Stride + x / 2] >> ((x & 1) == 0 ? 4 : 0)) & 0xF
                        : bytes[y * data.Stride + x];
                    indices[x, y] = value % 16;
                }
            }
            return indices;
        }

        Color[] colors = Enumerable.Range(0, 16).Select(c => palette.GetOpaqueColor(SelectedPaletteRow, c)).ToArray();
        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                Color pixel = image.GetPixel(x, y);
                if (pixel.A < 128)
                {
                    indices[x, y] = 0;
                    continue;
                }

                int best = 0, bestDistance = int.MaxValue;
                for (int c = 0; c < 16; c++)
                {
                    int dr = pixel.R - colors[c].R, dg = pixel.G - colors[c].G, db = pixel.B - colors[c].B;
                    int distance = dr * dr + dg * dg + db * db;
                    if (distance < bestDistance)
                    {
                        best = c;
                        bestDistance = distance;
                    }
                }
                indices[x, y] = best;
            }
        }
        return indices;
    }
    #endregion

    #region Undo / Redo
    public void AddAction(GenericEditorAction a)
    {
        UndoRedo.AddActionWithoutDo(a);
        setUndoRedoButtons();

        Status.ChangeMade();
    }

    private void UpdateActionStackFrameIndex(DropOutStack<GenericEditorAction> stack, int newIndex)
    {
        for (int i = 0; i < stack.Count; i++)
        {
            var action = stack[i];
            if (action is OamActionGroup group)
            {
                group.UpadteIndicesOfActions(newIndex);
                continue;
            }
            if (action is not OamAction a) continue;
            a.FrameIndex = newIndex;
        }
    }

    private void Undo()
    {
        FinishStroke();
        FinishModifyingActionGroup();
        UndoRedo.Undo();
        setUndoRedoButtons();
        Status.ChangeMade();
        DrawFrame(SelectedFrameIndex);
        HandleSelectedPartChanged(SelectedPartIndices);
    }

    private void Redo()
    {
        FinishStroke();
        FinishModifyingActionGroup();
        UndoRedo.Redo();
        setUndoRedoButtons();
        Status.ChangeMade();
        DrawFrame(SelectedFrameIndex);
        HandleSelectedPartChanged(SelectedPartIndices);
    }

    private void PopulateUndoRedoList(ToolStripSplitButton button, DropOutStack<GenericEditorAction> stack)
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
        if (UndoRedos.Count == 0 || SelectedFrameIndex < 0)
        {
            button_undo.Enabled = button_redo.Enabled = false;
            return;
        }
        button_undo.Enabled = UndoRedo.CanUndo && !playingAnimation;
        button_redo.Enabled = UndoRedo.CanRedo && !playingAnimation;
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
}
