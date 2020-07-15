using DevEdu_project.Figure;
using DevEdu_project.GetPoints;
using DevEdu_project.LineWidth;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEdu_project
{
    public abstract class AFigure
    {
        //_startPoint, _endPoint, _colorLine:
        //обязательные поля для каждого класса, который унаследует IFigure

        protected Brush.IBrush fill;

        public Point _startPoint;
        public Point _endPoint;
        public Color _colorLine;
        public double _brushWidth;

        public abstract List<Point> GetPoints();
        public abstract bool isMouseOnFigure(Point mouse);
        
        //public virtual List<Point> TestLineWidthGetPoints()
        //{
        //    List<Point> figurePoints;
        //    ChangeLine sl = new ChangeLine();

        //    if (_brushWidth > 0)
        //    {
        //        figurePoints = sl.GetWidthPoints(_startPoint, _endPoint, _brushWidth);
        //    }
        //    else
        //    {
        //        //figurePoints = getPoints.GetPoints(_startPoint, _endPoint);
        //    }
        //    return figurePoints;
        //}


        
    }
}
