using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    /// <summary>
    /// Represents additional elements that can be drawn on a rectangle. 
    /// It contains properties and methods for configuring and drawing 
    /// various elements such as veneer, waste marks, dimension text, 
    /// centered text, and structure lines.
    /// It's use in the RectangleDrawer class.
    /// </summary>
    public class RectangleAdditionalElements
    {
        private PieceToDraw Piece { get; set; }
        private ShapeDrawer Shape { get; set; }
        //przemyslec jak to zrobic
        public List<ShapeDrawer> Shapes { get; set; } = new List<ShapeDrawer>();

        // DimensionText settings

        // Centered text (identifier/description) settings


        public RectangleAdditionalElements(
            ShapeDrawer shape,
            PieceToDraw pieceObject
            ) 
        {
            Piece = pieceObject;
            Shape = shape;


            return;
        }


        // Check minimum length and width for piece size draw.
        // if not has requires size, return false.
        // widthRange and Length are in cm.
        public bool RequiredPieceSizeForPieceSizeDraw(PieceToDraw piece) =>
            (piece.Width > 10 && piece.Length > 10) ? true : false;


        public void MakeVeneer(ICanvas canvas)
        {
            new Veneer(
                shape: Shape,
                piece: Piece
                ).Draw(canvas);
        }

        public void MakeWasteMark(ICanvas canvas)
        {
            new WasteMark(
                shape: Shape
                ).Draw(canvas);
        }

        public void MakePieceSizeDraw(ICanvas canvas)
        {
            if (RequiredPieceSizeForPieceSizeDraw(Piece))
                new DimensionText(
                        shape: Shape,
                        piece: Piece
                    ).Draw(canvas);
        }

        public void MakeCenterText(ICanvas canvas)
        {
            new CenteredText(
                shape: Shape,
                piece: Piece
                ).Draw(canvas);
        }

        public void MakeStructure(ICanvas canvas)
        {
            if (Piece.BoardHasStructure)
            {
                new Structure(
                    piece: Piece,
                    shape: Shape
                    ).Draw(canvas);
            }
        }

        //public void Draw(ICanvas canvas)
        //{
        //    foreach (var shape in Shapes)
        //    {
        //        shape.Draw(canvas);
        //    }
        //}

        public void Draw(
            ICanvas canvas,
            bool veneer = true,
            bool wasteMartk = true,
            bool pieceSizeDraw = true,
            bool structure = true,
            bool centeredText = true
            )
        {
            if (structure) MakeStructure(canvas);
            if (pieceSizeDraw) MakePieceSizeDraw(canvas);

            switch (Piece.Type)
            {
                case DrawerType.Piece:
                    if (veneer) MakeVeneer(canvas);
                    if (centeredText) MakeCenterText(canvas);
                    break;

                case DrawerType.Waste:
                    if (wasteMartk) MakeWasteMark(canvas);
                    break;
            }
        }

    }
}
