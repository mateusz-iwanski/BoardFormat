using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Represents a job.
    /// </summary>
    public class Job
    {
        /// <summary>
        /// Job ID.
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// State of the job.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public readonly JobStateName State;

        /// <summary>
        /// If the job state is set to sError, then errorCode contains the error code.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public JobStateErrorCode ErrorCode { get; set; }

        /// <summary>
        /// Additional error information.
        /// </summary>
        public readonly string ErrorDescription;

        /// <summary>
        /// Optimization progress in percent, so 100 means 100%.
        /// </summary>
        public readonly float Progress;

        /// <summary>
        /// Number of combinations checked.
        /// </summary>
        public readonly long CombinationCount;

        /// <summary>
        /// Date of the job creation.
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Date when the job optimization started.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Date when job optimization ended.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Constructor for JobDetails class.
        /// </summary>
        /// <param name="id">Job ID.</param>
        /// <param name="state">State of the job.</param>        
        /// <param name="progress">Optimization progress in percent, so 100 means 100%.</param>
        /// <param name="combinationCount">Number of combinations checked.</param>
        /// <param name="createDate">Date of the job creation.</param>
        /// <param name="startDate">Date when the job optimization started.</param>
        /// <param name="endDate">Date when job optimization ended.</param>
        public Job(int id, 
            JobStateName state, 
            float progress, long combinationCount, 
            DateTime? createDate, DateTime? startDate, DateTime? endDate)
        {
            Id = id;
            State = state;
            Progress = progress;
            CombinationCount = combinationCount;
            CreateDate = createDate;
            StartDate = startDate;
            EndDate = endDate;
        }

        /// <summary>
        /// Constructor for activeJob class.
        /// </summary>
        /// <param name="id">Job ID.</param>
        /// <param name="state">State of the job.</param>        
        /// <param name="progress">Optimization progress in percent, so 100 means 100%.</param>
        /// <param name="combinationCount">Number of combinations checked.</param>
        public Job(int id,
            JobStateName state,
            float progress, int combinationCount)
        {
            Id = id;
            State = state;
            Progress = progress;
            CombinationCount = combinationCount;
        }

        /// <summary>
        /// Constructor for JobDetails when Error.
        /// </summary>
        /// <param name="id">Job ID.</param>
        /// <param name="state">State of the job.</param>
        /// <param name="errorCode">If the job state is set to sError, then errorCode contains the error code.</param>
        /// <param name="errorDescription">Additional error information.</param>
        public Job(int id, JobStateName state, JobStateErrorCode errorCode, string errorDescription)
        {
            Id = id;
            State = state;
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }
    }
}
