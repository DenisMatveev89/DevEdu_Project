﻿using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project
{
    [Serializable]
    public class Circle : AFigure
    {
        public Circle()
        {
            
        }

        public Circle(Point centre, double radius)
        {
            _centerPoint = centre;
            R = radius;
        }

        public double R;

        public override List<Point> GetPoints()
        {
            List<Point> circle = new List<Point>();
            int X0 = _centerPoint.X;
            int Y0 = _centerPoint.Y;
            int x = 0;
            int y = (int)R;
            int delta = 1 - 2 * (int)R;
            int error;
            while (y >= 0)
            {
                circle.Add(new Point(X0 + x, Y0 + y));
                circle.Add(new Point(X0 + x, Y0 - y));
                circle.Add(new Point(X0 - x, Y0 + y));
                circle.Add(new Point(X0 - x, Y0 - y));

                error = 2 * (delta + y) - 1;
                if ((delta < 0) && (error <= 0))
                {
                    delta += 2 * ++x + 1;
                    continue;
                }
                if ((delta > 0) && (error > 0))
                {
                    delta -= 2 * --y + 1;
                    continue;
                }
                delta += 2 * (++x - --y);
            }
            return circle;
        }

        public override bool IsMouseOnFigure(Point mouse)
        {
            bool check = false;

            if (Math.Pow((mouse.X - _startPoint.X), 2) + Math.Pow((mouse.Y - _startPoint.Y), 2) <= R * R)
            {
                check = true;
            }
            return check;
        }   
    }
}
