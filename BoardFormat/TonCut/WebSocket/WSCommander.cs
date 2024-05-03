using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TonCut
{
    public class WSCommander
    {
        public WSClientCommander _WSClientCommander { get; private set; }

        private async Task StartMessaging(ICommand_ command)
        {
            this._WSClientCommander = new WSClientCommander(command);
            WebSocketClient wSClient = new WebSocketClient(this._WSClientCommander);
            await Task.Run(() => wSClient.Send());
        }

        public async Task<int> AddJob(Configuration config, DataInput input, bool allowOverStock = false)
        {
            await StartMessaging(new CommandAddJob(config, input, allowOverStock));
            CommandAddJob command = (CommandAddJob)(this._WSClientCommander._Command);

            return command.JobId;
        }

        public async Task<Job> GetJobInfo(int jobId)
        {
            await StartMessaging(new CommandGetJobInfo(jobId));            
            CommandGetJobInfo command = (CommandGetJobInfo)(this._WSClientCommander._Command);

            return command._Job;
        }
        
        public async Task<DataOutputs> GetJobDataOutput(int jobId)
        {
            await StartMessaging(new CommandGetJobInfo(jobId));
            CommandGetJobInfo command = (CommandGetJobInfo)(this._WSClientCommander._Command);

            return command.DataOutput;
        }

        public async Task<List<Job>> GetListJobs()
        {
            await StartMessaging(new CommandListJobs());
            CommandListJobs command = (CommandListJobs)(this._WSClientCommander._Command);

            return command.JobsList;
        }

        public async Task RemoveJob(int jobId)
        {
            await StartMessaging(new CommandRemoveJob(jobId));
            CommandRemoveJob command = (CommandRemoveJob)(this._WSClientCommander._Command);            
        }

        public async Task<Job> GetCurrentlyOptimizedJob()
        {
            await StartMessaging(new CommandGetStatus());
            CommandGetStatus command = (CommandGetStatus)(this._WSClientCommander._Command);

            return command.ActiveJob;
        }

        public async Task<StatusName> GetServerStatus()
        {
            await StartMessaging(new CommandGetStatus());
            CommandGetStatus command = (CommandGetStatus)(this._WSClientCommander._Command);

            return command.Status;
        }

        public async Task<int> GetServerQueueSize()
        {
            await StartMessaging(new CommandGetStatus());
            CommandGetStatus command = (CommandGetStatus)(this._WSClientCommander._Command);

            return command.QueueSize;
        }

    }
}
