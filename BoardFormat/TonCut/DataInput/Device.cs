using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static TonCut.Device;
using static TonCut.Limits;

namespace TonCut
{
    /// <summary>
    /// Device object represents a cutting device.
    /// It specifies the features and limitations of the device.
    /// </summary>
    // TODO: check different parameters and serve exception.
    public class Device : DataGroupInput, IDataGroupRoot
    {
        /// <summary>
        /// Unique device id.
        /// </summary>
        public int id { get; }

        /// <summary>
        /// Device title.
        /// </summary>
        public string title { get; }

        /// <summary>
        /// Specifies the material kind this device is made for.
        /// Allowed values:
        ///     - 1d
        ///         1D materials like profiles, pipes, rods, beams, etc.
        ///     - 2d
        ///         2D materials like glass, panels, fabric, aluminum, cardboard, etc.
        /// </summary>
        // TODO: 1d, 2d can't be enum - first letter can be number
        [StringValueAssignable("1d", "2d")]
        public string materialKind { get; }

        /// <summary>
        /// Specifies support for miter cuts in 1D materials.
        /// 1D only
        /// </summary>
        public Slants slants { get; }

        /// <summary>
        /// Set it to true if the device allows the cuts to cross each other.
        /// 2D only
        /// </summary>
        public bool canCrossCuts { get; }

        /// <summary>
        /// Set it to true if only full cuts (from edge to edge) are allowed.
        /// 2D only.
        /// </summary>
        public bool fullCutsOnly { get; }

        /// <summary>
        /// Set it to true if the device cuts in strips (e.g. for panel saw). 
        /// 2D only
        /// It makes sense only if fullCutsOnly option is set to true.
        /// Otherwise, the program will not know what the size limit of the strip is. 
        /// This can lead to a situation where a strip with the width of the entire sheet is generated.
        /// </summary>
        public bool stripCuts { get; }

        /// <summary>
        /// The minimum distance between two cuts.
        /// 2D only.
        /// Setting this value makes sense when cutting glass – you don't want to have two parallel cuts too close to each other, 
        /// because then breaking off can be significantly more difficult.
        /// Please note that this is not a kerf that can be set in the material group settings.
        /// </summary>
        public int minCutWidth { get; }

        /// <summary>
        /// Edging method.
        /// 2D only
        /// Allowed values:
        ///     - optimal
        ///         An optimal edging method ensures precise and accurate cutting of edges, resulting in clean, smooth, and well-defined boundaries while minimizing any unintended removal or distortion of the desired elements.
        ///     - horizontalFirst
        ///         A "horizontalFirst" edging method involves cutting off the horizontal edges first, followed by the vertical edges.
        ///     - verticalFirst
        ///         A "verticalFirst" edging method refers to a technique where the vertical edges are cut off before the horizontal edges.
        /// </summary>
        // TODO: czy to dziala tak, ze w momencie jak optymaliztor uzna, ze lepiej obrocic plyte po szerokosci przy pierwszym cieciu, to ustawiajac opcje horizontalFirst to tnie pierwsze ciecie po szerokosci?
        // TODO: jesli nie... to zalezy czy optymalizator ustawi plyte po dlugosci lub szerokosci przy pierwszym cieciu, czesto sie zdarza, ze optymalniej bedzie zaczac ciac plyte po szerokosci
        // a nie dlugosci ... i co wtedy? Dla ciec gilotynowych optimal nie jest optymalne, wydluza sie czas ciecia, wiecej ruchow pily po calej dlugosci stolu.
        [StringValueAssignable("optimal", "horizontalFirst", "verticalFirst")]
        public string edgingCuts { get; }

        /// <summary>
        /// Edging method for the top and left edges.
        /// 2D only
        /// Allowed values:
        ///     - default
        ///         Nothing changes and edges will be cut off as described in edgingCuts property description.
        ///     - twoFullCuts
        ///          The Top and left edges will be cut off as full cuts(from edge to edge)
        /// </summary>
        [StringValueAssignable("default", "twoFullCuts")]
        public string originEdgingCuts { get; }

