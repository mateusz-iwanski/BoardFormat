using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    public class DataInputCollector
    {
        List<IDataGroupRoot> DataInputObjects;
        IDataInputCollectorAppend _IDataInputCollectorAppend;

        public DataInputCollector(IDataInputCollectorAppend iDataInputCollectorAppend)
        {
            this.DataInputObjects = new List<IDataGroupRoot> { };
            this._IDataInputCollectorAppend = iDataInputCollectorAppend;
        }

        public void Append(IDataGroupRoot dataGroupObject)
        {
            this.DataInputObjects.Add(this._IDataInputCollectorAppend.Add(dataGroupObject));
        }

        public List<IDataGroupRoot> GetObjectList() => this.DataInputObjects;
    }
}
