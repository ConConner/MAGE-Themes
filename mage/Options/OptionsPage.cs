using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Options;

public struct OptionsPage
{
    public OptionsPage() { }

    public string Name = "";
    public UserControl Page = null;
    public bool RequiresROM = false;
    public bool RequiresProject = false;
    public StatusStrip? CustomStatusStrip = null;
}