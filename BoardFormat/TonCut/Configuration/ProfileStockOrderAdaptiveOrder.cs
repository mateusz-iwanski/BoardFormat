using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Represents an additional dynamic stock reorder strategy that can be enabled.
    /// </summary>
    public class AdaptiveOrder : DataGroupInput
    {
        /// <summary>
        /// Enables or disables the adaptive reorder strategy.
        /// </summary>
        public bool enabled { get; }

        /// <summary>
        /// The waste size threshold expressed in percentage. If the waste is larger than the specified value, the order of the remaining stock items will be changed.
        /// Percentage Value
        /// </summary>
        public double minWaste { get; }

        /// <summary>
        /// The maximum number of reorders per cycle.
        /// </summary>
        // TODO: what is max value
        public int maxTries { get; }

        /// <summary>
        /// The maximum number of cycles. The cycle ends when we are optimizing again a StockItem that was already rejected by this strategy.
        /// </summary>
        // TODO: what is max value
        public int maxCycles { get; }

        /// <summary>
        /// Initializes a new instance of the AdaptiveOrder class with the specified enabled flag, waste size threshold, maximum number of reorders per cycle, and maximum number of cycles.
        /// </summary>
        /// <param name="enabled">The flag to enable or disable the adaptive reorder strategy.</param>
        /// <param name="minWaste">The waste size threshold expressed in percentage.</param>
        /// <param name="maxTries">The maximum number of reorders per cycle.</param>
        /// <param name="maxCycles">The maximum number of cycles.</param>
        public AdaptiveOrder(bool enabled, double minWaste, int maxTries, int maxCycles)
        {
            this.enabled = enabled;
            this.minWaste = minWaste;
            this.maxTries = maxTries;
            this.maxCycles = maxCycles;
        }
    }
}
