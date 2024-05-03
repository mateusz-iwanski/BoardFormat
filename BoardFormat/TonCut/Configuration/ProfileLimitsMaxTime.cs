using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Represents a criterion for specifying the maximum time for a single optimization.
    /// </summary>
    public class MaxTime : DataGroupInput
    {
        /// <summary>
        /// Enables or disables the criterion for maximum optimization time.
        /// </summary>
        public bool enabled { get; }

        /// <summary>
        /// The limit for the maximum time for a single optimization. Use seconds as unit.
        /// limit attribute Format = "5s"
        /// </summary>
        // TODO: check what is the max limit
        public double limit { get; }

        /// <summary>
        /// Initializes a new instance of the MaxTime class with the specified enabled flag and limit for the maximum optimization time.
        /// </summary>
        /// <param name="enabled">The flag to enable or disable the criterion.</param>
        /// <param name="limit">The limit for the maximum optimization time. Use seconds as unit.</param>
        public MaxTime(bool enabled, int limit)
        {
            this.enabled = enabled;
            this.limit = limit;            
        }
    }
}
