using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace DevEdu_project.Figure
{
    public class StraightLine: IFigure
    {
        public StraightLine() { }
        public StraightLine(Point StartPoint, Point EndPoint) { }
        //В эти конструкторы нужно передавать значения точек из MouseDown, MouswMove, MouseUp
        public Point StartPoint;
        public Point EndPoint;

        public List<Point> GetPoints()
        {
            //Создаем новый лист с точками координат
            List<Point> linePoints = new List<Point>();
            //Записываем в этот лист первую точку
            linePoints.Add(StartPoint);

            int dx = EndPoint.X - StartPoint.X;//абсолютное значение
            int dy = EndPoint.Y - StartPoint.Y;
            int steps;
            if (abs(dx) > abs(dy))
            {
                steps = abs(dx); //количество шагов
            }
            else
            {
                steps = abs(dy);
            }

            float Xinc = dx / (float)steps;//приращение для каждого шага 
            float Yinc = dy / (float)steps;

            float X = StartPoint.X;// кладем пиксель для каждого шага 
            float Y = StartPoint.Y;
            for (int i = 0; i <= steps; i++)
            {
                //Добавляем в лист каждую точку, полученную в ходе вычислений
                linePoints.Add(new Point((int)X, (int)Y));
                X += Xinc;
                Y += Yinc;
            }

            return linePoints;
        }

        private int abs(int n)
        {
            if (n > 0)
            {
                return n;
            }
            else
            {
                return n * -1;
            }
        }
    }
}
