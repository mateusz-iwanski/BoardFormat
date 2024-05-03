using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    internal class PieceTemplate
    {
        public static Piece PieceFurnitureMelamineBoard(
            int id, 
            int materialId,
            string identifier, string description,
            int length, int width, int quantity, string structure, 
            Veneers veneers)
        {
            return new Piece(
                id: id,
                materialId: materialId,
                identifier: identifier, description: description,
                length: length, width: width,
                shapeType: "none",
                quantity: quantity,
                structure: structure,
                priority: "normal",
                surplus: 0,
                margin: 0,
                veneers: veneers
                );
        }

    }
}
