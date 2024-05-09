using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    /// <summary>
    /// It's use to check if elements should be draw on canvas.
    /// Width and Length are in cm.
    /// </summary>
    public struct RequiredDrawDimension
    {
        public double Width { get; set; }
        public double Length { get; set; }
    }
}
