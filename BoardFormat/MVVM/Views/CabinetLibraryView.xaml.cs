using BoardFormat.MVVM.ViewsModels;
using BoardFormat.MVVM.Models;
using System.Runtime.CompilerServices;

namespace BoardFormat.MVVM.Views;



public partial class CabinetLibraryView : ContentPage
{	
	PieceCollectionViewModel pieceCollectionViewModel;
	CabinetLibraryViewModel cabinetLibraryViewModel;

	public CabinetLibraryView(PieceCollectionViewModel pieceCollectionViewModel)
	{
		InitializeComponent();
        cabinetLibraryViewModel = new CabinetLibraryViewModel();
        BindingContext = cabinetLibraryViewModel;
		this.pieceCollectionViewModel = pieceCollectionViewModel;
	}

	public void OnButtonClicked(object sender, EventArgs e)
	{
		IEnumerable<Cabinet> cabinetsLibrary = cabinetLibraryViewModel.CabinetCollection;

		foreach (Cabinet cabinet in cabinetsLibrary)
			cabinet.Pieces.ForEach(cabinetPieceBehavior =>
			{
				pieceCollectionViewModel.Pieces.Add(cabinetPieceBehavior.cabinetPiece.Piece);
			});
			
   //     pieceCollectionViewModel.Pieces.Add(new Piece(
   //             length: 1000.0f,
   //             width: 500.0f,
   //             structure: true
			//	)
			//);
		Navigation.PopAsync();
    }
}