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
        private Piece _piece { get; set; }        
        public PieceType PieceType { get; private set; }
        // we can disable checking behavior of _piece
        // if is disable we don't need to set range of _piece size
        public PieceLimits? PieceBehavior { get; private set; }
        public string Identifier { get; private set; }
        public Piece Piece { get => _piece; }

        /// <summary>
        /// Create cabinetPiece for cabinet.
        /// For the first time we will set empty cabinetPiece with specific behavior,
        /// type, etc. Piece will be set when cabinet will have size, etc.
        /// </summary>
        /// <param name="pieceType"></param>        
        /// <param name="identifier"></param>
        /// <param name="pieceBehavior">Disable/Enable checking behavior of _piece</param>
        public CabinetPiece(            
            PieceType pieceType,             
            string identifier,
            int cabinetId,
            PieceLimits? pieceBehavior = null
            )
        {
            // set default cabinetPiece, we will set it later when cabinet will have change size from default size
            this._piece = new Piece(
                length: 0, width: 0, 
                structure: false, 
                identifier: new Guid().ToString(),
                cabinetID: cabinetId
                );
            this.PieceType = pieceType;
            this.PieceBehavior = pieceBehavior;
            this.Identifier = identifier;
        }

        public void SetWidth(float width)
        {
            _piece.Width = width;
            if (PieceBehavior != null)
            {
                PieceBehavior.Validate();
                PieceBehavior.widthRange.CheckRange(_piece.Width);
            }
        }

        public void SetLength(float length)
        {
            _piece.Length = length;
            if (PieceBehavior != null)
            {

                PieceBehavior.Validate();
                PieceBehavior.lengthRange.CheckRange(_piece.Length);
            }
        }
    }
}
