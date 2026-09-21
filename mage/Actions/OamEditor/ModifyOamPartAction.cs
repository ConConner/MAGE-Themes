using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Actions.OamEditor;

public class ModifyOamPartAction : OamAction
{
    private OAM oam;
    public override int FrameIndex { get; set; }
    private int partIndex;
    private OAM.Part oldPart;
    private OAM.Part newPart;
    private string? actionText;

    public ModifyOamPartAction(OAM oam, int frameIndex, int partIndex, OAM.Part part, string? actionText = null)
    {
        this.oam = oam;
        this.FrameIndex = frameIndex;
        this.partIndex = partIndex;
        this.newPart = part;

        this.actionText = actionText;

        oldPart = oam.Frames[frameIndex].parts[partIndex];
    }

    public override Rectangle AffectedRegion => throw new NotImplementedException();

    public override string ActionText => actionText ?? "Modified Part";

    public override Action? DoUndoRun { get; set; } = null;

    public override void Do()
    {
        oam.Frames[FrameIndex].parts[partIndex] = newPart;
        DoUndoRun?.Invoke();
    }

    public override void Undo()
    {
        oam.Frames[FrameIndex].parts[partIndex] = oldPart;
        DoUndoRun?.Invoke();
    }
}
