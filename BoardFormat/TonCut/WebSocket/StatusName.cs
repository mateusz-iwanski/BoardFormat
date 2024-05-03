using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// The status of the server.
    /// </summary>
    public enum StatusName
    {
        /// <summary>
        /// The server is waiting for jobs to optimize.
        /// </summary>
        [EnumMember(Value = "idle")]
        idle,
        /// <summary>
        /// The server is currently optimizing a job.
        /// </summary>
        [EnumMember(Value = "working")]
        working
    }
}
