using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TonCut;

namespace BoardFormat.CutterBuilder
{
    public interface ICutterInputBuilder
    {
        public DataInputCollector Build();
    }
}
