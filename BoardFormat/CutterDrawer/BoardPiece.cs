using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonCut;

namespace BoardFormat.CutterDrawer
{
    public class BoardPieceToDraw
    {
        public PieceToDraw Board { get; private set; }
        
        public BoardPieceToDraw(StockItem stock)
        {
            Board = new PieceToDraw()
            {
                Length = ConvertToCm(stock.length),
                Width = ConvertToCm(stock.width),
                X = 0,
                Y = 0,
                Structure = stock.structure == "byLength" ? true : false,
                Type = DrawerType.Board,
                Rotated = false // TODO: if optimizer will can rotating the board Rotated will have to be used
            };
        }
        public double ConvertToCm(int valueInmm) => Convert.ToDouble(valueInmm / 10);
        public double ConvertToCm(double valueInmm) => valueInmm / 10.0d;

    }
}
