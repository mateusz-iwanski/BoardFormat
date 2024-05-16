using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.FurnitureLibrary
{
    /// <summary>
    /// This class is used to match width and length of _piece when 
    /// cabinet changes dimension in 3d.
    /// Look on CabinetPieceBehavior class.
    /// </summary>
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
        /// <summary>
        /// If is value is set to null, the value is not used.
        /// </summary>
        /// <returns>SizeMatch</returns>
        public SizeMatch SetNull()
        {
            nullSet = true;
            return this;
        }

        /// <summary>
        /// Get seted value. If value was set to null, return null.
        /// </summary>
        /// <returns></returns>
        public float? GetValue()
        {
            if (nullSet)
            {
                return null;
            }
            return this.value;
        }

        /// <summary>
        /// If value wasn't set to null, return true and out newPieceSize is the pieceSize corrected,
        /// by value wich was set before. 
        /// </summary>
        /// <param name="pieceSize"></param>
        /// <param name="newPieceSize"></param>
        /// <returns></returns>
        public bool TryCorrectSize(float pieceSize, out float newPieceSize)
        {
            if (!nullSet)
            {
                newPieceSize = pieceSize + value;
                return true;
            }
            newPieceSize = default(float);
            return false;
        }
    }
}
