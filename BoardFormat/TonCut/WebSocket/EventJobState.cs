using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TonCut
{
    /// <summary>
    /// The JobState event informs that job’s state has just changed
    /// </summary>
    internal class EventJobState : Event
    {
        /// <summary>
        /// ID of the job the state of which has changed.
        /// </summary>
        public readonly int JobId;
        /// <summary>
        /// State of the job.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public readonly JobStateName StateName;
        /// <summary>
        /// If the job state is set to sError, then errorCode CustomProperty contains the error code.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public readonly JobStateErrorCode ErrorCode;

        public readonly string ErrorDescription;

        public EventJobState(EventName eventName, JobStateName stateName, int _jobId)
        {
            Name = eventName;
            JobId = _jobId;
            StateName = stateName;
        }
        public EventJobState(EventName eventName, JobStateName stateName, int _jobId, JobStateErrorCode errorCode, string errorDescription)
        {
            Name = eventName;
            JobId = _jobId;
            StateName = stateName;
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }
    }
}
