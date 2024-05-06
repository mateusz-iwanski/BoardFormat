using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    /// <summary>
    /// Draw size width and height of the cabinetPiece inside rectangle.
    /// Draw on the center left and center top side of the rectangle.
    /// </summary>
    public class DimensionText : TextDrawer
    {
        private PieceToDraw Piece { get; set; }
        public string HeightText { get; set; }
        public string LengthText { get; set; }
        public int Margin { get; set; }
        public Color? TextFontColor { get; set; } = Color.FromRgb(0, 255, 0);  // color of text
        public float TextFontSize { get; set; } = 15.0f;  // text size
        public int TextMargin { get; set; } = 8;  // margin between text and shape


        public DimensionText(
            ShapeDrawer shape,
            PieceToDraw piece,
            int? margin = null,
            Color? fontColor = null, float? fontSize = null
            ) : base(
                x: shape.StartX, y: shape.StartY,
                width: shape.Width, height: shape.Height,
                fontColor: fontColor, fontSize: fontSize
                )
        {
            Piece = piece;
            HeightText = (((int)Piece.Width) * 10).ToString();
            LengthText = (((int)Piece.Length) * 10).ToString();
            Margin = margin ?? TextMargin;
            Format.FontColor = fontColor ?? TextFontColor;
            Format.FontSize = fontSize ?? TextFontSize;
            return;
        }

        private void DrawWidth(ICanvas canvas)
        {
            // make format for the text
            Format.FormatCanvas(canvas);

            // Calculate the center of the rectangle
            var centerX = StartX + Margin;// + widthRange / 2;
            var centerY = StartY + Height / 2;

            // Rotate the canvas
            canvas.Rotate(90, centerX, centerY);
            // Draw the text
            canvas.DrawString(LengthText, centerX, centerY, HorizontalAlignment.Center);
        }

        private void DrawLength(ICanvas canvas)
        {
            Format.FormatCanvas(canvas);

            // Calculate the center of the rectangle
            var centerX = StartX + Width / 2;
            var centerY = StartY + Margin * 2;

            // Draw the text
            canvas.DrawString(HeightText, centerX, centerY, HorizontalAlignment.Center);
        }

        public override void Draw(ICanvas canvas)
        {
            // make format for the text
            Format.FormatCanvas(canvas);

            // Save the current state of the canvas
            canvas.SaveState();

            DrawLength(canvas);
            DrawWidth(canvas);

            // Restore the state of the canvas
            canvas.RestoreState();
        }
    }
}
