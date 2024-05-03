using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.MVVM.Models
{

    public class Board : BaseMaterial
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public MaterialKind Kind { get; private set; }
        public Image Image { get; private set; }
        public int Tchikness { get; private set; }

        public Board(
            float length,
            float width,
            int thickness,
            bool structure,
            string name,
            string description,
            MaterialKind kind,
            Image image,
            string? identifier = null
            ) : base(length: length, width: width, structure: structure, identifier: identifier)    
        {
            Name = name;
            Description = description;
            Kind = kind;
            Image = image;
            Tchikness = thickness;
        }
    }
}
