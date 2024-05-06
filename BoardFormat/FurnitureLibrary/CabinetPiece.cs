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
        private Piece piece { get; set; }
        
        public Guid CabinetId { get; private set; }        
        public PieceType PieceType { get; private set; }
        // we can disable checking behavior of piece
        // if is disable we don't need to set range of piece size
        public PieceLimits? PieceBehavior { get; private set; }
        public string Identifier { get; private set; }
        public Piece Piece { get => piece; }

        /// <summary>
        /// Create cabinetPiece for cabinet.
        /// For the first time we will set empty cabinetPiece with specific behavior,
        /// type, etc. Piece will be set when cabinet will have size, etc.
        /// </summary>
        /// <param name="pieceType"></param>        
        /// <param name="cabinetId"></param>
        /// <param name="identifier"></param>
        /// <param name="piece"></param>
        /// <param name="pieceBehavior">Disable/Enable checking behavior of piece</param>
        public CabinetPiece(            
            PieceType pieceType,             
            Guid cabinetId,
            string identifier,
            PieceLimits? pieceBehavior = null
            )
        {
            // set default cabinetPiece, we will set it later when cabinet will have change size from default size
            this.piece = new Piece(length: 0, width: 0, structure: false, identifier: new Guid().ToString());//cabinetPiece;
            this.PieceType = pieceType;
            this.PieceBehavior = pieceBehavior;
            this.CabinetId = cabinetId;
            this.Identifier = identifier;
        }

        public void SetWidth(float width)
        {
            piece.Width = width;
            if (PieceBehavior != null)
            {
                PieceBehavior.Validate();
                PieceBehavior.widthRange.CheckRange(piece.Width);
            }
        }

        public void SetLength(float length)
        {
            piece.Length = length;
            if (PieceBehavior != null)
            {

                PieceBehavior.Validate();
                PieceBehavior.lengthRange.CheckRange(piece.Length);
            }
        }
    }
}
