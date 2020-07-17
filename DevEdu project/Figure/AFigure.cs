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
        public AFigure figure;
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
                fill.Fill(mouse, _fillColor, _colorLine);
            }
            else
            {
                fill = new EmptyFill();
            }            
        }

        public virtual void Move(Point _startMovingPoint, Point _movingPoint)
        {

        }

        public virtual AFigure Move(Point start, Point end, AFigure movingFigure)
        {
            int X0 = movingFigure._startPoint.X;
            int Y0 = movingFigure._startPoint.Y;
            int X1 = movingFigure._endPoint.X;
            int Y1 = movingFigure._endPoint.Y;            

            if (end.X >= start.X && end.Y >= start.Y)
            {
                int dx = end.X - start.X;
                int dy = end.Y - start.Y;
                X0 += dx;
                Y0 += dy;
                X1 += dx;
                Y1 += dy;
            }
            else if (end.X >= start.X && end.Y <= start.Y)
            {
                int dx = end.X - start.X;
                int dy = start.Y - end.Y;
                X0 += dx;
                Y0 -= dy;
                X1 += dx;
                Y1 -= dy;
            }
            else if (end.X <= start.X && end.Y >= start.Y)
            {
                int dx = start.X - end.X;
                int dy = end.Y - start.Y;
                X0 -= dx;
                Y0 += dy;
                X1 -= dx;
                Y1 += dy;
            }
            else
            {
                int dx = start.X - end.X;
                int dy = start.Y - end.Y;
                X0 -= dx;
                Y0 -= dy;
                X1 -= dx;
                Y1 -= dy;
            }
            movingFigure._startPoint = new Point(X0, Y0);
            movingFigure._endPoint = new Point(X1, Y1);

            return movingFigure;
        }
    }
}
