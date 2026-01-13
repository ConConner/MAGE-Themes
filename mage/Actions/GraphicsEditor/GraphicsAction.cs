using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Actions.GraphicsEditor;

public abstract class GraphicsAction
{
    public abstract Rectangle AffectedRegion { get; }

    public abstract void Do();

    public abstract void Undo();

    public abstract string ActionText { get; }
}
