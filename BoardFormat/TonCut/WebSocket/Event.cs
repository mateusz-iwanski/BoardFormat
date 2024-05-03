using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

namespace TonCut
{
    /// <summary>
    /// Additionally server sends events / notifications when there is some change.
    /// All events have one common property which are in Event class
    /// </summary>
    public class Event
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public EventName Name;
        public readonly DateTime FlashTime;

        public Event() 
        {
            FlashTime = DateTime.Now;
        }

        public DateTime GetTime()
        {
            return FlashTime;
        }        

    }
}
