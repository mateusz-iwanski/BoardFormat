using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{ 
    /// <summary>
    /// Represents a centered text drawer that can draw text within a specified rectangle.
    /// </summary>
    public class CenteredText : TextDrawer
    {
        PieceToDraw Piece { get; set; }
        public string Text { get; set; }
        public bool RotateText { get; set; }

        public Color? TextFontColor { get; set; } = Color.FromRgb(0, 255, 0);  // color of text
        public float TextFontSize { get; set; } = 15.0f;  // text size


        /// <summary>
        /// Initializes a new instance of the CenteredText class.
        /// </summary>
        /// <param name="text">The text to be drawn.</param>
        /// <param name="startX">The widthRange-coordinate of the starting point of the rectangle.</param>
        /// <param name="startY">The lengthRange-coordinate of the starting point of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="rotateWhenLength">Specifies whether to rotate the text when its length is smaller than the length of the rectangle.</param>
        /// <param name="fontColor">The color of the font.</param>
        /// <param name="fontSize">The size of the font.</param>
        public CenteredText(
            ShapeDrawer shape,
            PieceToDraw piece,
            bool rotateWhenLength = true,
            Color? fontColor = null, float? fontSize = null
            ) : base(
                x: shape.StartX, y: shape.StartY, 
                width: shape.Width, height: shape.Height, 
                fontColor: fontColor, fontSize: fontSize
                )
        {
            RotateText = rotateWhenLength;
            Format.FontColor = fontColor ?? TextFontColor;
            Format.FontSize = fontSize ?? TextFontSize;     
            Piece = piece;

        }

        /// <summary>
        /// Draw the centered text on the specified canvas.
        /// </summary>
        /// <param name="canvas">The canvas to draw on.</param>
        public override void Draw(ICanvas canvas)
        {
            // Calculate the center of the rectangle
            var centerX = StartX + Width / 2;
            var centerY = StartY + Height / 2;

            //Rotate the text if it is too long
            //if (RotateText)
            //{
            //    if (TextMeassure(Text).Item1 > widthRange - 10)
            //    {
            //        canvas.Rotate(90, centerX, centerY);
            //        canvas.ResetState();
            //    }
            //}

            // Resize the font if the text is too long
            //if (TextMeassure(Text).Item1 > widthRange - 10)
            //{
            //    Format.FontSize = (widthRange / 5);
            //    canvas.ResetState();
            //}

            // Make format for the text
            Format.FormatCanvas(canvas);

            // Draw the text
            canvas.DrawString(
                Piece.Identifier,
                centerX, centerY,
                HorizontalAlignment.Center
                );
        }

    }
}
