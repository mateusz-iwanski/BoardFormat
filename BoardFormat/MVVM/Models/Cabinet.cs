using BoardFormat.FurnitureLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.MVVM.Models
{

    public class Cabinet
    {
        string symbol;
        string name;
        Image image;
        string? description;

        public string Symbol { get => symbol; set => symbol = value; }
        public string Name { get => name; set => name = value; }
        public Image Image { get => image; set => image = value; }
        public string? Description { get => description; set => description = value; }


        List<Accessories> accessories;        
        List<CabinetPiece> pieces;
        CabinetCategory category;

        public List<Accessories> Accessories { get => accessories; set => accessories = value; }
        public List<CabinetPiece> Pieces { get => pieces; set => pieces = value; }
        public CabinetCategory Category { get => category; set => category = value; }

        public Cabinet(
            string symbol, 
            string name, 
            Image image,             
            List<Accessories> accessories,
            List<CabinetPiece> pieces,
            CabinetCategory category,
            string? description = null
            )
        {
            this.Symbol = symbol;
            this.Name = name;
            this.Image = image;
            this.Description = description;
            this.Accessories = accessories;
            this.Pieces = pieces;
            this.Category = category;
        }
    }
}
