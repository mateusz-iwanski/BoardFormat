using BoardFormat.FurnitureLibrary;
using BoardFormat.MVVM.Models;
using BoardFormat.MVVM.ViewsModels;

namespace BoardFormat.MVVM.Views;

public partial class CanbinetAddToList : ContentPage
{
    public Cabinet Cabinet { get; set; }
	private PieceCollectionViewModel _pieceCollectionViewModel { get; set; }
    private PieceFromCabinets _pieceFromCabinets;
    public CanbinetAddToList(Cabinet cabinet, PieceCollectionViewModel pieceCollectionViewModel)
	{
		InitializeComponent();
		Cabinet = cabinet;
		this._pieceCollectionViewModel = pieceCollectionViewModel;
        BindingContext = this;
	}

    private void createObjectForCabinetPieces()
    {
        _pieceFromCabinets = new PieceFromCabinets(cabinetSymbol: Cabinet.Symbol);
        _pieceCollectionViewModel.PieceFromCabinets.Add(_pieceFromCabinets);
    }

	private void addPieceToList()
	{
        Cabinet.Pieces.ForEach(cabinetPieceBehavior =>
        {
            //_pieceCollectionViewModel.Pieces.Add(cabinetPieceBehavior.cabinetPiece.Piece);
            _pieceFromCabinets.CabinetPiece.Add(cabinetPieceBehavior);
        });
    }

	private void resizeCabinet()
	{
        CabinetResizer resizer = new CabinetResizer(Cabinet);
        resizer.ResizeCabinet(
            new CabinetSize<float>(
                width: float.Parse(width.Text),
                height: float.Parse(height.Text),
                depth: float.Parse(depth.Text))
            );
    }

	public async void OnAddClicked(object sender, EventArgs e)
	{
        createObjectForCabinetPieces();
        resizeCabinet();
        addPieceToList();
        Navigation.PopAsync();
    }
}