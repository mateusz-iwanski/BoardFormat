using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.FurnitureLibrary
{
    /// <summary>
    /// This class is used to change the size of a cabinet cabinetPiece based on the size of the cabinet.    
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

        public CabinetPieceBehavior WidthChange(float cabinetWidth)
        {
            float newPieceSize = 0.0f;
            if (cabinetWidthPieceWidth.TryCorrectSize(cabinetPiece.Width, out newPieceSize))
            {
                cabinetPiece.SetWidth(newPieceSize);
                newPieceSize = 0.0f;
            }

            if (cabinetWidthPieceLength.TryCorrectSize(cabinetPiece.Length, out newPieceSize))
            {
                cabinetPiece.SetLength(newPieceSize);
            }
            
            return this;
        }

        public CabinetPieceBehavior HeightChange(float cabinetHeight)
        {
            float newPieceSize = 0.0f;
            if (cabinetHeightPieceWidth.TryCorrectSize(cabinetPiece.Width, out newPieceSize))
            {
                cabinetPiece.SetWidth(newPieceSize);
                newPieceSize = 0.0f;
            }

            if (cabinetHeightPieceLength.TryCorrectSize(cabinetPiece.Length, out newPieceSize))
            {
                cabinetPiece.SetLength(newPieceSize);
            }

            return this;
        }

        public CabinetPieceBehavior DepthChange(float cabinetDepth)
        {
            float newPieceSize = 0.0f;

            if (cabinetDepthPieceWidth.TryCorrectSize(cabinetPiece.Width, out newPieceSize))
            {
                cabinetPiece.SetWidth(newPieceSize);
                newPieceSize = 0.0f;
            }

            if (cabinetDepthPieceLength.TryCorrectSize(cabinetPiece.Length, out newPieceSize))
            {
                cabinetPiece.SetLength(newPieceSize);
            }

            return this;
        }

    }
}
