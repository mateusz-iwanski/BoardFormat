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
        private List<ShapeDrawer> shapeCollection { get; set; } = new List<ShapeDrawer>();

        public RectangleAdditionalElements() { return; }

        // Check minimum length and width for pice size.
        // If not has required size, return false.
        // widthRange and Length are in cm.
        public bool RequiredPieceSize(PieceToDraw piece) =>
            (piece.Width > 10 && piece.Length > 10) ? true : false;

        public void Add(ShapeDrawer shape) => shapeCollection.Add(shape);

        public void Draw(
            ICanvas canvas
            )
        {
            foreach (var shape in shapeCollection)
                shape.Draw(canvas);
        }

    }
}
