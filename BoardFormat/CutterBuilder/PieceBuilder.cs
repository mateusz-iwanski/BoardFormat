using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TonCut;

namespace BoardFormat.CutterBuilder
{
    public class PieceBuilder : BaseCutterBuilder, ICutterInputBuilder
    {
        DataInputCollector DataInputCollector { get; set; }
        int id { get; set; }
        int materialId { get; set; }
        string identifier { get; set; }
        string description { get; set; }
        int length { get; set; }
        int width { get; set; }
        int quantity { get; set; }
        string structure { get; set; }
        string shapeType { get; set; }
        string priority { get; set; }
        int surplus { get; set; }
        int margin { get; set; }
        /// <summary>
        /// When bold is true cabinetPiece has thickness as material * 2, 
        /// we add two pieceCollection to list with veneer 42mm set to one of cabinetPiece.        
        /// Otherwise we add one cabinetPiece with 21mm veneer
        /// We have default (18mm)/ assigned to board/ unicolour/ structure/ gloss type of veneer.
        /// We should have a list of veneer for all board colours/structures
        /// </summary>
        bool bold { get; set; }

        //Veneer object
        int? leftVeneerId { get; set; }
        int? rightVeneerId { get; set; }
        int? topVeneerId { get; set; }
        int? bottomVeneerId { get; set; }
        
        public PieceBuilder(
            DataInputCollector dataInputCollector,
            ref int id,
            int materialId,
            string identifier, string description,
            int length, int width, int quantity, bool structure,
            bool leftVeneer, bool rightVeneer, bool topVeneer, bool bottomVeneer,
            bool bold
            )
        {
            DataInputCollector = dataInputCollector;

            this.id = ++id;
            this.materialId = materialId;
            this.identifier = identifier;
            this.description = description;
            this.length = length;
            this.width = width;
            this.quantity = quantity;
            this.structure = structure ? "none,byLength,byWidth" : "byLength";


            this.shapeType = settings.CutterPiece.shapeType;
            this.priority = settings.CutterPiece.priority;
            this.surplus = settings.CutterPiece.surplus;
            this.margin = settings.CutterPiece.margin;

            // Veneer is set 1 (21mm) or 2 (42mm) because there is only two veneers in use with id 1 or 2 
            this.leftVeneerId = leftVeneer ? (bold ? 2 : 1) : null;
            this.rightVeneerId = rightVeneer ? (bold ? 2 : 1) : null;
            this.topVeneerId = topVeneer ? (bold ? 2 : 1) : null;
            this.bottomVeneerId = bottomVeneer ? (bold ? 2 : 1) : null;

            Build();
        }
        public DataInputCollector Build()
        {            
            Piece piece = new Piece(
                    id: id,
                    materialId: materialId,
                    identifier: identifier, description: description,
                    length: length, width: width,
                    shapeType: shapeType,
                    quantity: quantity,
                    structure: structure,
                    priority: priority,
                    surplus: surplus,
                    margin: margin,
                    veneers:
                        new Veneers(
                            leftVeneerId: this.leftVeneerId,
                            rightVeneerId: this.rightVeneerId,
                            topVeneerId: this.topVeneerId,
                            bottomVeneerId: this.bottomVeneerId)
                );
            
            this.DataInputCollector.Append(piece);

            if (bold)
            {
                piece.veneers = new Veneers(leftVeneerId: null, rightVeneerId: null, topVeneerId: null, bottomVeneerId: null);
                this.DataInputCollector.Append(piece);
            }

            return this.DataInputCollector;
        }
    }
}
