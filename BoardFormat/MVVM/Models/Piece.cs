using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.MVVM.Models
{
    public class Piece : BaseMaterial
    {
        /// If piece is from cabinet
        int? _cabinetID;
        public int? CabinetID { get => _cabinetID; private set => _cabinetID = value; }

        public Piece(
            float length, float width, 
            bool structure, 
            string? identifier = null, 
            int? cabinetID = null
            ) 
            : base(length, width, structure, identifier) 
        {
            this.CabinetID = cabinetID;
        }
    }
}
