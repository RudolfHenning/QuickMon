﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FastColoredTextBoxNS
{
    public class VisualMarker
    {
        public readonly Rectangle rectangle;

        public VisualMarker(Rectangle rectangle)
        {
            this.rectangle = rectangle;
        }

        public virtual void Draw(Graphics gr, Pen pen)
        {
        }

        public virtual Cursor Cursor
        {
            get { return Cursors.Hand; }
        }
    }

    class CollapseFoldingMarker: VisualMarker
    {
        public readonly int iLine;

        public CollapseFoldingMarker(int iLine, Rectangle rectangle)
            : base(rectangle)
        {
            this.iLine = iLine;
        }

        public override void Draw(Graphics gr, Pen pen)
        {
            //draw minus
            gr.FillRectangle(Brushes.White, rectangle);
            gr.DrawRectangle(pen, rectangle);
            gr.DrawLine(pen, rectangle.Left + 2, rectangle.Top + rectangle.Height / 2, rectangle.Right - 2, rectangle.Top + rectangle.Height / 2);
        }
    }

    class ExpandFoldingMarker : VisualMarker
    {
        public readonly int iLine;

        public ExpandFoldingMarker(int iLine, Rectangle rectangle)
            : base(rectangle)
        {
            this.iLine = iLine;
        }

        public override void Draw(Graphics gr, Pen pen)
        {
            //draw plus
            gr.FillRectangle(Brushes.White, rectangle);
            gr.DrawRectangle(pen, rectangle);
            gr.DrawLine(Pens.Red, rectangle.Left + 2, rectangle.Top + rectangle.Height / 2, rectangle.Right - 2, rectangle.Top + rectangle.Height / 2);
            gr.DrawLine(Pens.Red, rectangle.Left + rectangle.Width / 2, rectangle.Top + 2, rectangle.Left + rectangle.Width / 2, rectangle.Bottom - 2);
        }
    }

    class FoldedAreaMarker : VisualMarker
    {
        public readonly int iLine;

        public FoldedAreaMarker(int iLine, Rectangle rectangle)
            : base(rectangle)
        {
            this.iLine = iLine;
        }

        public override void Draw(Graphics gr, Pen pen)
        {
            gr.DrawRectangle(pen, rectangle);
        }
    }

    public class StyleVisualMarker : VisualMarker
    {
        public Style Style{get;private set;}

        public StyleVisualMarker(Rectangle rectangle, Style style)
            : base(rectangle)
        {
            this.Style = style;
        }
    }

    public class VisualMarkerEventArgs : MouseEventArgs
    {
        public Style Style { get; private set; }
        public StyleVisualMarker Marker { get; private set; }

        public VisualMarkerEventArgs(Style style, StyleVisualMarker marker, MouseEventArgs args)
            : base(args.Button, args.Clicks, args.X, args.Y, args.Delta)
        {
            this.Style = style;
            this.Marker = marker;
        }
    }
}
