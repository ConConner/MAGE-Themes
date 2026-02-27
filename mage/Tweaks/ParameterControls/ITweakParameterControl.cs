using System;
using System.Collections.Generic;
using System.Text;

namespace mage.Tweaks.ParameterControls;

public interface ITweakParameterControl
{
    public long? Value { get; set; }
}
