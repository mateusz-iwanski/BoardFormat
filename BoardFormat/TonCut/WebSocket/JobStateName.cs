using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Enum representing the status of a job.
    /// </summary>
    public enum JobStateName
    {
        /// <summary>
        /// The job is new and waiting in a queue.
        /// </summary>
        [EnumMember(Value = "sNew")]
        sNew,

        /// <summary>
        /// The job is currently optimized.
        /// </summary>
        [EnumMember(Value = "sPending")]
        sPending,

        /// <summary>
        /// The job was cancelled.
        /// </summary>
        [EnumMember(Value = "sCanceled")]
        sCanceled,

        /// <summary>
        /// The job was optimized.
        /// </summary>
        [EnumMember(Value = "sDone")]
        sDone,

        /// <summary>
        /// There was an error while handling the job.
        /// </summary>
        [EnumMember(Value = "sError")]
        sError
    }
}
