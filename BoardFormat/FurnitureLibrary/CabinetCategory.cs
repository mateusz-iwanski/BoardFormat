using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.FurnitureLibrary
{
    /// <summary>
    /// Furniture has cabinets, cabinets have categories, categories have destiny and type.
    /// One cabinet can have multiple destiny. For example, a cabinet can be used in the office 
    /// and in the living room like bookcase. Has type like shelf, bookcase, etc.
    /// </summary>
    public class CabinetCategory
    {
        public CabinetDestiny CabinetDestiny { get; set; }
        public CabinetType CabinetType { get; set; }
        public CabinetCategory(CabinetDestiny destiny, CabinetType cabinetType)
        {
            this.CabinetDestiny = destiny;
            this.CabinetType = cabinetType;
        }

    }
    
}
