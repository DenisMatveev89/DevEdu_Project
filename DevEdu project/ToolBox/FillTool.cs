using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu_project.ToolBox
{
    public class FillTool : ITool
    {        

        public override void DoLogicOnMouseClick(Point location, AFigure figure, Color color)
        {
            
            sBitmap.Copy();
            //sBitmap.DrawExceptIndexFigures(figure);
            //sBitmap.FillExceptIndexFigures(_currentFigure);
            figure._fillColor = color;
            figure.FillFigure(location);
            sBitmap.CopyFromFill();
        }

        public override void DoLogicOnMouseMove(Point preLocation, Point location, AFigure figure)
        {
            
        }

        public override void DoLogicOnMouseUp(AFigure figure)
        {
            
        }

        public override void DoLogigOnMouseDown(AFigure figure)
        {
            
        }
    }
}
