using System;
using System.Drawing;
using System.Windows.Forms;

namespace mage.Dialogs;

/// <summary>Minimal host/port/name prompt for starting or joining a coworking session.</summary>
public sealed class FormCoworkingConnect : Form
{
    public string HostAddress { get; private set; } = "";
    public int Port { get; private set; }
    public string UserName { get; private set; } = "";

    private readonly TextBox? hostBox;
    private readonly TextBox portBox;
    private readonly TextBox nameBox;

    public FormCoworkingConnect(bool showHostField, string title, string defaultUserName)
    {
        Text = title;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        ClientSize = new Size(280, showHostField ? 156 : 126);

        int y = 12;

        Controls.Add(new Label { Text = "Your name:", Left = 12, Top = y + 3, Width = 100 });
        nameBox = new TextBox { Left = 120, Top = y, Width = 140, Text = defaultUserName };
        Controls.Add(nameBox);
        y += 30;

        if (showHostField)
        {
            Controls.Add(new Label { Text = "Host address:", Left = 12, Top = y + 3, Width = 100 });
            hostBox = new TextBox { Left = 120, Top = y, Width = 140, Text = "127.0.0.1" };
            Controls.Add(hostBox);
            y += 30;
        }

        Controls.Add(new Label { Text = "Port:", Left = 12, Top = y + 3, Width = 100 });
        portBox = new TextBox { Left = 120, Top = y, Width = 140, Text = "7777" };
        Controls.Add(portBox);
        y += 34;

        Button ok = new() { Text = "OK", DialogResult = DialogResult.OK, Left = 100, Top = y, Width = 75 };
        Button cancel = new() { Text = "Cancel", DialogResult = DialogResult.Cancel, Left = 180, Top = y, Width = 75 };
        Controls.Add(ok);
        Controls.Add(cancel);
        AcceptButton = ok;
        CancelButton = cancel;

        ok.Click += (_, _) =>
        {
            string name = nameBox.Text.Trim();
            if (name.Length == 0)
            {
                MessageBox.Show(this, "Enter a name.", "Missing name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }

            HostAddress = hostBox?.Text.Trim() ?? "";
            if (!int.TryParse(portBox.Text.Trim(), out int port) || port is <= 0 or > 65535)
            {
                MessageBox.Show(this, "Enter a valid port number (1-65535).", "Invalid port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }

            UserName = name;
            Port = port;
        };
    }
}
