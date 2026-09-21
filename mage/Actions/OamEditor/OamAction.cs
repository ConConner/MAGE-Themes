using System;
using System.Collections.Generic;
using System.Text;

namespace mage.Actions.OamEditor;

public abstract class OamAction : GenericEditorAction
{
    public abstract int FrameIndex { get; set; }
    public abstract Action? DoUndoRun { get; set; }
}
