using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// The adaptive algorithm is a type of global algorithm. It operates by repeating the optimization process multiple times.
    /// In each subsequent iteration, problematic elements are shifted to earlier cuttings to improve the results.
    /// </summary>
    public class Adaptive : DataGroupInput
    {
        /// <summary>
        /// Enables or disables the adaptive object.
        /// </summary>            
        public bool enabled { get; }

        /// <summary>
        /// The maximum number of iterations that can be done for each solution.
        /// </summary>
        [Range(2, 40)]
        public int level { get; }

        /// <summary>
        /// Initializes a new instance of the Adaptive class with the specified enabled flag and level of iterations.
        /// </summary>
        /// <param name="enabled">The flag to enable or disable the adaptive algorithm.</param>
        /// <param name="level">The maximum level of iterations for each solution.</param>
        public Adaptive(bool enabled, int level)
        {
            this.enabled = enabled;
            this.level = level;

            RangeValueCheckAttribute<Adaptive>(this); 
        }
    }
}
