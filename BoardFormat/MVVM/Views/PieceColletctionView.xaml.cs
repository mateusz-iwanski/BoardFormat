namespace BoardFormat.MVVM.Views;

using System.Collections.ObjectModel;
using BoardFormat.MVVM.Models;
using WebSocket4Net.Common;
using System.Windows.Input;
using System.Diagnostics;

using BoardFormat.MVVM.ViewsModels;
using System.Collections;

public partial class PieceCollectionView : ContentView
{
    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
        nameof(ItemsSource), typeof(IEnumerable), typeof(PieceCollectionView), defaultBindingMode: BindingMode.TwoWay
        );
    public static readonly BindableProperty PiceLengthProperty = BindableProperty.Create(
        nameof(PiceLength), typeof(float), typeof(PieceCollectionView), defaultBindingMode: BindingMode.TwoWay 
        );
    public static readonly BindableProperty PiceWidthProperty = BindableProperty.Create(
        nameof(PiceWidth), typeof(float), typeof(PieceCollectionView), defaultBindingMode: BindingMode.TwoWay
        );
    public static readonly BindableProperty PiceStructureProperty = BindableProperty.Create(
        nameof(PiceStructure), typeof(bool), typeof(PieceCollectionView), defaultBindingMode: BindingMode.TwoWay
        );


    public IEnumerable ItemsSource
    {
        get => (IEnumerable)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public float PiceLength 
    { 
        get => (float)GetValue(PiceLengthProperty); 
        set => SetValue(PiceLengthProperty, value); 
    }

    public float PiceWidth 
    { 
        get => (float)GetValue(PiceWidthProperty); 
        set => SetValue(PiceWidthProperty, value); 
    }

    public bool PiceStructure
    {
        get => (bool)GetValue(PiceStructureProperty);
        set => SetValue(PiceStructureProperty, value);
    }

    public PieceCollectionView()
	{
		InitializeComponent();
        PiceStructure = false;
	}
}