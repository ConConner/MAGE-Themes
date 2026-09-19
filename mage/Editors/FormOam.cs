using mage.Actions;
using mage.Actions.OamEditor;
using mage.Bookmarks;
using mage.Controls;
using mage.Editors.NewEditors;
using mage.Properties;
using mage.Theming;
using mage.Utility;
using Parlot.Fluent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mage;

public partial class FormOam : Form
{
    // fields
    private GFX gfxObject;
    private Palette palette;
    private OAM oam;
    private Bitmap gfxImage;
    private VramObj vram;

    private GenericUndoRedo UndoRedo = new();
    private Status Status;
    private List<GenericEditorAction>? GroupedActions;

    private bool loading;
    private bool loadingPart;

    private FormMain main;
    private ByteStream romStream;

    private Timer animationTimer;

    // Drawables
    Pen partOutline = new Pen(Color.Aqua, 1);
    Pen partOutlineHovered = new Pen(Color.Orange, 1) { Alignment = PenAlignment.Inset };
    Pen partOutlineSelected = new Pen(Color.Red, 1);
    Pen CursorPen = new Pen(Color.Red, 1);
    Pen SelectionPenWhite = new Pen(Color.White, 1) { DashPattern = new float[] { 2, 3 } };
    Pen SelectionPenBlack = new Pen(Color.Black, 1) { DashPattern = new float[] { 2, 3 }, DashOffset = 2 };
    List<Drawable> partOutlines = new List<Drawable>();
    Drawable MultiPartSelection;
    Drawable gfxSelection;
    Drawable gfxCursor;
    Drawable PaletteCursor;
    Drawable PaletteSelection;

    // Data for saving
    int originalOamOffset;
    int originalNumOfFrames;

    // Context menu related
    Point ContextMenuOpenedAt = Point.Empty;

    // Moving related
    Point? PartsStartLocation = null;
    Point? MouseStartLocation = null;

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
            comboBox_Frame.Enabled = !playingAnimation;
            label_OAMFrame.Enabled = !playingAnimation;
            textBox_duration.Enabled = !playingAnimation;
            label_frameDuration.Enabled = !playingAnimation;
            button_addFrame.Enabled = !playingAnimation;
            button_removeFrame.Enabled = !playingAnimation;
            button_frameDown.Enabled = !playingAnimation;
            button_frameUp.Enabled = !playingAnimation;
            button_duplicate.Enabled = !playingAnimation;

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
            Program.Config.OamEditorViewOrigin = value;

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
            Program.Config.OamEditorViewPartOutlines = value;

