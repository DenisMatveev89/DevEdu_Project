using DevEdu_project.Brush;
using DevEdu_project.GetPoints;
using DevEdu_project.LineW;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEdu_project
{
    [Serializable]
    public abstract class AFigure
    {
        //_startPoint, _endPoint, _colorLine:
        //обязательные поля для каждого класса, который унаследует IFigure

        public Point _startPoint;
        public Point _endPoint;
        public Point _centerPoint;
        public Color _colorLine;
        public Color _fillColor;
        protected IBrush fill;
        public double _brushWidth;
        public int _lineWidth;
        

        public abstract List<Point> GetPoints();
        public abstract bool IsMouseOnFigure(Point mouse);
 /*       public virtual List<Point> WidthLine(Point start, Point end, int _lineWidth)
        {
            ILineWidth lineWidth = new LineWidth();
            return lineWidth.LWidth(start, end, _lineWidth);
        }*/
        public virtual void FillFigure(Point mouse)
        {

            if(_fillColor.IsNamedColor || _fillColor != Color.Transparent)
            {
                fill = new FullFill();
                fill.Fill(mouse, _fillColor);
            }
            else
            {
                fill = new EmptyFill();
            }            
        }
    }
}
