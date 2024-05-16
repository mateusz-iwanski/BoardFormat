using BoardFormat.FurnitureLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.MVVM.Models
{
    /// <summary>
    /// When we add cabinet to piece collection we will add all pieces from cabinet
    /// with specific behavior for each piece. We will know from what cabinet are pieces 
    /// and how should be behave.
    /// We can't add pieces from cabinet directly to piece collection in 
    /// PieceCollectionViewModel because we lost every information about objects.
    /// </summary>
    public class PieceFromCabinets
    {
        // is unique for cabinet
        public string CabinetSymbol { get; private set; }
        //public int SerriesID { get; private set; }
        public List<CabinetPieceBehavior> CabinetPiece { get; set;}

        public PieceFromCabinets(string cabinetSymbol)
        {
            CabinetSymbol = cabinetSymbol;
            CabinetPiece = new List<CabinetPieceBehavior>();
            return;
        }

    }
}
