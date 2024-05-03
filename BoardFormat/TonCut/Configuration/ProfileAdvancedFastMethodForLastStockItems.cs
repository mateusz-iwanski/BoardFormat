using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Optimization of last stock items usually takes more time because of less optimization tools available.
    /// To make this process faster one can enable fast method. 
    /// When this option is enabled, the fast method will be activated automatically when total size of available elements is smaller than provided percentage of the StockItem's size.
    /// </summary>
    public class FastMethodForLastStockItems : DataGroupInput
    {
        /// <summary>
        /// Enables or disables the fastMethodForLastStockItems.
        /// </summary>
        public bool enabled { get; set; }

        /// <summary>
        /// If total size of all available pieces is smaller than the value provided here, then fast method will be activated.
        /// Value in percent.
        /// </summary>
        public double threshold { get; set; }

        /// <summary>
        /// Constructor for FastMethodForLastStockItems class.
        /// </summary>
        /// <param name="enabled">Enables or disables the fastMethodForLastStockItems.</param>
        /// <param name="threshold">If total size of all available pieces is smaller than the value provided here, then fast method will be activated. Value express in percent</param>
        public FastMethodForLastStockItems(bool enabled, double threshold)
        {
            this.enabled = enabled;
            this.threshold = threshold;
        }
    }
}
