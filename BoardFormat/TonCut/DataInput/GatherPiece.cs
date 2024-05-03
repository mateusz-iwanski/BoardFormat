using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut 
{
    internal class GatherPiece : IDataInputCollectorAppend
    {
        public IDataGroupRoot Add(IDataGroupRoot piece)
        {
            return piece;
        }
    }
}
