using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Represents a modifier of the fromLarge direction that automatically changes the order of the remaining stock if waste exceeds the given threshold.
    /// </summary>
    public class SwitchToSmall : DataGroupInput
    {
        /// <summary>
        /// Enables or disables the switchToSmall modifier of the fromLarge direction.
        /// </summary>
        public bool enabled { get; }

        /// <summary>
        /// The waste threshold expressed in percentage. If the waste is larger than the specified value, the switchToSmall modifier will be executed.        
        /// </summary>
        public double minWaste { get; }

        /// <summary>
        /// Initializes a new instance of the SwitchToSmall class with the specified enabled flag and waste threshold.
        /// </summary>
        /// <param name="enabled">The flag to enable or disable the switchToSmall modifier.</param>
        /// <param name="minWaste">The waste threshold expressed in percentage.</param>
        public SwitchToSmall(bool enabled, double minWaste)
        {
            this.enabled = enabled;
            this.minWaste = minWaste;
        }
    }
}
