using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Specifies support for miter cuts in 1D materials. Only for 1D.
    /// </summary>
    public class Slants : DataGroupInput
    {
        /// <summary>
        /// Set it to true if the device supports miter cuts. Only for 1D.
        /// </summary>
        public bool supported { get; }

        /// <summary>
        /// How the left slant's angle is measured.
        /// Parameters: fromMiddleToLeft, fromMiddleToRight, fromLeft, fromRight
        /// </summary>
        [StringValueAssignable("fromMiddleToLeft", "fromMiddleToRight", "fromLeft", "fromRight")]
        public string leftMeasurement { get; }

        /// <summary>
        /// How the right slant's angle is measured.
        /// Parameters: fromMiddleToLeft, fromMiddleToRight, fromLeft, fromRight
        /// </summary>
        [StringValueAssignable("fromMiddleToLeft", "fromMiddleToRight", "fromLeft", "fromRight")]
        public string rightMeasurement { get; }

        /// <summary>
        /// Constructor for Slants class. Only for 1D
        /// </summary>
        /// <param name="supported">Set it to true if the device supports miter cuts.</param>
        /// <param name="leftMeasurement">How the left slant's angle is measured.</param>
        /// <param name="rightMeasurement">How the right slant's angle is measured.</param>
        public Slants(bool supported, string leftMeasurement, string rightMeasurement)
        {
            this.supported = supported;
            this.leftMeasurement = leftMeasurement;
            this.rightMeasurement = rightMeasurement;

            StringValueCheckAttribute<Slants>(this); 
        }
    }
}
