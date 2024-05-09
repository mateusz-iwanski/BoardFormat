using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    /// <summary>
    /// For one DrawableShapeObjects is one GraphicsView with list of one shape with children shapes inside
    /// </summary>
    public struct DrawableShapeObjects
    {
        public GraphicsView GraphicsView;
        public List<IPieceToDraw> ShapeWithPieceCollection;
    }
}
