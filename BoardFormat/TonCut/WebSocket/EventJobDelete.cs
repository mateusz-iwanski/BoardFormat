using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// The JobDelete event informs that a job has been just deleted.
    /// </summary>
    internal class EventJobDelete : Event
    {
        /// <summary>
        /// ID of the job that has been deleted.
        /// </summary>
        public readonly int JobId;

        public EventJobDelete(EventName eventName, int _jobId)
        {
            Name = eventName;
            JobId = _jobId;
        }
    }
}
