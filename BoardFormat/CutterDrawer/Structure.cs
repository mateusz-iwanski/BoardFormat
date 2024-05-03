using BoardFormat.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    public class Structure : ShapeDrawer
    {
        PieceToDraw Piece { get; set; }
        public Color StrokeColor { get; set; } = Color.FromRgb(221, 213, 213);  // color of structure lines
        public float StrokeSize { get; set; } = 1f;  // size of structure lines       
        public int SpacesBetweenLine { get; set; } = 5;  // spaces between line


        public Structure(
            ShapeDrawer shape,
            PieceToDraw piece,
            int? spacesBetweenLine = null,
            Color? strokeColor = null, float? strokeSize = null
            ) : base(
                    startX: shape.StartX, startY: shape.StartY,
                    width: shape.Width, height: shape.Height
                )
        {
            Piece = piece;
            Format.StrokeColor = strokeColor ?? StrokeColor;
            Format.StrokeSize = strokeSize ?? StrokeSize;
            SpacesBetweenLine = spacesBetweenLine ?? SpacesBetweenLine;
            return;
        }

        public override void Draw(ICanvas canvas)
        {

            if (Piece.BoardHasStructure)
            {
                //Format.FormatCanvas(canvas);
                base.SetFormat(canvas);

                if (Piece.Rotated)
                {                    

                    // Draw the vertical lines
                    for (float i = StartX; i <= StartX + Width; i += SpacesBetweenLine)
                    {
                        // Calculate the start and end points of the line
                        var startY = StartY;
                        var endY = StartY + Height;

                        // Draw the line
                        canvas.DrawLine(i, startY, i, endY);
                    }
                }
                else
                {
                    // Draw the horizontal lines
                    for (float i = StartY; i <= StartY + Height; i += SpacesBetweenLine)
                    {
                        // Calculate the start and end points of the line
                        var startX = StartX;
                        var endX = StartX + Width;

                        // Draw the line
                        canvas.DrawLine(startX, i, endX, i);
                    }
                }
            }

        }
    }
}
