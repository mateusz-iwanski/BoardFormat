using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    public enum DrawerType
    {
        Board,
        Piece,
        Waste
    }

    public struct PieceToDraw
    {
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

        public PieceToDraw(
            double length, 
            double width, 
            double x, 
            double y, 
            bool structure,
            string identifier,
            DrawerType typeEnum,
            bool rotated,
            bool leftVeneer,
            bool rightVeneer,
            bool topVeneer,
            bool bottomVeneer,
            bool boardHasStructure
            )
        {
            Length = length;
            Width = width;
            X = x;
            Y = y;
            Structure = structure;
            Identifier = identifier;
            Type = typeEnum;
            Rotated = rotated;
            LeftVeneer = leftVeneer;
            RightVeneer = rightVeneer;
            TopVeneer = topVeneer;
            BottomVeneer = bottomVeneer;
            BoardHasStructure = boardHasStructure;
        }
    }

}
