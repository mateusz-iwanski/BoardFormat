using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// The cmdRemoveJob allows to remove specified job.
    /// </summary>
    public class CommandRemoveJob : BaseCommand, ICommand_
    {
        /// <summary>
        /// ID of the job to be removed.
        /// </summary>
        public int JobId { get; set; }

        public CommandRemoveJob(int _jobId)
        {
            Name = CommandName.cmdRemoveJob;
            JobId = _jobId;
            // BaseCommand not request so set Succes on True
            Success = true;
        }
        public string GetCommand()
        {
            Hashtable command = new Hashtable();
            command.Add("id", Id);
            command.Add("jobId", this.JobId);            
            command.Add("cmd", Name.ToString());
            Console.WriteLine("BaseCommand sent:" + JsonConvert.SerializeObject(command, Formatting.Indented));
            return JsonConvert.SerializeObject(command, Formatting.Indented);
        }
        bool ICommand_.IsDataCompatible(Newtonsoft.Json.Linq.JObject message) => message.ContainsKey("event") ? false : true;
    }
}
