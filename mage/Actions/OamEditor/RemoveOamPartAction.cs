using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Actions.OamEditor;

public class RemoveOamPartAction : OamAction
{
    private OAM _oam;
    public override int FrameIndex { get; set; }
    private OAM.Part _oldPart;
    private int _removeAt;

    public override Action? DoUndoRun { get; set; } = null;

    public RemoveOamPartAction(OAM oam, int frameIndex, int removeAt)
    {
        _oam = oam;
        FrameIndex = frameIndex;
        _removeAt = removeAt;
        _oldPart = oam.Frames[frameIndex].parts[removeAt];
    }

    public override Rectangle AffectedRegion => throw new NotImplementedException();

    public override string ActionText => "Removed Part";

    private void OnPartCountChanged()
    {
        DoUndoRun?.Invoke();
    }

    public override void Undo()
    {
        OAM.Frame frame = _oam.Frames[FrameIndex];
        frame.parts.Insert(_removeAt, _oldPart);
        frame.numParts++;
        _oam.Frames[FrameIndex] = frame;
        OnPartCountChanged();
    }

    public override void Do()
    {
        OAM.Frame frame = _oam.Frames[FrameIndex];
        _oam.Frames[FrameIndex].parts.RemoveAt(_removeAt);
        frame.numParts--;
        _oam.Frames[FrameIndex] = frame;
        OnPartCountChanged();
    }
}
