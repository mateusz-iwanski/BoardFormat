using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.FurnitureLibrary
{
    public interface ISize
    {
        /// <summary>
        ///  Axis X
        /// </summary>
        /// <returns></returns>
        public float GetWidth();
        /// <summary>
        /// Axis Y
        /// </summary>
        /// <returns></returns>
        public float Height();
        /// <summary>
        /// Axis Z
        /// </summary>
        /// <returns></returns>
        public float Depth();
    }
}
