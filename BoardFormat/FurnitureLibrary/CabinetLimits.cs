using BoardFormat.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.FurnitureLibrary
{
    public class CabinetLimits
    {
        public MinMaxStatic<float> depthRange { get; private set; } = new MinMaxStatic<float>();
        public MinMaxStatic<float> heightRange { get; private set; } = new MinMaxStatic<float>();
        public MinMaxStatic<float> widthRange { get; private set; } = new MinMaxStatic<float>();

        public CabinetLimits WidthRange(float min, float max)
        {
            widthRange.Min = widthRange.Static.Equals(default(float))
                ? min : throw new Exception("Can't set width range if width static is set");
            widthRange.Max = max;
            return this;
        }

        public CabinetLimits WidthRange(float staticWidth)
        {
            widthRange.Static = (
                               widthRange.Min.Equals(default(float))
                                              && widthRange.Max.Equals(default(float)))
                ? staticWidth : throw new Exception("Can't set width static if width range is set");
            return this;
        }

        public CabinetLimits HeightRange(float min, float max)
        {
            heightRange.Min = heightRange.Static.Equals(default(float))
                ? min : throw new Exception("Can't set height range if height static is set");
            heightRange.Max = max;
            return this;
        }

        public CabinetLimits HeightRange(float staticHeight)
        {
            heightRange.Static = (
                               heightRange.Min.Equals(default(float))
                                              && heightRange.Max.Equals(default(float)))
                ? staticHeight : throw new Exception("Can't set height static if height range is set");
            return this;
        }

        public CabinetLimits DepthRange(float min, float max)
        {
            depthRange.Min = depthRange.Static.Equals(default(float))
                ? min : throw new Exception("Can't set height range if height static is set");
            depthRange.Max = max;
            return this;
        }

        public CabinetLimits DepthRange(float staticDepth)
        {
            depthRange.Static = (
                depthRange.Min.Equals(default(float))
                && depthRange.Max.Equals(default(float)))
                ? staticDepth : throw new Exception("Can't set depth static if width range is set");
            return this;
        }

        public CabinetLimits() : base()
        {
            depthRange = new MinMaxStatic<float>();
            return;
        }

        public void Validate()
        {
            if (depthRange.IsEmpty() || widthRange.IsEmpty() || heightRange.IsEmpty())
            {
                throw new Exception("CabinetLimits is not set correctly. " +
                    "Properties widthRange, lengthRange, depthRange can't be null.");
            }
        }
    }
}
