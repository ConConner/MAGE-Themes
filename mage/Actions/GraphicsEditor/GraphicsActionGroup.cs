using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Actions.GraphicsEditor;

internal class GraphicsActionGroup : GraphicsAction
{
    private List<GraphicsAction> actions = new List<GraphicsAction>();

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
            string text = actions[0].ActionText;
            if (actions.Count > 1) text += $" ({actions.Count})";
            return text;
        }
    }

    public void AddAction(GraphicsAction action)
    {
        actions.Add(action);
    }

    public override void Do() { foreach (var a in actions) a.Do(); }
    public override void Undo()
    {
        actions.Reverse();
        foreach (var a in actions) a.Undo();
        actions.Reverse();
    }
}
