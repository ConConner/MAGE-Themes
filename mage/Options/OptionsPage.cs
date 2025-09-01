using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Options;

public struct OptionsPage
{
    public string Name;
    public UserControl Page;
    public bool RequiresROM;
    public StatusStrip? CustomStatusStrip;
}