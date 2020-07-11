using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEdu_project
{
    public abstract class AFigure
    {
        //List<Point> GetPoints();, Update();, void Update(Point Start, Point End); - 
        //обязательные поля для каждого класса, который унаследует IFigure
        //реализация этого метода у каждого наследника будет своя 

        protected IGetPoints getPoints;
        protected Brush.IBrush fill;

        public Point _startPoint;
        public Point _endPoint;

        public Color _colorLine;

        public virtual List<Point> GetPoints()
        {
            return getPoints.GetPoints(_startPoint, _endPoint);
        }
    }
}
