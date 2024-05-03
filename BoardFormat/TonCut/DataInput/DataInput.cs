using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    public class DataInput : DataGroupInput
    {
        public int version { get; }
        public DefaultUnitsInput defaultUnits { get; set; }
        public List<IDataGroupRoot> devices { get; set;  }
        public List<IDataGroupRoot> materials { get; set;  }
        public List<IDataGroupRoot> pieces { get; set; }
        public List<IDataGroupRoot> stock { get; set; }
        public List<IDataGroupRoot> veneers { get; set; }

        public DataInput(
            int version, DefaultUnitsInput defaultUnits, 
            DataInputCollector materials, DataInputCollector devices, DataInputCollector pieces, DataInputCollector stock, DataInputCollector veneers)
        {
            this.version = version;
            this.defaultUnits = defaultUnits;
            this.devices = devices.GetObjectList();
            this.materials = materials.GetObjectList();
            this.pieces = pieces.GetObjectList();
            this.stock = stock.GetObjectList();
            this.veneers = veneers.GetObjectList();

            CheckMaterialCompatible(this.pieces, this.stock);
            CheckDeviceCompatible(this.devices, this.materials);
            //CheckPieceSizeWithMaterialSize(this.pieces, this.stock);
        }
    }

    



    
}
