using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu_project.ToolBox
{
    public abstract class ITool
    {
        public BitmapSingletone sBitmap = BitmapSingletone.GetInstance();

        public abstract void DoLogigOnMouseDown();
        public abstract void DoLogicOnMouseMove(Point preLocation, Point location, AFigure figure);
        public abstract void DoLogicOnMouseUp(AFigure figure);
        public abstract void DoLogicOnMouseClick(Point location, AFigure figure, Color color);

    }
}
