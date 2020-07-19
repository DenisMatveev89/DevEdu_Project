using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.ToolBox
{
    public class FigureMoveTool : ITool
    {
        public override void DoLogicOnMouseClick(Point location, AFigure figure, Color color)
        {
            
        }

        public override void DoLogicOnMouseMove(Point preLocation, Point location, AFigure figure)
        {
            sBitmap.Clear();
            if (sBitmap._figureList.Count > 1)
            {                
                sBitmap.DrawExceptIndexFigures(figure);
                sBitmap.Copy();
                sBitmap.FillExceptIndexFigures(figure);
            }                
            figure.Move(preLocation, location, figure);
            sBitmap.vDrawFigure(figure);
        }

        public override void DoLogicOnMouseUp(AFigure figure)
        {
            sBitmap.Copy();
            sBitmap.FillFigure(figure);
            sBitmap.CopyFromFill();
        }

        public override void DoLogigOnMouseDown(AFigure figure)
        {
            
        }
    }
}
