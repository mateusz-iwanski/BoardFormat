using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonCut;

namespace BoardFormat.CutterBuilder
{
    public class VeneerDefaultBuilder : VeneerBuilder , ICutterInputBuilder
    {
        public VeneerDefaultBuilder(DataInputCollector dataInputCollector) : base(dataInputCollector) { }
        public override DataInputCollector Build()
        {
            Veneer default18 = new Veneer(
                id: 1,
                title: "default 23mm",
                width: settings.CutterVeneer18.width,
                thickness: settings.CutterVeneer18.thickness,
                maxMaterialThickness: settings.CutterVeneer18.maxMaterialThickness
                );
            Veneer default38 = new Veneer(
                id: 2,
                title: "default 43mm",
                width: settings.CutterVeneer38.width,
                thickness: settings.CutterVeneer38.thickness,
                maxMaterialThickness: settings.CutterVeneer38.maxMaterialThickness
                );

            DataInputCollector.Append(default18);
            DataInputCollector.Append(default38);

            return DataInputCollector;
        }
    }
}
