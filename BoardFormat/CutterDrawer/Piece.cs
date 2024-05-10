using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    public struct PieceToDraw : IPieceToDraw
    {
        public Guid Id { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public bool Structure { get; set; }
        public string Identifier { get; set; }        
        public DrawerType Type {  get; set; }
        public bool Rotated { get; set; }
        public bool LeftVeneer {  get; set; }
        public bool RightVeneer { get; set; }
        public bool TopVeneer { get; set; }
        public bool BottomVeneer { get; set; }
        public bool BoardHasStructure { get; set; }

        public PieceToDraw()
        {
            Id = Guid.NewGuid();
        }
    }

}
