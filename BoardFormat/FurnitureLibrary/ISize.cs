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
        public float GetHeight();
        /// <summary>
        /// Axis Z
        /// </summary>
        /// <returns></returns>
        public float GetDepth();

        //public void SetWidth(float width);
        //public void SetHeight(float height);
        //public void SetDepth(float depth);
    }
}
