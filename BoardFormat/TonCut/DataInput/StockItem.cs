using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// List of StockItem objects.
    /// </summary>
    public class StockItem : DataGroupInput, ISemiFinished, IDataGroupRoot
    {
        /// <summary>
        /// Unique StockItem id.
        /// Mandatory
        /// </summary>
        public int id { get; }

        /// <summary>
        /// The ID of the material group the StockItem is made from.
        /// Mandatory
        /// </summary>
        public int materialId { get; }

        /// <summary>
        /// The user defined identifier of the StockItem. It must be Code128 barcode compatible.
        /// </summary>
        public string identifier { get; }

        /// <summary>
        /// Description of the StockItem.
        /// </summary>
        public string description { get; }

        /// <summary>
        /// Priority of the StockItem.
        /// Allowed values:
        ///     - normal
        ///         The StockItem is handled normally.
        ///     - low
        ///         The stock is handled with lower priority – the program will try to avoid it.
        /// </summary>
        [StringValueAssignable("normal", "low")]
        public string priority { get; }

        /// <summary>
        /// length of the StockItem.
        /// Mandatory
        /// </summary>
        public double length { get; }

        /// <summary>
        /// width of the StockItem.
        /// Mandatory. 2D Only
        /// </summary>
        public double width { get; }

        /// <summary>
        /// Specifies quantity of the stock items.
        /// Mandatory
        /// </summary>
        public int quantity { get; }

        /// <summary>
        /// Specifies the structure of the StockItem.
        /// Allowed values:
        ///     - none
        ///         The material has no structure.
        ///     - byLength
        ///         The structure is horizontal (along the length).
        ///    - byWidth
        ///         The structure is vertical(along the width).
        /// </summary>
        [StringValueAssignable("none", "byLength", "byWidth")]
        public string structure { get; }

        /// <summary>
        /// Edging configuration.
        /// Edging has to be reduced by kerf. If edging suppose left is set to 10, optimalization set 10 + kerf, it is not optimal.
        /// </summary>
        public Edging edging { get; }

        private double kerfSize { get; }

        /// <summary>
        /// Constructor for the StockItem class.
        /// </summary>
        /// <param name="id">Unique StockItem id (mandatory)</param>
        /// <param name="materialId">The ID of the material group the StockItem is made from (mandatory)</param>
        /// <param name="identifier">The user defined identifier of the StockItem</param>
        /// <param name="description">Description of the StockItem</param>
        /// <param name="priority">Priority of the StockItem (allowed values: normal, low)</param>
        /// <param name="length">length of the StockItem (mandatory)</param>
        /// <param name="width">width of the StockItem (mandatory for 2D only)</param>
        /// <param name="quantity">Specifies quantity of the stock items (mandatory)</param>
        /// <param name="structure">Specifies the structure of the StockItem (allowed values: none, byLength, byWidth)</param>
        /// <param name="kerfSize">Edging configuration. Edging parameters have to be reduced by kerf.</param>
        /// <param name="edging">Edging configuration.</param>
        public StockItem(int id, int materialId, string identifier, string description, string priority, double length, double width, int quantity, string structure,
            double kerfSize, Edging edging)//double edgingLeft, double edgingRight, double edgingTop, double edgingBottom, double kerfSize)
        {
            this.id = id;
            this.materialId = materialId;
            this.identifier = identifier;
            this.description = description;
            this.priority = priority;
            this.length = length;
            this.width = width;
            this.quantity = quantity;
            this.structure = structure;
            this.kerfSize = kerfSize;

            this.edging = edging;

            StringValueCheckAttribute<StockItem>(this);
        }

        /// <summary>
        /// Calculates the real size of the object by subtracting the edging from the length and width.
        /// </summary>
        /// <returns>An anonymous object with the calculated length and width.</returns>
        public dynamic SizeReal()
        {
            double _length = 0;
            double _width = 0;

            _length = edging.left != 0  
                ? this.length - (this.edging.left + this.kerfSize) 
                : this.length;

            _length = edging.right != 0
                ? _length - (this.edging.right + this.kerfSize)
                : _length;

            _width = edging.top != 0 
                ? this.width - (this.edging.top + this.kerfSize) 
                : this.width;

            _width = edging.bottom != 0
                ? _width - (this.edging.bottom + this.kerfSize)
                : _width;

            return new { Length = _length, Width = _width };
        }

    }
}
