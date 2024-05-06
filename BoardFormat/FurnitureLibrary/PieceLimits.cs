using BoardFormat.FurnitureLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.MVVM.Models
{
    /// <summary>
    /// It is a struct that contains a cabinetPiece type and a cabinetPiece behavior.
    /// Every cabinetPiece whith some kind of type has size behavior. 
    /// Piece will can change size between min and max values or 
    /// has static size.
    /// </summary>
    public class PieceLimits
    {
        public MinMaxStatic<float> widthRange { get; private set; }
        public MinMaxStatic<float> lengthRange { get; private set; }

        /// <summary>
        /// Width is X axis in 2D space. Sometimes is called length.
        /// </summary>
        /// <param name="min">Min size</param>
        /// <param name="max">Max size</param>
        public PieceLimits WidthRange(float min, float max)
        {
            widthRange.Min = widthRange.Static.Equals(default(float))
                ? min : throw new Exception("Can't set width range if width static is set");
            widthRange.Max = max;
            return this;
        }

        /// <summary>
        /// Height is Y axis in 2D space. Sometimes is called width.
        /// </summary>
        /// <param name="min">Min size</param>
        /// <param name="max">Max size</param>
        public PieceLimits LengthRange(float min, float max)
        {
            lengthRange.Min =  lengthRange.Static.Equals(default(float))
                ? min : throw new Exception("Can't set height range if height static is set");
            lengthRange.Max = max;
            return this;
        }

        /// <summary>
        /// Set if cabinetPiece has static size.
        /// </summary>
        /// <param name="staticWidth">Statitc width</param>
        public PieceLimits WidthRange(float staticWidth)
        {
            widthRange.Static = (
                widthRange.Min.Equals(default(float)) 
                && widthRange.Max.Equals(default(float))) 
                ? staticWidth : throw new Exception("Can't set width static if width range is set");  
            return this;
        }

        /// <summary>
        /// Set if cabinetPiece has static size.
        /// </summary>
        /// <param name="staticHeight">Static height</param>
        public PieceLimits LengthRange(float staticHeight)
        {
            lengthRange.Static = (lengthRange.Min.Equals(default(float)) && lengthRange.Equals(default(float))) 
                ? staticHeight : throw new Exception("Can't set height static if height range is set");
            return this;
        }

        public PieceLimits()
        { 
            widthRange = new MinMaxStatic<float>();
            lengthRange = new MinMaxStatic<float>();
            return; 
        }

        /// <summary>
        /// It checks if the PieceLimits is set correctly.
        /// Have to be called before adding to the collection of FurniturePiece.
        /// </summary>
        /// <exception cref="Exception">Call when empty</exception>
        public virtual void Validate()
        {
            if (widthRange.IsEmpty() || lengthRange.IsEmpty())
            {
                throw new Exception("PieceLimits is not set correctly. " +
                    "Properties widthRange, lengthRange can't be null.");
            }

        }
    }
}
