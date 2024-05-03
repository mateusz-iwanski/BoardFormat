using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using SuperSocket.ClientEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TonCut
{
    /// <summary>
    /// Creates a new job and adds it to the queue.
    /// </summary>
    public class CommandAddJob : BaseCommand, ICommand_
    {
        /// <summary>
        /// Configuration data group object.
        /// Please note that the configuration you provide here will overwrite 
        /// the default settings and remain in effect until it is changed again.
        /// </summary>
        public Configuration Config { get; }
        /// <summary>
        /// Input data group object.
        /// </summary>
        public DataInput Input { get; }
        /// <summary>
        /// Returned id of the job. Id's are unique for each job.
        /// </summary>
        public int JobId { get; set; }
        /// <summary>
        /// def: false
        /// The allowOverstock parameter controls the behavior of the cutting optimization algorithm.
        /// When set to true, the algorithm is permitted to allocate more stock items than currently available.
        /// This can be useful in scenarios where future stock replenishment is anticipated or over-allocation is acceptable.
        /// Please note that enabling this option may lead to situations where demand exceeds supply.
        /// Note that it applies only to standard stock sizes.So, in order to use more stock items than available, 
        /// you have to define standard stock items in material definition.
        /// Then, you have to add stock item with the same standard size.
        /// </summary>
        public bool AllowOverstock;
        public CommandAddJob(Configuration config, DataInput input, bool allowOverStock = false)
        {
            Name = CommandName.cmdAddJob;
            this.Config = config;
            this.Input = input;
            this.AllowOverstock = allowOverStock;
        }
        public string GetCommand()
        {
            Hashtable command = new Hashtable();
            command.Add("id", Id);
            command.Add("cmd", Name.ToString());
            command.Add("config", this.Input);
            command.Add("input", this.Input);            
            Console.WriteLine("BaseCommand sent:" + JsonConvert.SerializeObject(command, Formatting.Indented));
            return JsonConvert.SerializeObject(command, Formatting.Indented);
        }

        public void Add(Newtonsoft.Json.Linq.JObject message)
        {
            this.JobId = (int)message["jobId"];
        }

        bool ICommand_.IsDataCompatible(Newtonsoft.Json.Linq.JObject message) => message.ContainsKey("event") ? false : true;

    }
}
