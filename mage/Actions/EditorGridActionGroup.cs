using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Actions;

internal class EditorGridActionGroup : EditorGridAction
{
    private List<EditorGridAction> actions = new List<EditorGridAction>();

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

    public override string ActionText
    {
        get
        {
            string text = actions[actions.Count - 1].ActionText;
            return text;
        }
    }

    public void AddAction(EditorGridAction action)
    {
        actions.Add(action);
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
