using System;

namespace mage.Actions.RoomEditor
{
    public class RoomUndoRedo
    {
        public DropOutStack<RoomAction> UndoStack { get { return undoStack; } }
        public DropOutStack<RoomAction> RedoStack { get { return redoStack; } }
        public bool CanUndo { get { return undoStack.Count > 0; } }
        public bool CanRedo { get { return redoStack.Count > 0; } }

        // fields
        private DropOutStack<RoomAction> undoStack;
        private DropOutStack<RoomAction> redoStack;

        // constructor
        public RoomUndoRedo()
        {
            undoStack = new DropOutStack<RoomAction>();
            redoStack = new DropOutStack<RoomAction>();
        }

        public void Do(RoomAction a, Room room)
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

        public RoomAction Undo(Room room)
        {
            RoomAction a = undoStack.Pop();
            a.Undo(room);
            redoStack.Push(a);
            return a;
        }

        public RoomAction Redo(Room room)
        {
            RoomAction a = redoStack.Pop();
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
        }

    }
}
