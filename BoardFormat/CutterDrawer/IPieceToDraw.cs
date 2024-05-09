using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    public interface IPieceToDraw
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public DrawerType Type { get; set; }
        public string Identifier { get; set; }
    }

}
