using BoardFormat.MVVM.ViewsModels;
using BoardFormat.MVVM.Models;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BoardFormat.MVVM.Views;



public partial class CabinetLibraryView : ContentPage
{	
	PieceCollectionViewModel _pieceCollectionViewModel;
	CabinetLibraryViewModel _cabinetLibraryViewModel;

	public CabinetLibraryView(PieceCollectionViewModel pieceCollectionViewModel)
	{
		InitializeComponent();
        _cabinetLibraryViewModel = new CabinetLibraryViewModel();
        BindingContext = _cabinetLibraryViewModel;
        this._pieceCollectionViewModel = pieceCollectionViewModel;

        //orderInfo = new ObservableCollection<OrderInfo>();
        //this.GenerateOrders();
        //BindingContext = this;

        listView.DataSource.GroupDescriptors.Add(
            new Syncfusion.Maui.DataSource.GroupDescriptor()
            {
                PropertyName = "Category.CabinetDestiny",
            });

        listView.DataSource.GroupDescriptors.Add(
            new Syncfusion.Maui.DataSource.GroupDescriptor()
            {
                PropertyName = "Category.CabinetType",
            });


        listView.AllowGroupExpandCollapse = true;
        listView.CollapseAll();        

    }


    public void OnButtonClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var cabinet = (Cabinet)button.BindingContext;
        Trace.WriteLine("Button clicked2 " + cabinet.Symbol);

        CanbinetAddToList canbinetAddToList = new CanbinetAddToList(cabinet, _pieceCollectionViewModel);

        Navigation.PushAsync(canbinetAddToList);

        //cabinet.Pieces.ForEach(cabinetPieceBehavior =>
        //{
        //        _pieceCollectionViewModel.Pieces.Add(cabinetPieceBehavior.cabinetPiece.Piece);
        //});

        //Navigation.PopAsync();
        //Navigation.PushAsync(new MainPage());
    }
}