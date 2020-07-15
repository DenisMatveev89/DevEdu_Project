using DevEdu_project.Brush;
using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;

namespace DevEdu_project
{
    public abstract class AFigure
    {
        //_startPoint, _endPoint, _colorLine:
        //обязательные поля для каждого класса, который унаследует IFigure

        protected IGetPoints getPoints;
        protected IBrush fill;

        public Point _startPoint;
        public Point _endPoint;
        public Color _colorLine;
        public Color _fillColor; //
      
        
        
        

        //virtual позволяет менять реализацию метода в классах-наследниках
        public virtual List<Point> GetPoints()
        {
            return getPoints.GetPoints(_startPoint, _endPoint);
        }

        public abstract bool isMouseOnFigure(Point mouse);

        public virtual void Fill(Point mouse,  Color fillColor)
        {
            _fillColor = fillColor;
            fill.Fill(mouse, fillColor);
        }
        
    }
}
