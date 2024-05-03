using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Defines the main strategy for the order of stock selection.
    /// </summary>       
    public class Order : DataGroupInput
    {
        /// <summary>
        /// Defines if and how the stock will be sorted.
        /// Allowed values
        /// fromLarge:
        ///     The stock will be sorted by size, from larger to smaller.
        //  fromSmall:
        ///     The stock will be sorted by size, from smaller to larger.
        /// random:
        ///     The stock will be in random order.
        /// </summary>
        [StringValueAssignable("fromLarge", "fromSmall", "random")]
        public string direction { get; }

        /// <summary>
        /// It is modifier of the random direction. Defines number of random orders that should be checked.
        /// </summary>
        public int randomDrawCount { get; }

        /// <summary>
        /// Modifies the fromLarge direction. If waste exceeds the given threshold, the order of the remaining stock will be automatically changed according to fromSmall direction.
        /// </summary>
        public SwitchToSmall switchToSmall { get; }

        /// <summary>
        /// Modifies the fromSmall direction. It generates specified number of random orders for small stock items.
        /// </summary>
        public RandomOrders randomOrders { get; }

        /// <summary>
        /// Constructor for Order
        /// </summary>
        /// <param name="direction">Defines if and how the stock will be sorted. Allowed values: fromLarge (sort by size, from larger to smaller), fromSmall (sort by size, from smaller to larger), random (in random order)</param>
        /// <param name="randomDrawCount">It is modifier of the random direction. Defines number of random orders that should be checked.</param>
        /// <param name="switchToSmall">Modifies the fromLarge direction. If waste exceeds the given threshold, the order of the remaining stock will be automatically changed according to fromSmall direction.</param>
        /// <param name="randomOrders">Modifies the fromSmall direction. It generates specified number of random orders for small stock items.</param>
        public Order(
            string direction,
            int randomDrawCount,
            SwitchToSmall switchToSmall,
            RandomOrders randomOrders
            )
        {
            this.direction = direction;
            this.randomDrawCount = randomDrawCount;

            this.switchToSmall = switchToSmall;
            this.randomOrders = randomOrders;

            StringValueCheckAttribute<Order>(this);
        }
    }
}
