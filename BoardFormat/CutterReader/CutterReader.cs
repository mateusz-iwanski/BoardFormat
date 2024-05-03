using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonCut;
using BoardFormat.CutterBuilder;

namespace BoardFormat.CutterReader
{
    public class CutterReader : ICutterReader
    {
        public DataInput dataInput { get; private set; }
        public DataOutputs dataOutputs { get; private set; }        
        public CutterReader(DataInput dataInput, DataOutputs dataOutputs)
        {
            this.dataInput = dataInput;
            this.dataOutputs = dataOutputs;
        }
    }
}
