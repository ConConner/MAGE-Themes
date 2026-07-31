using System;
using System.Collections.Generic;
using System.Text;

namespace mage.Actions;

public class GenericUndoRedo
{
    public DropOutStack<EditorGridAction> UndoStack { get { return undoStack; } }
    public DropOutStack<EditorGridAction> RedoStack { get { return redoStack; } }
    public bool CanUndo { get { return undoStack.Count > 0; } }
    public bool CanRedo { get { return redoStack.Count > 0; } }

    // fields
    private DropOutStack<EditorGridAction> undoStack;
    private DropOutStack<EditorGridAction> redoStack;

    // constructor
    public GenericUndoRedo()
    {
        undoStack = new DropOutStack<EditorGridAction>();
        redoStack = new DropOutStack<EditorGridAction>();
    }

    public void AddActionWithoutDo(EditorGridAction a)
    {
        redoStack.Clear();
        undoStack.Push(a);
    }

    public EditorGridAction Undo()
    {
        EditorGridAction a = undoStack.Pop();
        a.Undo();
        redoStack.Push(a);
        return a;
    }

    public EditorGridAction Redo()
    {
        EditorGridAction a = redoStack.Pop();
        a.Do();
        undoStack.Push(a);
        return a;
    }
}
