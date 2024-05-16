using Microsoft.SqlServer.Server;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// The Piece object describes _piece.
    /// </summary>
    public class Piece : DataGroupInput, ISemiFinished, IDataGroupRoot
    {
        /// <summary>
        /// Unique _piece id.
        /// </summary>
        public int id { get; }

        /// <summary>
        /// The ID of the material group from which this _piece will be cut.
        /// </summary>
        public int materialId { get; }

        /// <summary>
        /// The user defined identifier of the _piece. It must be Code128 barcode compatible.
        /// </summary>
        public string identifier { get; }

        /// <summary>
        /// Description of the _piece.
        /// </summary>
        public string description { get; }

        /// <summary>
        /// The net length of the _piece. For 1D shapes, it is always the total length, including slants.
        /// </summary>
        public int length { get; }

        /// <summary>
        /// The net width of the _piece.
        /// </summary>
        public int width { get; }

        /// <summary>
        /// Type of the shape of the _piece. Allowed values: none, rectangle, linear. 
        /// Allowed values:
        ///     - none
        ///         No shape, the same as rectangle.
        ///     - rectangle
        ///         Just rectangle, so no additional shape definition is necessary.
        ///     linear
        ///         Linear 1D shape with slants.The shape property contains slant values.
        /// </summary>
        [StringValueAssignable("none", "rectangle", "linear")]
        public string shapeType { get; }

        /// <summary>
        /// Depending on shapeType it may contain different Format.
        /// Not using in 2D
        /// </summary>
        /// public string shape { get; }

        /// <summary>
        /// Specifies quantity of pieces.
        /// </summary>
        public int quantity { get; }

        /// <summary>
        /// Specifies acceptable structures of the _piece. Allowed values: none, byLength, byWidth.
        /// Allowed values
        ///     - none
        ///         The material has no structure. Is not good idea to use it, if set none optimalization not rotate the _piece.
        ///         Is better to use
        ///     - byLength
        ///         The structure is horizontal (along length).
        ///     - byWidth
        ///         The structure is vertical (along width).
        ///     - "none,byLength,byWidth" = The material has no structure or with structure but can be rotate.
        ///       With this settings the _piece will can be rotated by optimalization.
        ///     - any
        // TODO: any - check this value, it is not in documentation is in examples, is not working. Probably is should work as/for  “none,byLength,byWidth"
        /// </summary>
        [StringValueAssignable("none", "byLength", "byWidth", "none,byLength,byWidth")]
        public string structure { get; }
        
        /// <summary>
        /// Priority of the _piece. Allowed values: normal, high, critical.
        /// Allowed values
        ///     - normal
        ///         The _piece is handled normally.
        ///     - high
        ///         The _piece has 5x higher value than normal ones.
        ///     - critical
        ///         The _piece has 10x higher value than normal ones.
        /// </summary>
        [StringValueAssignable("normal", "high", "critical")]
        public string priority { get; }
        

        /// <summary>
        /// Specifies the surplus, meaning the amount by which the _piece size will be enlarged on all sides.
        /// For instance, if a _piece is 300x200 and the surplus is set to 2, the optimizer will use a size of 304x204.
        /// In the case of 1D materials, this applies, of course, only to the length.
        /// </summary>
        public int surplus { get; }

        /// <summary>
        /// Specifies the Margin, which is the amount by which the _piece size will be reduced on all sides.
        /// For instance, if a _piece is 300x200 and the Margin is set to 2, the optimizer will use 296x196.
        /// In the case of 1D materials, this applies, of course, only to the length.
        /// </summary>
        public int margin { get; }

        /// <summary>
        /// Specifies which veneers should be used, including leftVeneerId, rightVeneerId, topVeneerId, and bottomVeneerId.
        /// You have to have created object Venner before set it with Veneer->id.
        /// </summary>
        public Veneers veneers { get; set; }

        /// <summary>
        /// Unique _piece id.
        /// </summary>
        /// <param name="id">The unique _piece id.</param>
        /// <param name="materialId">The ID of the material group from which this _piece will be cut.</param>
        /// <param name="identifier">The user defined identifier of the _piece. It must be Code128 barcode compatible.</param>
        /// <param name="description">Description of the _piece.</param>
        /// <param name="length">The net length of the _piece. For 1D shapes, it is always the total length, including slants.</param>
        /// <param name="width">The net width of the _piece.</param>
        /// <param name="shapeType">Type of the shape of the _piece. Allowed values: none, rectangle, linear.</param>
        /// <param name="quantity">Specifies quantity of pieces.</param>
        /// <param name="structure">Specifies acceptable structures of the _piece. Allowed values: none, byLength, byWidth.</param>
        /// <param name="priority">Priority of the _piece. Allowed values: normal, high, critical.</param>
        /// <param name="surplus">Specifies the surplus, meaning the amount by which the _piece size will be enlarged on all sides.</param>
        /// <param name="margin">Specifies the Margin, which is the amount by which the _piece size will be reduced on all sides.</param>        
        /// <param name="veneers">Specifies which veneers should be used.2D Only</param>
        public Piece(
            int id, int materialId, 
            string identifier, string description, 
            int length, int width, string shapeType, int quantity, string structure, string priority, int surplus, int margin,
            Veneers veneers 
            )
        {
            this.id = id;
            this.materialId = materialId;
            this.identifier = identifier;
            this.description = description;
            this.length = length;
            this.width = width;
            this.shapeType = shapeType;            
            this.quantity = quantity;
            this.structure = structure;
            this.priority = priority;
            this.surplus = surplus;
            this.margin = margin;
            this.veneers = veneers;

            StringValueCheckAttribute<Piece>(this); 

        }

        /// <summary>
        /// Calculates the size of the _piece based on length, width, surplus and Margin.
        /// </summary>
        /// <returns>Returns an anonymous object with the calculated length and width.</returns>
        public dynamic SizeReal()
        {
            int _length = surplus == 0 ? this.length : this.length + (this.surplus * 2);
            int _width = surplus == 0 ? this.width : this.width + (this.surplus * 2);
            
            _length = margin == 0 ? _length : _length - (this.margin * 2);
            _width = margin == 0 ? _width : _width - (this.margin * 2);

            return new { Length = _length, Width = _width };
        }

    }
}
