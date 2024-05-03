using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TonCut
{
    /// <summary>
    /// The cmdGetStatus command returns current server status.
    /// The cmdGetStatus command does not have any additional request parameters.
    /// </summary>
    public class CommandGetStatus : BaseCommand, ICommand_
    {
        /// <summary>
        /// The status of the server.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusName Status { get; set; }
        /// <summary>
        /// Provides information about currently optimized job.
        /// </summary>
        public Job ActiveJob { get; set; }
        /// <summary>
        /// The queue size, not including the active job.
        /// </summary>
        public int QueueSize { get; set; }

        public CommandGetStatus()
        {
            Name = CommandName.cmdGetStatus;
        }

        public string GetCommand()
        {
            Hashtable command = new Hashtable();
            command.Add("id", Id);
            command.Add("cmd", Name.ToString());
            Console.WriteLine("BaseCommand sent:" + JsonConvert.SerializeObject(command, Formatting.Indented));
            return JsonConvert.SerializeObject(command, Formatting.Indented);
        }

        public void Add(Newtonsoft.Json.Linq.JObject message)
        {
            base.Add(message);

            QueueSize = (int)message["queueSize"];
            Status = (StatusName)Enum.Parse(typeof(StatusName), message["status"].ToString());
            Success = true;

            // when nothing od the queue, there isn't active job
            if (QueueSize > 0)
            {
                Status = (StatusName)Enum.Parse(typeof(StatusName), message["status"].ToString());                
                JobStateName jobStateName = (JobStateName)Enum.Parse(typeof(JobStateName), message["activeJob"]["state"].ToString());

                if (JobStateName.sError == jobStateName)
                {
                    Success = false;
                    JobStateErrorCode errorCode = (JobStateErrorCode)Enum.Parse(typeof(JobStateErrorCode), message["activeJob"]["errCode"].ToString());
                    ActiveJob = new Job(
                        (int)message["activeJob"], jobStateName, errorCode, message["errorDescription"].ToString());
                }
                else
                {
                    ActiveJob = new Job(
                        (int)message["ativeJob"]["id"],
                        jobStateName,
                        (float)message["ativeJob"]["progress"],
                        (int)message["ativeJob"]["combinationCount"]
                        );
                }
            }
        }

        bool ICommand_.IsDataCompatible(Newtonsoft.Json.Linq.JObject message) => message.ContainsKey("event") ? false : true;
    }
}
