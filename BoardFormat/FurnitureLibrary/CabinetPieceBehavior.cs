using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.FurnitureLibrary
{
    /// <summary>
    /// This class is used to change the size of a cabinet cabinetPiece based on the size of the cabinet.    
    /// For example:
    ///     cabinetWidthPieceWidth: new SizeMatch().SetValue(-2), // cabinetPiece.width = cabinetWidth - 2
    ///     cabinetWidthPieceLength: new SizeMatch().SetValue(-2), // cabinetPiece.length = cabinetWidth - 2
    ///     cabinetHeightPieceWidth: new SizeMatch().SetValue(2),  // cabinetPiece.width = cabinetHeight + 2
    ///     cabinetHeightPieceLength: new SizeMatch().SetValue(2), // cabinetPiece.length = cabinetHeight + 2
    ///     cabinetDepthPieceWidth: new SizeMatch().SetNull(),  // do nothing when cabinet changes depth
    ///     cabinetDepthPieceLength: new SizeMatch().SetNull()  // do nothing when cabinet changes depth
    /// </summary>
    public class CabinetPieceBehavior
    {
        public CabinetPiece cabinetPiece { get; private set; }

        ISizeMatch cabinetWidthPieceWidth;
        ISizeMatch cabinetWidthPieceLength;
        ISizeMatch cabinetHeightPieceWidth;
        ISizeMatch cabinetHeightPieceLength;
        ISizeMatch cabinetDepthPieceWidth;
        ISizeMatch cabinetDepthPieceLength;

        public CabinetPieceBehavior(
            CabinetPiece piece,
            ISizeMatch cabinetWidthPieceWidth,
            ISizeMatch cabinetWidthPieceLength,
            ISizeMatch cabinetHeightPieceWidth,
            ISizeMatch cabinetHeightPieceLength,
            ISizeMatch cabinetDepthPieceWidth,
            ISizeMatch cabinetDepthPieceLength
            )
        {
            this.cabinetPiece = piece;
            this.cabinetWidthPieceWidth = cabinetWidthPieceWidth;
            this.cabinetWidthPieceLength = cabinetWidthPieceLength;
            this.cabinetHeightPieceWidth = cabinetHeightPieceWidth;
            this.cabinetHeightPieceLength = cabinetHeightPieceLength;
            this.cabinetDepthPieceWidth = cabinetDepthPieceWidth;
            this.cabinetDepthPieceLength = cabinetDepthPieceLength;
            return;
        }

        /// <summary>
        /// When cabinet changes width, we will change cabinetPiece width and length based on cabinet width.
        /// </summary>
        /// <param name="cabinetWidth">Width of cabinet</param>
        /// <returns></returns>
        public CabinetPieceBehavior WidthChange(float cabinetWidth)
        {
            float newPieceSize = 0.0f;
            if (cabinetWidthPieceWidth.TryCorrectSize(cabinetWidth, out newPieceSize))
            {
                cabinetPiece.SetWidth(newPieceSize);
                newPieceSize = 0.0f;
            }

            if (cabinetWidthPieceLength.TryCorrectSize(cabinetWidth, out newPieceSize))
            {
                cabinetPiece.SetLength(newPieceSize);
            }
            
            return this;
        }

        /// <summary>
        /// When cabinet changes height, we will change cabinetPiece width and length based on cabinet height.
        /// </summary>
        /// <param name="cabinetHeight">Height of cabinet</param>
        /// <returns></returns>
        public CabinetPieceBehavior HeightChange(float cabinetHeight)
        {
            float newPieceSize = 0.0f;
            if (cabinetHeightPieceWidth.TryCorrectSize(cabinetHeight, out newPieceSize))
            {
                cabinetPiece.SetWidth(newPieceSize);
                newPieceSize = 0.0f;
            }

            if (cabinetHeightPieceLength.TryCorrectSize(cabinetHeight, out newPieceSize))
            {
                cabinetPiece.SetLength(newPieceSize);
            }

            return this;
        }

        /// <summary>
        /// When cabinet changes depth, we will change cabinetPiece width and length based on cabinet depth.
        /// </summary>
        /// <param name="cabinetDepth">Depth of cabinet</param>
        /// <returns></returns>
        public CabinetPieceBehavior DepthChange(float cabinetDepth)
        {
            float newPieceSize = 0.0f;

            if (cabinetDepthPieceWidth.TryCorrectSize(cabinetDepth, out newPieceSize))
            {
                cabinetPiece.SetWidth(newPieceSize);
                newPieceSize = 0.0f;
            }

            if (cabinetDepthPieceLength.TryCorrectSize(cabinetDepth, out newPieceSize))
            {
                cabinetPiece.SetLength(newPieceSize);
            }

            return this;
        }

    }
}
