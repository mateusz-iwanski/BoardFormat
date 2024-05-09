using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    public interface IShapeBuilder
    {
        public List<ShapeDrawer> GetShapes();
        // must return the height of the shape
        public float Build(
            List<IPieceToDraw> elementsToDrawListCollection,
            float imageScaleByWidth,
            float margin
        );
    }
}
