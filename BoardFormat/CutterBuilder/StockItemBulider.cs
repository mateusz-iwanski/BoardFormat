using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonCut;

namespace BoardFormat.CutterBuilder
{
    public class StockItemBulider : BaseCutterBuilder, ICutterInputBuilder
    {
        DataInputCollector DataInputCollector { get; set; }
        int id { get; set; }
        int materialId { get; set; }
        string identifier { get; set; }
        string description { get; set; }
        double length { get; set; }
        double width { get; set; }
        int quantity { get; set; }
        string structure { get; set; }        
        string priority { get; set; }
        double kerfSize { get; set; }

        //Edging object
        double left { get; set; }
        double right { get; set; }
        double top { get; set; }
        double bottom { get; set; }

        public StockItemBulider(
            DataInputCollector dataInputCollector,
            ref int id,
            int materialId,
            string identifier,
            string description,
            double length, double width,
            int quantity,
            bool structure)
        {
            DataInputCollector = dataInputCollector;

            this.id = ++id;
            this.materialId = materialId;
            this.identifier = identifier;
            this.description = description;
            this.length = length;
            this.width = width;
            this.quantity = quantity;
            this.structure = structure ? "byLength" : "none";
            this.priority = settings.CutterStockItem.priority;
            this.kerfSize = settings.CutterStockItem.kerfSize;

            //Edging object
            this.top = settings.CutterEdging.top;
            this.bottom = settings.CutterEdging.bottom;
            this.left = settings.CutterEdging.left;
            this.right = settings.CutterEdging.right;

            Build();
        }
        public DataInputCollector Build()
        {
            StockItem stockItem = new StockItem(
                    id: id,
                    materialId: materialId,
                    identifier: identifier,
                    description: description,
                    length: length,
                    width: width,
                    quantity: quantity,
                    structure: structure,
                    priority: priority,
                    kerfSize: kerfSize,
                    edging:
                        new Edging(
                            top: top,
                            bottom: bottom,
                            left: left,
                            right: right
                            )
                );

            this.DataInputCollector.Append(stockItem);

            return this.DataInputCollector;
        }
    }
}
