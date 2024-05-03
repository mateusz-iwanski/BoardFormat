using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    internal class CuttingStatistics2d
    {
        /// <summary>
        /// The total surface area of all used stock items.
        /// </summary>
        public double field { get; set; }

        /// <summary>
        /// The total surface area of all used pieces.
        /// </summary>
        public double usedField { get; set; }

        /// <summary>
        /// The total waste area.
        /// </summary>
        public double wasteField { get; set; }

        /// <summary>
        /// The total surface area of usable waste.
        /// </summary>
        public double unusedField { get; set; }

        /// <summary>
        /// The number of cuts.
        /// </summary>
        public int cutCount { get; set; }

        /// <summary>
        /// The total length of all the cuts.
        /// </summary>
        public double cutsLength { get; set; }

        /// <summary>
        /// Constructor for the TwoD class.
        /// </summary>
        /// <param name="field">The total surface area of all used stock items.</param>
        /// <param name="usedField">The total surface area of all used pieces.</param>
        /// <param name="wasteField">The total waste area.</param>
        /// <param name="unusedField">The total surface area of usable waste.</param>
        /// <param name="cutCount">The number of cuts.</param>
        /// <param name="cutsLength">The total length of all the cuts.</param>
        public CuttingStatistics2d(double field, double usedField, double wasteField, double unusedField, int cutCount, double cutsLength)
        {
            this.field = field;
            this.usedField = usedField;
            this.wasteField = wasteField;
            this.unusedField = unusedField;
            this.cutCount = cutCount;
            this.cutsLength = cutsLength;
        }

        public CuttingStatistics2d(JToken jObject) 
        { 
            this.field = (double)jObject["field"];
            this.usedField = (double)jObject["usedField"];
            this.wasteField = (double)jObject["wasteField"];
            this.unusedField = (double)jObject["unusedField"];
            this.cutCount = (int)jObject["cutCount"];
            this.cutsLength = (double)jObject["cutsLength"];
        }
    }
}
