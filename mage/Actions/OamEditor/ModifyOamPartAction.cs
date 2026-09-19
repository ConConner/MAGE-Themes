using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Actions.OamEditor;

public class ModifyOamPartAction : GenericEditorAction
{
    private OAM.Frame frame;
    private int partIndex;
    private OAM.Part oldPart;
    private OAM.Part newPart;
    private string? actionText;

    public ModifyOamPartAction(OAM.Frame frame, int partIndex, OAM.Part part, string? actionText = null)
    {
        this.frame = frame;
        this.partIndex = partIndex;
        this.newPart = part;

        this.actionText = actionText;

        oldPart = frame.parts[partIndex];
    }

    public override Rectangle AffectedRegion => throw new NotImplementedException();

    public override string ActionText => actionText ?? "Modified Part";

    public override void Do()
    {
        frame.parts[partIndex] = newPart;
    }

    public override void Undo()
    {
        frame.parts[partIndex] = oldPart;
    }
}
