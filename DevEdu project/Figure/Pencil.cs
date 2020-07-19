using DevEdu_project.Brush;
using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu_project.Figure
{
    [Serializable]
    public class Pencil : AFigure //Карандаш
    {
        public Pencil()
        {

        }

        List<Point> linePoints = new List<Point>();

        Point start = new Point(0, 0);
        Point end = new Point(0, 0);
        //int width = _width;
        public override List<Point> GetPoints()
        {
            /*//Этим условием мы правильно задаем начальную точку и все последующие точки карандаша
            if (start == new Point(0, 0))
            {
                start = _startPoint;
                end = _endPoint;
            }
            else
            {
                start = end;
                end = _endPoint;
            }

            int dx = end.X - start.X;//абсолютное значение
            int dy = end.Y - start.Y;
            int steps;
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                steps = Math.Abs(dx); //количество шагов
            }
            else
            {
                steps = Math.Abs(dy);
            }

            float Xinc = dx / (float)steps;//приращение для каждого шага 
            float Yinc = dy / (float)steps;

            float X = start.X;// кладем пиксель для каждого шага 
            float Y = start.Y;
            for (int i = 0; i <= steps; i++)
            {
                //Добавляем в лист каждую точку, полученную в ходе вычислений
                linePoints.Add(new Point((int)X, (int)Y));
                X += Xinc;
                Y += Yinc;
            }*/
            //Этим условием мы правильно задаем начальную точку и все последующие точки карандаша
            if (start == new Point(0, 0))
            {
                start = _startPoint;
                end = _endPoint;
            }
            else
            {
                start = end;
                end = _endPoint;
            }
            int dx = end.X - start.X;//абсолютное значение
            int dy = end.Y - start.Y;
            Point Delta = new Point(dx, dy);
            int steps;
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                steps = Math.Abs(dx); //количество шагов
            }
            else
            {
                steps = Math.Abs(dy);
            }

            float Xinc = dx / (float)steps;//приращение для каждого шага 
            float Yinc = dy / (float)steps;

            float X = start.X;// кладем пиксель для каждого шага 
            float Y = start.Y;
            for (int i = 0; i <= steps; i++)
            {
                for (int j = -_width; j <= _width; j++)
                {
                    double d = Math.Sqrt(_width * _width - j * j);
                    Point tmp = new Point((int)(j + X), (int)(_width + Y));
                    linePoints.Add(new Point(tmp.X, tmp.Y));
                    tmp = new Point((int)(j + X), (int)(-_width + Y));
                    linePoints.Add(new Point(tmp.X, tmp.Y));
                    tmp = new Point((int)(_width + X), (int)(j + Y));
                    linePoints.Add(new Point(tmp.X, tmp.Y));
                    tmp = new Point((int)(-_width + X), (int)(_width + Y));
                    linePoints.Add(new Point(tmp.X, tmp.Y));
                    tmp = new Point((int)(j + X), (int)(j + Y));
                    linePoints.Add(new Point(tmp.X, tmp.Y));
                    tmp = new Point((int)(j + X), (int)(-_width + Y));
                    linePoints.Add(new Point(tmp.X, tmp.Y));
                    tmp = new Point((int)(_width + X), (int)(j + Y));
                    linePoints.Add(new Point(tmp.X, tmp.Y));
                    tmp = new Point((int)(-_width + X), (int)(j + Y));
                    linePoints.Add(new Point(tmp.X, tmp.Y));
                }
                //Добавляем в лист каждую точку, полученную в ходе вычислений
                linePoints.Add(new Point((int)X, (int)Y));
                X += Xinc;
                Y += Yinc;
            }

            return linePoints;
        }

        public override bool IsMouseOnFigure(Point mouse)
        {
            bool check = false;
            List<Point> pencil = GetPoints();
            foreach (Point i in pencil)
            {
                if (i == mouse)
                    check = true;
            }

            return check;
        }

        public override void FillFigure(Point mouse)
        {
            fill = new EmptyFill();
        }
    }
}
