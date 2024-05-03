using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Type of the event
    /// </summary>
    public enum EventName
    {
        /// <summary>
        /// Event sent when job optimization is finished.
        /// </summary>
        JobResults,
        /// <summary>
        /// Informs that a new job has been created and added to the queue.
        /// </summary>
        JobAdd,
        /// <summary>
        /// Informs that a job has been just deleted.
        /// </summary>
        JobDelete,
        /// <summary>
        /// Informs that job’s state has just changed.
        /// </summary>
        JobState,
        /// <summary>
        /// Informs about progress of a job.
        /// </summary>
        JobProgress,
        /// <summary>
        /// Event sent when server’s state is changed.
        /// </summary>
        Status,
    }
}
