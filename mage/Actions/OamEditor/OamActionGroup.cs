using System;
using System.Collections.Generic;
using System.Text;

namespace mage.Actions.OamEditor;

public class OamActionGroup : GenericEditorActionGroup
{
    public Action? DoUndoRun { get; set; } = null;

    public void UpadteIndicesOfActions(int newIndex)
    {
        foreach (var action in actions)
        {
            if (action is OamActionGroup group)
            {
                group.UpadteIndicesOfActions(newIndex);
                continue;
            }
            if (action is not OamAction a) continue;
            a.FrameIndex = newIndex;
        }
    }

    public override void Do()
    {
        base.Do();
        DoUndoRun?.Invoke();
    }

    public override void Undo()
    {
        base.Undo();
        DoUndoRun?.Invoke();
    }
}
