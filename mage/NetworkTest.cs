using MageNet;
using MageNet.IO;
using MageNet.Packets;
using MageNet.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage;

public partial class NetworkTest : Form
{
    public static ServerClient Client;
    FormMain formMain;

    public NetworkTest(FormMain main)
    {
        formMain = main;
        InitializeComponent();

        txb_host_ip.Text = $"{Address.GetLocalIPAddress()}";
    }

    private void btn_start_server_Click(object sender, EventArgs e)
    {
        int port = (int)num_host_port.Value;

        ServerHost server = new ServerHost(Address.GetLocalIPAddress(), port, AddLogMessage);
        server.AcceptClients();
    }

    private void btn_connect_Click(object sender, EventArgs e)
    {
        IPAddress address = IPAddress.Parse(txb_ip.Text);
        int port = (int)num_port.Value;

        Client = new ServerClient("", AddLogMessage);
        Client.ConnectToServer(address, port);
    }

    private void btn_test_packet_Click(object sender, EventArgs e)
    {
        TestPacket t = new TestPacket(20);
        Packet p = new(PacketType.Dummy, t);

        Client.SendPacketToServerAsync(p);
    }

    void AddLogMessage(string message)
    {
        console?.AppendText(message + '\n');
    }
}
