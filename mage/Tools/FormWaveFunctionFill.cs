using mage.Actions.RoomEditor;
using mage.Theming;
using mage.Utility;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace mage
{
    public partial class FormWaveFunctionFill : Form
    {
        private readonly FormMain main;
        private readonly Room room;
        private readonly Rectangle trainingSelection;
        private WfcModel model;

        public FormWaveFunctionFill(FormMain main)
        {
            InitializeComponent();

            ThemeSwitcher.ChangeTheme(Controls, this);
            ThemeSwitcher.InjectPaintOverrides(Controls);

            this.main = main;
            room = main.Room;
            trainingSelection = main.Selection;

            Initialize();
        }

        private void Initialize()
        {
            if (!room.BG1.Exists)
            {
                label_info.Text = "This room's BG1 layer isn't in use, so there's nothing to fill.";
                button_generate.Enabled = false;
                return;
            }

            if (!HasValidSelection(trainingSelection))
            {
                label_info.Text = "Select a region of the room first (right-click and drag), then reopen this tool.";
                button_generate.Enabled = false;
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                model = BuildModel(room.header.tileset);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            label_info.Text =
                "Tileset: " + Hex.ToString(room.header.tileset) + "\n" +
                "Region: " + trainingSelection.Width + " x " + trainingSelection.Height +
                " at (" + trainingSelection.X + ", " + trainingSelection.Y + ")\n" +
                "Learned from " + model.SampleCount + " room(s) sharing this tileset, " +
                "using " + model.AllTiles.Count + " distinct tile(s).";

            if (!model.HasTiles)
            {
                label_info.Text += "\n\nNo tile data could be learned - nothing to generate from.";
                button_generate.Enabled = false;
            }
        }

        private static bool HasValidSelection(Rectangle sel)
        {
            return sel.X >= 0 && sel.Y >= 0 && sel.Width > 0 && sel.Height > 0;
        }

        private WfcModel BuildModel(byte tilesetId)
        {
            WfcModel m = new();

            for (byte area = 0; area < Version.RoomsPerArea.Length; area++)
            {
                for (byte r = 0; r < Version.RoomsPerArea[area]; r++)
                {
                    byte roomTileset = (byte)Header.GetValue(area, r, HeaderData.Tileset);
                    if (roomTileset != tilesetId) { continue; }

                    // use the live in-memory room for the room being edited, so any
                    // not-yet-saved edits are reflected instead of stale ROM data
                    bool isCurrentRoom = area == room.AreaID && r == room.RoomID;
                    if (isCurrentRoom)
                    {
                        if (room.BG1.Exists)
                        {
                            m.Learn(room.BG1.blocks, (x, y) => trainingSelection.Contains(x, y));
                        }
                        continue;
                    }

                    Room sample;
                    try { sample = new Room(area, r); }
                    catch { continue; }

                    if (!sample.BG1.Exists) { continue; }
                    m.Learn(sample.BG1.blocks);
                }
            }

            return m;
        }

        private void button_generate_Click(object sender, EventArgs e)
        {
            Rectangle target = main.Selection;
            if (!HasValidSelection(target))
            {
                label_status.Text = "Select a region in the room before generating.";
                return;
            }
            if (target.X + target.Width > room.Width || target.Y + target.Height > room.Height)
            {
                label_status.Text = "The current selection doesn't fit within the room.";
                return;
            }

            Cursor = Cursors.WaitCursor;
            ushort[,] fillResult;
            try
            {
                fillResult = WaveFunctionFiller.Fill(model, target.Width, target.Height, (x, y, dx, dy) =>
                {
                    int rx = target.X + x + dx;
                    int ry = target.Y + y + dy;

                    bool insideTarget = rx >= target.X && rx < target.X + target.Width &&
                                        ry >= target.Y && ry < target.Y + target.Height;
                    if (insideTarget) { return null; }

                    if (rx < 0 || ry < 0 || rx >= room.Width || ry >= room.Height) { return null; }

                    return room.BG1.blocks[rx, ry];
                });
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            Block[,] clipboard = new Block[target.Width, target.Height];
            for (int y = 0; y < target.Height; y++)
            {
                for (int x = 0; x < target.Width; x++)
                {
                    clipboard[x, y] = new Block { BG1 = fillResult[x, y] };
                }
            }

            EditBlocks action = new(room.backgrounds, clipboard, new Point(target.X, target.Y), 1, 0xFFFF, false);
            main.PerformAction(action);

            label_status.Text = "Filled " + target.Width + " x " + target.Height +
                " region on BG1. Use Ctrl+Z to undo, or Generate again for a new attempt.";
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
