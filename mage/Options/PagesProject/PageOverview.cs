using mage.Properties;
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

namespace mage.Options.Pages;

public partial class PageOverview : UserControl, IReloadablePage
{
    public PageOverview()
    {
        InitializeComponent();
        LoadPage();
    }
    public void LoadPage()
    { }
}
