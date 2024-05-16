using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Represents a _piece with its position and orientation.
    /// </summary>
    public class CuttingPiece
    {/// <summary>
     /// ID of the _piece.
     /// </summary>
        public int pieceId { get; set; }

        /// <summary>
        /// x position of the _piece.
        /// </summary>
        public double x { get; set; }

        /// <summary>
        /// y position of the _piece.
        /// </summary>
        public double y { get; set; }

        /// <summary>
        /// Specifies if the _piece was rotated.
        /// </summary>
        public bool rotated { get; set; }

        /// <summary>
        /// Specifies if the _piece was reversed (back to front). 
        /// Temporarily 1D only.
        /// </summary>
        public bool mirrored { get; set; }

        /// <summary>
        /// Constructor for the Piece class.
        /// </summary>
        /// <param name="pieceId">ID of the _piece.</param>
        /// <param name="x">x position of the _piece.</param>
        /// <param name="y">y position of the _piece.</param>
        /// <param name="rotated">Specifies if the _piece was rotated.</param>
        /// <param name="mirrored">Specifies if the _piece was reversed (back to front).</param>
        public CuttingPiece(int pieceId, double x, double y, bool rotated, bool mirrored)
        {
            this.pieceId = pieceId;
            this.x = x;
            this.y = y;
            this.rotated = rotated;
            this.mirrored = mirrored;
        }

        public CuttingPiece(JToken jObject)
        {
            pieceId = (int)jObject["pieceId"];
            x = (double)jObject["x"];
            y = (double)jObject["y"];
            rotated = (bool)jObject["rotated"];
            // mirrored = (bool)jObject["mirrored"];
        }
    }
}
