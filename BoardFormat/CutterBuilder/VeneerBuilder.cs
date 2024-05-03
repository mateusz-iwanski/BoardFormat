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
    public class VeneerBuilder : BaseCutterBuilder, ICutterInputBuilder
    {
        protected DataInputCollector DataInputCollector { get; set; }
        int id { get; set; }
        string title { get; set; }
        int width { get; set; }
        int thickness { get; set; }
        double maxMaterialThickness { get; set; }

        protected VeneerBuilder(DataInputCollector dataInputCollector) => this.DataInputCollector = dataInputCollector;

        public VeneerBuilder(
            DataInputCollector dataInputCollector,
            int id,
            string title,
            bool wide)
        {
            DataInputCollector = dataInputCollector;

            this.id = id;
            this.title = title;
            this.width = wide ? settings.CutterVeneer18.width : settings.CutterVeneer38.width;
            this.thickness = wide ? settings.CutterVeneer18.thickness : settings.CutterVeneer38.thickness;
            this.maxMaterialThickness = wide ? settings.CutterVeneer18.maxMaterialThickness : settings.CutterVeneer38.maxMaterialThickness;
        }
        public virtual DataInputCollector Build()
        {
            Veneer veneer = new Veneer(
                id:this.id,
                title:this.title,
                width:this.width,
                thickness:this.thickness,
                maxMaterialThickness: this.maxMaterialThickness
                );

            this.DataInputCollector.Append(veneer);

            return this.DataInputCollector;
        }
    }
}
