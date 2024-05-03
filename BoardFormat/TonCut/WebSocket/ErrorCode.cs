using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// On failure, success will be set to false and errCode will contain an error code.
    /// As you can see you can identify the response by the id.
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Unknown command.
        /// </summary>
        ecUnknownCommand,
        /// <summary>
        /// Missing required parameter.
        /// </summary>
        ecMissingParameter,
        /// <summary>
        /// Not found, e.g. wrong jobId
        /// </summary>
        ecNotFound
    }
}
