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
        public ICabinetSize<float> Size { get; set; } = new CabinetSize<float>();

        List<Accessories> accessories;        
        List<CabinetPieceBehavior> pieceCollection;
        CabinetCategory category;
        CabinetLimits behavior;

        public List<Accessories> Accessories { get => accessories; set => accessories = value; }
        public List<CabinetPieceBehavior> Pieces { get => pieceCollection; set => pieceCollection = value; }
        public CabinetCategory Category { get => category; set => category = value; }
        public CabinetLimits Behavior { get => behavior; set => behavior = value; }


        /// <summary>
        /// For the first time we will set empty cabinet with specific behavior, type, etc. 
        /// Size and piece collection will be set when cabinet will have change size from default size.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="name"></param>
        /// <param name="image"></param>
        /// <param name="accessories"></param>
        /// <param name="pieces"></param>
        /// <param name="category"></param>
        /// <param name="cabinetLimits"></param>
        /// <param name="description"></param>
        public Cabinet(
            string symbol, 
            string name, 
            Image image,             
            List<Accessories> accessories,
            List<CabinetPieceBehavior> pieces,
            CabinetCategory category,
            CabinetLimits cabinetLimits,
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
            this.Behavior = cabinetLimits;
        }
    }
}
