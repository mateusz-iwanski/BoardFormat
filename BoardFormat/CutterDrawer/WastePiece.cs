using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonCut;

namespace BoardFormat.CutterDrawer
{
    public class WastePiece
    {
        public PieceToDraw Waste { get; private set; }
        
        public WastePiece(CuttingRest rest, StockItem stock)
        {
            Waste = new PieceToDraw()
            {
                Length = ConvertToCm(rest.length),
                Width = ConvertToCm(rest.width),
                X = ConvertToCm(rest.x),
                Y = ConvertToCm(rest.y),
                Structure = stock.structure == "byLength" ? true : false,
                Type = DrawerType.Waste,
                Rotated = false,
                BoardHasStructure = stock.structure == "byLength" ? true : false
            };
        }
        private double ConvertToCm(int valueInmm) => Convert.ToDouble(valueInmm / 10);
        private double ConvertToCm(double valueInmm) => valueInmm / 10.0d;

    }
}
