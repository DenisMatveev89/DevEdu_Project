using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DevEdu_project.Figure;

namespace DevEdu_project
{
    public class RectangleSquar:IFigure
    {

        //В эти конструкторы нужно передавать значения точек из MouseDown, MouswMove, MouseUp
        public Point StartPoint;
        public Point EndPoint;

        public List<Point> GetPoints()
        {
            List<Point> listPoint = new List<Point>();
            int dx = EndPoint.X - StartPoint.X;//абсолютное значение
            int dy = dx;
            int d = dx; //длина диагонали

            float Xinc = dx / (float)d;//приращение для каждого шага 
            float Yinc = dy / (float)d;

            float X = StartPoint.X;// кладем пиксель для каждого шага 
            float Y = StartPoint.Y;

            for (int i = 0; i <= d; i++)
            {
                listPoint.Add(new Point((int)X+1, (int)Y));
                listPoint.Add(new Point((int)X+1, (int)Y + d));
                X += Xinc;
            }
            for (int j = 0; j <= d; j++)
            {
                listPoint.Add(new Point((int)X, (int)Y));
                listPoint.Add(new Point((int)X - d, (int)Y));
                Y += Yinc;
            }
            return listPoint;
        }
    }
}
