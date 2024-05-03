using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonCut;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BoardFormat.CutterBuilder
{
    public class CutterBuilder : BaseCutterBuilder
    {
        Configuration config { get; set; }
        DataInput dataInput { get; set; }

        public Configuration Config
        {
            get => config;
            set => config = value;
        }

        public DataInput DataInput
        {
            get => dataInput;
            set => dataInput = value;
        }   

        public CutterBuilder(DataInputBuilder cutterBuilderAssociating)
        {
            Config = new Configuration(
                _version: settings.CutterVersion,
                _defaultUnits: (DefaultUnitsInput) new DefaultUnitsInputBuilder().Build(),
                _profiles: (Profile) new ProfileBuilder().Build()
                );

            DataInput = cutterBuilderAssociating.Build();
        }

    }
}