        /// <summary>
        /// Specifies whether the first cut will be done horizontally or vertically.
        /// 2D only
        /// It's important to note that setting the correct firstCutDirection can be crucial when used in conjunction with the maxCutDepth option.
        /// Allowed values:
        ///     - horizontal
        ///         First cut will be horizontal, along the length of the StockItem.
        ///     - vertical
        ///         First cut will be vertical, along the width of the StockItem.
        ///     - any
        ///         The Algorithm will decide.
        /// </summary>
        [StringValueAssignable("horizontal", "vertical", "any")]
        public string firstCutDirection { get; }

        /// <summary>
        /// Specifies maximum cut depth level the device is supporting.
        /// 2D only
        /// It makes sense only if fullCutsOnly is set to true.
        /// </summary>
        public MaxCutDepth maxCutDepth { get; set; }

        /// <summary>
        /// Maximum horizontal cut length.
        /// It can also be used when cutting in strips - then it allows to limit the width of the strip.
        /// This option is especially useful when the device is a guillotine.
        /// </summary>
        // TODO: what's that mean? I don't understand it, when can i use it and for what?
        public MaxCutLengthByLength maxCutLengthByLength { get; }


        /// <summary>
        /// Maximum vertical cut length.
        /// It can also be used when cutting in strips - then it allows to limit the width of the strip.
        /// This option is especially useful when the device is a guillotine.
        /// </summary>
        // TODO: what's that mean? I don't understand it, when can i use it and for what?
        public MaxCutLengthByWidth maxCutLengthByWidth { get; }

        /// <summary>
        /// Constructor for the Device class.
        /// </summary>
        /// <param name="id">Unique device id.</param>
        /// <param name="title">Device title.</param>
        /// <param name="materialKind">Specifies the material kind this device is made for.</param>
        /// <param name="slants">Only 1D. Specifies support for miter cuts in 1D materials. Set it to true if the device supports miter cuts.</param>
        /// <param name="canCrossCuts">Set it to true if the device allows the cuts to cross each other.</param>
        /// <param name="fullCutsOnly">Set it to true if only full cuts (from edge to edge) are allowed.</param>
        /// <param name="stripCuts">Set it to true if the device cuts in strips.</param>
        /// <param name="minCutWidth">The minimum distance between two cuts.</param>
        /// <param name="edgingCuts">Edging method.</param>
        /// <param name="originEdgingCuts">Edging method for the top and left edges.</param>
        /// <param name="firstCutDirection">Specifies whether the first cut will be done horizontally or vertically.</param>
        /// <param name="maxCutDepth"> Specifies maximum cut depth level the device is supporting. It makes sense only if fullCutsOnly is set to true.</param>
        /// <param name="maxCutLengthByLength"> Maximum horizontal cut length. It can also be used when cutting in strips - then it allows to limit the width of the strip. This option is especially useful when the device is a guillotine.</param>
        /// <param name="maxCutLengthByWidth">Maximum vertical cut length. It can also be used when cutting in strips - then it allows to limit the width of the strip. This option is especially useful when the device is a guillotine.</param>
        public Device(
            int id,
            string title,
            string materialKind,
            Slants slants, //bool slantsSupported, string slantsLeftMeasurement, string slantsRightMeasurement,
            bool canCrossCuts,
            bool fullCutsOnly,
            bool stripCuts,
            int minCutWidth,
            string edgingCuts,
            string originEdgingCuts,
            string firstCutDirection,
            MaxCutDepth maxCutDepth, // bool maxCutDepthEnabled, int maxCutDepthLimit, bool maxCutDepthincludeEdging,
            MaxCutLengthByLength maxCutLengthByLength, //bool maxCutLengthByLengthEnabled, int maxCutLengthByLengthLimit,
            MaxCutLengthByWidth maxCutLengthByWidth // bool maxCutLengthByWidthEnabled, int maxCutLengthByWidthLimit
            )
        {
            this.id = id;
            this.title = title;
            this.materialKind = materialKind;

            this.slants = slants;
            
            this.canCrossCuts = canCrossCuts;
            this.fullCutsOnly = fullCutsOnly;
            this.stripCuts = stripCuts;
            this.minCutWidth = minCutWidth;
            this.edgingCuts = edgingCuts;
            this.originEdgingCuts = originEdgingCuts;
            this.firstCutDirection = firstCutDirection;

            this.maxCutDepth = maxCutDepth;

            this.maxCutLengthByLength = maxCutLengthByLength;

            this.maxCutLengthByWidth = maxCutLengthByWidth;

            StringValueCheckAttribute<Device>(this);
        }
        
    }
}
