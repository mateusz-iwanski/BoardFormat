using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterDrawer
{
    public class TextFormat
    {
        private Color _fontColor;
        public Color FontColor {
            get => _fontColor; 
            set 
            {
                _fontColor = value.Alpha == 1.0f ?
                    value :
                    throw new Exception("Color has to be without channel alpha, use Color from RGB");
            }
        }
        public float FontSize { get; set; }

        public TextFormat(
            Color fontColor,
            float fontSize
            )
        {
            FontColor = fontColor;
            FontSize = fontSize;
        }

        public void FormatCanvas(ICanvas canvas)
        {
            canvas.FontSize = FontSize;
            canvas.FontColor = FontColor;
        }
    }
}
