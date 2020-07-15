using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DevEdu_project
{
    public class Storage
    {        
        public List<AFigure> figureList = new List<AFigure>();

        public void figureListCreate()
        {
            figureList = new List<AFigure>();
        }

        public List<AFigure> saveFigures(AFigure figure)
        {
            figureList.Add(figure);
            return figureList;
        }

        public AFigure figureUnderMouse(Point mouse)
        {
            AFigure figure = null;
            foreach(AFigure i in figureList)
            {
                if (i.isMouseOnFigure(mouse))
                {
                    figure = i;
                }
            }
            return figure;
        }
    }
}
