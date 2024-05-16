using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static TonCut.StockOrder;
using System.Threading;
using WebSocket4Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
using System.Runtime.InteropServices;

namespace TonCut
{
    public class TonCut
    {        

        public DataInput testInput()
        {
            DefaultUnitsInput defaultUnits = new DefaultUnitsInput(_time: "s", _length: "mm", _field: "sqmm", _angle: "deg");

            Material materials = new Material(
                    id: 1, deviceId: 1, title: "Test material", kind: "2d",
                    width: 0, thickness: 18, canHaveStructure: true,
                    canRotate: true, canMirror: false,
                    surplus: 0, surplusEditable: true, margin: 0, marginEditable: true,
                    defaultEdging: 0, cuttingDimensions: "net", canBeVeneered: true,
                    kerf: 4.5d,
                    allowEdgeCuts: true,
                    rauseWaste: new ReuseWaste(
                        minShorterLength: 200, minLongerLength: 200,
                        wasteEdging: new MaterialWasteEdging(enabled: false, _default: 0)
                        ),
                    standardStockItems: new List<StandardStockItem> { }
                );

            Piece piece = PieceTemplate.PieceFurnitureMelamineBoard(
                id: 1, materialId: 1, identifier: "9999", description: "Test _piece",
                length: 1000, width: 500, quantity: 1, structure: "byLength",
                veneers: new Veneers(leftVeneerId: null, rightVeneerId: null, topVeneerId: null, bottomVeneerId: null));
                

            StockItem stock = new StockItem(
                id: 1, materialId: 1,
                identifier: "12345678901234567890",
                description: "Test stock item", priority: "normal", length: 1014.5d, width: 605.5d, quantity: 10000, structure: "byLength",                
                kerfSize: 4.5d,
                edging: new Edging(left: 5.0d, right: 5.0d, top: 5.0d, bottom: 5.0d)
                );

            DataInputCollector collectorVeneer = new DataInputCollector(new GatherVeneer());
            
            DataInputCollector collectorDevice = new DataInputCollector(new GatherDevice());
            Device devices = new DeviceRepository().device.Find(x => x.id == 1);
            collectorDevice.Append(devices);

            DataInputCollector collectorMaterial = new DataInputCollector(new GatherMaterial());
            collectorMaterial.Append(materials);

            DataInputCollector collectorPiece = new DataInputCollector(new GatherPiece());
            collectorPiece.Append(piece);

            //CSVPieceReader epr = new CSVPieceReader();
            //foreach (var i in epr.CreatePiece())
            //{
            //    collectorPiece.Append(i);
            //}


            DataInputCollector collectorStock = new DataInputCollector(new GatherStock());
            collectorStock.Append(stock);


            DataInput dataInput = new DataInput(2, defaultUnits, collectorMaterial, collectorDevice, collectorPiece, collectorStock, collectorVeneer);

            
            return dataInput;
        }
       
        public static async Task<int> AddJob(Configuration config, DataInput input)
        {
            WSCommander wSCommander = new WSCommander();
            var id = await wSCommander.AddJob(config, input);
            return id;
        }

        public static async Task<Job> GetJobInfo(int jobID)
        {
            WSCommander wSCommander = new WSCommander();
            var job = await wSCommander.GetJobInfo(jobID);
            return job;
        }

        public static async Task<DataOutputs> GetJobDataOutput(int jobID)
        {
            WSCommander wSCommander = new WSCommander();
            var dataOutput = await wSCommander.GetJobDataOutput(jobID);
            return dataOutput;
        }


        public static async Task<List<Job>> GetListJobs()
        {
            WSCommander wSCommander = new WSCommander();
            var listJob = await wSCommander.GetListJobs();
            return listJob;
        }

        public static async Task RemoveJob(int id)
        {
            WSCommander wSCommander = new WSCommander();
            await wSCommander.RemoveJob(id);            
        }

        public DataOutputs test() 
        {
            Configuration config = new ProfileRepository().FromLargeProfileConfigurationTest();

            TonCut tonCut = new TonCut();



            //var jobList = GetListJobs().Result;//.Where(x => x.State == JobStateName.sCanceled).ToList();

            //Console.WriteLine($"Job List Info: \n {JsonConvert.SerializeObject(jobList, Formatting.Indented)}");

            //while (true)
            //{
            //    Thread.Sleep(2000);
            //    var job = GetJobInfo(id).Result;
            //    Console.WriteLine($"Job Info: \n {JsonConvert.SerializeObject(job, Formatting.Indented)}");
            //}

            //foreach (var item in jobList)
            //  RemoveJob(item.Id).Wait();

            var id = AddJob(config, tonCut.testInput()).Result;
            Console.WriteLine($"Job ID: {id}");
            Thread.Sleep(2000);
            var jobInfo = GetJobDataOutput(id).Result;
            return jobInfo;
        }



    }
}

