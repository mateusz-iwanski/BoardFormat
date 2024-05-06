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

        public CabinetSize(float width, float height, float depth)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
        }

        public CabinetSize()
        {
            this.width = default(float);
            this.height = default(float);
            this.depth = default(float);
        }

        public float GetDepth()
        {
            return depth;
        }

        public float GetHeight()
        {
            return height;
        }

        public float GetWidth()
        {
            return width;
        }
        //public void SetDepth(float depth)
        //{
        //    this.depth = depth;
        //}
        //public void SetHeight(float height)
        //{
        //    this.height = height;
        //}
        //public void SetWidth(float width)
        //{
        //    this.width = width;
        //}
    }
}
