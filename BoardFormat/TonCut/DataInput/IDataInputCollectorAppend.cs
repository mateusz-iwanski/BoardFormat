using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDataInputCollectorAppend
    {
        public IDataGroupRoot Add(IDataGroupRoot dataGroupRoot);
    }
}
