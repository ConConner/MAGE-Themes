using mage.Coworking;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace mage.Options.Pages
{
    /// <summary>
    /// Lets the user point at unmodified vanilla ROMs for MZM/Fusion, verified
    /// against known checksums. These are the baseline that coworking ROM diffs
    /// are generated and applied against, so peers never need to transfer the
    /// (copyrighted) ROM itself over the network - just their edits.
    /// </summary>
    public class PageCoworking : UserControl, IReloadablePage
    {
        private TextBox zeroMissionPathBox;
        private Label zeroMissionStatusLabel;
        private TextBox fusionPathBox;
        private Label fusionStatusLabel;

        public PageCoworking()
        {
            Dock = DockStyle.Fill;

            int y = 12;
            (zeroMissionPathBox, zeroMissionStatusLabel, y) = AddRomRow(VanillaRom.MetroidZeroMissionUsa, y);
            (fusionPathBox, fusionStatusLabel, y) = AddRomRow(VanillaRom.MetroidFusionUsa, y);

            Controls.Add(new Label
            {
                Text = "These are used to sync ROM edits between coworking peers as small diffs instead of transferring "
                    + "the whole ROM. They must be unmodified retail dumps of the US release.",
                Left = 12,
                Top = y + 8,
                Width = 460,
                Height = 50,
            });

            LoadPage();
        }

        private (TextBox path, Label status, int nextY) AddRomRow(VanillaRom rom, int y)
        {
            Controls.Add(new Label { Text = VanillaRomCatalog.DisplayName(rom), Left = 12, Top = y, Width = 300, Font = new Font(Font, FontStyle.Bold) });
            y += 20;

            TextBox path = new() { Left = 12, Top = y, Width = 340, ReadOnly = true };
            Button browse = new() { Text = "Browse...", Left = 360, Top = y - 1, Width = 80 };
            Controls.Add(path);
            Controls.Add(browse);
            y += 26;

            Label status = new() { Left = 12, Top = y, Width = 430, Height = 16 };
            Controls.Add(status);
            y += 30;

            browse.Click += (_, _) => BrowseFor(rom, path, status);

            return (path, status, y);
        }

        private void BrowseFor(VanillaRom rom, TextBox pathBox, Label status)
        {
            using OpenFileDialog ofd = new() { Filter = "GBA ROM (*.gba)|*.gba|All files (*.*)|*.*" };
            if (ofd.ShowDialog(this) != DialogResult.OK) { return; }

            pathBox.Text = ofd.FileName;
            SetConfigPath(rom, ofd.FileName);
            Validate(rom, ofd.FileName, status);
        }

        private static void SetConfigPath(VanillaRom rom, string path)
        {
            switch (rom)
            {
                case VanillaRom.MetroidZeroMissionUsa: Program.Config.VanillaZeroMissionRomPath = path; break;
                case VanillaRom.MetroidFusionUsa: Program.Config.VanillaFusionRomPath = path; break;
            }
        }

        private static void Validate(VanillaRom rom, string path, Label status)
        {
            if (string.IsNullOrEmpty(path))
            {
                status.Text = "Not set.";
                status.ForeColor = SystemColors.GrayText;
                return;
            }

            if (!File.Exists(path))
            {
                status.Text = "File not found.";
                status.ForeColor = Color.Red;
                return;
            }

            try
            {
                if (VanillaRomCatalog.Verify(rom, path, out _))
                {
                    status.Text = "Verified - matches the known vanilla checksum.";
                    status.ForeColor = Color.Green;
                }
                else
                {
                    status.Text = $"Checksum mismatch - this isn't an unmodified {VanillaRomCatalog.DisplayName(rom)} ROM.";
                    status.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                status.Text = "Could not read file: " + ex.Message;
                status.ForeColor = Color.Red;
            }
        }

        public void LoadPage()
        {
            zeroMissionPathBox.Text = Program.Config.VanillaZeroMissionRomPath;
            Validate(VanillaRom.MetroidZeroMissionUsa, Program.Config.VanillaZeroMissionRomPath, zeroMissionStatusLabel);

            fusionPathBox.Text = Program.Config.VanillaFusionRomPath;
            Validate(VanillaRom.MetroidFusionUsa, Program.Config.VanillaFusionRomPath, fusionStatusLabel);
        }
    }
}
