using mage.Networking;
using MageNet.Data;
using MageNet.IO;
using MageNet.Packets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Text.Json;

namespace mage
{
    public class UndoRedo
    {
        public DropOutStack<Action> UndoStack { get { return undoStack; } }
        public DropOutStack<Action> RedoStack { get { return redoStack; } }
        public bool CanUndo { get { return undoStack.Count > 0; } }
        public bool CanRedo { get { return redoStack.Count > 0; } }

        // fields
        private DropOutStack<Action> undoStack;
        private DropOutStack<Action> redoStack;

        // constructor
        public UndoRedo()
        {
            undoStack = new DropOutStack<Action>();
            redoStack = new DropOutStack<Action>();
        }

        public void Do(Action a, Room room)
        {
            a.Do(room);
            redoStack.Clear();
            if (undoStack.Count != 0 && a.combine)
            {
                if (!undoStack.Peek().TryCombine(a))
                {
                    undoStack.Push(a);
                }
            }
            else
            {
                undoStack.Push(a);
            }
        }

        public Action Undo(Room room)
        {
            Action a = undoStack.Pop();
            a.Undo(room);
            redoStack.Push(a);
            return a;
        }

        public Action Redo(Room room)
        {
            Action a = redoStack.Pop();
            a.Do(room);
            undoStack.Push(a);
            return a;
        }

        public void FinalizePreviousAction()
        {
            if (undoStack.Count > 0)
            {
                undoStack.Peek().combine = false;
            }
            SendActionToServer();
        }

        private void SendActionToServer()
        {
            if (!Session.InSession) return;

            //Serialize the current action
            Action a = undoStack.Peek();

            //Check action type
            if (a is EditBlocks)
            {
                EditBlocks action = a as EditBlocks;

                //Convert all the changed blocks in the action
                List<BlockChange> changes = new();
                foreach (KeyValuePair<Point, Block> kvp in action.oldBlocks)
                {
                    BlockChange b = new BlockChange()
                    {
                        BG0 = kvp.Value.BG0,
                        BG1 = kvp.Value.BG1,
                        BG2 = kvp.Value.BG2,
                        Clip = kvp.Value.CLP,
                        Location = kvp.Key
                    };

                    changes.Add(b);
                }

                TileChange tc = new TileChange(FormMain.MainWindow.Room.AreaID, FormMain.MainWindow.Room.RoomID, changes);
                Packet p = new Packet(PacketType.TileChange, tc);
                _ = Session.SessionClient.SendPacketToServerAsync(p);
            }

            //TODO: Handle other actions here
        }
    }
}
