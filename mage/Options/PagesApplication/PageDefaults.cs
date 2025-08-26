using mage.Properties;
using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Options.Pages;

public partial class PageDefaults : UserControl, IReloadablePage
{
    FormMain Parent;
    bool init = false;

    public PageDefaults()
    {
        InitializeComponent();

        // This page uses a very stupid workaround to set these values because Biospark made bad decisions
        Parent = FormMain.Instance;
        LoadPage();
    }

    public void LoadPage()
    {
        LoadValues();
    }

    private void LoadValues()
    {
        init = true;
        checkBox_bg0.Checked = Parent.menuItem_defaultBG0.Checked;
        checkBox_bg1.Checked = Parent.menuItem_defaultBG1.Checked;
        checkBox_bg2.Checked = Parent.menuItem_defaultBG2.Checked;
        checkBox_bg3.Checked = Parent.menuItem_defaultBG3.Checked;

        checkBox_collision.Checked = Parent.menuItem_defaultClipCollision.Checked;
        checkBox_breakable.Checked = Parent.menuItem_defaultClipBreakable.Checked;
        checkBox_values.Checked = Parent.menuItem_defaultClipValues.Checked;
        checkBox_none.Checked = !checkBox_collision.Checked && !checkBox_breakable.Checked && !checkBox_values.Checked;

        checkBox_sprites.Checked = Parent.menuItem_defaultSprites.Checked;
        checkBox_spriteOutlines.Checked = Parent.menuItem_defaultSpriteOutlines.Checked;
        checkBox_doors.Checked = Parent.menuItem_defaultDoors.Checked;
        checkBox_scrolls.Checked = Parent.menuItem_defaultScrolls.Checked;
        checkBox_screenOutlines.Checked = Parent.menuItem_defaultScreens.Checked;

        radio_hex.Checked = Hex.ToHex;
        radio_dec.Checked = !Hex.ToHex;

        checkBox_hideTooltips.Checked = Parent.menuItem_tooltips.Checked;
        init = false;
    }

    private void SetValues()
    {
        Parent.menuItem_defaultBG0.Checked = checkBox_bg0.Checked;
        Parent.menuItem_defaultBG1.Checked = checkBox_bg1.Checked;
        Parent.menuItem_defaultBG2.Checked = checkBox_bg2.Checked;
        Parent.menuItem_defaultBG3.Checked = checkBox_bg3.Checked;

        Parent.menuItem_defaultClipCollision.Checked = checkBox_collision.Checked;
        Parent.menuItem_defaultClipBreakable.Checked = checkBox_breakable.Checked;
        Parent.menuItem_defaultClipValues.Checked = checkBox_values.Checked;

        Parent.menuItem_defaultSprites.Checked = checkBox_sprites.Checked;
        Parent.menuItem_defaultSpriteOutlines.Checked = checkBox_spriteOutlines.Checked;
        Parent.menuItem_defaultDoors.Checked = checkBox_doors.Checked;
        Parent.menuItem_defaultScrolls.Checked = checkBox_scrolls.Checked;
        Parent.menuItem_defaultScreens.Checked = checkBox_screenOutlines.Checked;
    }

    private void checkBox_ValueChanged(object sender, EventArgs e)
    {
        if (init) return;
        SetValues();
    }

    private void radio_hex_CheckedChanged(object sender, EventArgs e)
    {
        if (init) return;
        Hex.ToHex = radio_hex.Checked;
        Parent.UpdateRoomNumbers();
    }

    private void checkBox_hideTooltips_CheckedChanged(object sender, EventArgs e)
    {
        Parent.menuItem_tooltips.Checked = checkBox_hideTooltips.Checked;
        Parent.HideTooltips(checkBox_hideTooltips.Checked);
    }
}
