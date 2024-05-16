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
        public ObservableCollection<Cabinet> CabinetCollection { get; set; }

        public CabinetLibraryViewModel()
        {
            CabinetCollection = new ObservableCollection<Cabinet>();

            CabinetPieceBehavior cabinetPieceCollection = new CabinetPieceBehavior(
                piece: new CabinetPiece(
                                cabinetId: 0,
                                //cabinetPiece: new Piece(length: 1100, width: 500, structure: true),
                                pieceType: PieceType.Front,
                                //pieceBehavior: new PieceLimits()
                                //    .WidthRange(1000, 1500)  // cabinetPiece length
                                //    .LengthRange(500, 1300),  // cabinetPiece width
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
                                    cabinetId: 0,
                                    pieceType: PieceType.Left,
                                    //pieceBehavior: new PieceLimits()
                                    //.WidthRange(1000, 1500)  // cabinetPiece length
                                    //.LengthRange(500, 1300),  // cabinetPiece width
                                    identifier: "bok"
                                    ),
                                    cabinetWidthPieceWidth: new SizeMatch().SetNull(),  // do nothing
                                    cabinetWidthPieceLength: new SizeMatch().SetNull(),  // do nothing
                                    cabinetHeightPieceWidth: new SizeMatch().SetNull(),  // do nothing
                                    cabinetHeightPieceLength: new SizeMatch().SetValue(0),
                                    cabinetDepthPieceWidth: new SizeMatch().SetValue(0),  
                                    cabinetDepthPieceLength: new SizeMatch().SetNull()   // do nothing
                                    );

            Accessories accessories = new Accessories("symbol", "name", new Image(), "description");

            Cabinet c1 = new Cabinet(
                    symbol: "KSD1",
                    name: "Korpus dolny 1",
                    image: new Image()
                    {
                        Source = ImageSource.FromUri(new Uri("https://img.freepik.com/darmowe-wektory/kolorowy-gradient-ilustracji-ptakow_343694-1741.jpg?w=900&t=st=1715686595~exp=1715687195~hmac=a851fdc99181fa20fd4a2c1a4954ab659ccd5654b471c6e2db32ed0f1e15af9a"))
                    },
                    uriImageSource: "https://img.freepik.com/darmowe-wektory/kolorowy-gradient-ilustracji-ptakow_343694-1741.jpg?w=900&t=st=1715686595~exp=1715687195~hmac=a851fdc99181fa20fd4a2c1a4954ab659ccd5654b471c6e2db32ed0f1e15af9a",
                    category: new CabinetCategory(
                        destiny: CabinetDestiny.Kitchen,
                        cabinetType: CabinetType.Standing
                    ),
                    cabinetLimits: new CabinetLimits()
                        .WidthRange(1, 1500)
                        .HeightRange(1, 1600)
                        .DepthRange(1, 9000)
                );

            CabinetPieceBehavior cb1 = new CabinetPieceBehavior(
                piece: new CabinetPiece(
                                cabinetId: c1.ID,
                                //cabinetPiece: new Piece(length: 1100, width: 500, structure: true),
                                pieceType: PieceType.Front,
                                //pieceBehavior: new PieceLimits()
                                //    .WidthRange(1000, 1500)  // cabinetPiece length
                                //    .LengthRange(500, 1300),  // cabinetPiece width
                                identifier: "front"
                            ),
                cabinetWidthPieceWidth: new SizeMatch().SetValue(-2),
                cabinetWidthPieceLength: new SizeMatch().SetValue(-2),
                cabinetHeightPieceWidth: new SizeMatch().SetValue(-2),
                cabinetHeightPieceLength: new SizeMatch().SetValue(-2),
                cabinetDepthPieceWidth: new SizeMatch().SetNull(),  // do nothing
                cabinetDepthPieceLength: new SizeMatch().SetNull()  // do nothing
                );

            CabinetPieceBehavior cb2 = new CabinetPieceBehavior(
                               piece: new CabinetPiece(
                                    cabinetId: c1.ID,
                                    pieceType: PieceType.Left,
                                    //pieceBehavior: new PieceLimits()
                                    //.WidthRange(1000, 1500)  // cabinetPiece length
                                    //.LengthRange(500, 1300),  // cabinetPiece width
                                    identifier: "bok"
                                    ),
                                    cabinetWidthPieceWidth: new SizeMatch().SetNull(),  // do nothing
                                    cabinetWidthPieceLength: new SizeMatch().SetNull(),  // do nothing
                                    cabinetHeightPieceWidth: new SizeMatch().SetNull(),  // do nothing
                                    cabinetHeightPieceLength: new SizeMatch().SetValue(0),
                                    cabinetDepthPieceWidth: new SizeMatch().SetValue(0),
                                    cabinetDepthPieceLength: new SizeMatch().SetNull()   // do nothing
                                    );

            new CabinetBuilder(c1)
                .AddPiece(cb1)
                .AddPiece(cb2)
                .AddAccessories(accessories)
                ;

            AddCabinet(c1);

            

            Cabinet c2 = new Cabinet(
                    symbol: "KSD2",
                    name: "Korpus gorny 1",
                    image: new Image()
                    {
                        Source = ImageSource.FromUri(new Uri("https://img.freepik.com/darmowe-wektory/kolorowy-gradient-ilustracji-ptakow_343694-1741.jpg?w=900&t=st=1715686595~exp=1715687195~hmac=a851fdc99181fa20fd4a2c1a4954ab659ccd5654b471c6e2db32ed0f1e15af9a"))
                    },
                    uriImageSource: "https://img.freepik.com/darmowe-wektory/kolorowy-gradient-ilustracji-ptakow_343694-1741.jpg?w=900&t=st=1715686595~exp=1715687195~hmac=a851fdc99181fa20fd4a2c1a4954ab659ccd5654b471c6e2db32ed0f1e15af9a",
                    category: new CabinetCategory(
                        destiny: CabinetDestiny.Kitchen,
                        cabinetType: CabinetType.Hanging
                    ),
                    cabinetLimits: new CabinetLimits()
                        .WidthRange(1000, 1500)
                        .HeightRange(1000, 1600)
                        .DepthRange(1000)
                );

            CabinetPieceBehavior cb3 = new CabinetPieceBehavior(
                piece: new CabinetPiece(
                                cabinetId: c2.ID,
                                //cabinetPiece: new Piece(length: 1100, width: 500, structure: true),
                                pieceType: PieceType.Front,
                                //pieceBehavior: new PieceLimits()
                                //    .WidthRange(1000, 1500)  // cabinetPiece length
                                //    .LengthRange(500, 1300),  // cabinetPiece width
                                identifier: "front"
                            ),
                cabinetWidthPieceWidth: new SizeMatch().SetValue(-2),
                cabinetWidthPieceLength: new SizeMatch().SetValue(-2),
                cabinetHeightPieceWidth: new SizeMatch().SetValue(-2),
                cabinetHeightPieceLength: new SizeMatch().SetValue(-2),
                cabinetDepthPieceWidth: new SizeMatch().SetNull(),  // do nothing
                cabinetDepthPieceLength: new SizeMatch().SetNull()  // do nothing
                );


            new CabinetBuilder(c2)
                .AddPiece(cb3)
                .AddAccessories(accessories)
                ;

            AddCabinet(c2);




            Cabinet c3 = new Cabinet(
                    symbol: "KSD3",
                    name: "szafka livingroom",
                    image: new Image()
                    {
                        Source = ImageSource.FromUri(new Uri("https://img.freepik.com/darmowe-wektory/kolorowy-gradient-ilustracji-ptakow_343694-1741.jpg?w=900&t=st=1715686595~exp=1715687195~hmac=a851fdc99181fa20fd4a2c1a4954ab659ccd5654b471c6e2db32ed0f1e15af9a"))
                    },
                    uriImageSource: "https://img.freepik.com/darmowe-wektory/kolorowy-gradient-ilustracji-ptakow_343694-1741.jpg?w=900&t=st=1715686595~exp=1715687195~hmac=a851fdc99181fa20fd4a2c1a4954ab659ccd5654b471c6e2db32ed0f1e15af9a",
                    category: new CabinetCategory(
                        destiny: CabinetDestiny.LivingRoom,
                        cabinetType: CabinetType.Shelf
                    ),
                    cabinetLimits: new CabinetLimits()
                        .WidthRange(1000, 1500)
                        .HeightRange(1000, 1600)
                        .DepthRange(1000)
                );

            CabinetPieceBehavior cb4 = new CabinetPieceBehavior(
                   piece: new CabinetPiece(
                        cabinetId: c3.ID,
                        pieceType: PieceType.Left,
                        //pieceBehavior: new PieceLimits()
                        //.WidthRange(1000, 1500)  // cabinetPiece length
                        //.LengthRange(500, 1300),  // cabinetPiece width
                        identifier: "bok"
                        ),
                        cabinetWidthPieceWidth: new SizeMatch().SetNull(),  // do nothing
                        cabinetWidthPieceLength: new SizeMatch().SetNull(),  // do nothing
                        cabinetHeightPieceWidth: new SizeMatch().SetNull(),  // do nothing
                        cabinetHeightPieceLength: new SizeMatch().SetValue(0),
                        cabinetDepthPieceWidth: new SizeMatch().SetValue(0),
                        cabinetDepthPieceLength: new SizeMatch().SetNull()   // do nothing
                        );

            new CabinetBuilder(c3)
                .AddPiece(cb4)
                .AddAccessories(accessories)
                ;

            AddCabinet(c2);
        }

        public void AddCabinet(Cabinet cabinet)
        {
            CabinetSize<float> cabinetSize = new CabinetSize<float>(width:1200, height:1100, depth:1000);
            ICabinetResize resize = new CabinetResizer(cabinet).ResizeCabinet(cabinetSize);
            CabinetCollection.Add(cabinet);          
        }
    }
}
