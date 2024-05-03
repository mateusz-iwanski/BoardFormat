using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Material object for defining material group.
    /// Each piece or StockItem must belong to a material group.
    /// Thanks to this, the program knows which pieces are to be placed on which stock items.
    /// </summary>
    public class Material : DataGroupInput, IDataGroupRoot
    {
        /// <summary>
        /// Unique id of a material group. (mandatory)
        /// </summary>
        public int id { get; }

        /// <summary>
        /// Id of a cutting device used to cut this material group. (mandatory)
        /// </summary>
        public int deviceId { get; }

        /// <summary>
        /// Title of the material group. (mandatory)
        /// </summary>
        public string title { get; }

        /// <summary>
        /// Specifies the type of the material. (mandatory)
        /// Allowed values
        ///     - 1d
        ///         1D materials like profiles, pipes, rods, beams, etc.
        ///     - 2d
        ///         2D materials like glass, panels, fabric, aluminum, cardboard, etc.
        /// </summary>
        [StringValueAssignable("1d", "2d")]
        public string kind { get; }

        /// <summary>
        /// Specifies the width of the material. (mandatory, 1D only)
        /// </summary>
        public int width { get; }

        /// <summary>
        /// Specifies the thickness of the material. (mandatory)
        /// </summary>
        public int thickness { get; }

        /// <summary>
        /// Specifies whether the material group can have a structure. (2D only)
        /// </summary>
        public bool canHaveStructure { get; }

        /// <summary>
        /// Specifies whether the pieces of this material group can be rotated. (1D only?)
        /// </summary>
        // TODO: in documentation it is 1D only, is it?
        public bool canRotate { get; }

        /// <summary>
        /// Specifies whether the pieces of this material group can be reversed (back to front). (1D only)
        /// </summary>
        public bool canMirror { get; }

        /// <summary>
        /// This setting defines the default surplus for pieces, meaning the amount by which each cut element will be enlarged on all sides. 
        /// For instance, if a 
        /// is 300x200 and the surplus is set to 2, the optimizer will use a size of 304x204. 
        /// In the case of 1D materials, this applies, of course, only to the length.
        /// </summary>
        public int surplus { get; }

        /// <summary>
        /// This setting determines whether the surplus can be adjusted in the piece configuration. 
        /// If set to false, any surplus specified by the piece will be disregarded and the one defined in material group will be used.
        /// </summary>
        public bool surplusEditable { get; }

        /// <summary>
        /// This setting determines the default Margin for pieces, which is the amount by which each cut element will be reduced on all sides. 
        /// For instance, if a piece is 300x200 and the Margin is set to 2, the optimizer will use 296x196. 
        /// In the case of 1D materials, this applies, of course, only to the length.
        /// </summary>
        public int margin { get; }

        /// <summary>
        /// This setting determines whether the Margin can be adjusted in the piece configuration. 
        /// If set to false, any Margin specified by the piece will be disregarded and the one defined in material group will be used.
        /// </summary>
        public bool marginEditable { get; }

        /// <summary>
        /// Specifies default edging for new stock items.
        /// </summary>
        public int defaultEdging { get; }

        /// <summary>
        /// Piece size used for cutting. (mandatory, 2D only)
        /// Allowed values
        ///     - net
        ///         The size specified by length & width of the piece will be used.
        ///         Note that surplus and Margin may be applied if they are specified.
        ///     - gross
        ///         The size of the piece will be increased by the thickness of the veneers used.
        /// </summary>
        [StringValueAssignable("net", "gross")]
        public string cuttingDimensions { get; }

        /// <summary>
        /// Specifies whether pieces of the material group can be veneered. (2D only)
        /// </summary>
        public bool canBeVeneered { get; }

        /// TODO: It's in examples but not in documentation
        private bool grindable { get; }

        /// <summary>
        /// Specifies the size of the kerf, i.e. the width of the waste line left by the cutting device.
        /// </summary>
        // TODO : can be double? Yes It can
        public double kerf { get; }

        /// <summary>
        /// Specifies whether it is possible to do something that we call the "edge cutting". 
        /// If you have 2mm to cut off and the kerf is 3mm, then you kind of have to "take off" those 2mm with just the saw blade - that's edge cutting.
        /// It is ignored if minCutWidth property of used cutting device is greater than zero.
        /// </summary>
        public bool allowEdgeCuts { get; }

        /// <summary>
        /// It defines the criterion for qualifying waste as usable. usable waste is one that goes to the warehouse for later use.
        /// </summary>
        public ReuseWaste rauseWaste { get; }

        /// <summary>
        /// The list of standardStockItems for the material group.
        /// </summary>
        public List<StandardStockItem> standardStockItems { get; }

        // TODO: check what is this, it's in examples but not in documentation
        //"standardSheet": [],

        /// <summary>
        /// Initializes a new instance of the Material class.
        /// </summary>
        /// <param name="id">Unique id of a material group. (mandatory)</param>
        /// <param name="deviceId">Id of a cutting device used to cut this material group. (mandatory)</param>
        /// <param name="title">Title of the material group. (mandatory)</param>
        /// <param name="kind">Specifies the type of the material. (mandatory)</param>
        /// <param name="width">Specifies the width of the material. (mandatory, 1D only)</param>
        /// <param name="thickness">Specifies the thickness of the material. (mandatory)</param>
        /// <param name="canHaveStructure">Specifies whether the material group can have a structure. (2D only)</param>
        /// <param name="canRotate">Specifies whether the pieces of this material group can be rotated. (1D only?)</param>
        /// <param name="canMirror">Specifies whether the pieces of this material group can be reversed (back to front). (1D only)</param>
        /// <param name="surplus">This setting defines the default surplus for pieces, meaning the amount by which each cut element will be enlarged on all sides.</param>
        /// <param name="surplusEditable">This setting determines whether the surplus can be adjusted in the piece configuration.</param>
        /// <param name="margin">This setting determines the default Margin for pieces, which is the amount by which each cut element will be reduced on all sides.</param>
        /// <param name="marginEditable">This setting determines whether the Margin can be adjusted in the piece configuration.</param>
        /// <param name="defaultEdging">Specifies default edging for new stock items.</param>
        /// <param name="cuttingDimensions">Piece size used for cutting. (mandatory, 2D only)</param>
        /// <param name="canBeVeneered">Specifies whether pieces of the material group can be veneered. (2D only)</param>
        /// <param name="kerf">Specifies the size of the kerf, i.e. the width of the waste line left by the cutting device.</param>
        /// <param name="allowEdgeCuts">Specifies whether it is possible to do something that we call the "edge cutting".</param>
        public Material(int id, int deviceId, string title, string kind, 
            int width, int thickness, bool canHaveStructure, 
            bool canRotate, bool canMirror, int surplus, bool surplusEditable, 
            int margin, bool marginEditable, 
            int defaultEdging, 
            string cuttingDimensions, 
            bool canBeVeneered, 
            double kerf, 
            bool allowEdgeCuts,
            ReuseWaste rauseWaste,
            List<StandardStockItem> standardStockItems)
        {
            // Assigning values to properties
            this.id = id;
            this.deviceId = deviceId;
            this.title = title;
            this.kind = kind;
            this.width = width;
            this.thickness = thickness;
            this.canHaveStructure = canHaveStructure;
            this.canRotate = canRotate;
            this.canMirror = canMirror;
            this.surplus = surplus;
            this.surplusEditable = surplusEditable;
            this.margin = margin;
            this.marginEditable = marginEditable;
            this.defaultEdging = defaultEdging;
            this.cuttingDimensions = cuttingDimensions;
            this.canBeVeneered = canBeVeneered;
            this.kerf = kerf;
            this.allowEdgeCuts = allowEdgeCuts;


            this.rauseWaste = rauseWaste;

            this.standardStockItems = standardStockItems;

            StringValueCheckAttribute<Material>(this); 
        }
    }
}
