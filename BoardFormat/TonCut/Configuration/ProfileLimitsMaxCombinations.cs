using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Represents a criterion for specifying the maximum number of combinations within the optimization of a single StockItem.
    /// </summary>
    public class MaxCombinations : DataGroupInput
    {
        /// <summary>
        /// Enables or disables the criterion for maximum combinations.
        /// </summary>
        public bool enabled { get; }

        /// <summary>
        /// Optimization of a single StockItem will be completed if the number of checked combinations exceeds the given value.
        /// </summary>
        // TODO: check what is the limit
        public int limit { get; }

        /// <summary>
        /// Initializes a new instance of the MaxCombinations class with the specified enabled flag and limit for the maximum number of combinations.
        /// </summary>
        /// <param name="enabled">The flag to enable or disable the criterion.</param>
        /// <param name="limit">The limit for the maximum number of combinations.</param>
        public MaxCombinations(bool enabled, int limit)
        {
            this.enabled = enabled;
            this.limit = limit;            
        }
    }
}
