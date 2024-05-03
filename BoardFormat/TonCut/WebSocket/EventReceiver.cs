using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TonCut
{
    /// <summary>
    /// This class accumulates all events. One command can return many events.
    /// </summary>
    public class EventReceiver
    {
        /// <summary>
        /// Additionally server sends events / notifications when there is some change.        
        /// The event property identifies the type of the event.
        /// </summary>
        public List<Event> Events = new List<Event>();

        public void Add(Newtonsoft.Json.Linq.JObject message) 
        {                        
            EventName _event = (EventName)Enum.Parse(typeof(EventName), message["event"].ToString());                                            
                
            switch (_event)
            {
                case EventName.JobAdd:
                    Events.Add(new EventJobAdd(
                                EventName.JobAdd,
                                (int)message["jobId"]
                            ));                            
                    break;
                    
                case EventName.Status:
                    StatusName eventStatusName = (StatusName)Enum.Parse(typeof(StatusName), message["status"].ToString());
                    Events.Add(new EventStatus(
                                EventName.Status,
                                eventStatusName,
                                (int)message["queueSize"]
                            ));
                    break;

                case EventName.JobState:
                    JobStateName eventJobStateName = (JobStateName)Enum.Parse(typeof(JobStateName), message["state"].ToString());

                    if (message.ContainsKey("errorCode"))
                    {
                        JobStateErrorCode eventJobStateError = (JobStateErrorCode)Enum.Parse(typeof(JobStateErrorCode), message["errorCode"].ToString());
                        Events.Add(new EventJobState(
                                EventName.JobState,
                                eventJobStateName,
                                (int)message["jobId"],
                                eventJobStateError,
                                message["errorDescription"].ToString()
                            ));
                    }
                    else
                    {
                        Events.Add(new EventJobState(
                                EventName.JobState,
                                eventJobStateName,
                                (int)message["jobId"]
                            ));
                    }
                        
                    break;

                case EventName.JobResults:
                    Events.Add(new EventJobResults(
                                EventName.JobResults,
                                (int)message["jobId"],
                                message["results"].ToString()
                            ));
                    break;

                case EventName.JobProgress:
                    Events.Add(new EventJobProgress(
                                EventName.JobProgress,
                                (int)message["jobId"],
                                (double)message["progress"],
                                (long)message["combinationCount"]
                            ));
                    break;
                    
                case EventName.JobDelete:
                    Events.Add(new EventJobDelete(
                                EventName.JobDelete,
                                (int)message["jobId"]
                            ));
                    break;
            }
            
        }

        public bool IsDataCompatible(Newtonsoft.Json.Linq.JObject message) => message.ContainsKey("event") ? true : false;

    }
}
