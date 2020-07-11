using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Factory
{
    public class SquareFactory : AFactory
    {
        public SquareFactory()
        {
            figure = new RectangleSquare();
        }

        //public AFigure Create(Point start, Point end)
        //{
        //    RectangleSquar square = new RectangleSquar();
        //    square._startPoint = start;
        //    square._endPoint = end;
        //    return square;
        //}
    }
}
