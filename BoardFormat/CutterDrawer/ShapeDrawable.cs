using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    /// <summary>
    /// The ShapeDrawable is a class that implements the IDrawable interface. 
    /// It represents a drawable object that can be used to draw shapes on a canvas.
    /// All objects from output data are converted to shapes and stored in a list.
    /// All shapes are drawable in one GraphicsView.
    /// Before you draw shapes from list, make sure that MakeShapes method is called.
    /// </summary>
    public class ShapeDrawable : IDrawable
    {
        private List<IPieceToDraw> ElementsToDrawListCollection;

        private IShapeBuilder _shapeBuilder;
        public List<ShapeDrawer> Shapes;
        public float ShapeHeight { get; private set; }

        public ShapeDrawable(
            List<IPieceToDraw> elementsToDrawCollection,
            IShapeBuilder shapeBuilder,
            float scaleToWidth,
            float leftRightMargin,
            float topMargin
            )
        {
            ElementsToDrawListCollection = elementsToDrawCollection;
            _shapeBuilder = shapeBuilder;
            Shapes = new List<ShapeDrawer>();
            float maxSize = GetMaxFromELementsToDrawCollection(elementsToDrawCollection);
            ShapeHeight = maxSize;
            MakeShapes(
                scaleToWidth,
                leftRightMargin,
                topMargin,
                maxSize
                );
            return;
        }

        // Get the maximum length value from the list of boards with pieceCollection to draw.
        // The longest should be always length of one of the board
        // Every graphics view should by scale by the longest element 
        public float GetMaxFromELementsToDrawCollection(List<IPieceToDraw> listPiece) =>
            listPiece.Max(piece => (float)piece.Y + (float)piece.Length);

        private float ScaleToGraphicsViewSize(
            float width,
            float marginLeftRightSize,
            float maxSize
            )
        {

            float canvasWidth = width - marginLeftRightSize;
            float scale = canvasWidth / maxSize;

            return scale;
        }

        // Make Shapes from the list of PieceToDraw
        private void MakeShapes(
            float scaleToWidth,
            float leftRightMargin,
            float betweenBoardMargin,
            float maxSize
            )
        {
            float scale = ScaleToGraphicsViewSize(
                width: scaleToWidth,
                marginLeftRightSize: leftRightMargin,
                maxSize: maxSize
                );

            ShapeHeight = _shapeBuilder.Build(
                                elementsToDrawListCollection: ElementsToDrawListCollection,
                                imageScaleByWidth: scale,
                                margin: betweenBoardMargin
                            );
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {            
            foreach (var shape in _shapeBuilder.GetShapes())
                shape.Draw(canvas);
        }

    }
}
