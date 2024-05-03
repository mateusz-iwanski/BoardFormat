using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.MVVM.Models
{
    public class Piece : BaseMaterial
    {
        public Piece(float length, float width, bool structure, string? identifier = null) 
            : base(length, width, structure, identifier) {}
    }
}
