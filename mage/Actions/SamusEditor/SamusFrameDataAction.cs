using mage.Actions.OamEditor;
using System;
using System.Drawing;

namespace mage.Actions.SamusEditor;

/// <summary>
/// Changes which graphics and OAM a frame of a Samus animation uses
/// </summary>
public class SamusFrameDataAction : OamAction
{
    private readonly SamusAnimation animation;
    private readonly SamusGfx oldTop, oldBottom, newTop, newBottom;
    private readonly SamusOamData oldOam, newOam;
    private readonly string actionText;

    public override int FrameIndex { get; set; }
    public override Action? DoUndoRun { get; set; } = null;

    public SamusFrameDataAction(SamusAnimation animation, int frameIndex, SamusGfx top, SamusGfx bottom, SamusOamData oam, string actionText)
    {
        this.animation = animation;
        FrameIndex = frameIndex;
        SamusFrame frame = animation.Frames[frameIndex];
        oldTop = frame.Top;
        oldBottom = frame.Bottom;
        oldOam = frame.Oam;
        newTop = top;
        newBottom = bottom;
        newOam = oam;
        this.actionText = actionText;
    }

    public override Rectangle AffectedRegion => Rectangle.Empty;

    public override string ActionText => actionText;

    private void Apply(SamusGfx top, SamusGfx bottom, SamusOamData oam)
    {
        SamusFrame frame = animation.Frames[FrameIndex];
        frame.Top = top;
        frame.Bottom = bottom;
        animation.SetFrameOam(FrameIndex, oam);
        DoUndoRun?.Invoke();
    }

    public override void Do() => Apply(newTop, newBottom, newOam);

    public override void Undo() => Apply(oldTop, oldBottom, oldOam);
}
