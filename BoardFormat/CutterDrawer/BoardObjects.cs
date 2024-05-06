using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    /// <summary>
    /// For one BoardObjects is one GraphicsView with one board with pieceCollection drawable
    /// </summary>
    public struct BoardObjects
    {
        public GraphicsView BoardGraphicsView;
        public List<PieceToDraw> BoardWithPieceCollection;
    }
}
