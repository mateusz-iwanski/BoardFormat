using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// The output data (result) of WSClientCommander
    /// There are two commnds which give us DataOutput result, one is cmdGetJobInfo and the other is cmdAddJob.
    /// CmdAddJob receive data when we demand for a new job. Server receive Events with OutputData after we send command. Is the fastest Way.
    /// CmdGetJobInfo receive data after we use cmdAddJob. We have to wait to finish adding job and next by job id get job info.
    /// CmdGetJobInfo is slower way to get data, we need to 2 times receive data from Server.
    /// </summary>
    public class WSReaderOutputData
    {
        private DataOutputs DataOutput;

        public Statistics2d GlobalStatistics2D
        {
            get { return DataOutput.statistics._2d; } 
        }

        public DefaultUnits DefaultUnits
        {
            get { return DataOutput.defaultUnits; }
        }

        public List<Cutting> Cuttings
        {
            get { return DataOutput.cuttings; }
        }

        public WSReaderOutputData(WSClientCommander wsc)
        {
            if (wsc.IsDone)
            {
                if (CommandName.cmdGetJobInfo == ((BaseCommand)wsc._Command).Name)
                {
                    CommandGetJobInfo commandResults = (CommandGetJobInfo)wsc._Command;
                    DataOutput = commandResults.DataOutput;
                }
                else if (CommandName.cmdAddJob == ((BaseCommand)wsc._Command).Name)
                {
                    EventJobResults eventJobResults = (EventJobResults)wsc._EventReceiver.Events.FirstOrDefault(x => x.Name == EventName.JobResults);
                    DataOutput = eventJobResults.results;
                }
                else throw new Exception("WSReaderOutputData only support commands CommandGetJobInfo and CommandAddJob!");
            }
            else throw new Exception("WSClientCommander not receive data!");
        }


    }
}
