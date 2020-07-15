using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DevEdu_project.Brush
{
    public interface IBrush
    {   
        void Fill(Point point, AFigure figure, Color colorLine, Color colorFill);
    }
}
