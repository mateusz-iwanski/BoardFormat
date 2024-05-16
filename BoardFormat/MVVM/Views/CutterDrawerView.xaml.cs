using BoardFormat.CutterReader;
using BoardFormat.MVVM.Models;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using TonCut;
using BoardFormat.CutterDrawer;
using Microsoft.Maui.Controls.Compatibility;


namespace BoardFormat.MVVM.Views;

public partial class CutterDrawerView : ContentView
{
    private CutterReader.CutterReader cutterReader;
    private List<DrawableShapeObjects> BoardWithPiecesObjects;
    private List<List<PieceToDraw>> PieceToDrawListCollections;
    private float leftRightMargin = 10.0f;
    private float topMargin = 10.0f;
    private float betweenBoardMargin = 10.0f;
    private double layoutHeight = 10.0f;


    public static readonly BindableProperty OptimizeDataOutputProperty = BindableProperty.Create(
        nameof(OptimizeDataOutput)
        , typeof(DataOutputs), typeof(CutterDrawerView), defaultBindingMode: BindingMode.TwoWay
    );
    public static readonly BindableProperty OptimizeDataInputProperty = BindableProperty.Create(
        nameof(OptimizeDataInput)
        , typeof(DataInput), typeof(CutterDrawerView), defaultBindingMode: BindingMode.TwoWay
    );
    public static readonly BindableProperty LayoutHeightProperty = BindableProperty.Create(
        nameof(layoutHeight)
        , typeof(double), typeof(CutterDrawerView), defaultBindingMode: BindingMode.TwoWay
    );
    public static readonly BindableProperty LeftRightMarginProperty = BindableProperty.Create(
        nameof(leftRightMargin)
        , typeof(float), typeof(CutterDrawerView), defaultBindingMode: BindingMode.TwoWay
    );
    public static readonly BindableProperty TopMarginProperty = BindableProperty.Create(
        nameof(topMargin)
        ,typeof(float), typeof(CutterDrawerView), defaultBindingMode: BindingMode.TwoWay
    );
    public static readonly BindableProperty BetweenBoardMarginProperty = BindableProperty.Create(
       nameof(betweenBoardMargin)
        ,typeof(float), typeof(CutterDrawerView), defaultBindingMode: BindingMode.TwoWay
    );


    public float LeftRightMargin
    {
        get => (float)GetValue(LeftRightMarginProperty);
        set => SetValue(LeftRightMarginProperty, value);
    }

    public float TopMargin
    {
        get => (float)GetValue(TopMarginProperty);
        set => SetValue(TopMarginProperty, value);
    }
   
    public float BetweenBoardMargin
    {
        get => (float)GetValue(BetweenBoardMarginProperty);
        set => SetValue(BetweenBoardMarginProperty, value);
    }

    public double LayoutHeight { 
        get => (double)GetValue(LayoutHeightProperty); 
        set => SetValue(LayoutHeightProperty, value);
    }

    public DataInput OptimizeDataInput
    {
        get => (DataInput)GetValue(OptimizeDataInputProperty);
        set => SetValue(OptimizeDataInputProperty, value);
    }
    
    public DataOutputs OptimizeDataOutput
    {
        get => (DataOutputs)GetValue(OptimizeDataOutputProperty);
        set => SetValue(OptimizeDataOutputProperty, value);
    }

    public CutterDrawerView()                
    {
        InitializeComponent();
        BindingContext = this;

        BoardWithPiecesObjects = new List<DrawableShapeObjects>();

        PieceToDrawListCollections = new List<List<PieceToDraw>>();

        GraphicsVerticalStackLayout.SizeChanged += (s, e) => 
            new GraphicsViewCreator(
                shapeObjects: BoardWithPiecesObjects,
                graphicsLayout: GraphicsVerticalStackLayout
                ).Draw(
                    scaleToWidth: (float)GraphicsVerticalStackLayout.Width,
                    leftRightMargin: LeftRightMargin,
                    topMargin: BetweenBoardMargin
                    );
    }

    /// <summary>
    /// Create list of Shapes to draw. 
    /// List<DrawableShapeObjects> board with pieceCollection drawable for GraphicsView.
    /// It's a first function you have to use before create graphics.
    /// </summary>
    public void Draw()
    {
        // data from cutter engine and input data from user
        cutterReader = new CutterReader.CutterReader(
            dataInput: OptimizeDataInput, dataOutputs: OptimizeDataOutput);

        // We have to reset the data to avoid duplicate drawing
        PieceToDrawListCollections.Clear();
        BoardWithPiecesObjects.Clear();

        // Add board and pieces to list for draw        
        OptimizeDataOutput.cuttings.ForEach(cutting =>
        {
            List<IPieceToDraw> PieceToDrawList = new List<IPieceToDraw>();
            // read data from input Stock for board
            var stockInputData = new CutterStockReader(cutterReader).
                GetStock(cutting.stockItemId);

            // build shape board to draw
            PieceToDrawList.Add(new BoardPieceToDraw(stockInputData).Board);

            // buid shape pieces for board to draw
            cutting.pieces.ForEach(piece =>
            {
                var pieceInputData = new CutterPieceReader(cutterReader).
                    GetPieceInput(piece.pieceId);

                PieceToDrawList.Add(new FormPieceToDraw(
                    pieceInputData: pieceInputData,
                    piece: piece,
                    stock: stockInputData
                    ).Form);
            });

            // build shape rest/waste pieces to list for draw
            cutting.rest.ForEach(rest =>
            {
                PieceToDrawList.Add(new WastePiece(rest: rest, stock: stockInputData).Waste);
            });

            // Add board with pieceCollection to draw to collection
            
            var graphicsView = new GraphicsView();
            var graphicsViewSetup = new RectangleGraphicsViewSetup(graphicsView);
            graphicsViewSetup.RectangleSelected += (s, e) =>
            {
                Debug.WriteLine("Rectangle selected");
                Debug.WriteLine("Rectangle selected " 
                    + e.Rectangle.Piece.Identifier 
                    + " -- " + e.Rectangle.Piece.Id);
            };

            BoardWithPiecesObjects.Add(
                new DrawableShapeObjects()
                {
                    GraphicsView = graphicsView,
                    ShapeWithPieceCollection = PieceToDrawList,
                    graphicsViewSetup = graphicsViewSetup
                }); ;

        });

        // Create GraphicsView and draw shapes
        new GraphicsViewCreator(
                shapeObjects: BoardWithPiecesObjects,
                graphicsLayout: GraphicsVerticalStackLayout
                ).Draw(
                    scaleToWidth: (float)GraphicsVerticalStackLayout.Width,
                    leftRightMargin: LeftRightMargin,
                    topMargin: BetweenBoardMargin
                    );

        // Clear Data to avoid duplicate drawing
        OptimizeDataInput = null;
        OptimizeDataOutput = null;
    }

}