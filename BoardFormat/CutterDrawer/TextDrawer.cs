using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SkiaSharp;

namespace BoardFormat.CutterDrawer
{
    public abstract class TextDrawer : ShapeDrawer
    {
        // Default Value
        // override inherited value
        public TextFormat Format = new TextFormat(
            fontColor: Color.FromRgb(0, 0, 0), // Set RGBA values for black color
            fontSize: 12.0f
            );

        public TextDrawer(
            float x, float y,
            float width, float height,
            Color? fontColor = null, 
            float? fontSize = null
            ) : base(
                    startX: x, startY: y,
                    width: width, height: height
                )
        {
            Format.FontColor = fontColor ?? Format.FontColor;
            Format.FontSize = fontSize ?? Format.FontSize;
        }

        /// <summary>
        /// Meassure the text width and height
        /// </summary>
        /// <param name="text">text to measure</param>
        /// <returns>(widthRange, GetHeight)</returns>
        public (float, float) TextMeassure(string text)
        {
            var paint = new SKPaint
            {
                TextSize = Format.FontSize
            };
            var bounds = new SKRect();
            paint.MeasureText(text, ref bounds);

            return (bounds.Width, bounds.Height);
        }

        public override abstract void Draw(ICanvas canvas);
    }
}
