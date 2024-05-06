using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.FurnitureLibrary
{
    public class CabinetSize<T> : ICabinetSize<T> where T : IComparable<T>
    {
        T depth { get; set; }
        T height { get; set; }
        T width { get; set; }

        public CabinetSize(T width, T height, T depth)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
        }

        public CabinetSize()
        {
            this.width = default(T);
            this.height = default(T);
            this.depth = default(T);
        }

        public T GetDepth()
        {
            return depth;
        }

        public T GetHeight()
        {
            return height;
        }

        public T GetWidth()
        {
            return width;
        }
    }
}
