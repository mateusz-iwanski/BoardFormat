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

        public RectangleGraphicsViewSetup()
        {
            return;
        }

        public void Setup(RectangleBuilder shapeBuilder, GraphicsView graphicsView)
        {
            _shapeBuilder = shapeBuilder;
            _graphicsView = graphicsView;
            _graphicsView.StartInteraction += OnStartInteraction;
            _graphicsView.EndInteraction += OnEndInteraction;
            //return new GraphicsView();
        }

        void OnStartInteraction(object Sender, TouchEventArgs evt)
        {
            PointF p = evt.Touches.FirstOrDefault();
            Trace.WriteLine($"Touch/click at X - {p.X} Y- {p.Y}");
            var a = _shapeBuilder.GetShapes().Cast<Rectangle>().ToList();//.FirstOrDefault(
            foreach (var item in a)
            {
                if (item.CheckDrawerPosition(p.X, p.Y))
                {
                    Trace.WriteLine($"Piece found at X - {item.StartX} Y - {item.StartY} with identifier {item.Piece.Identifier} ");
                }
            }

        }

        void OnEndInteraction(object Sender, TouchEventArgs evt)
        {
            //PointF p = evt.Touches.FirstOrDefault();
            //Trace.WriteLine($"Released/click at X - {p.X} Y- {p.Y}");
            //var a = _shapeBuilder.GetShapes().Cast<Rectangle>().ToList();//.FirstOrDefault(
            //foreach (var item in a)
            //{
            //    if (item.CheckDrawerPosition(p.X, p.Y))
            //    {
            //        Trace.WriteLine($"Piece found at X - {item.StartX} Y - {item.StartY} with identifier {item.Piece.Identifier} ");
            //    }
            //}
        }


    }
}
