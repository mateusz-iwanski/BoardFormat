using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.FurnitureLibrary
{
    public class SizeMatch : ISizeMatch
    {
        float value { get; set; }
        bool nullSet { get; set; } = true;

        public SizeMatch SetValue(float value)
        {
            this.value = value;
            nullSet = false;
            return this;
        }

        // do nothing
        public SizeMatch SetNull()
        {
            nullSet = true;
            return this;
        }

        public float? GetValue()
        {
            if (nullSet)
            {
                return null;
            }
            return this.value;
        }

        public bool TryCorrectSize(float cabinetSize, out float newPieceSize)
        {
            if (!nullSet)
            {
                newPieceSize = cabinetSize + value;
                return true;
            }
            newPieceSize = default(float);
            return false;
        }
    }
}
