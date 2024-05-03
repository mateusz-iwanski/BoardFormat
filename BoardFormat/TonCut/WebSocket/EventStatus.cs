using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TonCut
{
    /// <summary>
    /// The Status event is sent when server’s state is changed.
    /// </summary>
    internal class EventStatus : Event
    {
        /// <summary>
        /// The status of the server.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public readonly StatusName status;
        /// <summary>
        /// The queue size, not including the active job.
        /// </summary>
        public readonly int queueSize;

        public EventStatus(EventName eventName, StatusName _status, int _queueSize)
        {
            Name = eventName;
            status = _status;
        }

    }
}
