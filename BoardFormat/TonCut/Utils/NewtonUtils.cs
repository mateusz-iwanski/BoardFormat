using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    public class NewtonUtils
    {
        /// <summary>
        /// Deserialize the input message to a JObject
        /// </summary>
        /// <param name="message">The input message to be deserialized</param>
        /// <returns>A JObject representing the deserialized message</returns>
        public static JObject DeserializeToJObject(string message)
        {
            Dictionary<string, object> deserializeObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(message);
            var incomingMessage = JsonConvert.SerializeObject(deserializeObject);
            var jObject = JObject.Parse(incomingMessage);
            return jObject;
        }
    }
}
