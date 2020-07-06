using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project
{
    public class Triangle
    {
        Line line = new Line();

       
        public void IsoscelesTriangle(int x0, int y0, int x1, int y1, Color currentColor)
        {

            line.DrawLine(x0, y0, x1, y1, currentColor);
            line.DrawLine(x1, y1, (x0 - (x1 - x0)), y1, currentColor);
            line.DrawLine((x0 - (x1 - x0)), y1, x0, y0, currentColor);

        }
        public void RightTriangle(int x0, int y0, int x1, int y1, Color currentColor)
        {

            line.DrawLine(x0, y0, x1, y1, currentColor);
            line.DrawLine(x1, y1, x0, y1, currentColor);
            line.DrawLine(x0, y1, x0, y0, currentColor);
        }
        public void EquilateralTriangle(int x0, int y0, int x1, int y1, Color currentColor)
        {
            line.DrawLine(x0, y0, x1, y1, currentColor); //рисуем первую грань треугольника
            double angleRadian = 60 * Math.PI / 180;

            //Находим вторую пару координат линии, которую мы разворачиваем на 60 градусов.
            int x2 = (int)((x0 - x1) * Math.Cos(angleRadian) - (y0 - y1) * Math.Sin(angleRadian) + x1);
            int y2 = (int)((x0 - x1) * Math.Sin(angleRadian) + (y0 - y1) * Math.Cos(angleRadian) + y1);
            //Рисуем линию развернутую на 60 градусов
            line.DrawLine(x1, y1, x2, y2, currentColor);
            line.DrawLine(x2, y2, x0, y0, currentColor);
        }
    }
}
