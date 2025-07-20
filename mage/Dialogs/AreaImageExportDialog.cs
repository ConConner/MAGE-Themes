using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Dialogs;

public partial class AreaImageExportDialog : Form
{
    FormMain main;
    private string filePath = String.Empty;
    private byte[] roomsPerArea;
    private int area;
    private string areaName => Version.AreaNames[area];
    private bool requireDoors => checkBox_roomRequireDoors.Checked;
    private List<int> excludedRooms => listbox_excludedRooms.SelectedIndices.Cast<int>().ToList();

    public AreaImageExportDialog(FormMain main, byte[] roomsPerArea, int area)
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        this.main = main;
        this.roomsPerArea = roomsPerArea;
        this.area = area;

        listbox_excludedRooms.Items.Clear();
        for (int i = 0; i < roomsPerArea[area]; i++)
        {
            string item = $"{areaName} - {Hex.ToString(i)}";
            listbox_excludedRooms.Items.Add(item);
        }
    }

    private void button_choose_Click(object sender, EventArgs e)
    {
        SaveFileDialog dialog = new SaveFileDialog();
        dialog.Filter = "PNG files (*.png)|*.png";
        if (dialog.ShowDialog() != DialogResult.OK) return;

        filePath = dialog.FileName;
        panel1.Enabled = true;
    }

    private void button_save_Click(object sender, EventArgs e)
    {
        if (filePath == String.Empty)
        {
            MessageBox.Show("No save location selected", "Select save location!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Export image
        List<Room> rooms = new List<Room>();
        (Point, Point) bounds = new(new Point(16, 16), new Point(0, 0));

        for (byte room = 0; room < roomsPerArea[area]; room++)
        {
            if (excludedRooms.Contains(room)) continue;

            Room r;
            try { r = new Room(area, room); }
            catch { continue; }

            if (requireDoors && r.doorList.Count < 1) continue;

            rooms.Add(r);

            //Figuring out the minimum size of the area in screens
            if (r.header.mapX < bounds.Item1.X) bounds.Item1.X = r.header.mapX;
            if (r.header.mapY < bounds.Item1.Y) bounds.Item1.Y = r.header.mapY;
            if (r.header.mapX + r.WidthInScreens > bounds.Item2.X) bounds.Item2.X = r.header.mapX + r.WidthInScreens;
            if (r.header.mapY + r.HeightInScreens > bounds.Item2.Y) bounds.Item2.Y = r.header.mapY + r.HeightInScreens;
        }
        //Rectangle used to crop image
        Rectangle areaSize = new Rectangle(
            bounds.Item1.X * 15 * 16,
            bounds.Item1.Y * 10 * 16,
            (bounds.Item2.X - bounds.Item1.X) * 15 * 16,
            (bounds.Item2.Y - bounds.Item1.Y) * 10 * 16
        );

        //Maximum Area Size
        int areaPixelWidth = 15 * 16 * 32;
        int areaPixelHeight = 10 * 16 * 32;

        //Creating bitmap
        Bitmap areaImage = new(areaPixelWidth, areaPixelHeight);
        Graphics g = Graphics.FromImage(areaImage);

        foreach (Room r in rooms)
        {
            Bitmap roomImage = new Bitmap(r.Width * 16, r.Height * 16);
            Draw.DrawRoom(r, roomImage, main);

            Rectangle visibleRegion = new Rectangle(16 * 2, 16 * 2, (r.Width - 4) * 16, (r.Height - 4) * 16);

            int areaCoordinateX = r.header.mapX * 15 * 16;
            int areaCoordinateY = r.header.mapY * 10 * 16;
            g.DrawImage(roomImage, areaCoordinateX, areaCoordinateY, visibleRegion, GraphicsUnit.Pixel);
            roomImage.Dispose();
        }

        g.Dispose();

        //Crop image
        Bitmap clone = areaImage.Clone(areaSize, areaImage.PixelFormat);
        clone.Save(filePath);

        clone.Dispose();
        areaImage.Dispose();
        Close();
    }
}
