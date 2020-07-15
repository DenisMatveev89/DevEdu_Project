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
    public class Pencil : AFigure //Карандаш
    {
        public Pencil()
        {
            
        }

        List<Point> linePoints = new List<Point>();

        Point start = new Point(0, 0);
        Point end = new Point(0, 0);

        public override List<Point> GetPoints()
        {
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
            }

            return linePoints;
        }

        public override bool isMouseOnFigure(Point mouse)
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
    }
}
