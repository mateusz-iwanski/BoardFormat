using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    /// <summary>
    /// The RectangleBuilder class is responsible for constructing list of Shapes (rectangles). 
    /// It is used to build board and usable pieceCollection to draw on canvas.
    /// Look out! For Carpenter/Specialist length of cabinetPiece/board is width for graphics/layouts and
    /// width is height for graphics/layouts elements.
    /// </summary>
    public class RectangleBuilder
    {
        public List<Rectangle> RectangleShapes { get; private set; }

        public RectangleBuilder()
        {
            RectangleShapes = new List<Rectangle>();
        }

        /// <summary>
        /// Add shape (rectangle) to list
        /// </summary>
        /// <param name="piece">PieceToDraw</param>
        /// <param name="imageScale">Scale by width</param>
        /// <param name="margin">Add position to lengthRange position (ex.: margin)</param>
        /// <returns></returns>
        public float Add(
            PieceToDraw piece,
            float imageScale,
            float margin
            )
        {
            // Scale rectangle
            float scaledX = (float)piece.X * imageScale;            
            float scaledY = ((float)piece.Y * imageScale) + margin; // Scale lengthRange and increase lengthRange position by margin
            float scaledWidth = (float)piece.Width * imageScale;
            float scaledLength = (float)piece.Length * imageScale;

            // Look out! For carpenter length of cabinetPiece and board is width.
            // Board/cabinetPiece width is height for graphics/layouts elements.
            RectangleShapes.Add(
                new Rectangle(
                    x: scaledX,
                    y: scaledY,
                    width: scaledLength,
                    height: scaledWidth,
                    piece: piece
                    )
                );

            // if cabinetPiece is board, send width of board + margin
            return piece.Type == DrawerType.Board ? margin + scaledWidth : 0;
        }

        
        /// <summary>
        /// The Build method in the RectangleBuilder class is responsible for constructing 
        /// board and pieceCollection to draw on canvas. Rectangles are build from the list of Board 
        /// and pices inside.
        /// </summary>
        /// <param name="pieceToDrawListCollection"></param>
        /// <param name="imageScaleByWidth"></param>
        public float Build(
            List<PieceToDraw> pieceToDrawListCollection,
            float imageScaleByWidth,
            float margin
            )
        {
            float shapeHeight = 0;

            float heightPointYPosition = 0;

            pieceToDrawListCollection.ForEach(piece =>
            {
                // Setter for height of this board in loop

                heightPointYPosition = Add(
                    piece: piece,
                    imageScale: imageScaleByWidth,
                    margin: margin
                );

                // Add return board size and next is use to set Layout Height
                shapeHeight += heightPointYPosition;

            });

            return shapeHeight;
        }

    }       
}
