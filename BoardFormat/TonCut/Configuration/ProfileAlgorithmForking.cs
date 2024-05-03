using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Forking is a global optimization algorithm developed together with the West Pomeranian University of Technology in Szczecin.
    /// The algorithm checks more solutions assuming that not always the best single solution found is the best in the context of the entire optimization.
    /// This algorithm is deprecated and will most likely be removed soon.
    /// </summary>
    public class Forking : DataGroupInput
    {
        /// <summary>
        /// Enables or disables the forking object.
        /// </summary>
        public bool enabled { get; }

        /// <summary>            
        /// Depending on the level of accuracy and the iteration number, a different number of best solutions will be checked:
        ///      1: 2, 1
        ///      2: 4, 1
        ///      3: 4, 2, 1
        ///      4: 8, 4, 2, 1
        ///      5: 16, 8, 4, 2, 1
        /// This means that at level 2, the algorithm will check 4 best solutions during the 
        /// first iteration and an 1 additional solution during the second iteration.
        /// def: 1
        /// </summary>
        [Range(1, 5)]
        public int level { get; }

        /// <summary>
        /// Initializes a new instance of the Forking class with the specified enabled flag and level of accuracy.
        /// </summary>
        /// <param name="enabled">The flag to enable or disable forking.</param>
        /// <param name="level">The level of accuracy for forking.</param>
        public Forking(bool enabled, int level)
        {
            this.enabled = enabled;
            this.level = level;

            RangeValueCheckAttribute<Forking>(this);
        }
    }
}
