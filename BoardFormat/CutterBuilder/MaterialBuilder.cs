using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TonCut;

namespace BoardFormat.CutterBuilder
{
    public class MaterialBuilder : BaseCutterBuilder, ICutterInputBuilder
    {
        // Material object
        DataInputCollector DataInputCollector { get; set; }
        public int id { get; private set; }
        int deviceId { get; set; }
        string title { get; set; }
        string kind { get; set; }
        int width { get; set; }
        int thickness { get; set; }
        bool canHaveStructure { get; set; }
        bool canRotate { get; set; }
        bool canMirror { get; set; }
        int surplus { get; set; }
        bool surplusEditable { get; set; }
        int margin { get; set; }
        bool marginEditable { get; set; }
        int defaultEdging { get; set; }
        string cuttingDimensions { get; set; }
        bool canBeVeneered { get; set; }
        double kerf { get; set; }
        bool allowEdgeCuts { get; set; }
        
        //RauseWaste object
        public int minLongerLength { get; set; }
        public int minShorterLength { get; set; }

        //MaterialWasteEdging
        public bool materialWasteEdgingEnabled { get; set; }
        public int materialWasteEdgingDefault { get; set; }        

        public MaterialBuilder(
            DataInputCollector dataInputCollector,
            ref int id, 
            string title, 
            int thickness, 
            bool canHaveStructure, bool canRotate) 
        {
            DataInputCollector = dataInputCollector;
            this.id = ++id;
            this.title = title;
            this.thickness = thickness;
            this.canHaveStructure = canHaveStructure;
            this.canRotate = canRotate;

            this.deviceId = settings.CutterMaterial.deviceId;
            this.kind = settings.CutterMaterial.kind;
            this.width = settings.CutterMaterial.width;
            this.canMirror = settings.CutterMaterial.canMirror;
            this.surplus = settings.CutterMaterial.surplus;
            this.surplusEditable = settings.CutterMaterial.surplusEditable;
            this.margin = settings.CutterMaterial.margin;
            this.marginEditable = settings.CutterMaterial.marginEditable;
            this.defaultEdging = settings.CutterMaterial.defaultEdging;
            this.cuttingDimensions = settings.CutterMaterial.cuttingDimensions;
            this.canBeVeneered = settings.CutterMaterial.canBeVeneered;
            this.kerf = settings.CutterMaterial.kerf;
            this.allowEdgeCuts  = settings.CutterMaterial.allowEdgeCuts;
            
            //RauseWaste object
            this.minLongerLength = settings.CutterRauseWaste.minLongerLength;
            this.minShorterLength = settings.CutterRauseWaste.minShorterLength;

            //MaterialWasteEdging
            this.materialWasteEdgingEnabled = settings.CutterWasteEdging.enabled;
            this.materialWasteEdgingDefault = settings.CutterWasteEdging._default;

            Build();
        }

        public DataInputCollector Build()
        {
            Material material = new Material(
                    id: id,
                    deviceId: deviceId,
                    title: title,
                    kind: kind,
                    width: width,
                    thickness: thickness,
                    canHaveStructure: canHaveStructure,
                    canRotate: canRotate,
                    canMirror: canMirror,
                    surplus: surplus, surplusEditable: surplusEditable,
                    margin: margin, marginEditable: marginEditable,
                    defaultEdging: defaultEdging,
                    cuttingDimensions: cuttingDimensions,
                    canBeVeneered: canBeVeneered,
                    kerf: kerf,
                    allowEdgeCuts: allowEdgeCuts,
                    rauseWaste:
                        new ReuseWaste(
                                minShorterLength: minShorterLength, minLongerLength: minLongerLength,
                    wasteEdging:
                        new MaterialWasteEdging(
                                enabled: materialWasteEdgingEnabled, _default: materialWasteEdgingDefault
                            )
                        ),

                    standardStockItems: new List<StandardStockItem> { }

                );

            this.DataInputCollector.Append(material);

            return this.DataInputCollector;
        }
    }   
}
