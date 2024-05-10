using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    public interface IGraphicsViewSetup
    {
        public void Setup(RectangleBuilder shapeBuilder);
    }
}
