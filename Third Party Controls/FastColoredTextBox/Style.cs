﻿using System.Drawing;
using System;
using System.Drawing.Drawing2D;

namespace FastColoredTextBoxNS
{
    /// <summary>
    /// Style of chars
    /// </summary>
    /// <remarks>This is base class for all text and design renderers</remarks>
    public abstract class Style : IDisposable
    {
        /// <summary>
        /// This style is exported to outer formats (HTML for example)
        /// </summary>
        public virtual bool IsExportable { get; set; }
        /// <summary>
        /// Occurs when user click on StyleVisualMarker joined to this style 
        /// </summary>
        public event EventHandler<VisualMarkerEventArgs> VisualMarkerClick;

        /// <summary>
        /// Constructor
        /// </summary>
        public Style()
        {
            IsExportable = true;
        }

        /// <summary>
        /// Renders given range of text
        /// </summary>
        /// <param name="gr">Graphics object</param>
        /// <param name="position">Position of the range in absolute control coordinates</param>
        /// <param name="range">Rendering range of text</param>
        public abstract void Draw(Graphics gr, Point position, Range range);

        /// <summary>
        /// Occurs when user click on StyleVisualMarker joined to this style 
        /// </summary>
        public virtual void OnVisualMarkerClick(FastColoredTextBox tb, VisualMarkerEventArgs args)
        {
            if (VisualMarkerClick != null)
                VisualMarkerClick(tb, args);
        }

        /// <summary>
        /// Shows VisualMarker
        /// Call this method in Draw method, when you need to show VisualMarker for your style
        /// </summary>
        protected virtual void AddVisualMarker(FastColoredTextBox tb, StyleVisualMarker marker)
        {
            tb.AddVisualMarker(marker);
        }

        public static Size GetSizeOfRange(Range range)
        {
            return new Size((range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
        }

        public static GraphicsPath GetRoundedRectangle(Rectangle rect, int d)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddArc(rect.X, rect.Y, d, d, 180, 90);
            gp.AddArc(rect.X + rect.Width - d, rect.Y, d, d, 270, 90);
            gp.AddArc(rect.X + rect.Width - d, rect.Y + rect.Height - d, d, d, 0, 90);
            gp.AddArc(rect.X, rect.Y + rect.Height - d, d, d, 90, 90);
            gp.AddLine(rect.X, rect.Y + rect.Height - d, rect.X, rect.Y + d / 2);

            return gp;
        }

        public virtual void Dispose()
        {
            ;
        }
    }

    /// <summary>
    /// Style for chars rendering
    /// This renderer can draws chars, with defined fore and back colors
    /// </summary>
    public class TextStyle : Style
    {
        public Brush ForeBrush { get; set; }
        public Brush BackgroundBrush { get; set; }
        public FontStyle FontStyle { get; set; }
        //public readonly Font Font;
        public StringFormat stringFormat;

        public TextStyle(Brush foreBrush, Brush backgroundBrush, FontStyle fontStyle)
        {
            this.ForeBrush = foreBrush;
            this.BackgroundBrush = backgroundBrush;
            this.FontStyle = fontStyle;
            stringFormat = new StringFormat(StringFormatFlags.MeasureTrailingSpaces);
        }

