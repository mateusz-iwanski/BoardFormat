using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Specifies the accuracy of the search. The higher the values here, the better results will be found.
    /// Be careful, as setting too high numbers here can make the optimization process much longer.
    /// </summary>
    public class SearchPrecision : DataGroupInput
    {
        /// <summary>
        /// How many pieces should be checked in the first step. (default: maximum/all pieces)
        /// def: maximum/all pieces
        /// </summary>
        public int firstLevel { get; set; }

        /// <summary>
        /// How many pieces should be checked in the next steps. (default: 1)
        /// Note that value of 2 here is already very high!
        /// def: 1
        /// </summary>
        // TODO: set [Range(1, what max?)]
        public int nextLevels { get; set; }

        /// <summary>
        /// Constructor for SearchPrecision class.
        /// </summary>
        /// <param name="firstLevel">How many pieces should be checked in the first step.</param>
        /// <param name="nextLevels">How many pieces should be checked in the next steps.</param>
        public SearchPrecision(int firstLevel, int nextLevels)
        {
            this.firstLevel = firstLevel;
            this.nextLevels = nextLevels;

            // ValidationPropertyCheck<SearchPrecision>(this); - add when max set
        }
    }
}
