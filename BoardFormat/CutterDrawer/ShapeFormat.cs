using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    /// <summary>
    /// How shape will look on the canvas
    /// </summary>
    public class ShapeFormat
    {
        private Color strokeColor;
        private Color fillColor;
        public Color StrokeColor 
        { 
            get => strokeColor;
            set
            {
                strokeColor = value.Alpha == 1.0f ?
                    value :
                    throw new Exception("Color has to be without channel alpha, use Color from RGB");
            }
        } 
        public Color FillColor
        {
            get => fillColor;
            set
            {
                fillColor = value.Alpha == 1.0f ?
                    value :
                    throw new Exception("Color has to be without channel alpha, use Color from RGB");
            }
        }
        public float StrokeSize { get; set; }

        public ShapeFormat(Color strokeColor, Color fillColor, float strokeSize)
        {
            StrokeColor = strokeColor;
            FillColor = fillColor;
            StrokeSize = strokeSize;
        }

        public void FormatCanvas(ICanvas canvas)
        {
            canvas.StrokeColor = StrokeColor; 
            canvas.FillColor = FillColor;
            canvas.StrokeSize = StrokeSize;
        }
    }
}
