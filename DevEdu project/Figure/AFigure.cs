using DevEdu_project.Brush;
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

        public Point _startPoint;
        public Point _endPoint;
        public Color _colorLine;
        public Color _fillColor;
        public double _brushWidth;
        protected IBrush fill;

        public abstract List<Point> GetPoints();
        public abstract bool IsMouseOnFigure(Point mouse);

        public virtual void Fill(Point mouse, Color fillColor)
        {
            _fillColor = fillColor;
            fill.Fill(mouse, fillColor);
        }
        
    }
}
