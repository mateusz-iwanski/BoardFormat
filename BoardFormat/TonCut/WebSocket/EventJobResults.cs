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
    /// The JobResults event is sent when job optimization if finished.
    /// </summary>
    public class EventJobResults : Event
    {
        /// <summary>
        /// ID of the job that has been finished.
        /// </summary>
        public readonly int JobId;
        /// <summary>
        /// Results of the optimization in a form of DataOutput object.
        /// </summary>
        public readonly DataOutputs results;

        public EventJobResults(EventName eventName, int _jobId, string _results)
        {
            JObject jObject = NewtonUtils.DeserializeToJObject(_results);

            Name = eventName;
            JobId = _jobId;            
            results = new DataOutputs(jObject);
        }
    }
}
