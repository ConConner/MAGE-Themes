using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Controls;

public class ExtendedPanel : Panel
{
    protected override void OnMouseWheel(MouseEventArgs e)
    {
        if ((ModifierKeys & Keys.Control) != 0) return;
        if ((ModifierKeys & Keys.Shift) != 0)
        {
            int step = SystemInformation.MouseWheelScrollDelta;
            int newPos = HorizontalScroll.Value - Math.Sign(e.Delta) * step;
            newPos = Math.Max(HorizontalScroll.Minimum,
                              Math.Min(HorizontalScroll.Maximum - HorizontalScroll.LargeChange + 1, newPos));

            HorizontalScroll.Value = newPos;
            PerformLayout();          // force update
            ((HandledMouseEventArgs)e).Handled = true;
            return;
        }
        base.OnMouseWheel(e);
    }

    protected override Point ScrollToControl(Control activeControl)
    {
        return this.AutoScrollPosition;
    }
}
