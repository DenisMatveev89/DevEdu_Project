using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu_project.ToolBox
{
    public class EraserTool : ITool
    {       

        public override void DoLogicOnMouseClick(Point location, AFigure figure, Color color)
        {
            sBitmap.Clear();
            sBitmap.EraseIndexFigure(figure);
            sBitmap.Copy();
            sBitmap.FillAllFigures();
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
