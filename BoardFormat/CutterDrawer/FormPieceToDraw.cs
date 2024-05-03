using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonCut;

namespace BoardFormat.CutterDrawer
{
    public class FormPieceToDraw
    {
        
        public PieceToDraw Form { get; private set; }

        public FormPieceToDraw(
            Piece pieceInputData,
            CuttingPiece piece,
            StockItem stock)
        {
            Form = new PieceToDraw()
            {
                Length = ConvertToCm(
                        piece.rotated ? pieceInputData.width : pieceInputData.length
                    ), 
                Width = ConvertToCm(
                        piece.rotated ? pieceInputData.length : pieceInputData.width
                    ),
                X = ConvertToCm(piece.x),
                Y = ConvertToCm(piece.y),
                Structure = pieceInputData.structure == "byLength" ? true : false,
                Type = DrawerType.Piece,
                Identifier = pieceInputData.identifier,
                Rotated = piece.rotated,
                LeftVeneer = pieceInputData.veneers.leftVeneerId == null ? false : true,
                RightVeneer = pieceInputData.veneers.rightVeneerId == null ? false : true,
                TopVeneer = pieceInputData.veneers.topVeneerId == null ? false : true,
                BottomVeneer = pieceInputData.veneers.bottomVeneerId == null ? false : true,
                // get strcutre from board in stock
                BoardHasStructure = stock.structure == "byLength" ? true : false
            };
        }

        private double ConvertToCm(int valueInmm) => Convert.ToDouble(valueInmm / 10);
        private double ConvertToCm(double valueInmm) => valueInmm / 10.0d;


    }
}
