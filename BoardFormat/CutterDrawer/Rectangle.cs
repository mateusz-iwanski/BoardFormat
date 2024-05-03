using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    public class Rectangle : ShapeDrawer
    {
        PieceToDraw Piece { get; set; }
        public ShapeFormat BoardFormat { get; set; }
        public ShapeFormat PieceFormat { get; set; }

        public ShapeFormat WasteFromat = new ShapeFormat(
            strokeColor: Color.FromRgb(0, 0, 0), // Set RGBA values for black color
            fillColor: Color.FromRgb(243, 242, 242), // Set RGBA values for white color
            strokeSize: 1.0f);

        public Rectangle(
            float x, float y, 
            float width, float height, 
            PieceToDraw piece,
            Color? strokeColor = null, Color? fillColor = null, float? strokeSize = null
            ) : base(
                    startX: x, startY: y,
                    width: width, height: height,
                    strokeColor: strokeColor, fillColor: null,
                    strokeSize: strokeSize
                )
        {
            Piece = piece;
        }

        public override void Draw(ICanvas canvas)
        {
            if (Piece.Type == DrawerType.Waste)
                WasteFromat.FormatCanvas(canvas);
            else
                // Default
                Format.FormatCanvas(canvas);                

            canvas.FillRectangle(StartX, StartY, Width, Height);
            canvas.DrawRectangle(StartX, StartY, Width, Height);

            // add additional elements
            new RectangleAdditionalElements(
                        shape: this,    
                        pieceObject: Piece
                        ).Draw(canvas);

        }
    }
}
