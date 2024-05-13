using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    public class RectangleGraphicsViewSetupEventArgs
    {
        public Rectangle Rectangle { get; }

        public RectangleGraphicsViewSetupEventArgs(Rectangle rectangle)
        {
            Rectangle = rectangle;
        }
    }
}
