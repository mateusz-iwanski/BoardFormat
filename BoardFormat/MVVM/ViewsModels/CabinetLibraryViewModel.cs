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

            CabinetPieceBehavior cabinetPieceCollection = new CabinetPieceBehavior(
                piece: new CabinetPiece(
                                cabinetId: Guid.NewGuid(),
                                //cabinetPiece: new Piece(length: 1100, width: 500, structure: true),
                                pieceType: PieceType.Front,
                                pieceBehavior: new PieceLimits()
                                    .WidthRange(1000, 1500)  // cabinetPiece length
                                    .LengthRange(500, 1300),  // cabinetPiece width
                                identifier: "front"
                            ),
                cabinetWidthPieceWidth: new SizeMatch().SetValue(-2),
                cabinetWidthPieceLength: new SizeMatch().SetValue(-2),
                cabinetHeightPieceWidth: new SizeMatch().SetValue(-2),
                cabinetHeightPieceLength: new SizeMatch().SetValue(-2),
                cabinetDepthPieceWidth: new SizeMatch().SetNull(),  // do nothing
                cabinetDepthPieceLength: new SizeMatch().SetNull()  // do nothing
                );

            //create CabinetPieceBehavior for testing
            CabinetPieceBehavior cabinetPieceCollection2 = new CabinetPieceBehavior(
                               piece: new CabinetPiece(
                                    cabinetId: Guid.NewGuid(),
                                    pieceType: PieceType.Left,
                                    //pieceBehavior: new PieceLimits()
                                    //.WidthRange(1000, 1500)  // cabinetPiece length
                                    //.LengthRange(500, 1300),  // cabinetPiece width
                                    identifier: "front"
                                    ),
                                    cabinetWidthPieceWidth: new SizeMatch().SetNull(),  // do nothing
                                    cabinetWidthPieceLength: new SizeMatch().SetNull(),  // do nothing
                                    cabinetHeightPieceWidth: new SizeMatch().SetNull(),  // do nothing
                                    cabinetHeightPieceLength: new SizeMatch().SetValue(0),
                                    cabinetDepthPieceWidth: new SizeMatch().SetValue(0),  
                                    cabinetDepthPieceLength: new SizeMatch().SetNull()   // do nothing
                                    );

            AddCabinet(new Cabinet(
                    symbol: "symbol",
                    name: "name",
                    image: new Image(),
                    accessories: new List<Accessories>()
                    {
                            new Accessories("symbol", "name", new Image(), "description"),
                    },
                    pieces: new List<CabinetPieceBehavior>()
                    {
                            cabinetPieceCollection,
                            cabinetPieceCollection2,
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
                    ),
                    cabinetLimits: new CabinetLimits()
                        .WidthRange(1000, 1500)
                        .HeightRange(1000, 1600)
                        .DepthRange(1000)
                )
            );
        }

        public void AddCabinet(Cabinet cabinet)
        {
            CabinetSize<float> cabinetSize = new CabinetSize<float>(width:1200, height:1100, depth:1000);
            ICabinetResize resize = new CabinetResizer(cabinet).ResizeCabinet(cabinetSize);
            CabinetCollection.Add(cabinet);          
        }
    }
}
