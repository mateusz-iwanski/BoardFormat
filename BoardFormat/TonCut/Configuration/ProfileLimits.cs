using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Defines the conditions for early termination of global and/or single optimization.
    /// </summary>
    public class Limits : DataGroupInput
    {
        /// <summary>
        /// Allows to specify the maximum number of combinations within the optimization of a single StockItem.
        /// </summary>
        public MaxCombinations maxCombinations { get; }

        /// <summary>
        /// Allows to specify the maximum optimization time for a single StockItem.
        /// </summary>
        public MaxTimeSingle maxTimeSingle { get; }

        /// <summary>
        /// Allows to specify the maximum time for a single optimization.
        /// </summary>
        public MaxTime maxTime { get; }

        /// <summary>
        /// Constructor for Limits
        /// </summary>
        /// <param name="maxCombinations">Allows to specify the maximum number of combinations within the optimization of a single StockItem</param>
        /// <param name="maxTimeSingle">Allows to specify the maximum optimization time for a single StockItem</param>
        /// <param name="maxTime">Allows to specify the maximum time for a single optimization</param>
        /// <param name="goodEnoughWaste">Allows to specify (in percent) the amount of waste (usable and non-usable) that is acceptable. This criterion applies to the optimization of a single StockItem. Value expressed in percent</param>
        public GoodEnoughWaste goodEnoughWaste { get; }

        public Limits(
            MaxCombinations maxConbinations,
            MaxTimeSingle maxTimeSingle,
            MaxTime maxTime,
            GoodEnoughWaste goodEnoughWaste
            )
        {
            // TODO: check what is the limit, what is the range
            this.maxCombinations = maxConbinations;
            this.maxTimeSingle = maxTimeSingle;
            this.maxTime = maxTime;
            this.goodEnoughWaste = goodEnoughWaste;
        }
    }
}
