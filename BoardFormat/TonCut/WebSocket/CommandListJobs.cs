using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TonCut
{
    /// <summary>
    /// You can use the cmdListJobs command to get a list of jobs.
    /// The list will show you all the jobs, no matter if they are finished, waiting or in process.
    /// A job is in process when it is currently being optimized.
    /// The cmdListJobs command does not have any additional request parameters.
    /// </summary>
    internal class CommandListJobs : BaseCommand, ICommand_
    {
        /// <summary>
        /// Contains list of all the job.
        /// Each job is described by an object with the following properties.
        /// </summary>
        public List<Job> JobsList { get; }
        
        public CommandListJobs()
        {
            Name = CommandName.cmdListJobs;
            JobsList = new List<Job>();
        }

        public string GetCommand()
        {
            Hashtable command = new Hashtable();
            command.Add("id", Id);
            command.Add("cmd", Name.ToString());
            Console.WriteLine("BaseCommand to send:" + JsonConvert.SerializeObject(command, Formatting.Indented));
            return JsonConvert.SerializeObject(command, Formatting.Indented);
        }

        public void Add(Newtonsoft.Json.Linq.JObject message)
        {
            base.Add(message);
                        
            foreach (var _message in message["jobs"])
            {
                JobStateName jobStateName = (JobStateName)Enum.Parse(typeof(JobStateName), _message["state"].ToString());
                if (JobStateName.sError == jobStateName)
                {
                    JobStateErrorCode errorCode = (JobStateErrorCode)Enum.Parse(typeof(JobStateErrorCode), _message["errCode"].ToString());
                    JobsList.Add(new Job(
                        id:(int)_message["jobId"], 
                        state:jobStateName, 
                        errorCode:errorCode, errorDescription:_message["errorDescription"].ToString()));
                }
                else
                {
                    DateTime createDate;
                    DateTime startDate;
                    DateTime endDate;

                    DateTime.TryParse(_message["createDate"].ToString(), out createDate);
                    DateTime.TryParse(_message["startDate"].ToString(), out startDate);
                    DateTime.TryParse(_message["endDate"].ToString(), out endDate);

                    JobsList.Add(new Job(
                        (int)_message["id"],
                        jobStateName,
                        (float)_message["progress"],
                        (long)_message["combinationCount"],
                        createDate, startDate, endDate
                    ));
                }
            }
        }

        bool ICommand_.IsDataCompatible(Newtonsoft.Json.Linq.JObject message) => message.ContainsKey("event") ? false : true;
    }
}
