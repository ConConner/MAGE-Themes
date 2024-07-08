using MageNet;
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

namespace mage
{
    public partial class NetworkTest : Form
    {
        public static ServerClient client;
        FormMain formMain;

        public NetworkTest(FormMain main)
        {
            formMain = main;
            InitializeComponent();
        }

        private void btn_start_server_Click(object sender, EventArgs e)
        {
            ServerHost server = new ServerHost(IPAddress.Parse("127.0.0.1"), 8000, formMain.AddTileFromNetwork);
            server.AcceptClients();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            client = new ServerClient();
            client.ConnectToServer(IPAddress.Parse("127.0.0.1"), 8000);
        }

        private void btn_test_packet_Click(object sender, EventArgs e)
        {
            if (client == null) return;
            byte[] testData = { 0, 1, 2, 3, 4 };
            client.SendPacket(testData);
        }
    }
}
