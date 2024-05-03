using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    internal class GatherMaterial : IDataInputCollectorAppend
    {
        public IDataGroupRoot Add(IDataGroupRoot material)
        {
            return material;
        }
    }
}
