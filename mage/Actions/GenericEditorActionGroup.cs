using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Actions;

internal class GenericEditorActionGroup : GenericEditorAction
{
    private List<GenericEditorAction> actions = new List<GenericEditorAction>();
    private string? _actionText;

    public GenericEditorActionGroup(string? actionText = null)
    {
        _actionText = actionText;
    }

    public override Rectangle AffectedRegion
    {
        get
        {
            Rectangle rect = Rectangle.Empty;
            foreach (var a in actions)
            {
                rect = Rectangle.Union(rect, a.AffectedRegion);
            }
            return rect;
        }
    }

    public override string ActionText => _actionText ?? actions[actions.Count - 1].ActionText;

    public void AddAction(GenericEditorAction action)
    {
        actions.Add(action);
    }

    public void SetActions(List<GenericEditorAction> actions)
    {
        this.actions = actions ?? new List<GenericEditorAction>();
    }

    public int ActionCount => actions.Count;

    public override void Do() { foreach (var a in actions) a.Do(); }
    public override void Undo()
    {
        actions.Reverse();
        foreach (var a in actions) a.Undo();
        actions.Reverse();
    }
}
