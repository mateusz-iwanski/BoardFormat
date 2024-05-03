using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    public class GatherDataInput : IDataInputCollectorAppend
    {
        public IDataGroupRoot Add(IDataGroupRoot dataInput)
        {
            return dataInput;
        }
    }
}
