using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    /// <summary>
    /// Mark waste/rest/unused cabinetPiece
    /// Add element inside rectangle
    /// </summary>
    public class WasteMark : ShapeDrawer
    {
        public WasteMark(
            ShapeDrawer shape,            
            Color? strokeColor = null, float? strokeSize = null
            ) : base(
                    startX: shape.StartX, startY: shape.StartY,
                    width: shape.Width, height: shape.Height,
                    strokeColor: strokeColor, fillColor: null,
                    strokeSize: strokeSize
                )
        {
            return;
        }

        public override void Draw(ICanvas canvas)
        {
            Format.FormatCanvas(canvas);
            // Draw line from top left to bottom right
            canvas.DrawLine(StartX, StartY, StartX + Width, StartY + Height);
            // Draw line from top right to bottom left
            //canvas.DrawLine(StartX + widthRange, StartY, StartX, StartY + GetHeight);
        }
    }
}
