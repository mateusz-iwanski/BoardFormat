using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Represents the statistics for 2D cutting if the material type is 2D.
    /// </summary>
    public class Statistics2d
    {
        /// <summary>
        /// The total surface area of all used stock items.
        /// </summary>
        public double field { get; set; }

        /// <summary>
        /// The total surface area of all used stock items.
        /// </summary>
        public double usedField { get; set; }

        /// <summary>
        /// The total surface area of all used pieces.
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
        /// <param name="usedField">The total surface area of all used stock items.</param>
        /// <param name="wasteField">The total surface area of all used pieces.</param>
        /// <param name="unusedField">The total surface area of usable waste.</param>
        /// <param name="cutCount">The number of cuts.</param>
        /// <param name="cutsLength">The total length of all the cuts.</param>
        public Statistics2d(double field, double usedField, double wasteField, double unusedField, int cutCount, double cutsLength)
        {
            field = field;
            usedField = usedField;
            wasteField = wasteField;
            unusedField = unusedField;
            cutCount = cutCount;
            cutsLength = cutsLength;
        }

        public Statistics2d(JToken jToken)
        {
            field = (double)jToken["field"];
            usedField = (double)jToken["usedField"];
            wasteField = (double)jToken["wasteField"];
            unusedField = (double)jToken["unusedField"];
            cutCount = (int)jToken["cutCount"];
            cutsLength = (double)jToken["cutsLength"];
        }
    }

}

