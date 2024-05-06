using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.FurnitureLibrary
{
    public interface ISizeMatch
    {
        SizeMatch SetValue(float value);
        SizeMatch SetNull();
        float? GetValue();
        bool TryCorrectSize(float pieceSize, out float newPieceSize);
    }
}
