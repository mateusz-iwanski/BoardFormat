using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    internal class DeviceRepository
    {
        public List<Device> device { get; set; }
        
        public DeviceRepository()
        {
            device = new List<Device>();
            device.Add(DeviceSektor450());
        }

        private Device DeviceSektor450()
        {
            return new Device(
                    id: 1,
                    title: "BiesseSektor450",
                    materialKind: "2d",
                    slants: new Slants(
                        supported: true,
                        leftMeasurement: "fromMiddleToRight",
                        rightMeasurement: "fromMiddleToLeft"
                    ),
                    canCrossCuts: true,
                    fullCutsOnly: true,
                    stripCuts: true,
                    minCutWidth: 0,
                    edgingCuts: "optimal",
                    originEdgingCuts: "default",
                    firstCutDirection: "any",
                    maxCutDepth: new MaxCutDepth(
                        enabled: true,
                        limit: 5,
                        includeEdging: false
                        ),
                    maxCutLengthByLength: new MaxCutLengthByLength(
                        enabled: false,
                        limit: 10000.0d
                        ),
                    maxCutLengthByWidth: new MaxCutLengthByWidth(
                        enabled: false,
                        limit: 10000.0d
                        )
                    );
        }
        
    }
}
