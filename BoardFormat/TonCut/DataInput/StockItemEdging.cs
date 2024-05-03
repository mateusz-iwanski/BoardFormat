using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Edging configuration.
    /// </summary>
    public class Edging : DataGroupInput
    {
        /// <summary>
        /// The size of the edge to be cut off on the left side of the StockItem.
        /// </summary>
        public double left;

        /// <summary>
        /// The size of the edge to be cut off on the right side of the StockItem.
        /// </summary>
        public double right;

        /// <summary>
        /// The size of the edge to be cut off on the top of the StockItem. (2D only)
        /// </summary>
        public double top;

        /// <summary>
        /// The size of the edge to be cut off on the bottom of the StockItem. (2D only)
        /// </summary>
        public double bottom;

        /// <summary>
        /// Constructor for Edging class.
        /// </summary>
        /// <param name="left">The size of the edge to be cut off on the left side of the StockItem.</param>
        /// <param name="right">The size of the edge to be cut off on the right side of the StockItem.</param>
        /// <param name="top">The size of the edge to be cut off on the top of the StockItem.</param>
        /// <param name="bottom">The size of the edge to be cut off on the bottom of the StockItem.</param>
        public Edging(double left, double right, double top, double bottom)
        {
            this.left = left;
            this.right = right;
            this.top = top;
            this.bottom = bottom;
        }
    }
}
