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
        public List<BoardObjects> BoardObject { get; private set; }
        private Layout GraphicsLayout;

        public GraphicsViewCreator(
            List<BoardObjects> boardObjects, 
            Layout graphicsLayout
            )
        {
            BoardObject = boardObjects;
            GraphicsLayout = graphicsLayout;
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
            if (BoardObject.Count > 0)
                if (BoardObject[0].BoardGraphicsView != null)
                {
                    GraphicsLayout.Clear();
                    // it's use to set layout height the same as shape height
                    float shapeHeight = 0;

                    foreach (var element in BoardObject)
                    {

                        // create board with pieceCollection drawable and add to layout
                        if (element.BoardWithPieceCollection.Count > 0)
                        {
                            // make shapes (one board and pieceCollection inside) drawable                         
                            var drawable = new CutterDrawer.ShapeDrawable(
                                pieceToDrawCollection: element.BoardWithPieceCollection,
                                scaleToWidth: scaleToWidth,
                                leftRightMargin: leftRightMargin,
                                topMargin: topMargin
                            );

                            // shape size (ShapeDrawable) after scalling + top margin
                            shapeHeight += drawable.ShapeHeight + topMargin;

                            // Set GraphicsView height as size height of Drawable shape
                            element.BoardGraphicsView.HeightRequest = drawable.ShapeHeight;
                            // Set GraphicsView width as size of layout - 10px margin
                            element.BoardGraphicsView.WidthRequest = (float)GraphicsLayout.Width - 10;

                            // Set the height of the layout to the height of the Drawable
                            GraphicsLayout.HeightRequest = shapeHeight;

                            // Update the Drawable
                            element.BoardGraphicsView.Drawable = drawable;

                            GraphicsLayout.Children.Add(element.BoardGraphicsView);
                        }
                    }
                }
        }
    }
}
