using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Represents a criterion for specifying the maximum optimization time for a single StockItem.
    /// </summary>
    public class MaxTimeSingle : DataGroupInput
    {
        /// <summary>
        /// Enables or disables the criterion for maximum optimization time.
        /// </summary>
        public bool enabled { get; }

        /// <summary>
        /// Optimization of a single StockItem will be terminated if it takes longer than the specified time. Use seconds as unit.
        /// limit attribute Format = "5s"
        /// </summary>
        // TODO: check what is the max limit
        public double limit { get; }

        /// <summary>
        /// Initializes a new instance of the MaxTimeSingle class with the specified enabled flag and limit for the maximum optimization time.
        /// </summary>
        /// <param name="enabled">The flag to enable or disable the criterion.</param>
        /// <param name="limit">The limit for the maximum optimization time. Use seconds as unit.</param>
        public MaxTimeSingle(bool enabled, int limit)
        {
            this.enabled = enabled;
            this.limit = limit;
        }
    }
}
