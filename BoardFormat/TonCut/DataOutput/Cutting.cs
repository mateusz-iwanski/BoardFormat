using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TonCut
{
    /// <summary>
    /// Represents a cutting object.
    /// </summary>
    public class Cutting
    {
        public int stockItemId { get; set;  }
        public int quantity { get; set;  }
        public CuttingStatistics statistics { get; set; }
        public List<CuttingPiece> pieces { get; set; }
        public List<CuttingRest> rest { get; set; }
        public List<Cut> cuts { get; set; }        

        public Cutting(JToken jToken)
        {
                        
            stockItemId = (int)jToken["stockItemId"];
            quantity = (int)jToken["quantity"];
            pieces = new List<CuttingPiece>();
            rest = new List<CuttingRest>();
            cuts = new List<Cut>();
            statistics = new CuttingStatistics(jToken["statistics"]);

            foreach (JToken piece in jToken["pieces"]) 
                pieces.Add(new CuttingPiece(piece));

            foreach (JToken _rest in jToken["rest"])
                rest.Add(new CuttingRest(_rest));

            foreach (JToken cut in jToken["cuts"])
                cuts.Add(new Cut(cut));



        }
    }
}
