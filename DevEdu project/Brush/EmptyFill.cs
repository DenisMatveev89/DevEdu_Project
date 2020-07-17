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
    public class EmptyFill : IBrush
    {
        public override void Fill(Point mouse, Color fillColor, Color lineColor)
        {
          
        }
    }
}
