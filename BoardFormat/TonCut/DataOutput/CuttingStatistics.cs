using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Represents the statistics for a cutting object.
    /// </summary>
    public class CuttingStatistics
    {
        [JsonProperty("1d")]
        CuttingStatistics1d _1d { get; set; }
        [JsonProperty("2d")]
        CuttingStatistics2d _2d { get; set; }

        public CuttingStatistics(JToken jToken)
        {
            // this._1d = new CuttingStatistics1d(jToken["1d"]);
            this._2d = new CuttingStatistics2d(jToken["2d"]);
        }
    }
}
