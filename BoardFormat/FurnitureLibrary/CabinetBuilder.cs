using BoardFormat.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.FurnitureLibrary
{
    class CabinetBuilder
    {
        private Cabinet _cabinet;

        public CabinetBuilder(Cabinet cabinet)
        {
            _cabinet = cabinet;
            return;
        }

        public CabinetBuilder AddPiece(CabinetPieceBehavior cabinetPieceBehavior)
        {
            _cabinet.Pieces.Add(cabinetPieceBehavior);
            return this;
        }

        public CabinetBuilder AddAccessories(Accessories accessories)
        {
            _cabinet.Accessories.Add(accessories);
            return this;
        }
    }
}
