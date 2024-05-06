using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.FurnitureLibrary
{
    public class CabinetSize : ISize
    {
        float depth { get; set; }
        float height { get; set; }
        float width { get; set; }


        public float Depth()
        {
            return depth;
        }

        public float Height()
        {
            return height;
        }

        public float GetWidth()
        {
            return width;
        }
    }
}
