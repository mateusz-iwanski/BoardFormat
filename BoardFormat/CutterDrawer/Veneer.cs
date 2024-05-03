using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    /// <summary>
    /// Draw veneer inside the shape
    /// </summary>
    public class Veneer : ShapeDrawer
    {        
        PieceToDraw Piece { get; set; }
        /// <summary>
        /// Margin between the veneer and the edge of the shape
        /// </summary>
        public int Margin { get; set; } = 3;
        /// <summary>
        /// Line size reduce to draw the veneer inside the shape
        /// </summary>
        public int LineSizeReduce { get; set; } = 3;
        /// <summary>
        /// Change the line style to dashed
        /// </summary>
        public float[] DashedLine { get; set; } = new float[] { 5, 5 }; // dashed line pattern
        public Color StrokeColor { get; set; } = Color.FromRgb(255, 51, 0);  // color of veneer line
        public float StrokeSize { get; set; } = 1.5f;  // size of veneer line

        public Veneer(
            ShapeDrawer shape,
            PieceToDraw piece,
            float[]? dashedLine = null,
            int? lineSizeReduce = null,
            int? margin = null,
            Color? strokeColor = null, float? strokeSize = null
            ) : base(
                    startX: shape.StartX, startY: shape.StartY,
                    width: shape.Width, height: shape.Height
                )
        {
            Piece = piece;
            Margin = margin ?? Margin;
            LineSizeReduce = lineSizeReduce ?? LineSizeReduce;
            
            DashedLine = dashedLine ?? DashedLine;
            Format.StrokeColor = strokeColor ?? StrokeColor;
            Format.StrokeSize = strokeSize ?? StrokeSize;

            return;
        }

        public override void SetFormat(ICanvas canvas)
        {
            base.SetFormat(canvas);
            canvas.StrokeDashPattern = DashedLine;
        }

        public override void Draw(ICanvas canvas)
        {
            //Format.FormatCanvas(canvas);
            SetFormat(canvas);

            if (Piece.TopVeneer)
            {
                canvas.DrawLine(
                    StartX + Margin + LineSizeReduce, StartY + Margin,
                    StartX + Width - Margin - LineSizeReduce, StartY + Margin
                    );
            }
            if (Piece.RightVeneer)
            {
                canvas.DrawLine(
                    StartX + Width - Margin, StartY + Margin + LineSizeReduce,
                    StartX + Width - Margin, StartY + Height - Margin - LineSizeReduce
                    );
            }
            if (Piece.BottomVeneer)
            {
                canvas.DrawLine(
                    StartX + Margin + LineSizeReduce, StartY + Height - Margin,
                    StartX + Width - Margin - +LineSizeReduce, StartY + Height - Margin
                    );
            }
            if (Piece.LeftVeneer)
            {
                canvas.DrawLine(
                    StartX + Margin, StartY + Margin + LineSizeReduce,
                    StartX + Margin, StartY + Height - Margin - LineSizeReduce
                    );
            }

            canvas.StrokeDashPattern = null;
        }
    }
}