            foreach (Drawable d in partOutlines) d.Visible = value;
            tileDisplay_oam.Invalidate();
        }
    }
    private bool viewPartOutline = false;

    private bool ViewPalette
    {
        get => viewPalette;
        set
        {
            viewPalette = value;
            Program.Config.OamEditorViewPalette = value;
            button_viewPalette.Checked = value;
            panel_palette.Visible = value;
        }
    }
    private bool viewPalette = true;

    private bool ViewVram
    {
        get => viewVram;
        set
        {
            viewVram = value;
            Program.Config.OamEditorViewVram = value;
            button_viewVram.Checked = value;

            DrawImage();
        }
    }
    private bool viewVram = false;

    private bool LoadCommonGraphics
    {
        get => loadCommonGraphics;
        set
        {
            bool old = loadCommonGraphics == value;
            loadCommonGraphics = value;
            Program.Config.OamEditorLoadCommonGraphics = value;
            button_loadCommonGraphics.Checked = value;

            if (!loading)
            {
                DrawNewGFX();
                LoadPalette(0);
            }

            if (old) return;
            SelectedPaletteRow = Math.Clamp(SelectedPaletteRow + (value == true ? 8 : -8), 0, 15);

        }
    }
    private bool loadCommonGraphics = true;

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
            SetPartOutlines(SelectedFrame);
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
        SetPartOutlines(SelectedFrame);

        button_removePart.Enabled = SelectedPartIndices.Count > 0;
        panel_partEditing.Enabled = SelectedPartIndices.Count > 0;
        HandleSelectedPartChanged(SelectedPartIndices);
    }

    private Point? MultiSelectPivot { get; set; } = null;
    private Point? OldMultiSelectPosition { get; set; } = null;

    private int SelectedPaletteRow
    {
        get => selectedPaletteRow;
        set
        {
            selectedPaletteRow = value;
            if (value == -1)
            {
                PaletteSelection.Visible = false;
                return;
            }

            PaletteSelection.Visible = true;
            PaletteSelection.Rectangle = new Rectangle(0, value * 17, 16 * 16 + 17, 17);
            if (!loading)
            {
                DrawImage();
            }
        }
    }
    private int selectedPaletteRow = 8;

    private int SelectedFrameIndex => comboBox_Frame.SelectedIndex;
    private OAM.Frame SelectedFrame => oam.Frames[comboBox_Frame.SelectedIndex];


    // constructor
    public FormOam(FormMain main, int gfxOffset, int palOffset, int oamOffset, bool compressed = true)
    {
        InitializeComponent();

        //Theming
        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        this.main = main;
        this.romStream = ROM.Stream;
        this.palette = new Palette(romStream, palOffset, 1);

        // Load Settings
        ViewOrigin = Program.Config.OamEditorViewOrigin;
        ViewPartOutline = Program.Config.OamEditorViewPartOutlines;
        ViewPalette = Program.Config.OamEditorViewPalette;
        UpdateGfxZoom(Program.Config.OamEditorGfxZoom);
        UpdateOamZoom(Program.Config.OamEditorOamZoom);

        loading = true;

        textBox_imageOffset.Text = Hex.ToString(gfxOffset);
        textBox_palOffset.Text = Hex.ToString(palOffset);
        textBox_oamOffset.Text = Hex.ToString(oamOffset);
        checkBox_compressed.Checked = compressed;

        //Event based
        textBox_duration.TextChanged += textBox_duration_TextChanged;
        textBox_tile.TextChanged += controlElements_changeMade;
        textBox_x.TextChanged += controlElements_changeMade;
        textBox_y.TextChanged += controlElements_changeMade;

        animationTimer = new Timer();
        animationTimer.Tick += AnimationTimer_Tick;

        //Creating Drawables
        MultiPartSelection = new Drawable(Rectangle.Empty, SelectionPenWhite) { Visible = false };
        MultiPartSelection.DrawPens.Add(SelectionPenBlack);
        gfxSelection = new Drawable(Rectangle.Empty, SelectionPenWhite, 1) { Visible = false };
        gfxSelection.DrawPens.Add(SelectionPenBlack);
        gfxCursor = new Drawable(Rectangle.Empty, CursorPen, 1) { Visible = false };
        gfxView_gfx.AddDrawable(gfxSelection);
        gfxView_gfx.AddDrawable(gfxCursor);

        //Palette Drawables
        PaletteCursor = new Drawable(Rectangle.Empty, CursorPen, 1) { Visible = true };
        PaletteSelection = new Drawable(Rectangle.Empty, SelectionPenWhite, 1) { Visible = true };
        PaletteSelection.DrawPens.Add(SelectionPenBlack);
        paletteView.AddDrawable(PaletteCursor);
        paletteView.AddDrawable(PaletteSelection);

        LoadCommonGraphics = true; // We don't want to draw/reload graphics during initalization so this must come after `loading = true`

        Status = new Status(label_Status, button_save);

        loading = false;
        DrawNewGFX();
        LoadPalette(0);
        DrawPalette();
        SetOAM();
    }


    #region general
    private void ChangePen(Drawable drawable, Pen pen)
    {
        drawable.DrawPens.Clear();
        drawable.DrawPens.Add(pen);
    }

    private void Save()
    {
        if (oam == null)
        {
            MessageBox.Show("No OAM data to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Get the original frame pointers to find the old frame data
        List<int> originalFramePointers = new List<int>();
        for (int i = 0; i < originalNumOfFrames; i++)
        {
            originalFramePointers.Add(ROM.Stream.ReadPtr(originalOamOffset + 8 * i));
        }

        ByteStream BuildFrameData(OAM.Frame frame)
        {
            ByteStream frameData = new ByteStream();
            frameData.Write16((ushort)frame.numParts);
            foreach (OAM.Part part in frame.parts)
            {
                ushort[] partData = part.GetAttributes();
                frameData.Write16(partData[0]); // Attr0
                frameData.Write16(partData[1]); // Attr1
                frameData.Write16(partData[2]); // Attr2
            }
            return frameData;
        }

        /// STEP 0: Mark unused frame lists as freespace
        for (int i = oam.NumFrames; i < originalNumOfFrames; i++)
        {
            int unusedFramePtr = originalFramePointers[i];
            int unusedNumOfParts = ROM.Stream.Read16(unusedFramePtr);
            int unusedLength = 2 + unusedNumOfParts * 6;

            ROM.Stream.MarkFreeSpace(unusedFramePtr, unusedLength, 0);
        }
        if (oam.NumFrames < originalNumOfFrames) originalNumOfFrames = oam.NumFrames;

        /// STEP 1: SAVE FRAME DATA
        // Overlapping/old frame data
        List<int> newFramePointers = new List<int>();
        for (int i = 0; i < originalNumOfFrames; i++)
        {
            OAM.Frame frame = oam.Frames[i];
            int offset = originalFramePointers[i];
            int originalNumOfParts = ROM.Stream.Read16(offset);

            //Calculate length of old data
            int oldLength = 2 + originalNumOfParts * 6; // 2 for numParts, 6 for each part (3x16 bits)

            // Build frame data up
            ByteStream frameData = BuildFrameData(frame);

            //Write data to the ROM
            ROM.Stream.Write2(frameData, oldLength, ref offset, false);
            newFramePointers.Add(offset);
        }

        // New frame data
        for (int i = originalNumOfFrames; i < oam.NumFrames; i++)
        {
            OAM.Frame frame = oam.Frames[i];
            ByteStream frameData = BuildFrameData(frame);
            int writtenTo = ROM.Stream.WriteNewData(frameData);

            newFramePointers.Add(writtenTo);
        }

        /// STEP 3: SAVE FRAME POINTERS / FRAME LIST
        int oldPointerLength = originalNumOfFrames * 8 + 8;
        ByteStream framePointerData = new ByteStream();
        for (int i = 0; i < oam.NumFrames; i++)
        {
            framePointerData.WritePtr(newFramePointers[i]);
            framePointerData.Write32(oam.Frames[i].duration);
        }
        framePointerData.Write32(0);
        framePointerData.Write32(0); // 8 empty bytes to end the frame list
        int writeOffset = originalOamOffset;
        ROM.Stream.Write2(framePointerData, oldPointerLength, ref writeOffset, true);

        // Display message with the new offset
        if (writeOffset != originalOamOffset)
        {
            if (
                MessageBox.Show(
                    "OAM data needs to be repointed.\n\nDo you want to save the new location as a Bookmark?",
                    "Repointing required", MessageBoxButtons.YesNo, MessageBoxIcon.Information
                )
                != DialogResult.Yes
                || !BookmarkManager.RepointedDataCreateBookmark(originalOamOffset, writeOffset)
            )
            {
                MessageBox.Show($"OAM data was repointed to: {Hex.ToString(writeOffset)}", "Repointed OAM",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Version.RepointedOAM(originalOamOffset, writeOffset);
            textBox_oamOffset.Text = Hex.ToString(writeOffset);
            SetOAM();
        }

        Status.Save();
    }

    private bool CheckUnsaved()
    {
        DialogResult result = MessageBox.Show("Do you want to save changes to the OAM?",
            "Unsaved Changes", MessageBoxButtons.YesNoCancel);
        if (result == DialogResult.Cancel) return false;
        if (result == DialogResult.Yes) Save();
        return true;
    }

    private void KeyPressed(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.H:
            case Keys.X:
                if (SelectedPartIndex == -1) break;
                checkBox_xFlip.Checked = !checkBox_xFlip.Checked;
                break;

            case Keys.V:
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

            default:
                break;
        }
    }

    private void button_save_Click(object sender, EventArgs e) => Save();

    private void FormOam_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!Status.UnsavedChanges) return;
        if (!CheckUnsaved()) e.Cancel = true;
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
    private void DrawNewGFX()
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
            return;
        }
        int width = 32;

        if (checkBox_compressed.Checked)
        {
            try
            {
                int len = romStream.Read32(offset) >> 8;
                if (romStream.Read8(offset) != 0x10 || len == 0)
                {
                    throw new FormatException();
                }
                gfxObject = new GFX(romStream, offset, width);
                if (gfxObject.origLen == 0)
                {
                    throw new FormatException();
                }
            }
            catch
            {
                MessageBox.Show("There are no compressed graphics at the given offset.",
                    "Compressed graphics error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        else
        {
            int height = 16;
            gfxObject = new GFX(romStream, offset, width, height);
        }

        CreateVram(button_loadCommonGraphics.Checked);
        DrawFrame(comboBox_Frame.SelectedIndex);
        DrawImage();
        UpdateGfxZoom(gfxView_gfx.Zoom);
    }

    private void DrawImage()
    {
        if (!ViewVram && LoadCommonGraphics) gfxImage = gfxObject.Draw4bpp(vram.palette, SelectedPaletteRow, true);
        else if (!ViewVram && !LoadCommonGraphics) gfxImage = gfxObject.Draw4bpp(vram.palette, SelectedPaletteRow, true);
        else if (ViewVram && !LoadCommonGraphics) gfxImage = gfxObject.Draw4bpp(vram.palette, SelectedPaletteRow, true); // A weird edge-case where this condition would render a blank Vram Viewer
        else gfxImage = vram.VramGFX.Draw15bpp(vram.palette, SelectedPaletteRow, true);
        gfxView_gfx.TileImage = gfxImage;
    }

    private void UpdateGfxZoom(int zoom)
    {
        zoom = Math.Clamp(zoom, 0, 4);
        gfxView_gfx.Zoom = zoom;
        Program.Config.OamEditorGfxZoom = zoom;
        button_gfxZoomIn.Enabled = zoom < maxZoom;
        button_gfxZoomOut.Enabled = zoom > 0;
        label_gfxZoom.Text = $"{1 << zoom}00%";
    }

    private void button_viewPalette_Click(object sender, EventArgs e) => ViewPalette = !button_viewPalette.Checked;
    private void button_viewVram_Click(object sender, EventArgs e) => ViewVram = !button_viewVram.Checked;
    private void button_loadCommonGraphics_Click(object sender, EventArgs e) => LoadCommonGraphics = !button_loadCommonGraphics.Checked;


    private void checkBox_compressed_CheckedChanged(object sender, EventArgs e)
    {
        if (!loading)
        {
            LoadPalette(0);
            DrawNewGFX();
        }
    }

    private void gfxView_gfx_MouseMove(object sender, TileDisplay.TileDisplayArgs e)
    {
        int offset = ViewVram ? 0 : 16;
        if (!ViewVram)
        {
            if (LoadCommonGraphics) offset = 16;
            else offset = 0;
        }
        int tileNum = e.TileIndexPosition.X + (e.TileIndexPosition.Y + offset) * 32;
        statusLabel_coor.Text = Hex.ToString(tileNum);

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
        int offset = ViewVram ? 0 : 16;
        if (!ViewVram)
        {
            if (LoadCommonGraphics) offset = 16;
            else offset = 0;
        }
        int tileNum = e.TileIndexPosition.X + (e.TileIndexPosition.Y + offset) * 32;

        if (SelectedPartIndex == -1) return;
        textBox_tile.Text = Hex.ToString(tileNum);
    }
    #endregion

    #region PAL
    private void DrawPalette()
    {
        CreateVram(button_loadCommonGraphics.Checked);
        paletteView.TileImage = vram.palette.Draw(16, 0, 16, 0);
        DrawFrame(comboBox_Frame.SelectedIndex);
    }

    private void LoadPalette(int diff)
    {
        try
        {
            int offset = Hex.ToInt(textBox_palOffset.Text);
            if (diff != 0)
            {
                offset += diff;
                textBox_palOffset.Text = Hex.ToString(offset);
            }

            int count = !checkBox_compressed.Checked ? 8 : (gfxObject.height / 2);

            palette = new Palette(romStream, offset, count);
            CreateVram(button_loadCommonGraphics.Checked);
            DrawImage();
            DrawPalette();
        }
        catch (Exception ex)
        {
            MessageBox.Show("The offset entered was not valid.\n\n" + ex.GetType().ToString() + '\n'
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void button_increasePalette_Click(object sender, EventArgs e) => LoadPalette(32);
    private void button_decreasePalette_Click(object sender, EventArgs e) => LoadPalette(-32);

    private void button_editPal_Click(object sender, EventArgs e)
    {
        try
        {
            int offset = Hex.ToInt(textBox_palOffset.Text);

            FormPaletteNew.OpenPaletteEditor(offset, 1);
        }
        catch (Exception ex)
        {
            MessageBox.Show("The offset entered was not valid.\n\n" + ex.GetType().ToString() + '\n'
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void paletteView_TileMouseMove(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        if (PaletteCursor.Y == e.TilePixelPosition.Y) return;
        PaletteCursor.Visible = true;
        PaletteCursor.Rectangle = new Rectangle(0, Math.Min(e.TilePixelPosition.Y, 17 * 15), 16 * 16 + 17, 17);

    }

    private void paletteView_TileMouseDown(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        PaletteCursor.Visible = false;
        SelectedPaletteRow = e.TilePixelPosition.Y / 17;
    }

    #endregion

    #region OAM
    private void UpdateOamZoom(int zoom)
    {
        zoom = Math.Clamp(zoom, 0, 4);
        if (zoom == tileDisplay_oam.Zoom) return;

        tileDisplay_oam.Zoom = zoom;
        Program.Config.OamEditorOamZoom = zoom;
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

        // Center view
        int centerX = (panel_oam.DisplayRectangle.Width - panel_oam.ClientSize.Width) / 2;
        int centerY = (panel_oam.DisplayRectangle.Height - panel_oam.ClientSize.Height) / 2;

        panel_oam.AutoScrollPosition = new Point(centerX, centerY);
    }

    private void button_go_Click(object sender, EventArgs e)
    {
        if (Status.UnsavedChanges && !CheckUnsaved())
        {
            return;
        }

        UndoRedo = new();
        Status.LoadNew();
        DrawNewGFX();
        LoadPalette(0);
        SetOAM();
    }

    private void SetOAM()
    {
        PlayingAnimation = false;
        try
        {
            int offset = Hex.ToInt(textBox_oamOffset.Text);
            oam = new OAM(offset);

            originalOamOffset = offset;
            originalNumOfFrames = oam.NumFrames;

            //Populate frame selection
            SetFrameSelectionCombobox();
            comboBox_Frame.SelectedIndex = 0;
        }
        catch
        {
            MessageBox.Show("No valid OAM found.", "Invalid OAM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            oam = null;
        }
    }

    private void CreateVram(bool loadCommonGraphics)
    {
        vram = new VramObj(gfxObject, palette, loadCommonGraphics);
    }

    private void DrawFrame(int frameNumber)
    {
        if (oam == null || vram == null) return;
        Bitmap frame = oam.DrawReal(vram.objTiles, vram.palette, 0, frameNumber);
        tileDisplay_oam.TileImage = frame;

        // Display Part boxes
        SetPartOutlines(SelectedFrame);
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
        OAM.Frame f = oam.Frames[frame];
        int timeInMs = (int)(16.67f * f.duration);
        animationTimer.Interval = Math.Max(1, timeInMs);
    }

    private void SetFrameSelectionCombobox()
    {
        int old = SelectedFrameIndex;

        comboBox_Frame.Items.Clear();
        for (int i = 0; i < oam.NumFrames; i++) comboBox_Frame.Items.Add(i);
        if (old >= 0 && old < comboBox_Frame.Items.Count) comboBox_Frame.SelectedIndex = old;
        else comboBox_Frame.SelectedIndex = oam.NumFrames - 1;
    }

    private void SetPartSelectionCombobox()
    {
        int old = SelectedPartIndex;

        comboBox_part.Items.Clear();
        for (int i = 0; i < oam.Frames[comboBox_Frame.SelectedIndex].parts.Count; i++) comboBox_part.Items.Add(Hex.ToString(i));
        if (old >= 0 && old < comboBox_part.Items.Count) comboBox_part.SelectedIndex = old;
    }

    private void comboBox_Frame_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (loading) return;
        DrawFrame(comboBox_Frame.SelectedIndex);
        loading = true;
        textBox_duration.Text = Hex.ToString(oam.Frames[comboBox_Frame.SelectedIndex].duration);
        loading = false;
        SelectedPartIndex = -1;

        // Enable/disable move buttons
        if (!playingAnimation)
        {
            button_frameDown.Enabled = oam.Frames.Count > 1 && SelectedFrameIndex != oam.Frames.Count - 1;
            button_frameUp.Enabled = oam.Frames.Count > 1 && SelectedFrameIndex != 0;
        }

        //if (playingAnimation) return;
        SetPartSelectionCombobox();
    }

    private void button_playAnimation_Click(object sender, EventArgs e)
    {
        PlayingAnimation = !PlayingAnimation;
        if (!PlayingAnimation) return;

        SetTimerInterval(comboBox_Frame.SelectedIndex);
        animationTimer.Start();
    }

    private void AnimationTimer_Tick(object? sender, EventArgs e)
    {
        comboBox_Frame.SelectedIndex = (comboBox_Frame.SelectedIndex + 1) % oam.NumFrames;
        SetTimerInterval(comboBox_Frame.SelectedIndex);
    }

    private void button_viewOrigin_Click(object sender, EventArgs e) => ViewOrigin = !button_viewOrigin.Checked;

    private void button_viewOutline_Click(object sender, EventArgs e) => ViewPartOutline = !button_viewOutline.Checked;


    #region FRAME EDITING
    private void button_addFrame_Click(object sender, EventArgs e)
    {
        oam.Frames.Add(OAM.Frame.Empty);
        oam.NumFrames++;
        SetFrameSelectionCombobox();
        comboBox_Frame.SelectedIndex = oam.NumFrames - 1;
        Status.ChangeMade();
    }
    private void button_duplicate_Click(object sender, EventArgs e)
    {
        // Create copy of frame
        OAM.Frame copy = OAM.Frame.Empty;
        copy.duration = SelectedFrame.duration;
        copy.numParts = SelectedFrame.numParts;
        foreach (OAM.Part part in SelectedFrame.parts) copy.parts.Add(part);

        oam.Frames.Add(copy);
        oam.NumFrames++;
        SetFrameSelectionCombobox();
        comboBox_Frame.SelectedIndex = oam.NumFrames - 1;
        Status.ChangeMade();
    }
    private void button_removeFrame_Click(object sender, EventArgs e)
    {
        if (SelectedFrameIndex == -1) return;
        if (oam.NumFrames <= 1)
        {
            MessageBox.Show("Cannot remove the last frame.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        oam.Frames.RemoveAt(SelectedFrameIndex);
        oam.NumFrames--;
        SetFrameSelectionCombobox();
        Status.ChangeMade();
    }

    private void textBox_duration_TextChanged(object? sender, EventArgs e)
    {
        if (loading || SelectedFrameIndex == -1) return;

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
            oam.Frames[SelectedFrameIndex] = frame;
            Status.ChangeMade();
        }
        catch { }
    }

    private void button_frameUp_Click(object sender, EventArgs e)
    {
        if (SelectedFrameIndex <= 0) return;
        // Swap frames
        OAM.Frame temp = oam.Frames[SelectedFrameIndex];
        oam.Frames[SelectedFrameIndex] = oam.Frames[SelectedFrameIndex - 1];
        oam.Frames[SelectedFrameIndex - 1] = temp;
        // Update selection
        comboBox_Frame.SelectedIndex--;
        Status.ChangeMade();
    }
    private void button_frameDown_Click(object sender, EventArgs e)
    {
        if (SelectedFrameIndex >= oam.NumFrames - 1) return;
        // Swap frames
        OAM.Frame temp = oam.Frames[SelectedFrameIndex];
        oam.Frames[SelectedFrameIndex] = oam.Frames[SelectedFrameIndex + 1];
        oam.Frames[SelectedFrameIndex + 1] = temp;
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

    private bool CheckPartHovered(OAM.Part part, int pixelX, int pixelY)
    {
        Point position = new Point(
            pixelX - OAM.FrameOriginX,
            pixelY - OAM.FrameOriginY
        );
        return part.Area.Contains(position);
    }

    #region Reordering Parts
    private void ReorderPart(int oldIndex, int newIndex)
    {
        if (oldIndex < 0 || oldIndex >= SelectedFrame.parts.Count || newIndex < 0 || newIndex >= SelectedFrame.parts.Count)
            return;

        OAM.Part temp = SelectedFrame.parts[oldIndex];
        SelectedFrame.parts.RemoveAt(oldIndex);
        if (newIndex == SelectedFrame.parts.Count)
            SelectedFrame.parts.Add(temp);
        else
            SelectedFrame.parts.Insert(newIndex, temp);

        SelectedPartIndex = newIndex;

        DrawFrame(SelectedFrameIndex);
        Status.ChangeMade();
    }

    private void contextMenu_oam_Opening(object sender, CancelEventArgs e)
    {
        if (SelectedPartIndex == -1)
        {
            contextMenu_oam.Close();
            return;
        }

        // Enable/disable context menu items based on selected part
        int parts = SelectedFrame.parts.Count;
        button_toFront.Enabled = SelectedPartIndex != 0;
        button_toBack.Enabled = SelectedPartIndex != parts - 1;
        button_layerDown.Enabled = SelectedPartIndex != parts - 1 && parts > 1;
        button_layerUp.Enabled = SelectedPartIndex != 0 && parts > 1;
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
        if (SelectedFrame.parts.Count == 0xFF)
        {
            MessageBox.Show("Cannot add more parts to this frame, maximum reached (0xFF).", "Maximum Parts Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        OAM.Frame newFrame = SelectedFrame;

        OAM.Part p = OAM.Part.Empty;
        p.tileNum = 0x200;
        p.palRow = 0x8;
        p.xPos = x;
        p.yPos = y;

        newFrame.parts.Insert(0, p);
        newFrame.numParts++;

        oam.Frames[SelectedFrameIndex] = newFrame;
        SetPartSelectionCombobox();
        DrawFrame(SelectedFrameIndex);
        SelectedPartIndex = 0;
        Status.ChangeMade();
    }

    private void button_removePart_Click(object sender, EventArgs e)
    {
        if (SelectedPartIndex == -1) return;
        OAM.Frame newFrame = SelectedFrame;
        newFrame.parts.RemoveAt(SelectedPartIndex);
        newFrame.numParts--;
        oam.Frames[SelectedFrameIndex] = newFrame;
        SetPartSelectionCombobox();
        DrawFrame(SelectedFrameIndex);
        SelectedPartIndex = -1;
        Status.ChangeMade();
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
        int subtract = ViewVram ? 0 : 16;
        Point gfxPosition = new(part.tileNum % 32 * gfxView_gfx.TileSize, (part.tileNum / 32 - subtract) * gfxView_gfx.TileSize);
        gfxSelection.Rectangle = new Rectangle(gfxPosition, part.Dimensions);
        gfxSelection.Visible = true;
    }

    private void HandleSelectedPartChanged(List<int> partIndices)
    {
        if (partIndices.Count <= 0)
        {
            loadingPart = false;
            ResetPartData();
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

    private Point PointToSignedPosition(Point pos) => new Point(
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

        ModifyOamPartAction a = new(SelectedFrame, SelectedPartIndex, part);
        a.Do();
        AddActionToGroup(a);

        HighlightPartInGfx(part);
    }

    private void ModifyMultiPart(Point position, int palRow)
    {
        Point oldPos = GetMultiPartArea().Location;
        Point diff = new(position.X - oldPos.X, position.Y - oldPos.Y);

        GenericEditorActionGroup multiModifyAction = new();

        foreach (int index in SelectedPartIndices)
        {
            OAM.Part p = SelectedFrame.parts[index];
            p.xPos += diff.X;
            p.yPos += diff.Y;
            if (palRow != -1) p.palRow = palRow;

            ModifyOamPartAction a = new(SelectedFrame, index, p);
            multiModifyAction.AddAction(a);
        }

        multiModifyAction.Do();
        AddActionToGroup(multiModifyAction);
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
        catch (Exception exc) { }
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
        if (hoveringSelection) Cursor = Cursors.SizeAll;
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

    private bool ButtonDown(TileDisplay.TileDisplayArgs e)
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
        if (GroupedActions is null || GroupedActions.Count < 1) return;

        if (GroupedActions.Count == 1)
        {
            AddAction(GroupedActions[0]);
            GroupedActions = null;
            return;
        }

        GenericEditorActionGroup group = new();
        group.AddAction(GroupedActions[0]);
        group.AddAction(GroupedActions[GroupedActions.Count - 1]);
        AddAction(group);
        GroupedActions = null;
    }

    private void oamView_oam_TileMouseDown(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        if (oam == null) return;
        if (!ButtonDown(e)) return;
        if (PlayingAnimation) return;

        // General Part selection code
        int hoveredPart = FindPart(SelectedFrame, e.PixelPosition.X, e.PixelPosition.Y);
        bool hoveringOverSelection = HoveringOverSelection(e.PixelPosition);

        SetOamCursor(hoveredPart, hoveringOverSelection);

        // Deselect old selection if not hovering over anything and start multi-select
        if (hoveredPart == -1)
        {
            SelectedPartIndex = -1;
            MultiSelectPivot = e.PixelPosition;
            return;
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
            if (SelectedPartIndex != -1) tileDisplay_oam.ContextMenuStrip = contextMenu_oam;
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

        // Multi Select
        if (MultiSelectPivot is not null && ButtonDown(e))
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

        StartModifyingActionGroup();
        if (MouseStartLocation is null || PartsStartLocation is null || e.Button != MouseButtons.Left) return;
        Point diff = new Point(
            e.PixelPosition.X - MouseStartLocation.Value.X,
            e.PixelPosition.Y - MouseStartLocation.Value.Y
        );
        Point newPartLocation = new Point(
            Math.Clamp(PartsStartLocation.Value.X + diff.X, -256, 255),
            Math.Clamp(PartsStartLocation.Value.Y + diff.Y, -128, 127)
        );
        textBox_x.Text = Hex.ToString(newPartLocation.X < 0 ? newPartLocation.X + 512 : newPartLocation.X);
        textBox_y.Text = Hex.ToString(newPartLocation.Y < 0 ? newPartLocation.Y + 256 : newPartLocation.Y);
    }

    private void oamView_oam_TileMouseUp(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
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
        SaveFileDialog saveAnimation = new SaveFileDialog();
        saveAnimation.Filter = "GIF files (*.gif)|*.gif";
        if (saveAnimation.ShowDialog() != DialogResult.OK) return;
        if (oam == null)
        {
            MessageBox.Show("No OAM loaded", "OAM Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        if (vram == null)
        {
            MessageBox.Show("No VRAM loaded", "VRAM Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        Rectangle oamBounds = oam.Bounds;
        oamBounds.X += OAM.FrameOriginX;
        oamBounds.Y += OAM.FrameOriginY;

        using (GifWriter writer = new GifWriter(saveAnimation.FileName, 500, 0))
        {
            for (int i = 0; i < oam.NumFrames; i++)
            {
                OAM.Frame frame = oam.Frames[i];

                Bitmap frameImage = oam.DrawReal(vram.objTiles, vram.palette, 0, i);
                frameImage = frameImage.Crop(oamBounds);

                int frameDurationInMs = (int)(16.67f * frame.duration);
                writer.WriteFrame(frameImage, frameDurationInMs);
            }
        }
    }

    private void button_exportOam_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveOAM = new SaveFileDialog();
        saveOAM.Filter = "MAGE OAM files (*.mgo)|*.mgo";
        if (saveOAM.ShowDialog() != DialogResult.OK) return;
        if (oam == null)
        {
            MessageBox.Show("No OAM loaded", "OAM Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        File.WriteAllText(saveOAM.FileName, OamSerializer.Serialize(oam));
    }

    private void button_exportAssembly_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveASM = new SaveFileDialog();
        saveASM.Filter = "Assembly files (*.asm)|*.asm";
        if (saveASM.ShowDialog() != DialogResult.OK) return;
        if (oam == null)
        {
            MessageBox.Show("No OAM loaded", "OAM Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        string animationName = Path.GetFileName(saveASM.FileName);
        animationName = Path.GetFileNameWithoutExtension(animationName);
        File.WriteAllText(saveASM.FileName, OamSerializer.ToASM(oam, animationName));
    }

    void button_importOam_Click(object sender, EventArgs e)
    {
        OpenFileDialog openOAM = new OpenFileDialog();
        openOAM.Filter = "MAGE OAM files (*.mgo)|*.mgo";
        if (openOAM.ShowDialog() != DialogResult.OK) return;
        if (oam == null)
        {
            MessageBox.Show("No OAM loaded. Please load the OAM that you want to replace.", "OAM Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        string json = File.ReadAllText(openOAM.FileName);
        OAM? imported = OamSerializer.Deserialize(json);
        if (imported == null) return;

        oam = imported;
        Save();
        SetOAM();
        UndoRedo = new();
    }

    private void button_importAssembly_Click(object sender, EventArgs e)
    {
        OpenFileDialog openASM = new OpenFileDialog();
        openASM.Filter = "Assembly files (*.asm)|*.asm";
        if (openASM.ShowDialog() != DialogResult.OK) return;
        if (oam == null)
        {
            MessageBox.Show("No OAM loaded. Please load the OAM that you want to replace.", "OAM Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        string assembly = File.ReadAllText(openASM.FileName);
        OAM? imported = OamSerializer.FromASM(assembly);
        if (imported == null) return;

        oam = imported;
        Save();
        SetOAM();
        UndoRedo = new();
    }

    #endregion
    #region Undo / Redo
    public void AddAction(GenericEditorAction a)
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
}
