using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.MVVM.Models
{
    public abstract class BaseMaterial
    {
        public float length { get; set; }  // Look out! for cutter engine is length, but for the rest of the world is width
        public float width { get; set; }  // Look out! for cutter engine is width, but for the rest of the world is heigth 
        public bool structure { get; set; }
        public string? identifier { get; set; }  // symbol or name

        public float Length { get => length; set => length = value; }
        public float Width { get => width; set => width = value; }
        public bool Structure { get => structure; set => structure = value; }
        public string? Identifier { get => identifier; set => identifier = value; }

        public BaseMaterial(float length, float width, bool structure, string? identifier = null)
        {
            this.Length = length;
            this.Width = width;
            this.Structure = structure;
            this.Identifier = identifier;
        }

        
    }
}
