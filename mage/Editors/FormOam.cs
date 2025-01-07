using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage;

public partial class FormOam : Form
{
    // fields
    private GFX gfxObject;
    private Palette palette;
    private OAM oam;
    private Bitmap gfxImage;
    private VramObj vram;

    private bool loading;
    private int gfxZoom;
    private int oamZoom;

    private FormMain main;
    private ByteStream romStream;

    private Bitmap oamImage
    {
        get => (Bitmap)gfxView_oam.BackgroundImage;
        set
        {
            if (oamImage != null) oamImage.Dispose();
            gfxView_oam.BackgroundImage = value;
            updateOamZoom();
        }
    }

    // constructor
    public FormOam(FormMain main, int gfxOffset, int width, int height, int palOffset, int oamOffset)
    {
        InitializeComponent();

        //Theming
        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        this.main = main;
        this.romStream = ROM.Stream;
        this.palette = new Palette(romStream, palOffset, 1);
        gfxZoom = 0;
        oamZoom = 3;

        loading = true;

        textBox_imageOffset.Text = Hex.ToString(gfxOffset);
        textBox_palOffset.Text = Hex.ToString(palOffset);
        textBox_oamOffset.Text = Hex.ToString(oamOffset);
        if (height == 0) { checkBox_compressed.Checked = true; }
        else
        {
            numericUpDown_width.Value = width;
            numericUpDown_height.Value = height;
        }

        loading = false;
        DrawNewGFX();
        DrawPalette();
        SetOAM();
    }

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
        int width = (int)numericUpDown_width.Value;

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
            int height = (int)numericUpDown_height.Value;
            gfxObject = new GFX(romStream, offset, width, height);
        }

        CreateVram();
        DrawFrame(comboBox_Frame.SelectedIndex);
        DrawImage();
        UpdateZoom();

        statusLabel_changes.Text = "";
    }

    private void DrawImage()
    {
        gfxImage = gfxObject.Draw4bpp(palette, 0, true);
        gfxView_gfx.BackgroundImage = gfxImage;
        statusLabel_size.Text = gfxImage.Width + " x " + gfxImage.Height;
    }

    private void UpdateZoom()
    {
        gfxView_gfx.Size = new Size(gfxImage.Width << gfxZoom, gfxImage.Height << gfxZoom);
    }

    private void button_imageGo_Click(object sender, EventArgs e)
    {
        DrawNewGFX();
    }

    private void numericUpDown_width_ValueChanged(object sender, EventArgs e)
    {
        if (!loading) { DrawNewGFX(); }
    }

    private void numericUpDown_height_ValueChanged(object sender, EventArgs e)
    {
        if (!loading) { DrawNewGFX(); }
    }

    private void checkBox_compressed_CheckedChanged(object sender, EventArgs e)
    {
        numericUpDown_height.Enabled = !checkBox_compressed.Checked;
        if (!loading) { DrawNewGFX(); }
    }
    #endregion

    #region PAL
    private void DrawPalette()
    {
        pictureBox_palette.Image = palette.Draw(16, 0, 1);

        CreateVram();
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

            palette = new Palette(romStream, offset, 1);
            DrawImage();
            DrawPalette();
        }
        catch (Exception ex)
        {
            MessageBox.Show("The offset entered was not valid.\n\n" + ex.GetType().ToString() + '\n'
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void button_paletteGo_Click(object sender, EventArgs e)
    {
        LoadPalette(0);
    }

    private void button_plus_Click(object sender, EventArgs e)
    {
        LoadPalette(32);
    }

    private void button_minus_Click(object sender, EventArgs e)
    {
        LoadPalette(-32);
    }

    private void button_editPal_Click(object sender, EventArgs e)
    {
        try
        {
            int offset = Hex.ToInt(textBox_palOffset.Text);

            FormPalette form = new FormPalette(main, offset, 1);
            form.Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show("The offset entered was not valid.\n\n" + ex.GetType().ToString() + '\n'
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void gfxView_gfx_MouseMove(object sender, MouseEventArgs e)
    {
        statusLabel_coor.Text = "(" + (e.X >> gfxZoom) + ", " + (e.Y >> gfxZoom) + ")";
    }
    #endregion

    #region OAM
    private void button_oamGo_Click(object sender, EventArgs e)
    {
        SetOAM();
    }

    private void CreateVram()
    {
        vram = new VramObj(gfxObject, palette);
    }

    private void SetOAM()
    { 
        int offset = Hex.ToInt(textBox_oamOffset.Text);
        oam = new OAM(offset);

        comboBox_Frame.Items.Clear();
        for (int i = 0; i < oam.numFrames; i++)
        {
            comboBox_Frame.Items.Add(i);
        }
        comboBox_Frame.SelectedIndex = 0;
    }

    private void DrawFrame(int frameNumber)
    {
        if (oam == null || vram == null) return;
        Bitmap frame = oam.Draw(vram.objTiles, vram.palette, 0, frameNumber);
        oamImage = frame;
    }

    private void comboBox_Frame_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (loading) return;
        DrawFrame(comboBox_Frame.SelectedIndex);
    }

    private void updateOamZoom()
    {
        gfxView_oam.Size = new Size(oamImage.Width << oamZoom, oamImage.Height << oamZoom);
    }
    #endregion

    #region IMPORT / EXPORT
    private void ImportImage()
    {
        loading = true;

        DrawImage();
        UpdateZoom();
        int prevOffset = gfxObject.Offset;
        gfxObject.Write(romStream, false);
        textBox_imageOffset.Text = Hex.ToString(gfxObject.Offset);
        numericUpDown_height.Value = Math.Min(gfxObject.height, 32);

        FormMain.UpdateEditors();
        statusLabel_changes.Text = "Changes saved";
        loading = false;

        if (prevOffset != gfxObject.Offset)
        {
            string message = "Graphics were repointed to " + Hex.ToString(gfxObject.Offset);
            MessageBox.Show(message, "Repointed Graphics", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void menuItem_gfxImportRaw_Click(object sender, EventArgs e)
    {
        OpenFileDialog openRaw = new OpenFileDialog();
        openRaw.Filter = "GFX files (*.gfx)|*.gfx|All files (*.*)|*.*";
        if (openRaw.ShowDialog() == DialogResult.OK)
        {
            byte[] data = File.ReadAllBytes(openRaw.FileName);

            gfxObject = new GFX(gfxObject, data);
            ImportImage();
        }
    }

    private void menuItem_gfxImportImg_Click(object sender, EventArgs e)
    {
        OpenFileDialog openImg = new OpenFileDialog();
        openImg.Filter = "Bitmaps (*.png, *.bmp, *.gif, *.jpeg, *.jpg, *.tif, *.tiff)|*.png;*.bmp;*.gif;*.jpeg;*.jpg;*.tif;*.tiff";
        if (openImg.ShowDialog() == DialogResult.OK)
        {
            Bitmap inputImg = new Bitmap(openImg.FileName);

            try
            {
                PortImage pi = new PortImage(inputImg);
                pi.GetGfx(palette, false);
                gfxObject = new GFX(gfxObject, pi.gfxData);
                ImportImage();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void menuItem_gfxExportRaw_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveRaw = new SaveFileDialog();
        saveRaw.Filter = "GFX files (*.gfx)|*.gfx|All files (*.*)|*.*";
        if (saveRaw.ShowDialog() == DialogResult.OK)
        {
            File.WriteAllBytes(saveRaw.FileName, gfxObject.data);
        }
    }

    private void menuItem_gfxExportImg_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveImg = new SaveFileDialog();
        saveImg.Filter = "PNG files (*.png)|*.png";
        if (saveImg.ShowDialog() == DialogResult.OK)
        {
            PixelFormat format = PixelFormat.Undefined;
            if (menuItem_4bitIndexed.Checked) { format = PixelFormat.Format4bppIndexed; }
            else if (menuItem_24bitRGB.Checked) { format = PixelFormat.Format24bppRgb; }
            else if (menuItem_32bitARGB.Checked) { format = PixelFormat.Format32bppArgb; }

            Bitmap output = PortImage.Export(gfxImage, format);
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

    private void ImportPalette(PalFileType type)
    {
        OpenFileDialog import = new OpenFileDialog();
        import.Filter = FormPalette.GetFileFilter(type);
        if (import.ShowDialog() == DialogResult.OK)
        {
            palette.Import(import.FileName, type);
            palette.Write(romStream);
            DrawPalette();
        }
    }

    private void ExportPalette(PalFileType type)
    {
        SaveFileDialog export = new SaveFileDialog();
        export.Filter = FormPalette.GetFileFilter(type);
        if (export.ShowDialog() == DialogResult.OK)
        {
            palette.Export(export.FileName, type);
        }
    }

    private void menuItem_palImport_raw_Click(object sender, EventArgs e)
    {
        ImportPalette(PalFileType.Raw);
    }

    private void menuItem_palImport_tlp_Click(object sender, EventArgs e)
    {
        ImportPalette(PalFileType.TLP);
    }

    private void menuItem_palImport_yychr_Click(object sender, EventArgs e)
    {
        ImportPalette(PalFileType.YYCHR);
    }

    private void menuItem_palExport_raw_Click(object sender, EventArgs e)
    {
        ExportPalette(PalFileType.Raw);

    }

    private void menuItem_palExport_tlp_Click(object sender, EventArgs e)
    {
        ExportPalette(PalFileType.TLP);

    }

    private void menuItem_palExport_yychr_Click(object sender, EventArgs e)
    {
        ExportPalette(PalFileType.YYCHR);
    }
    #endregion

    #region ZOOM
    private void toolStrip_zoom100_Click(object sender, EventArgs e)
    {
        statusLabel_zoomLevel.Text = "100%";
        gfxZoom = 0;
        UpdateZoom();
    }

    private void toolStrip_zoom200_Click(object sender, EventArgs e)
    {
        statusLabel_zoomLevel.Text = "200%";
        gfxZoom = 1;
        UpdateZoom();
    }

    private void toolStrip_zoom400_Click(object sender, EventArgs e)
    {
        statusLabel_zoomLevel.Text = "400%";
        gfxZoom = 2;
        UpdateZoom();
    }

    private void toolStrip_zoom800_Click(object sender, EventArgs e)
    {
        statusLabel_zoomLevel.Text = "800%";
        gfxZoom = 3;
        UpdateZoom();
    }

    private void toolStrip_zoom1600_Click(object sender, EventArgs e)
    {
        statusLabel_zoomLevel.Text = "1600%";
        gfxZoom = 4;
        UpdateZoom();
    }
    #endregion
}
