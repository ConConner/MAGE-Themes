using System;
using System.Collections.Generic;
using System.Text;

namespace mage.Actions;

public class GenericUndoRedo
{
    public DropOutStack<GenericEditorAction> UndoStack { get { return undoStack; } }
    public DropOutStack<GenericEditorAction> RedoStack { get { return redoStack; } }
    public bool CanUndo { get { return undoStack.Count > 0; } }
    public bool CanRedo { get { return redoStack.Count > 0; } }

    // fields
    private DropOutStack<GenericEditorAction> undoStack;
    private DropOutStack<GenericEditorAction> redoStack;

    // constructor
    public GenericUndoRedo()
    {
        undoStack = new DropOutStack<GenericEditorAction>();
        redoStack = new DropOutStack<GenericEditorAction>();
    }

    public void AddActionWithoutDo(GenericEditorAction a)
    {
        redoStack.Clear();
        undoStack.Push(a);
    }

    public GenericEditorAction Undo()
    {
        GenericEditorAction a = undoStack.Pop();
        a.Undo();
        redoStack.Push(a);
        return a;
    }

    public GenericEditorAction Redo()
    {
        GenericEditorAction a = redoStack.Pop();
        a.Do();
        undoStack.Push(a);
        return a;
    }
}
