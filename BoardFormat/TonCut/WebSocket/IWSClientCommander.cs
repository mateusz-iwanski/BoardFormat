using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    public interface IWSClientCommander
    {
        public ICommand_ _Command { get; }
        public EventReceiver _EventReceiver { get; }
        public bool IsDone { get; }
        public void SetDone();        
        public bool Add(string message);
    }
}
