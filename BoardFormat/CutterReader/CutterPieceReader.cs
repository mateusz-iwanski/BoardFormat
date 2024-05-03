using BoardFormat.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonCut;

namespace BoardFormat.CutterReader
{
    public class CutterPieceReader
    {
        ICutterReader _reader;

        public CutterPieceReader(ICutterReader reader)
        {
            _reader = reader;
        }

        public TonCut.Piece GetPieceInput(int pieceId) =>
            _reader.dataInput.pieces.Cast<TonCut.Piece>().ToList().First(p => p.id == pieceId)
            ;

        public CuttingPiece GetPieceOutput(int pieceId)
        {
            CuttingPiece? piece = null;
            
            _reader.dataOutputs.cuttings.ForEach(cutting =>
                    //if (piece == null)
                    piece = cutting.pieces.FirstOrDefault(p => p.pieceId == pieceId) ?? piece
            );

            return piece;
        }

        
    }
}
