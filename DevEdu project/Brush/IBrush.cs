using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Color = System.Drawing.Color;

namespace DevEdu_project.Brush
{
    [Serializable]
    public abstract class IBrush
    {
        public Color _fillColor;
        public int _width;
        public Color _colorLine;
        public virtual void Fill(Point mouse, Color fillColor, Color lineColor) { }
    }
}
