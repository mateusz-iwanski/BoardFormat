using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TonCut;

namespace BoardFormat.CutterReader
{
    public class CutterStockReader
    {
        ICutterReader _reader;

        public CutterStockReader(ICutterReader reader)
        {
            _reader = reader;
        }

        /// <summary>
        /// From DataInput get StockItem
        /// </summary>
        /// <param name="stockItemId"></param>
        /// <returns></returns>
        public StockItem GetStock(int stockItemId) =>
            _reader.dataInput.stock.Cast<StockItem>().First(p => p.id == stockItemId);
    }
}
