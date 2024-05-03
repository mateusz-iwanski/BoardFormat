using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// The JobAdd event informs that a new job has been created and added to the queue.
    /// </summary>
    internal class EventJobAdd : Event
    {
        /// <summary>
        /// ID of the job that has been created.
        /// </summary>
        int JobId;
        public EventJobAdd(EventName eventName, int jobId)
        {
            Name = eventName;
            JobId = jobId;
        }
    }
}
