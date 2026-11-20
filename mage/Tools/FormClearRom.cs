using mage.Theming;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Asset = mage.RomClearer.Asset;

namespace mage
{
    /// <summary>
    /// Lets the user choose which assets <see cref="RomClearer"/> removes
    /// </summary>
    public partial class FormClearRom : Form
    {
        /// <summary>The assets the user selected, without dependencies</summary>
        public Asset Selection => userSelection;
        /// <summary>Whether a backup should be created before clearing</summary>
        public bool CreateBackup => checkBox_backup.Checked;

        private readonly Dictionary<CheckBox, Asset> boxes;
        private Asset userSelection = Asset.All;
        private bool updating;

        public FormClearRom()
        {
            InitializeComponent();

            boxes = new()
            {
                { checkBox_rooms, Asset.Rooms },
                { checkBox_roomSprites, Asset.RoomSprites },
                { checkBox_doors, Asset.Doors },
                { checkBox_scrolls, Asset.Scrolls },
                { checkBox_areaConnections, Asset.AreaConnections },
                { checkBox_doorEvents, Asset.DoorEvents },
                { checkBox_locationNames, Asset.LocationNames },
                { checkBox_hatchLocks, Asset.HatchLockEvents },
                { checkBox_tilesets, Asset.Tilesets },
                { checkBox_animTilesets, Asset.AnimatedTilesets },
                { checkBox_animGfx, Asset.AnimatedGraphics },
                { checkBox_animPalettes, Asset.AnimatedPalettes },
                { checkBox_spritesets, Asset.Spritesets },
                { checkBox_minimaps, Asset.Minimaps },
                { checkBox_demos, Asset.Demos },
            };
            foreach (CheckBox box in boxes.Keys) box.CheckedChanged += checkBox_asset_CheckedChanged;

            ThemeSwitcher.ChangeTheme(Controls, this);
            ThemeSwitcher.InjectPaintOverrides(Controls);

            UpdateBoxes();
        }

        private void checkBox_asset_CheckedChanged(object? sender, EventArgs e)
        {
            if (updating) return;

            CheckBox box = (CheckBox)sender!;
            if (box.Checked) userSelection |= boxes[box];
            else userSelection &= ~boxes[box];
            UpdateBoxes();
        }

        /// <summary>
        /// Checks and locks the assets that have to be removed because of other selected assets
        /// </summary>
        private void UpdateBoxes()
        {
            updating = true;
            Asset effective = RomClearer.WithDependencies(userSelection);
            foreach (var (box, asset) in boxes)
            {
                bool forced = (RomClearer.WithDependencies(userSelection & ~asset) & asset) != 0;
                box.Checked = (effective & asset) != 0;
                box.Enabled = !forced;
            }
            updating = false;

            label_notes.Text = GetNotes(effective);
            button_clear.Enabled = effective != Asset.None;
        }

        private static string GetNotes(Asset effective)
        {
            bool Has(Asset a) => (effective & a) != 0;
            List<string> notes = new();

            if (Has(Asset.Rooms))
            {
                notes.Add("The game still refers to some rooms by their number (e.g. elevators, bosses and cutscenes). These won't work anymore.");
            }
            else
            {
                if (Has(Asset.Doors)) notes.Add("Only room 0 of every area keeps a door. All other rooms can't be entered anymore.");
                if (Has(Asset.Tilesets)) notes.Add("All rooms will use the blank tileset.");
                if (Has(Asset.Spritesets)) notes.Add("All rooms will use the blank spriteset.");
            }
            if (!Has(Asset.Tilesets))
            {
                if (Has(Asset.AnimatedTilesets)) notes.Add("All tilesets will use the blank animated tileset.");
                if (Has(Asset.AnimatedPalettes)) notes.Add("All tilesets will use the blank animated palette.");
            }
            if (Has(Asset.Doors) && !Has(Asset.Demos)) notes.Add("Demos will start at door 0.");

            notes.Add("All open editors are closed and unsaved changes are discarded. This cannot be undone.");
            return "• " + string.Join("\n• ", notes);
        }

        private void SetSelection(Asset selection)
        {
            userSelection = selection;
            UpdateBoxes();
        }

        private void button_all_Click(object? sender, EventArgs e) => SetSelection(Asset.All);

        private void button_none_Click(object? sender, EventArgs e) => SetSelection(Asset.None);

        private void button_clear_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
