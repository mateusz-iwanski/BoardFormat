using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TonCut;


namespace BoardFormat.CutterBuilder
{
    
    public class DataInputBuilder: BaseCutterBuilder
    {
        DefaultUnitsInput DefaultUnitsCollector { get; set; }
        DataInputCollector VeneerCollector { get; set; }
        DataInputCollector DeviceCollector { get; set; }
        DataInputCollector MaterialCollector { get; set; }
        DataInputCollector PieceCollector { get; set; }
        DataInputCollector StockItemCollector { get; set; }

        int MaterialId = 0;
        int PieceId = 0;
        int StockItemId = 0;

        public DataInputBuilder()
        {
            VeneerCollector = new DataInputCollector(new GatherVeneer());
            DeviceCollector = new DataInputCollector(new GatherDevice());
            MaterialCollector = new DataInputCollector(new GatherMaterial());
            PieceCollector = new DataInputCollector(new GatherPiece());
            StockItemCollector = new DataInputCollector(new GatherStock());
            VeneerCollector = new DataInputCollector(new GatherVeneer());

            DefaultUnitsCollector = new DefaultUnitsInputBuilder().Build();
            var _veneerCollector = new VeneerDefaultBuilder(VeneerCollector).Build();
            var _deviceCollector = new DeviceBuilder(DeviceCollector).Build();
        }

        public int AddMaterial(string title, int thickness, bool canHaveStructure, bool canRotate)
        {   
            
            MaterialBuilder materialCutterBuilder = new MaterialBuilder(
                dataInputCollector: MaterialCollector,
                id: ref MaterialId,
                title: title,
                thickness: thickness,
                canHaveStructure: canHaveStructure, 
                canRotate: canRotate
                );            
            return materialCutterBuilder.id;
        }

        public void AddPiece(
            int materialId,
            string identifier, string description,
            int length, int width, int quantity, bool structure,
            bool leftVeneer, bool rightVeneer, bool topVeneer, bool bottomVeneer,
            bool bold)
        {
            
            PieceBuilder pieceCutterBuilder = new PieceBuilder(
                dataInputCollector: PieceCollector,
                id: ref PieceId,
                materialId: materialId,
                identifier: identifier, description: description,
                length: length, width: width,
                quantity: quantity, structure: structure,
                leftVeneer: leftVeneer, rightVeneer: rightVeneer, topVeneer: topVeneer, bottomVeneer: bottomVeneer,
                bold: bold
                );            
        }

        public void AddStockItem(
            int materialId,
            string identifier, string description,
            double length, double width,
            int quantity,
            bool structure)
        {
            StockItemBulider stockItemCutterBuilder = new StockItemBulider(
                dataInputCollector: StockItemCollector,
                id: ref StockItemId,
                materialId: materialId,
                identifier: identifier, description: description,
                length: length, width: width,
                quantity: quantity,
                structure: structure
                );
        }

        public DataInput Build() =>
                new DataInput(
                    version: settings.CutterVersion,
                    defaultUnits: DefaultUnitsCollector,
                    veneers: VeneerCollector,
                    devices: DeviceCollector,
                    materials: MaterialCollector,
                    pieces: PieceCollector,
                    stock: StockItemCollector
                    );
    }
}
