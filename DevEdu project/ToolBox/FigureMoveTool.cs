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
            sBitmap.vDrawFigure(figure);
        }
        

        public override void DoLogicOnMouseMove(Point preLocation, Point location, AFigure figure)
        {
            sBitmap.Copy();
            figure.Move(preLocation, location, figure);
            sBitmap.vDrawFigure(figure);
        }

        public override void DoLogicOnMouseUp(AFigure figure)
        {
            sBitmap.Copy();          
            sBitmap.FillFigure(figure);
            sBitmap.CopyFromFill();
            figure._movingPoint = new Point(0, 0);
            figure._nextMovingPoint = new Point(0, 0);
        }

        public override void DoLogigOnMouseDown(AFigure figure)
        {
            sBitmap.Clear();
            sBitmap.DrawExceptIndexFigures(figure);
            if (sBitmap._figureList.Count > 1)
            {                
                sBitmap.Copy();
                sBitmap.FillExceptIndexFigures(figure);
                sBitmap.CopyFromFill();
            }           

        }
    }
}
