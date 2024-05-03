using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// The JobProgress event informs about progress of a job.
    /// </summary>
    internal class EventJobProgress : Event
    {
        /// <summary>
        /// ID of the job.
        /// </summary>
        public readonly int JobId;
        /// <summary>
        /// Optimization progress in percent, so 100 means 100%.
        /// </summary>
        public readonly double Progress;
        /// <summary>
        /// Number of combinations checked.
        /// </summary>
        public readonly long CombinationCount;

        public EventJobProgress(EventName eventName, int _jobId, double _progress, long _combinationCount)
        {
            Name = eventName;
            JobId = _jobId;
            Progress = _progress;
            CombinationCount = _combinationCount;
        }

    }
}
