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
    private bool pixelMode;

    public AreaImageExportDialog(FormMain main, byte[] roomsPerArea, int area, bool pixelMode = false)
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

        Text = pixelMode ? "Export Area Pixel Image" : "Export Area Image";
        this.pixelMode = pixelMode;
    }

    private void button_save_Click(object sender, EventArgs e)
    {
        SaveFileDialog dialog = new SaveFileDialog();
        dialog.Filter = "PNG files (*.png)|*.png";
        if (dialog.ShowDialog() != DialogResult.OK) return;

        filePath = dialog.FileName;

        // List of all relevant rooms
        List<Room> rooms = new List<Room>();
        (Point, Point) bounds = new(new Point(16, 16), new Point(0, 0));

        for (byte room = 0; room < roomsPerArea[area]; room++)
        {
            if (excludedRooms.Contains(room)) continue;

            Room r;
            try { r = new Room(area, room); }
            catch { continue; }

            if (requireDoors && r.doorList.Count < 1) continue;

            //TODO: Add option to hide backgrounds
            //r.backgrounds.View[0] = false;
            rooms.Add(r);

            //Figuring out the minimum size of the area in screens
            if (r.header.mapX < bounds.Item1.X) bounds.Item1.X = r.header.mapX;
            if (r.header.mapY < bounds.Item1.Y) bounds.Item1.Y = r.header.mapY;
            if (r.header.mapX + r.WidthInScreens > bounds.Item2.X) bounds.Item2.X = r.header.mapX + r.WidthInScreens;
            if (r.header.mapY + r.HeightInScreens > bounds.Item2.Y) bounds.Item2.Y = r.header.mapY + r.HeightInScreens;
        }

        if (!pixelMode) exportAreaImage(rooms, bounds);
        else exportPixelImage(rooms, bounds);
    }

    private void exportAreaImage(List<Room> rooms, (Point, Point) bounds)
    {
        //Rectangle with maximum area size
        Rectangle areaSize = new Rectangle(
            bounds.Item1.X * 15 * 16,
            bounds.Item1.Y * 10 * 16,
            (bounds.Item2.X - bounds.Item1.X) * 15 * 16,
            (bounds.Item2.Y - bounds.Item1.Y) * 10 * 16
        );

        //Creating bitmap
        Bitmap areaImage = new(areaSize.Width, areaSize.Height);
        Graphics g = Graphics.FromImage(areaImage);

        foreach (Room r in rooms)
        {
            Bitmap roomImage = new Bitmap(r.Width * 16, r.Height * 16);
            Draw.DrawRoom(r, roomImage, main);

            Rectangle visibleRegion = new Rectangle(16 * 2, 16 * 2, (r.Width - 4) * 16, (r.Height - 4) * 16);

            int areaCoordinateX = r.header.mapX * 15 * 16 - areaSize.X;
            int areaCoordinateY = r.header.mapY * 10 * 16 - areaSize.Y;
            g.DrawImage(roomImage, areaCoordinateX, areaCoordinateY, visibleRegion, GraphicsUnit.Pixel);
            roomImage.Dispose();
        }
        g.Dispose();

        areaImage.Save(filePath);
        areaImage.Dispose();
        Close();
    }

    private void exportPixelImage(List<Room> rooms, (Point, Point) bounds)
    {
        //Rectangle with maximum area size
        Rectangle areaSize = new(
            bounds.Item1.X * 15,
            bounds.Item1.Y * 10,
            (bounds.Item2.X - bounds.Item1.X) * 15,
            (bounds.Item2.Y - bounds.Item1.Y) * 10
        );

        //Creating bitmap
        using Bitmap areaImage = new Bitmap(areaSize.Width, areaSize.Height);
        using Graphics g = Graphics.FromImage(areaImage);

        foreach (Room r in rooms)
        {
            using Bitmap roomImage = new(r.Width - 4, r.Height - 4);
            r.backgrounds.clipTypes.DrawCollisionPixel(roomImage, new(), true);

            int areaCoordinateX = r.header.mapX * 15 - areaSize.X;
            int areaCoordinateY = r.header.mapY * 10 - areaSize.Y;
            g.DrawImage(roomImage, areaCoordinateX, areaCoordinateY, roomImage.Width, roomImage.Height);
        }

        areaImage.Save(filePath);
        Close();
    }
}
