using mage.Actions.RoomEditor;
using mage.Dialogs;
using mage.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace mage
{
    public partial class FormMain
    {
        private delegate void CoworkingActionHandler(int roomId, Action action, bool isUndo);
        private delegate void CoworkingPresenceHandler(List<PresenceEntry> roster);

        private RoomCoworkingSession? coworkingSession;
        private bool coworkingUndoRedoPending;
        private string coworkingUserName = Environment.UserName;
        private List<PresenceEntry> coworkingRoster = [];

        private ToolStripMenuItem coworkingHostItem;
        private ToolStripMenuItem coworkingJoinItem;
        private ToolStripMenuItem coworkingDisconnectItem;
        private ToolStripMenuItem coworkingStatusItem;
        private ToolStripStatusLabel coworkingPresenceLabel;

        private void InitCoworkingMenu()
        {
            coworkingHostItem = new ToolStripMenuItem("Host Session...");
            coworkingHostItem.Click += (_, _) => HostCoworkingSession();

            coworkingJoinItem = new ToolStripMenuItem("Join Session...");
            coworkingJoinItem.Click += (_, _) => JoinCoworkingSession();

            coworkingDisconnectItem = new ToolStripMenuItem("Disconnect") { Enabled = false };
            coworkingDisconnectItem.Click += (_, _) => DisconnectCoworkingSession();

            coworkingStatusItem = new ToolStripMenuItem("Not connected") { Enabled = false };

            ToolStripMenuItem coworkingMenu = new("Coworking");
            coworkingMenu.DropDownItems.Add(coworkingHostItem);
            coworkingMenu.DropDownItems.Add(coworkingJoinItem);
            coworkingMenu.DropDownItems.Add(coworkingDisconnectItem);
            coworkingMenu.DropDownItems.Add(new ToolStripSeparator());
            coworkingMenu.DropDownItems.Add(coworkingStatusItem);

            menuStrip_tools.DropDownItems.Add(new ToolStripSeparator());
            menuStrip_tools.DropDownItems.Add(coworkingMenu);

            coworkingPresenceLabel = new ToolStripStatusLabel("") { Visible = false };
            statusStrip.Items.Add(coworkingPresenceLabel);
        }

        private void HostCoworkingSession()
        {
            if (coworkingSession != null) { MessageBox.Show(this, "Already in a coworking session.", "Coworking", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (room == null) { MessageBox.Show(this, "Load a ROM and open a room first.", "Coworking", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            using FormCoworkingConnect dialog = new(showHostField: false, "Host Coworking Session", coworkingUserName);
            if (dialog.ShowDialog(this) != DialogResult.OK) { return; }

            try
            {
                coworkingUserName = dialog.UserName;
                coworkingSession = RoomCoworkingSession.Host(dialog.Port);
                AttachCoworkingSession();
                SetCoworkingStatus($"Hosting on port {dialog.Port}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Could not start hosting: {ex.Message}", "Coworking", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void JoinCoworkingSession()
        {
            if (coworkingSession != null) { MessageBox.Show(this, "Already in a coworking session.", "Coworking", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (room == null) { MessageBox.Show(this, "Load the same ROM the host is using, and open a room, before joining.", "Coworking", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            using FormCoworkingConnect dialog = new(showHostField: true, "Join Coworking Session", coworkingUserName);
            if (dialog.ShowDialog(this) != DialogResult.OK) { return; }

            try
            {
                coworkingUserName = dialog.UserName;
                coworkingSession = RoomCoworkingSession.Join(dialog.HostAddress, dialog.Port);
                AttachCoworkingSession();
                SetCoworkingStatus($"Connected to {dialog.HostAddress}:{dialog.Port}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Could not connect: {ex.Message}", "Coworking", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AttachCoworkingSession()
        {
            coworkingSession!.ActionReceived += OnCoworkingActionReceived;
            coworkingSession.PresenceReceived += OnCoworkingPresenceReceived;
            coworkingSession.PeerDisconnected += OnCoworkingPeerDisconnected;
            coworkingHostItem.Enabled = false;
            coworkingJoinItem.Enabled = false;
            coworkingDisconnectItem.Enabled = true;

            // room flipping isn't networked yet - keep it off the table while coworking
            menuItem_flip_h.Enabled = false;
            menuItem_flip_v.Enabled = false;

            SendCoworkingPresenceUpdate();
        }

        private void DisconnectCoworkingSession()
        {
            if (coworkingSession == null) { return; }

            coworkingSession.ActionReceived -= OnCoworkingActionReceived;
            coworkingSession.PresenceReceived -= OnCoworkingPresenceReceived;
            coworkingSession.PeerDisconnected -= OnCoworkingPeerDisconnected;
            coworkingSession.Dispose();
            coworkingSession = null;
            coworkingUndoRedoPending = false;

            coworkingHostItem.Enabled = true;
            coworkingJoinItem.Enabled = true;
            coworkingDisconnectItem.Enabled = false;
            menuItem_flip_h.Enabled = true;
            menuItem_flip_v.Enabled = true;
            SetCoworkingStatus("Not connected");

            coworkingRoster = [];
            UpdateCoworkingPresenceLabel();
            UpdateUndoRedo();
        }

        private void OnCoworkingPeerDisconnected()
        {
            if (InvokeRequired) { BeginInvoke(new System.Action(OnCoworkingPeerDisconnected)); return; }

            SetCoworkingStatus("Disconnected (peer connection lost)");
            coworkingSession?.Dispose();
            coworkingSession = null;
            coworkingUndoRedoPending = false;

            coworkingHostItem.Enabled = true;
            coworkingJoinItem.Enabled = true;
            coworkingDisconnectItem.Enabled = false;
            menuItem_flip_h.Enabled = true;
            menuItem_flip_v.Enabled = true;

            coworkingRoster = [];
            UpdateCoworkingPresenceLabel();
            UpdateUndoRedo();
        }

        private void SetCoworkingStatus(string status)
        {
            coworkingStatusItem.Text = status;
        }

        private void SendCoworkingAction(Action a, bool isUndo)
        {
            int roomId = RoomCoworkingSession.MakeRoomId(room.AreaID, room.RoomID);
            coworkingSession!.SendAction(roomId, a, isUndo);
        }

        private void SendCoworkingPresenceUpdate()
        {
            if (coworkingSession == null || room == null) { return; }
            coworkingSession.SendPresence(coworkingUserName, RoomCoworkingSession.MakeRoomId(room.AreaID, room.RoomID));
            UpdateCoworkingPresenceLabel();
        }

        private void OnCoworkingActionReceived(int roomId, Action a, bool isUndo)
        {
            if (InvokeRequired) { BeginInvoke(new CoworkingActionHandler(OnCoworkingActionReceived), roomId, a, isUndo); return; }

            coworkingUndoRedoPending = false;

            // v1 limitation: actions for a room other than the one currently open
            // locally are dropped rather than applied off-screen or queued.
            if (room == null || roomId != RoomCoworkingSession.MakeRoomId(room.AreaID, room.RoomID)) { return; }

            if (isUndo)
            {
                a.Undo(room);
                if (undoRedo.CanUndo) { undoRedo.DiscardTopUndo(); }
                Sound.PlaySound("undo.wav");
            }
            else
            {
                undoRedo.Do(a, room);
            }

            UpdateUI(a);
            UpdateUndoRedo();
        }

        private void OnCoworkingPresenceReceived(List<PresenceEntry> roster)
        {
            if (InvokeRequired) { BeginInvoke(new CoworkingPresenceHandler(OnCoworkingPresenceReceived), roster); return; }

            coworkingRoster = roster;
            UpdateCoworkingPresenceLabel();
        }

        private void UpdateCoworkingPresenceLabel()
        {
            if (coworkingSession == null || room == null)
            {
                coworkingPresenceLabel.Visible = false;
                return;
            }

            int currentRoomId = RoomCoworkingSession.MakeRoomId(room.AreaID, room.RoomID);
            string[] others = coworkingRoster
                .Where(p => p.RoomId == currentRoomId && p.ClientId != coworkingSession.ClientId)
                .Select(p => p.UserName)
                .ToArray();

            if (others.Length > 0)
            {
                coworkingPresenceLabel.Text = "Also editing this room: " + string.Join(", ", others);
                coworkingPresenceLabel.Visible = true;
            }
            else
            {
                coworkingPresenceLabel.Visible = false;
            }
        }
    }
}
