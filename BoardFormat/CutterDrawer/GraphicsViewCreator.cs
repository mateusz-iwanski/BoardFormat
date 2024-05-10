using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Maui.Layouts;


namespace BoardFormat.CutterDrawer
{
    public class GraphicsViewCreator
    {
        public List<DrawableShapeObjects> ShapeObjects { get; private set; }
        private Layout _graphicsLayout;
        private IGraphicsViewSetup _graphicsViewSetup;

        public GraphicsViewCreator(
            List<DrawableShapeObjects> shapeObjects, 
            Layout graphicsLayout
            )
        {
            ShapeObjects = shapeObjects;
            _graphicsLayout = graphicsLayout;
        }

        /// <summary>
        /// Creates the GraphicsView with the specified parameters.
        /// Graphics (one board with pieceCollection) is children of layout. 
        /// Dynamically change layout height when shape height size is scalling
        /// and dynamically change shape width if layout width is changing
        /// </summary>
        /// <param name="scaleToWidth">The scale factor to fit the GraphicsView by width.</param>
        /// <param name="leftRightMargin">The left and right margin of the GraphicsView.</param>
        /// <param name="topMargin">The top margin of the GraphicsView.</param>
        public void Draw(
            float scaleToWidth,
            float leftRightMargin,
            float topMargin
        )
        {
            if (ShapeObjects.Count > 0)
                if (ShapeObjects[0].GraphicsView != null)
                {
                    _graphicsLayout.Clear();
                    // it's use to set layout height the same as shape height
                    float shapeHeight = 0;

                    foreach (var element in ShapeObjects)
                    {

                        // create board with pieceCollection drawable and add to layout
                        if (element.ShapeWithPieceCollection.Count > 0)
                        {
                            RectangleBuilder shapeBuilder = new RectangleBuilder();

                            // make shapes (piece and piece children) drawable                         
                            var drawable = new ShapeDrawable(
                                elementsToDrawCollection: element.ShapeWithPieceCollection,
                                shapeBuilder: shapeBuilder,
                                scaleToWidth: scaleToWidth,
                                leftRightMargin: leftRightMargin,
                                topMargin: topMargin
                            );

                            // shape size (ShapeDrawable) after scalling + top margin
                            shapeHeight += drawable.ShapeHeight + topMargin;

                            // Set GraphicsView height as size height of Drawable shape
                            element.GraphicsView.HeightRequest = drawable.ShapeHeight;
                            // Set GraphicsView width as size of layout - 10px margin
                            element.GraphicsView.WidthRequest = (float)_graphicsLayout.Width - 10;

                            // Set the height of the layout to the height of the Drawable
                            _graphicsLayout.HeightRequest = shapeHeight;

                            // Update the Drawable
                            element.GraphicsView.Drawable = drawable;

                            _graphicsLayout.Children.Add(element.GraphicsView);

                            // Set up the GraphicsView
                            element.graphicsViewSetup.Setup(shapeBuilder);
                        }
                    }
                }
        }
    }
}
