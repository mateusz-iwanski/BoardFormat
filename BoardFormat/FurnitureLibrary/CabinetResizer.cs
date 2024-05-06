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
        private Cabinet cabinet;
        public CabinetResizer(Cabinet cabinet)
        {
            this.cabinet = cabinet;
            return;
        }

        public CabinetResizer ResizeCabinet(ISize size)
        {
            cabinet.Size = size;
            foreach (var piece in cabinet.Pieces)
            {
                piece.WidthChange(size.GetWidth());
                piece.HeightChange(size.GetHeight());
                piece.DepthChange(size.GetDepth());
            }
            return this;
        }
    }
}