        public override void Draw(Graphics gr, Point position, Range range)
        {
            //draw background
            if (BackgroundBrush != null)
                gr.FillRectangle(BackgroundBrush, position.X, position.Y, (range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
            //draw chars
            Font f = new Font(range.tb.Font, FontStyle);
            //Font fHalfSize = new Font(range.tb.Font.FontFamily, f.SizeInPoints/2, FontStyle);
            Line line = range.tb[range.Start.iLine];
            float dx = range.tb.CharWidth;
            float y = position.Y + range.tb.LineInterval / 2;
            float x = position.X - range.tb.CharWidth/3;

            if(ForeBrush == null)
                ForeBrush = new SolidBrush(range.tb.ForeColor);

            //IME mode
            if (range.tb.ImeAllowed)
            for (int i = range.Start.iChar; i < range.End.iChar; i++)
            {
                SizeF size = FastColoredTextBox.GetCharSize(f, line[i].c);
                
                var gs = gr.Save();
                float k = size.Width>range.tb.CharWidth + 1?range.tb.CharWidth / size.Width:1;
                gr.TranslateTransform(x, y+(1-k)*range.tb.CharHeight/2);
                gr.ScaleTransform(k, (float)Math.Sqrt(k));
                gr.DrawString(line[i].c.ToString(), f, ForeBrush, 0, 0, stringFormat);
                gr.Restore(gs);
                /*
                if(size.Width>range.tb.CharWidth*1.5f)
                    gr.DrawString(line[i].c.ToString(), fHalfSize, foreBrush, x, y+range.tb.CharHeight/4, stringFormat);
                else
                    gr.DrawString(line[i].c.ToString(), f, foreBrush, x, y, stringFormat);
                 * */
                x += dx;
            }
            else
            //classic mode 
            for (int i = range.Start.iChar; i < range.End.iChar; i++)
            {
                //draw char
                gr.DrawString(line[i].c.ToString(), f, ForeBrush, x, y, stringFormat);
                x += dx;
            }
            //
            f.Dispose();
        }

        public override void Dispose()
        {
            base.Dispose();
            
            if(ForeBrush!=null)
                ForeBrush.Dispose();
            if(BackgroundBrush!=null)
                BackgroundBrush.Dispose();
        }
    }

    /// <summary>
    /// Renderer for folded block
    /// </summary>
    public class FoldedBlockStyle : TextStyle
    {
        public FoldedBlockStyle(Brush foreBrush, Brush backgroundBrush, FontStyle fontStyle):
            base(foreBrush, backgroundBrush, fontStyle)
        {
        }

        public override void Draw(Graphics gr, Point position, Range range)
        {
            if (range.End.iChar > range.Start.iChar)
            {
                base.Draw(gr, position, range);

                int firstNonSpaceSymbolX = position.X;
                
                //find first non space symbol
                for (int i = range.Start.iChar; i < range.End.iChar; i++)
                    if (range.tb[range.Start.iLine][i].c != ' ')
                        break;
                    else
                        firstNonSpaceSymbolX += range.tb.CharWidth;

                //create marker
                range.tb.AddVisualMarker(new FoldedAreaMarker(range.Start.iLine, new Rectangle(firstNonSpaceSymbolX, position.Y, position.X + (range.End.iChar - range.Start.iChar) * range.tb.CharWidth - firstNonSpaceSymbolX, range.tb.CharHeight)));
            }
            else
            {
                //draw '...'
                using(Font f = new Font(range.tb.Font, FontStyle))
                    gr.DrawString("...", f, ForeBrush, range.tb.LeftIndent, position.Y - 2);
                //create marker
                range.tb.AddVisualMarker(new FoldedAreaMarker(range.Start.iLine, new Rectangle(range.tb.LeftIndent + 2, position.Y, 2 * range.tb.CharHeight, range.tb.CharHeight)));
            }
        }
    }

    /// <summary>
    /// Renderer for selection area
    /// </summary>
    public class SelectionStyle : Style
    {
        public Brush BackgroundBrush{get;set;}

        public override bool IsExportable
        {
            get{return false;}  set{}
        }

        public SelectionStyle(Brush backgroundBrush)
        {
            this.BackgroundBrush = backgroundBrush;
        }

        public override void Draw(Graphics gr, Point position, Range range)
        {
            //draw background
            if (BackgroundBrush != null)
            {
                Rectangle rect = new Rectangle(position.X, position.Y, (range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
                if (rect.Width == 0)
                    return;
                gr.FillRectangle(BackgroundBrush, rect);
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            if (BackgroundBrush != null)
                BackgroundBrush.Dispose();
        }
    }

    /// <summary>
    /// Marker style
    /// Draws background color for text
    /// </summary>
    public class MarkerStyle : Style
    {
        public Brush BackgroundBrush{get;set;}

        public MarkerStyle(Brush backgroundBrush)
        {
            this.BackgroundBrush = backgroundBrush;
            IsExportable = false;
        }

        public override void Draw(Graphics gr, Point position, Range range)
        {
            //draw background
            if (BackgroundBrush != null)
            {
                Rectangle rect = new Rectangle(position.X, position.Y, (range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
                if (rect.Width == 0)
                    return;
                //var path = GetRoundedRectangle(rect, 5);
                //gr.FillPath(BackgroundBrush, path);
                gr.FillRectangle(BackgroundBrush, rect);
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            if (BackgroundBrush != null)
                BackgroundBrush.Dispose();
        }
    }

    public class ShortcutStyle : Style
    {
        public Pen borderPen;

        public ShortcutStyle(Pen borderPen)
        {
            this.borderPen = borderPen;
        }

        public override void Draw(Graphics gr, Point position, Range range)
        {
            //get last char coordinates
            Point p = range.tb.PlaceToPoint(range.End);
            //draw small square under char
            Rectangle rect = new Rectangle(p.X - 5, p.Y + range.tb.CharHeight - 3, 4, 3);
            gr.FillPath(Brushes.White, GetRoundedRectangle(rect, 1));
            gr.DrawPath(borderPen, GetRoundedRectangle(rect, 1));
            //add visual marker for handle mouse events
            AddVisualMarker(range.tb, new StyleVisualMarker(new Rectangle(p.X-range.tb.CharWidth, p.Y, range.tb.CharWidth, range.tb.CharHeight), this));
        }

        public override void Dispose()
        {
            base.Dispose();

            if (borderPen != null)
                borderPen.Dispose();
        }
    }
}
