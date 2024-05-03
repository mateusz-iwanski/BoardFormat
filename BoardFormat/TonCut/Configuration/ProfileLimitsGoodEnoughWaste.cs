using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Represents a criterion for specifying the acceptable amount of waste during the optimization of a single StockItem.
    /// </summary>
    public class GoodEnoughWaste : DataGroupInput
    {
        /// <summary>
        /// Enables or disables the criterion for acceptable waste.
        /// </summary>
        public bool enabled { get; }

        /// <summary>
        /// The acceptable amount of waste (in percent) during the optimization of a single StockItem.
        /// Value express in percent
        /// </summary>
        public double limit { get; }

        /// <summary>
        /// Initializes a new instance of the GoodEnoughWaste class with the specified enabled flag and limit for the acceptable waste.
        /// </summary>
        /// <param name="enabled">The flag to enable or disable the criterion.</param>
        /// <param name="limit">The acceptable amount of waste. Value express in percent</param>
        public GoodEnoughWaste(bool enabled, double limit)
        {
            this.enabled = enabled;
            this.limit = limit;
        }
    }
}
