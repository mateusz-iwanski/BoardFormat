using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardFormat.MVVM.Models;

namespace BoardFormat.FurnitureLibrary
{
    /// <summary>
    /// It is a struct that contains a cabinetPiece, a cabinetPiece type and a cabinetPiece behavior
    /// in Furniture. It is used to create a collection of pieceCollection in Furniture 
    /// with specific behavior.
    /// </summary>
    public struct CabinetPiece
    {
        public Guid CabinetId { get; private set; }
        public Piece piece { get; private set; }
        public PieceType PieceType { get; private set; }
        public PieceLimits PieceBehavior { get; private set; }
        public string Identifier { get; private set; }
        public float Length { get => piece.Length; }
        public float Width { get => piece.Width; }

        /// <summary>
        /// Create cabinetPiece for cabinet.
        /// For the first time we will set empty cabinetPiece with specific behavior,
        /// type, etc. Piece will be set when cabinet will have size, etc.
        /// </summary>
        /// <param name="pieceType"></param>
        /// <param name="pieceBehavior"></param>
        /// <param name="cabinetId"></param>
        /// <param name="identifier"></param>
        /// <param name="piece"></param>
        public CabinetPiece(            
            PieceType pieceType, 
            PieceLimits pieceBehavior,
            Guid cabinetId,
            string identifier
            //Piece cabinetPiece
            )
        {
            // set default cabinetPiece, we will set it later when cabinet will have change size from default size
            this.piece = new Piece(length: 0, width: 0, structure: false, identifier: new Guid().ToString());//cabinetPiece;
            this.PieceType = pieceType;
            this.PieceBehavior = pieceBehavior;
            this.CabinetId = cabinetId;
            this.Identifier = identifier;
            //Validate();
        }

        /// <summary>
        /// Validate when cabinet change size.
        /// </summary>
        private void Validate()
        {
            // first check that range is set
            PieceBehavior.Validate();
            // then check if cabinetPiece size is in range
            // look out! Piece.Length is width and Piece.GetWidth is height
            PieceBehavior.widthRange.CheckRange(piece.Width);
            PieceBehavior.lengthRange.CheckRange(piece.Length);
        }

        public void SetWidth(float width)
        {
            piece.Width = width;
            PieceBehavior.widthRange.CheckRange(piece.Width);
            PieceBehavior.Validate();
            //Validate();
        }

        public void SetLength(float length)
        {
            piece.Length = length;
            PieceBehavior.Validate();
            PieceBehavior.lengthRange.CheckRange(piece.Length);
            //Validate();
        }
    }
}
