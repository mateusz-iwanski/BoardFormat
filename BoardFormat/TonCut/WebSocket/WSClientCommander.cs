using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    public class WSClientCommander : IWSClientCommander
    {
        public ICommand_ _Command { get; set; }
        public EventReceiver _EventReceiver { get; }

        [JsonProperty("Done")]
        private bool Done = false;
        public WSClientCommander(ICommand_ command)
        {
            _Command = command;
            _EventReceiver = new EventReceiver();
        }

        /// <summary>
        /// Adds a message to the receiver.
        /// If adding Commands response return True. For Events response return False.
        /// </summary>
        /// <param name="message">The message to be added.</param>
        /// <returns>True if the message was successfully added, false otherwise.</returns>
        public bool Add(string message)
        {
            var jObject = NewtonUtils.DeserializeToJObject(message);

            if (_EventReceiver.IsDataCompatible(jObject))
            {
                _EventReceiver.Add(jObject);
                return false;
            }
            else if (_Command.IsDataCompatible(jObject))
            {
                _Command.Add(jObject);
                SetDone();
                return true;
            }
            else
                throw new Exception($"Wrong data Format in WSClientCommander - {jObject.ToString()}");

            return false;
        }


        public void SetDone() => this.Done = true;
        
        [JsonIgnore]
        public bool IsDone { get => this.Done; }
    }
}
