using BoardFormat.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.FurnitureLibrary
{
    public class CabinetResizer
    {
        public CabinetResizer()
        {
            return;
        }

        public void ResizeCabinet(Cabinet cabinet, ISize size)
        {
            foreach (var piece in cabinet.Pieces)
            {
                piece.cabinetPiece.SetWidth(width);
                piece.cabinetPiece.SetLength(height);
            }
        }
    }
}
