using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Represents a modifier of the fromSmall direction that generates a specified number of random orders for small stock items.
    /// </summary>
    public class RandomOrders : DataGroupInput
    {
        /// <summary>
        /// Enables or disables the randomOrders modifier of the fromSmall direction.
        /// </summary>
        public bool enabled { get; }

        /// <summary>
        /// The number of random orders for the small stock items.
        /// </summary>
        // TODO: What is the range
        public int count { get; }

        /// <summary>
        /// Initializes a new instance of the RandomOrders class with the specified enabled flag and count of random orders.
        /// </summary>
        /// <param name="enabled">The flag to enable or disable the randomOrders modifier.</param>
        /// <param name="count">The number of random orders for the small stock items.</param>
        public RandomOrders(bool enabled, int count)
        {
            this.enabled = enabled;
            this.count = count;            
        }
    }
}
