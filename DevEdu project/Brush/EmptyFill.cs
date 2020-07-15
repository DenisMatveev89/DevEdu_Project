using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Color = System.Drawing.Color;

namespace DevEdu_project.Brush
{
    public class EmptyFill : IBrush
    {
        public void Fill(Point point, AFigure figure, Color colorLine, Color colorFill)
        {

        }
    }
}
