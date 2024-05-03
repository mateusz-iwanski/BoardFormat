using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    public interface ICommand_
    {
        public void Add(Newtonsoft.Json.Linq.JObject message);
        public bool IsDataCompatible(Newtonsoft.Json.Linq.JObject message);
        public string GetCommand();
    }
}
