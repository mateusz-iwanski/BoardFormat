using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Maximum horizontal cut length.
    /// It can also be used when cutting in strips - then it allows to limit the width of the strip.
    /// This option is especially useful when the device is a guillotine.
    /// </summary>
    public class MaxCutLengthByLength : DataGroupInput
    {
        /// <summary>
        /// Enables or disables maximum horizontal cut length.
        /// </summary>
        public bool enabled { get; }

        /// <summary>
        /// Maximum cut length.
        /// </summary>
        // TODO: what is max limit?
        public double limit { get; }

        /// <summary>
        /// Constructor for MaxCutLengthByLength class.
        /// </summary>
        /// <param name="enabled">Enables or disables maximum horizontal cut length.</param>
        /// <param name="limit">Maximum cut length.</param>
        public MaxCutLengthByLength(bool enabled, double limit)
        {
            this.enabled = enabled;
            this.limit = limit;
        }
    }
}
