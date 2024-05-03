using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TonCut;

namespace BoardFormat.CutterBuilder
{
    public class DeviceBuilder : BaseCutterBuilder, ICutterInputBuilder
    {
        DataInputCollector DataInputCollector { get; set; }

        public DeviceBuilder(DataInputCollector dataInputCollector) => this.DataInputCollector = dataInputCollector;
        public DataInputCollector Build()
        {
            TonCut.Device device = new TonCut.Device(
                id: settings.CutterDevice.id,
                title: settings.CutterDevice.title,
                materialKind: settings.CutterDevice.materialKind,
                canCrossCuts: settings.CutterDevice.canCrossCuts,
                fullCutsOnly: settings.CutterDevice.fullCutsOnly,
                stripCuts: settings.CutterDevice.stripCuts,
                minCutWidth: settings.CutterDevice.minCutWidth,
                edgingCuts: settings.CutterDevice.edgingCuts,
                originEdgingCuts: settings.CutterDevice.originEdgingCuts,
                firstCutDirection: settings.CutterDevice.firstCutDirection,
                slants: new Slants(
                    supported: settings.CutterDevice.CutterSlants.supported,
                    leftMeasurement: settings.CutterDevice.CutterSlants.leftMeasurement,
                    rightMeasurement: settings.CutterDevice.CutterSlants.rightMeasurement
                ),
                maxCutDepth: new MaxCutDepth(
                    enabled: settings.CutterDevice.CutterMaxCutDepth.enabled,
                    limit: settings.CutterDevice.CutterMaxCutDepth.limit,
                    includeEdging: settings.CutterDevice.CutterMaxCutDepth.includeEdging
                    ),
                maxCutLengthByLength: new MaxCutLengthByLength(
                    enabled: settings.CutterDevice.CutterMaxCutLengthByLength.enabled,
                    limit: settings.CutterDevice.CutterMaxCutLengthByLength.limit
                    ),
                maxCutLengthByWidth: new MaxCutLengthByWidth(
                    enabled: settings.CutterDevice.CutterMaxCutLengthByWidth.enabled,
                    limit: settings.CutterDevice.CutterMaxCutLengthByWidth.limit
                    )
                );
            
            this.DataInputCollector.Append(device);
            return this.DataInputCollector;
        }
    }
}
