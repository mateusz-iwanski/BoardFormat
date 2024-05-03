using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// AI is a type of global optimization algorithm that leverages artificial intelligence to 
    /// discover superior solutions that cannot be achieved by traditional algorithms.
    /// </summary>
    public class AI : DataGroupInput
    {
        /// <summary>
        /// Enables or disables the AI object.
        /// </summary>            
        public bool enabled { get; }

        /// <summary>
        /// The level of the AI algorithm refers to several of its parameters. A higher level means a longer optimization process but also results in a better solution.
        /// Typically, levels 1 or 2 produce satisfactory results..
        /// </summary>
        [Range(0, 4)]
        public int level { get; }

        /// <summary>
        /// Initializes a new instance of the AI class with the specified enabled flag and level of optimization.
        /// </summary>
        /// <param name="enabled">The flag to enable or disable the AI algorithm.</param>
        /// <param name="level">The level of the AI algorithm.</param>
        public AI(bool enabled, int level)
        {
            this.enabled = enabled;
            this.level = level;

            RangeValueCheckAttribute<AI>(this);
        }
    }
}
