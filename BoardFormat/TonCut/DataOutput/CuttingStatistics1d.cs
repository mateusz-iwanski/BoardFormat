using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Contains cutting's statistics if the material type is 1D.
    /// </summary>
    public class CuttingStatistics1d
    {
        /// <summary>
        /// The total length of all used stock items.
        /// </summary>
        public double length { get; set; }

        /// <summary>
        /// The total length of all used pieces.
        /// </summary>
        public double usedLength { get; set; }

        /// <summary>
        /// The total waste length.
        /// </summary>
        public double wasteLength { get; set; }

        /// <summary>
        /// The total length of usable waste.
        /// </summary>
        public double unusedLength { get; set; }

        /// <summary>
        /// The number of cuts.
        /// </summary>
        public int cutCount { get; set; }

        /// <summary>
        /// The total length of all the cuts.
        /// </summary>
        public double cutsLength { get; set; }

        /// <summary>
        /// Constructor for the OneD class.
        /// </summary>
        /// <param name="length">The total length of all used stock items.</param>
        /// <param name="usedLength">The total length of all used pieces.</param>
        /// <param name="wasteLength">The total waste length.</param>
        /// <param name="unusedLength">The total length of usable waste.</param>
        /// <param name="cutCount">The number of cuts.</param>
        /// <param name="cutsLength">The total length of all the cuts.</param>
        public CuttingStatistics1d(double length, double usedLength, double wasteLength, double unusedLength, int cutCount, double cutsLength)
        {
            this.length = length;
            this.usedLength = usedLength;
            this.wasteLength = wasteLength;
            this.unusedLength = unusedLength;
            this.cutCount = cutCount;
            this.cutsLength = cutsLength;
        }

        public CuttingStatistics1d(JToken jObject) 
        { 
            this.length = (double)jObject["length"];
            this.usedLength = (double)jObject["usedLength"];
            this.wasteLength = (double)jObject["wasteLength"];
            this.unusedLength = (double)jObject["unusedLength"];
            this.cutCount = (int)jObject["cutCount"];
            this.cutsLength = (double)jObject["cutsLength"];
        }
    }
}
