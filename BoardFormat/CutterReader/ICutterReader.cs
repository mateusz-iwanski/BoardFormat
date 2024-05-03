using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TonCut;

namespace BoardFormat.CutterReader
{
    public interface ICutterReader
    {
        public DataInput dataInput { get; }
        public DataOutputs dataOutputs { get; }
    }
}
