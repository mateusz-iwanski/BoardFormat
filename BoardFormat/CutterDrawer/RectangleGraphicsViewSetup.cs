using BoardFormat.FurnitureLibrary;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    public class RectangleGraphicsViewSetup : IGraphicsViewSetup
    {
        RectangleBuilder _shapeBuilder;
        GraphicsView _graphicsView;
        Rectangle _rectangle;        
        bool _startInteraction;

        public event EventHandler<RectangleGraphicsViewSetupEventArgs> RectangleSelected;

        public RectangleGraphicsViewSetup(GraphicsView graphicsView)
        {
            // we don't want to add to start and end interaction multiple times
            _startInteraction = false;
            _graphicsView = graphicsView;
            return;
        }

        public void Setup(RectangleBuilder shapeBuilder)
        {
            _shapeBuilder = shapeBuilder;

            // add to GraphicsView event handlers just once
            if (!_startInteraction)
            {                
                _graphicsView.StartInteraction += OnStartInteraction;
                _graphicsView.EndInteraction += OnEndInteraction;
                _startInteraction = true;
            }
        }

        void OnStartInteraction(object Sender, TouchEventArgs evt)
        {
            PointF p = evt.Touches.FirstOrDefault();
            Trace.WriteLine($"Touch/click at X - {p.X} Y- {p.Y}");
            var a = _shapeBuilder.GetShapes().Cast<Rectangle>().ToList();//.FirstOrDefault(
            foreach (var item in a)
            {
                if (item.Piece.Type != DrawerType.Board)
                {
                    if (item.CheckDrawerPosition(p.X, p.Y))
                    {
                        Trace.WriteLine($"Point position X {p.X} Y {p.Y}");
                        Trace.WriteLine($"StartX {item.StartX} StartX + Width {item.StartX + item.Width} StartY {item.StartY} StartY + Height {item.StartY + item.Height}");
                        Trace.WriteLine($"Piece found at X - {item.StartX} Y - {item.StartY} with identifier {item.Piece.Identifier} ");
                        _rectangle = item;
                        RectangleSelected?.Invoke(this, new RectangleGraphicsViewSetupEventArgs(_rectangle));
                    }
                }
            }
        }

        void OnEndInteraction(object Sender, TouchEventArgs evt)
        {
            Trace.WriteLine("########### Released/click");
        }



    }
}
