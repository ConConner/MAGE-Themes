using System;
using System.Collections.Generic;
using System.Text;

namespace mage.Actions.GraphicsEditor;

public class GraphicsUndoRedo
{
    public DropOutStack<GraphicsAction> UndoStack { get { return undoStack; } }
    public DropOutStack<GraphicsAction> RedoStack { get { return redoStack; } }
    public bool CanUndo { get { return undoStack.Count > 0; } }
    public bool CanRedo { get { return redoStack.Count > 0; } }

    // fields
    private DropOutStack<GraphicsAction> undoStack;
    private DropOutStack<GraphicsAction> redoStack;

    // constructor
    public GraphicsUndoRedo()
    {
        undoStack = new DropOutStack<GraphicsAction>();
        redoStack = new DropOutStack<GraphicsAction>();
    }

    public void AddActionWithoutDo(GraphicsAction a)
    {
        redoStack.Clear();
        undoStack.Push(a);
    }

    public GraphicsAction Undo()
    {
        GraphicsAction a = undoStack.Pop();
        a.Undo();
        redoStack.Push(a);
        return a;
    }

    public GraphicsAction Redo()
    {
        GraphicsAction a = redoStack.Pop();
        a.Do();
        undoStack.Push(a);
        return a;
    }
}
