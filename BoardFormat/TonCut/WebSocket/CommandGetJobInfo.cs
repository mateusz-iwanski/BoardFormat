using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuperSocket.ClientEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// The cmdGetJobInfo command returns all information about the specified job
    /// </summary>
    public class CommandGetJobInfo : BaseCommand, ICommand_
    {
        /// <summary>
        /// State of the job.
        /// </summary>
        public Job _Job { get; set; }
        /// <summary>
        /// Output data group contains optimization results.
        /// </summary>
        public DataOutputs? DataOutput { get; set; }
        /// <summary>
        /// ID of the job to get information about.
        /// </summary>
        public int JobId { get; set; }

        public CommandGetJobInfo(int _jobId)
        {
            Name = CommandName.cmdGetJobInfo;
            JobId = _jobId;
        }

        public string GetCommand()
        {
            Hashtable command = new Hashtable();
            command.Add("id", Id);
            command.Add("jobId", JobId);
            command.Add("cmd", Name.ToString());
            Console.WriteLine("BaseCommand sent:" + JsonConvert.SerializeObject(command, Formatting.Indented));
            return JsonConvert.SerializeObject(command, Formatting.Indented);
        }

        public void Add(Newtonsoft.Json.Linq.JObject _message)
        {
            base.Add(_message);

            JobStateName jobStateName = (JobStateName)Enum.Parse(typeof(JobStateName), _message["state"].ToString());
            if (JobStateName.sError == jobStateName)
            {
                JobStateErrorCode errorCode = (JobStateErrorCode)Enum.Parse(typeof(JobStateErrorCode), _message["errCode"].ToString());
                _Job = new Job(
                    (int)_message["jobId"], jobStateName, errorCode, _message["errorDescription"].ToString());
            }
            else
            {
                DateTime createDate;
                DateTime startDate;
                DateTime endDate;

                DateTime.TryParse(_message["createDate"].ToString(), out createDate);
                DateTime.TryParse(_message["startDate"].ToString(), out startDate);
                DateTime.TryParse(_message["endDate"].ToString(), out endDate);

                _Job = new Job(
                    (int)_message["id"],
                    jobStateName,
                    (float)_message["progress"],
                    (long)_message["combinationCount"],
                    createDate, startDate, endDate
                    );

                var results = JsonConvert.SerializeObject(_message["results"], Formatting.Indented);
                DataOutput = JobStateName.sDone == jobStateName ? new DataOutputs(JObject.Parse(results)) : null;
            }
        }

        bool ICommand_.IsDataCompatible(Newtonsoft.Json.Linq.JObject message) => message.ContainsKey("event") ? false : true;
    }
}
