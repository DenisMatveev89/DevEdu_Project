using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DevEdu_project.Figure;
using DevEdu_project.Factory;
using DevEdu_project.GetPoints;

namespace DevEdu_project
{
    public class Rectangle : AFigure // Прямоугольник
    {        
        public Rectangle()
        {
            getPoints = new RectanglePoints();
        }        

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            this._startPoint.X = x1;
            this._startPoint.Y = y1;
            this._endPoint.X = x2;
            this._endPoint.Y = y2;
        }

        
    }
}
