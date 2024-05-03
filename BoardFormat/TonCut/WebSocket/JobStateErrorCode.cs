using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Enum representing different error codes for JobState.
    /// </summary>
    public enum JobStateErrorCode
    {
        /// <summary>
        /// No active license was found.
        /// </summary>
        ecNoActiveLicenseFound,

        /// <summary>
        /// There was an error while parsing the configuration data group.
        /// </summary>
        ecConfigParsingFailed,

        /// <summary>
        /// There was an error while parsing the Input data group.
        /// </summary>
        ecInputParsingFailed,

        /// <summary>
        /// No active optimization profiles were found. Probably all of them are not active.
        /// </summary>
        ecNoActiveProfilesFound,

        /// <summary>
        /// No results found.
        /// There may be many reasons for this, e.g., no stocks provided, stock material groups not matching piece material groups, too small stock items, etc.
        /// </summary>
        ecNoResultsFound,

        /// <summary>
        /// There was an unexpected error. Please contact us to solve the problem!
        /// </summary>
        ecUnexpectedException
    }
}
