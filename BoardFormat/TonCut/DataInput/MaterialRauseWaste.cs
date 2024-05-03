using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// It defines the criterion for qualifying waste as usable.
    /// usable waste is one that goes to the warehouse for later use.
    /// </summary>
    public class ReuseWaste : DataGroupInput
    {
        /// <summary>
        /// The minimum size of the longer dimension that qualifies the waste as usable.
        /// </summary>
        public int minLongerLength { get; }

        /// <summary>
        /// The minimum size of the shorter dimension that qualifies the waste as usable. (2D only)
        /// </summary>
        public int minShorterLength { get; }

        public MaterialWasteEdging edging { get; }

        /// <summary>
        /// Constructor for ReuseWaste class.
        /// </summary>
        /// <param name="minLongerLength">The minimum size of the longer dimension that qualifies the waste as usable.</param>
        /// <param name="minShorterLength">The minimum size of the shorter dimension that qualifies the waste as usable.</param>
        /// <param name="wasteEdging">Specified default edging for the waste that was qualified as usable.</param>
        public ReuseWaste(
            int minLongerLength, int minShorterLength,
            MaterialWasteEdging wasteEdging)
        {
            this.minLongerLength = minLongerLength;
            this.minShorterLength = minShorterLength;

            this.edging = wasteEdging;
        }
    }
}
