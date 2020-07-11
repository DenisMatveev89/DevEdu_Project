using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Factory
{
    public class SquareFactory : IFactory
    {
        public AFigure Create(Point start, Point end)
        {
            RectangleSquare square = new RectangleSquare();
            square._startPoint = start;
            square._endPoint = end;
            return square;
        }
    }
}
