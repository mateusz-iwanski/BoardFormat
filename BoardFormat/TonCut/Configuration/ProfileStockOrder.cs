using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Here we can specify the stock sequence strategy. This is of great importance and can significantly affect the quality of the results.
    /// These settings apply to all algorithms except ai.
    /// </summary>
    public class StockOrder
    {
        /// <summary>
        /// An additional dynamic stock reorder strategy can be enabled here.
        /// This strategy only works in a “forward” manner and does not alter the order of already optimized cuttings.
        /// If the waste of a single cutting exceeds a given threshold, the program will reject it and move the StockItem to the end of the queue.Optimization will then continue with the next StockItem.
        /// </summary>
        public AdaptiveOrder adaptiveOrder { get; }

        /// <summary>
        /// Here we define the main strategy for the order of stock selection.
        /// </summary>
        public Order order { get; }

        /// <summary>
        /// Constructor for StockOrder
        /// </summary>
        /// <param name="order">The main strategy for the order of stock selection</param>
        /// <param name="adaptiveOrder">An additional dynamic stock reorder strategy that can be enabled</param>
        public StockOrder(
            Order order,
            AdaptiveOrder adaptiveOrder
            )
        {
            this.order = order;
            this.adaptiveOrder = adaptiveOrder;
        }

    }
}
