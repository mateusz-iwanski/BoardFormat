using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    public class Rectangle : ShapeDrawer
    {
        // pure _piece, without scalling or any other transformation
        public PieceToDraw Piece { get; private set; }
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

        /// <summary>
        /// Check if point is in rectangle
        /// </summary>
        /// <param name="x">Axis X</param>
        /// <param name="y">Axis Y</param>
        /// <returns></returns>
        public bool CheckDrawerPosition(float x, float y) 
        {            
            if (x >= StartX && x <= StartX + Width && y >= StartY && y <= StartY + Height)
            {
                Trace.WriteLine($"Type {Piece.Type} identifier {Piece.Identifier}");
                return true;
            }
            return false;
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
            var additionalElements = new RectangleAdditionalElements();

            additionalElements.Add(new DimensionText(shape: this, piece: Piece, 
                requiredDrawDimension: new RequiredDrawDimension() { Length=10, Width=10 })
                );
            additionalElements.Add(new Structure(shape: this, piece: Piece));
            additionalElements.Add(new Veneer(shape: this ,piece: Piece));
            additionalElements.Add(new WasteMark(shape: this, piece: Piece));
            additionalElements.Add(new CenteredText(shape: this, piece: Piece));
            additionalElements.Draw(canvas);


        }
    }
}
