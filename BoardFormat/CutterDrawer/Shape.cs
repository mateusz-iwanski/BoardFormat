using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    public abstract class ShapeDrawer
    {
        public float StartX { get; set; }
        public float StartY { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        // Default Value
        public ShapeFormat Format = new ShapeFormat(
            strokeColor: Color.FromRgb(0, 0, 0), // Set RGBA values for black color
            fillColor: Color.FromRgb(255, 255, 255), // Set RGBA values for white color
            strokeSize: 1.0f
            );

        public ShapeDrawer(
            float startX, float startY, float width, float height,
            Color? strokeColor = null, Color? fillColor = null, float? strokeSize = null)
        {
            StartX = startX;
            StartY = startY;
            Width = width;
            Height = height;

            Format.StrokeColor = strokeColor ?? Format.StrokeColor;
            Format.FillColor = fillColor ?? Format.FillColor;
            Format.StrokeSize = strokeSize ?? Format.StrokeSize;
        }

        public abstract void Draw(ICanvas canvas);
        public virtual void SetFormat(ICanvas canvas)
        {
            Format.FormatCanvas(canvas);
        }
    }
}
