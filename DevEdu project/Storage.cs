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
        //List<Point> figuresList = new List<Point>();
        public List<AFigure> figureList = new List<AFigure>();

        public List<AFigure> saveFigures(AFigure figure)
        {
            figureList.Add(figure);
            return figureList;
        }

        //public void 

        //public List<Point> saveFigure(List<Point> figure)
        //{
        //    figuresList.AddRange(figure);
        //    return figuresList;
        //}

        //public List<Point> saveFigure(AFigure figure)
        //{
        //    figuresList.Add(figure._startPoint);
        //    figuresList.Add(figure._endPoint);
        //    return figuresList;
        //}
    }
}
