using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace mage
{
    public partial class OamView : Control
    {
        /// <summary>
        /// A group of objects that represent a colored rectangle on the OamView.
        /// </summary>
        /// <param name="Rectangle">The rectangle to draw</param>
        /// <param name="DrawPen">The color and stroke width to use</param>
        /// <param name="indent">a value that is applied to the width and height of the rectangle AFTER its zoomed</param>
        public record Drawable(Rectangle Rectangle, Pen DrawPen, int indent = 0)
        {
            public Rectangle Rectangle { get; set; } = Rectangle;
            public Pen DrawPen { get; set; } = DrawPen;
            public int Indent { get; set; } = indent;
            public bool Visible { get; set; } = true;
        }


        // Properties
        public List<Drawable> Drawables { get; private set; } = new();
        public bool DisplayOrigin { get; set; } = true;
        public Image OamImage
        {
            get => BackgroundImage;
            set
            {
                if (BackgroundImage != null) BackgroundImage.Dispose();
                BackgroundImage = value;
                ScaleImage();
            }
        }


        public int Zoom
        {
            get => zoom;
            set
            {
                zoom = value;
                if (BackgroundImage == null) return;
                ScaleImage();
            }
        }
        private int zoom = 0;

        public OamView()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            BackgroundImageLayout = ImageLayout.Stretch;
            TabStop = false;

            Drawables.Clear();
        }


        private Rectangle ScaleDrawable(Drawable drawable)
        {
            Rectangle r = drawable.Rectangle;
            r.Size = new Size((r.Width << Zoom) + drawable.Indent, (r.Height << Zoom) + drawable.Indent);
            r.Location = new Point(r.X << Zoom, r.Y << Zoom);
            return r;
        }

        public void ResetDrawables()
        {
            Drawables.Clear();
        }

        private void ScaleImage()
        {
            if (BackgroundImage == null) return;
            Size = new Size(BackgroundImage.Width << Zoom, BackgroundImage.Height << Zoom);
        }

        public void InvalidateDrawable(Drawable drawable)
        {
            Rectangle r = ScaleDrawable(drawable);
            r.Inflate(1, 1);
            Invalidate(r);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            foreach (Drawable d in Drawables)
            {
                if (!d.Visible) continue;

                //Scale the rectangle to the zoom level
                Rectangle r = ScaleDrawable(d);

                pe.Graphics.DrawRectangle(d.DrawPen, r);
            }

            Pen p = new Pen(Color.White, 1);

            if (DisplayOrigin)
            {
                pe.Graphics.DrawLine(p, 0, OAM.FrameOriginY << Zoom, OAM.XPosRange << Zoom, OAM.FrameOriginY << Zoom);
                pe.Graphics.DrawLine(p, OAM.FrameOriginX << Zoom, 0, OAM.FrameOriginX << Zoom, OAM.YPosRange << Zoom);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            pevent.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            pevent.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            base.OnPaintBackground(pevent);
        }


    }
}
