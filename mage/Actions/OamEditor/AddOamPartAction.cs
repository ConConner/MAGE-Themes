using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Actions.OamEditor;

public class AddOamPartAction : OamAction
{
    private OAM _oam;
    public override int FrameIndex { get; set; }
    private OAM.Part _part;
    private int _insertAt;

    public override Action? DoUndoRun { get; set; } = null;

    public AddOamPartAction(OAM oam, int frameIndex, OAM.Part part, int insertAt)
    {
        _oam = oam;
        FrameIndex = frameIndex;
        _part = part;
        _insertAt = insertAt;
    }

    public override Rectangle AffectedRegion => throw new NotImplementedException();

    public override string ActionText => "Added Part";

    private void OnPartCountChanged()
    {
        DoUndoRun?.Invoke();
    }

    public override void Do()
    {
        OAM.Frame frame = _oam.Frames[FrameIndex];
        frame.parts.Insert(_insertAt, _part);
        frame.numParts++;
        _oam.Frames[FrameIndex] = frame;
        OnPartCountChanged();
    }

    public override void Undo()
    {
        OAM.Frame frame = _oam.Frames[FrameIndex];
        _oam.Frames[FrameIndex].parts.RemoveAt(_insertAt);
        frame.numParts--;
        _oam.Frames[FrameIndex] = frame;
        OnPartCountChanged();
    }
}
