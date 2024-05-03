using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardFormat.MVVM.Models;

namespace BoardFormat.FurnitureLibrary
{
    /// <summary>
    /// It is a struct that contains a piece, a piece type and a piece behavior
    /// in Furniture. It is used to create a collection of pieces in Furniture 
    /// with specific behavior.
    /// </summary>
    public struct CabinetPiece
    {
        public Piece Piece { get; private set; }
        public PieceType PieceType { get; private set; }
        public PieceBehavior PieceBehavior { get; private set; }

        public CabinetPiece(Piece piece, PieceType pieceType, PieceBehavior pieceBehavior)
        {
            this.Piece = piece;
            this.PieceType = pieceType;
            this.PieceBehavior = pieceBehavior;
            Validate();
        }

        private void Validate()
        {
            // first check that range is set
            PieceBehavior.Validate();
            // then check if piece size is in range
            // look out! Piece.Length is width and Piece.Width is height
            PieceBehavior.widthRange.CheckRange(Piece.Width);
            PieceBehavior.lengthRange.CheckRange(Piece.Length);
        }
    }
}
