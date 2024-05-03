using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    public class GatherVeneer : IDataInputCollectorAppend
    {

        public IDataGroupRoot Add(IDataGroupRoot veneer)
        {
            return veneer;
        }
    }
}
