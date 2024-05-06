using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.FurnitureLibrary
{
    public interface ICabinetSize<T>
    {
        /// <summary>
        ///  Axis X
        /// </summary>
        /// <returns></returns>
        public T GetWidth();
        /// <summary>
        /// Axis Y
        /// </summary>
        /// <returns></returns>
        public T GetHeight();
        /// <summary>
        /// Axis Z
        /// </summary>
        /// <returns></returns>
        public T GetDepth();
    }
}
