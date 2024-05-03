using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Specified default edging for the waste that was qualified as usable.
    /// </summary>
    public class MaterialWasteEdging : DataGroupInput
    {
        /// <summary>
        /// Enables or disables setting the edging to the StockItem created from the usable waste.
        /// </summary>
        public bool enabled { get; }

        /// <summary>
        /// The default edging size. Note that edging will be applied to all edges of the new StockItem.
        /// </summary>
        // TODO: Change to different name, default is the system name, i can't use it now
        [JsonProperty("default")]
        public int _default { get; }

        /// <summary>
        /// Constructor for Edging class.
        /// </summary>
        /// <param name="enabled">Enables or disables setting the edging to the StockItem created from the usable waste.</param>
        /// <param name="default">The default edging size.</param>
        public MaterialWasteEdging(bool enabled, int _default)
        {
            this.enabled = enabled;
            this._default = _default;
        }
    }
}
