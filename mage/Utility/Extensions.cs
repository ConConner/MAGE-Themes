using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Utility;

public static class Extensions
{
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

    private const int WM_SETREDRAW = 11;

    /// <summary>
    /// Temporarily stops the drawing of the control
    /// </summary>
    /// <param name="control"></param>
    public static void SuspendDrawing(this Control control)
    {
        SendMessage(control.Handle, WM_SETREDRAW, false, 0);
    }

    /// <summary>
    /// Resumes the drawing of the control
    /// </summary>
    /// <param name="control"></param>
    public static void ResumeDrawing(this Control control)
    {
        SendMessage(control.Handle, WM_SETREDRAW, true, 0);
        control.Refresh();
    }

    public static Bitmap Crop(this Bitmap source, Rectangle area)
    {
        Bitmap cropped = new Bitmap(area.Width, area.Height);
        using (Graphics g = Graphics.FromImage(cropped))
        {
            g.DrawImage(source, new Rectangle(0, 0, cropped.Width, cropped.Height), 
                area, GraphicsUnit.Pixel);
        }
        return cropped;
    }
}
