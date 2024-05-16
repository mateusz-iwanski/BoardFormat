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
        static int lastId = default;
        int id;
        // symbol has to be unique
        string symbol;
        string name;
        Image image;
        string? uriImageSource;
        string? description;

        // symbol has to be unique
        public string Symbol { get => symbol; private set => symbol = value; }
        public string Name { get => name; private set => name = value; }
        public Image Image { get => image; private set => image = value; }
        public string? UriImageSource { get => uriImageSource; private set => uriImageSource = value; }
        public string? Description { get => description; private set => description = value; }
        public ICabinetSize<float> Size { get; set; } = new CabinetSize<float>();
        public int ID { get => id; private set => id = value;}

        List<Accessories> accessories;        
        List<CabinetPieceBehavior> pieceCollection;
        CabinetCategory category;
        CabinetLimits behavior;

        public List<Accessories> Accessories { get => accessories; private set => accessories = value; }
        public List<CabinetPieceBehavior> Pieces { get => pieceCollection; private set => pieceCollection = value; }
        public CabinetCategory Category { get => category; private set => category = value; }
        public CabinetLimits Behavior { get => behavior; private set => behavior = value; }


        /// <summary>
        /// For the first time we will set empty cabinet with specific behavior, type, etc. 
        /// Size and _piece collection will be set when cabinet will have change size from default size.
        /// Pieces add by CabinetBuilder, first cabinet instance should be done
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="name"></param>
        /// <param name="image"></param>
        /// <param name="category"></param>
        /// <param name="cabinetLimits"></param>
        /// <param name="description"></param>
        public Cabinet(
            string symbol, 
            string name,             
            CabinetCategory category,
            CabinetLimits cabinetLimits,
            Image image,
            string? description = null,            
            string? uriImageSource = null
            )
        {
            id = ++lastId;
            this.Symbol = symbol;
            this.Name = name;
            this.Image = image;
            this.Description = description;
            this.Category = category;
            this.Behavior = cabinetLimits;
            this.UriImageSource = uriImageSource;            

            Pieces = new List<CabinetPieceBehavior>();
            Accessories = new List<Accessories>();
        }
    }
}
