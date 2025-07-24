using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Controls;

public class ExtendedPanel : Panel
{
    protected override void OnMouseWheel(MouseEventArgs e)
    {
        if ((ModifierKeys & (Keys.Shift | Keys.Control)) != 0)
        {
            int step = SystemInformation.MouseWheelScrollDelta;
            int newPos = HorizontalScroll.Value - Math.Sign(e.Delta) * step;
            HorizontalScroll.Value = Math.Max(0, Math.Min(HorizontalScroll.Maximum, newPos));
            ((HandledMouseEventArgs)e).Handled = true;
            return;
        }
        base.OnMouseWheel(e);
    }
}
