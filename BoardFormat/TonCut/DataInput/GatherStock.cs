using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    internal class GatherStock : IDataInputCollectorAppend
    {
        public IDataGroupRoot Add(IDataGroupRoot stock)
        {
            return stock;
        }
    }
}
