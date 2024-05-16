using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardFormat.MVVM.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Maui.Controls; // Add this line

using BoardFormat.CutterBuilder;
using TonCut;

namespace BoardFormat.MVVM.ViewsModels
{

    public class PieceCollectionViewModel : BaseViewModel
    {
        private DataInput dataInput;
        private DataOutputs dataOutput;

        public ObservableCollection<BoardFormat.MVVM.Models.Piece> Pieces { get; set; }
        public ObservableCollection<BoardFormat.MVVM.Models.PieceFromCabinets> PieceFromCabinets { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public bool Structure { get; set; }

        public DataInput DataInput { get => dataInput; set => SetProperty(ref dataInput, value); }
        public DataOutputs DataOutput { get => dataOutput; set => SetProperty(ref dataOutput, value); }


        public System.Windows.Input.ICommand OnAddPieceClicked => new Command(OnAddPieceCommand);
        public System.Windows.Input.ICommand OnOptimizeClicked => new Command(OnOptimizeCommand);


        public PieceCollectionViewModel()
        {
            Pieces = new ObservableCollection<BoardFormat.MVVM.Models.Piece>();
            PieceFromCabinets = new ObservableCollection<BoardFormat.MVVM.Models.PieceFromCabinets>();
            //configuration = MauiProgram.Services.GetService<IConfiguration>();
        }

        private async void OnOptimizeCommand()
        {
            Debug.WriteLine("Button OnOptimizeCommand");

            DataInputBuilder dib = new DataInputBuilder();

            int materialId = dib.AddMaterial(title: "Material", thickness: 18, canHaveStructure: true, canRotate: false);
            dib.AddStockItem(materialId: materialId, identifier: "material on stock", "description ...", length: 2800, width: 2070, quantity: 200, structure: true);

            int materialId2 = dib.AddMaterial(title: "Material2", thickness: 18, canHaveStructure: true, canRotate: false);
            dib.AddStockItem(materialId: materialId2, identifier: "material on stock", "description ...", length: 1000, width: 2000, quantity: 200, structure: true);

            dib.AddPiece(
                materialId: materialId2, identifier: "c1", description: "description ...",
                length: 200, width: 500, quantity: 1, structure: true, leftVeneer: true, rightVeneer: true, topVeneer: false, bottomVeneer: false, bold: false);

            dib.AddPiece(
                materialId: materialId2, identifier: "c2", description: "description ...",
                length: 200, width: 500, quantity: 2, structure: true, leftVeneer: true, rightVeneer: true, topVeneer: false, bottomVeneer: false, bold: false);

            dib.AddPiece(
                materialId: materialId2, identifier: "c3", description: "description ...",
                length: 200, width: 500, quantity: 5, structure: true, leftVeneer: true, rightVeneer: true, topVeneer: false, bottomVeneer: false, bold: false);

            dib.AddPiece(
                materialId: materialId, identifier: "cabinetPiece", description: "description ...",
                length: 1000, width: 200, quantity: 1, structure: true, leftVeneer: true, rightVeneer: true, topVeneer: true, bottomVeneer: true, bold: false);

            //dib.AddPiece(
            //    materialId: materialId, identifier: "cabinetPiece", description: "description ...",
            //    length: 1200, width: 400, quantity: 23, structure: true, leftVeneer: true, rightVeneer: true, topVeneer: false, bottomVeneer: false, bold: false);

            CutterBuilder.CutterBuilder cutterBuilder = new CutterBuilder.CutterBuilder(dib);

            Debug.WriteLine($"Data Input config: \n {Newtonsoft.Json.JsonConvert.SerializeObject(cutterBuilder.Config, Newtonsoft.Json.Formatting.Indented)}");
            Debug.WriteLine($"Data Input data: \n {Newtonsoft.Json.JsonConvert.SerializeObject(cutterBuilder.DataInput, Newtonsoft.Json.Formatting.Indented)}");


            var i = await AddJob(cutterBuilder.Config, cutterBuilder.DataInput);

            Thread.Sleep(500);
            var jobInfo = await GetJobDataOutput(i);
            Thread.Sleep(500);
            Console.WriteLine($"Job id: \n {i}");
            Console.WriteLine($"Job Info: \n {jobInfo}");
            Debug.WriteLine($"Job Info: \n {Newtonsoft.Json.JsonConvert.SerializeObject(jobInfo, Newtonsoft.Json.Formatting.Indented)}");

            this.DataInput = cutterBuilder.DataInput;
            this.DataOutput = jobInfo;
        }

        private async void OnAddPieceCommand()
        {
            Debug.WriteLine("Button OnAddPieceCommand");

            Pieces.Add(new Models.Piece(
                length: this.Length,
                width: this.Width,
                structure: this.Structure
                )
            );
        }
        private static async Task<int> AddJob(Configuration config, DataInput input)
        {
            WSCommander wSCommander = new WSCommander();
            var id = await wSCommander.AddJob(config, input);
            return id;
        }

        private static async Task<DataOutputs> GetJobDataOutput(int jobID)
        {
            WSCommander wSCommander = new WSCommander();
            var dataOutput = await wSCommander.GetJobDataOutput(jobID);
            return dataOutput;
        }
    }


}
