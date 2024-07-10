using mage.Theming;
using MageNet.Util;
using MageNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MageNet.Packets;
using MageNet.IO;
using System.Net;

namespace mage.Networking;

public partial class FormCollabSession : Form
{
    private FormMain main;
    public FormCollabSession(FormMain main)
    {
        InitializeComponent();
        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);
        this.main = main;

        //If no session connected
        if (Session.InSession)
        {
            grp_users.Enabled = true;
            SetUIButtons();
        }
    }

    private void SetUIButtons()
    {
        if (Session.SelfHosting)
        {
            btn_host.Text = "Stop collaboration session";
            grp_join.Enabled = false;
        }
        else
        {
            btn_join_session.Text = "Leave collaboration session";
            grp_host.Enabled = false;
        }
        txb_host_name.Enabled = false;
        txb_host_port.Enabled = false;
        txb_join_ip.Enabled = false;
        txb_join_name.Enabled = false;
        txb_join_port.Enabled = false;
    }
    private void ResetUIButtons()
    {
        btn_host.Text = "Host a collaboration session";
        btn_join_session.Text = "Join a collaboration session";
        grp_join.Enabled = true;
        grp_users.Enabled = false;
        grp_host.Enabled = true;
        txb_host_name.Enabled = true;
        txb_host_port.Enabled = true;
        txb_join_ip.Enabled = true;
        txb_join_name.Enabled = true;
        txb_join_port.Enabled = true;
    }

    /// <summary>
    /// Start hosting a server and connect to it
    /// </summary>
    private void btn_host_Click(object sender, EventArgs e)
    {
        if (Session.InSession)
        {
            Session.EndSession();
            ResetUIButtons();
            return;
        }

        //Start the session
        int port = Convert.ToInt32(txb_host_port.Text, 10);
        Session.CreateSession(port);
        Session.SelfHosting = true;

        Session.JoinSession(txb_host_name.Text);

        //Set UI
        SetUIButtons();
    }

    /// <summary>
    /// Connect to a server
    /// </summary>
    private void btn_join_session_Click(object sender, EventArgs e)
    {
        if (Session.InSession)
        {
            Session.EndSession();
            ResetUIButtons();
            return;
        }

        //Join a Session
        int port = Convert.ToInt32(txb_join_port.Text, 10);
        IPAddress address = IPAddress.Parse(txb_join_ip.Text);

        Session.JoinSession(txb_join_name.Text, address, port);

        //Set UI Buttons
        SetUIButtons();
    }
}
