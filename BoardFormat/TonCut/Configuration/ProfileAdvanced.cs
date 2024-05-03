using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Here we can change some advanced settings.
    /// Before you change anything here, make sure you understand what you are doing, as these settings may significantly 
    /// change the quality of results and also time of the optimization process.
    /// </summary>
    public class Advanced : DataGroupInput
    {
        /// <summary>
        /// This is a simple, yet very effective strategy that shortens optimization time significantly.
        /// If the program cannot find a better solution for the specified time, it will switch optimization process to something that we call “a fast route”.
        /// The “fast route” will be automatically disabled when the time comes.
        /// </summary>
        public DynamicMethodSwitch dynamicMethodSwitch { get; }

        /// <summary>
        /// Optimization of last stock items usually takes more time because of less optimization tools available.
        /// To make this process faster one can enable fast method.
        /// When this option is enabled, the fast method will be activated automatically when total size of available elements is smaller than provided percentage of the StockItem's size.
        /// </summary>
        public FastMethodForLastStockItems fastMethodForLastStockItems { get; }

        /// <summary>
        /// Specifies the accuracy of the search.
        /// The higher the values here, the better results will be found.
        /// Be careful, as setting too high numbers here can make the optimization process much longer.
        /// </summary>
        public SearchPrecision searchPrecision { get; }

        /// <summary>
        /// Specifies the direction in which items are placed on the StockItem.
        /// byLength - Horizontally, by length.
        /// byWidth - Vertically, by width (doesn’t make sense for 1D materials).
        /// auto - The direction will be selected automatically
        /// </summary>
        [StringValueAssignable("byLength", "byWidth", "auto")]
        public string searchDirection { get; }

        /// <summary>
        /// Constructor for Advanced
        /// </summary>
        /// <param name="dynamicMethodSwitch">The dynamic method switch setting</param>
        /// <param name="fastMethodForLastStockItems">The fast method for last stock items setting</param>
        /// <param name="searchPrecision">The search precision setting</param>
        /// <param name="searchDirectionOfStockItem">The search direction of StockItem</param>
        public Advanced(
            DynamicMethodSwitch dynamicMethodSwitch,
            FastMethodForLastStockItems fastMethodForLastStockItems,
            SearchPrecision searchPrecision,
            string searchDirectionOfStockItem)
        {
            this.dynamicMethodSwitch = dynamicMethodSwitch;
            this.fastMethodForLastStockItems = fastMethodForLastStockItems;
            this.searchPrecision = searchPrecision;

            this.searchDirection = searchDirectionOfStockItem;

            StringValueCheckAttribute<Advanced>(this);
        }

    }
}
