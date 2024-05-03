using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.MVVM.Models
{
    public class Accessories
    {
        string symbol;
        string name;
        Image image;
        string description;

        public string Symbol { get => symbol; set => symbol = value; }
        public string Name { get => name; set => name = value; }
        public Image Image { get => image; set => image = value; }
        public string Description { get => description; set => description = value; }


        public Accessories(string symbol, string name, Image image, string description)
        {
            this.Symbol = symbol;
            this.Name = name;
            this.Image = image;
            this.Description = description;
        }
    }
}
