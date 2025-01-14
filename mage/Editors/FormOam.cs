using mage.Properties;
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

    Pen partOutline = new Pen(Color.Aqua, 1);

    private bool loading;
    private int gfxZoom;
    private int oamZoom;

    private FormMain main;
    private ByteStream romStream;

    private Timer animationTimer;
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

            // Stop timer if needed
            if (playingAnimation) return;
            if (animationTimer == null) return;
            animationTimer.Stop();
        }
    }
    private bool playingAnimation = false;


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

        animationTimer = new Timer();
        animationTimer.Tick += AnimationTimer_Tick;

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
    private void SetOAM()
    {
        PlayingAnimation = false;
        try
        {
            int offset = Hex.ToInt(textBox_oamOffset.Text);
            oam = new OAM(offset);

            //Populate frame selection
            comboBox_Frame.Items.Clear();
            for (int i = 0; i < oam.numFrames; i++)
            {
                comboBox_Frame.Items.Add(i);
            }
            comboBox_Frame.SelectedIndex = 0;
        }
        catch
        {
            MessageBox.Show("No valid OAM found.", "Invalid OAM", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CreateVram()
    {
        vram = new VramObj(gfxObject, palette);
    }

    private void DrawFrame(int frameNumber)
    {
        if (oam == null || vram == null) return;
        Bitmap frame = oam.DrawReal(vram.objTiles, vram.palette, 0, frameNumber);
        oamView_oam.OamImage = frame;

        // Display Part boxes
        AddPartOutlines(oam.frames[frameNumber]);
    }

    private void AddPartOutlines(OAM.Frame frame)
    {
        oamView_oam.ResetDrawables();
        foreach (OAM.Part p in frame.parts)
        {
            Size s = p.Dimensions;
            Rectangle r = new Rectangle(p.xPos + OAM.FrameOriginX, p.yPos + OAM.FrameOriginY, s.Width, s.Height);
            OamView.Drawable outline = new(r, partOutline)
            {
                Visible = false,
            };
            oamView_oam.Drawables.Add(outline);
        }
    }

    private void SetTimerInterval(int frame)
    {
        OAM.Frame f = oam.frames[frame];
        int timeInMs = (int)(16.67f * f.duration);
        animationTimer.Interval = Math.Max(1, timeInMs);
    }

    private void button_oamGo_Click(object sender, EventArgs e) => SetOAM();

    private void comboBox_Frame_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (loading) return;
        DrawFrame(comboBox_Frame.SelectedIndex);
        textBox_duration.Text = Hex.ToString(oam.frames[comboBox_Frame.SelectedIndex].duration);
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
        comboBox_Frame.SelectedIndex = (comboBox_Frame.SelectedIndex + 1) % oam.numFrames;
        SetTimerInterval(comboBox_Frame.SelectedIndex);
    }
    #endregion

    #region ZOOM
    #region GFX
    private void toolStrip_zoom100_Click(object sender, EventArgs e)
    {
        statusStrip_zoom.Text = "100%";
        gfxZoom = 0;
        UpdateZoom();
    }

    private void toolStrip_zoom200_Click(object sender, EventArgs e)
    {
        statusStrip_zoom.Text = "200%";
        gfxZoom = 1;
        UpdateZoom();
    }

    private void toolStrip_zoom400_Click(object sender, EventArgs e)
    {
        statusStrip_zoom.Text = "400%";
        gfxZoom = 2;
        UpdateZoom();
    }

    private void toolStrip_zoom800_Click(object sender, EventArgs e)
    {
        statusStrip_zoom.Text = "800%";
        gfxZoom = 3;
        UpdateZoom();
    }

    private void toolStrip_zoom1600_Click(object sender, EventArgs e)
    {
        statusStrip_zoom.Text = "1600%";
        gfxZoom = 4;
        UpdateZoom();
    }
    #endregion
    #region OAM
    private void toolStrip_zoomOam100_Click(object sender, EventArgs e)
    {
        toolStrip_zoomOam.Text = "100%";
        oamView_oam.Zoom = 0;
    }

    private void toolStrip_zoomOam200_Click(object sender, EventArgs e)
    {
        toolStrip_zoomOam.Text = "200%";
        oamView_oam.Zoom = 1;
    }

    private void toolStrip_zoomOam400_Click(object sender, EventArgs e)
    {
        toolStrip_zoomOam.Text = "400%";
        oamView_oam.Zoom = 2;
    }

    private void toolStrip_zoomOam800_Click(object sender, EventArgs e)
    {
        toolStrip_zoomOam.Text = "800%";
        oamView_oam.Zoom = 3;
    }

    private void toolStrip_zoomOam1600_Click(object sender, EventArgs e)
    {
        toolStrip_zoomOam.Text = "1600%";
        oamView_oam.Zoom = 4;
    }
    #endregion
    #endregion

}
