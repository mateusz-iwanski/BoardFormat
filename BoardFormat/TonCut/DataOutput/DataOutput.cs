using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Output data group contains optimization results.
    /// </summary>
    public class DataOutputs
    {
        /// <summary>
        /// Version number of the data group.
        /// </summary>
        public int version;
        /// <summary>
        /// Default units specification as described in defaultUnits section.
        /// </summary>
        public DefaultUnits defaultUnits;
        /// <summary>
        /// Global statistics of the entire optimization.
        /// </summary>
        public Statistics statistics;
        /// <summary>
        /// List of cutting objects.
        /// </summary>
        public List<Cutting> cuttings;

        /// <summary>
        /// Initializes a new instance of the class. JObject is a Object from Newtonsoft.Json.
        /// In such a nested structure of object we can't use JsonConvert.DeserializeObject
        /// </summary>
        /// <param name="jobject">Newtonsoft.Json JObject</param>        
        public DataOutputs(JObject jobject) 
        { 
            this.version = (int)jobject["version"];
            this.defaultUnits = new DefaultUnits(jobject["defaultUnits"]);
            this.statistics = new Statistics(jobject["statistics"]);
            this.cuttings = new List<Cutting>();
            
            foreach (JToken cutting in jobject["cuttings"])
                this.cuttings.Add(new Cutting(cutting));
        }
    }   
}
