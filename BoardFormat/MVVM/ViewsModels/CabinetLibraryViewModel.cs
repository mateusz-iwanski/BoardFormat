using BoardFormat.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardFormat.FurnitureLibrary;

namespace BoardFormat.MVVM.ViewsModels
{
    public class CabinetLibraryViewModel : BaseViewModel
    {
        public ObservableCollection<BoardFormat.MVVM.Models.Cabinet> CabinetCollection { get; set; }

        public CabinetLibraryViewModel()
        {
            CabinetCollection = new ObservableCollection<BoardFormat.MVVM.Models.Cabinet>();

            AddCabinet(new Cabinet(
                    symbol: "symbol",
                    name: "name",
                    image: new Image(),
                    accessories: new List<Accessories>()
                    {
                            new Accessories("symbol", "name", new Image(), "description"),
                    },
                    pieces: new List<CabinetPiece>()
                    {
                            new CabinetPiece(
                                piece: new Piece(length: 1100, width: 500, structure:true),
                                pieceType: PieceType.DrawerLeft,
                                pieceBehavior: new PieceBehavior()
                                    .WidthRange(1000, 1500)  // piece length
                                    .LengthRange(500, 1000)  // piece width
                            ),
                    },
                    category: new CabinetCategory(
                        destiny: new List<CabinetDestiny>()
                        {
                                CabinetDestiny.Kitchen
                        },
                        cabinetType: new List<CabinetType>()
                        {
                                CabinetType.Drawer
                        }
                    )
                )
            );
        }

        public void AddCabinet(Cabinet cabinet)
        {
            CabinetCollection.Add(cabinet);
        }
    }
}
