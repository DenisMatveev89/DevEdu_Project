using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEdu_project
{
    public abstract class AFigure
    {
        //_startPoint, _endPoint, _colorLine:
        //обязательные поля для каждого класса, который унаследует IFigure

        protected IGetPoints getPoints;
        protected Brush.IBrush fill;

        public Point _startPoint;
        public Point _endPoint;
        public Color _colorLine;

        //virtual позволяет менять реализацию метода в классах-наследниках
        public virtual List<Point> GetPoints()
        {
            return getPoints.GetPoints(_startPoint, _endPoint);
        }
    }
}
