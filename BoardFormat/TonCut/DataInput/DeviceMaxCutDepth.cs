using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Specifies maximum cut depth level the device is supporting.
    /// It makes sense only if fullCutsOnly is set to true.
    /// </summary>
    public class MaxCutDepth : DataGroupInput
    {
        /// <summary>
        /// Enables or disables maximum cut depth limit. (default: disabled)
        /// </summary>
        public bool enabled { get; set; }

        /// <summary>
        /// The cut depth limit.
        /// </summary>
        // TODO: what is max limit?
        public int limit { get; set; }

        /// <summary>
        /// Set it to true if cutting off edges should be included when calculating cut depth. (default: disabled)
        /// </summary>
        public bool includeEdging { get; set; }

        /// <summary>
        /// Constructor for MaxCutDepth class.
        /// </summary>
        /// <param name="enabled">Enables or disables maximum cut depth limit.</param>
        /// <param name="limit">The cut depth limit.</param>
        /// <param name="includeEdging">Set it to true if cutting off edges should be included when calculating cut depth.</param>
        public MaxCutDepth(bool enabled, int limit, bool includeEdging)
        {
            this.enabled = enabled;
            this.limit = limit;
            this.includeEdging = includeEdging;
        }
    }
}
