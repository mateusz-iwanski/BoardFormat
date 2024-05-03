using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    internal class GatherDevice : IDataInputCollectorAppend
    {
        public IDataGroupRoot Add(IDataGroupRoot device)
        {
            return device;
        }
    }
}
