using BoardFormat.MVVM.ViewsModels;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

using BoardFormat.CutterBuilder;
using TonCut;
using Newtonsoft.Json;
using System.ComponentModel;

using TonCut;
using BoardFormat.MVVM.Views;

namespace BoardFormat
{
    public partial class MainPage : ContentPage
    {
        PieceCollectionViewModel pieceCollectionViewModel;
        public MainPage()
        {
            InitializeComponent();
            pieceCollectionViewModel = new PieceCollectionViewModel();
            pieceCollectionViewModel.PropertyChanged += OnDataOutputChanged;
            BindingContext = pieceCollectionViewModel;
        }

        public void OnLibraryClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CabinetLibraryView(pieceCollectionViewModel));
        }

        private void OnDataOutputChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "DataOutput")
            {
                CutterDrawerView.OptimizeDataOutput = ((PieceCollectionViewModel)sender).DataOutput;
                
            }
            if (e.PropertyName == "DataInput")
            {
                CutterDrawerView.OptimizeDataInput = ((PieceCollectionViewModel)sender).DataInput;
                
            }
            if (CutterDrawerView.OptimizeDataOutput != null && CutterDrawerView.OptimizeDataInput != null)
            {
                CutterDrawerView.Draw();
            }
        }

    }

}
