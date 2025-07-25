﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mage.Theming.CustomControls;

using System.Drawing.Drawing2D;
using System.Windows.Forms;

/// <summary>
/// Inherits from PictureBox; adds Interpolation Mode Setting
/// </summary>
public class PictureBoxWithInterpolationMode : PictureBox
{
    public InterpolationMode InterpolationMode { get; set; }

    protected override void OnPaint(PaintEventArgs paintEventArgs)
    {
        paintEventArgs.Graphics.InterpolationMode = InterpolationMode;
        base.OnPaint(paintEventArgs);
    }
}
