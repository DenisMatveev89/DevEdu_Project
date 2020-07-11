﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.GetPoints
{
    public class EllipsePoints : IGetPoints
    {
        public List<Point> GetPoints(Point start, Point end, double RX, double RY)
        {
            List<Point> ellipse = new List<Point>();

            //double RX = Math.Sqrt(Math.Pow((end.X - start.X), 2));
            //double RY = Math.Sqrt(Math.Pow((end.Y - start.Y), 2));

            int centerX = start.X;
            int centerY = start.Y;
            int radiusX = (int)RX;
            int radiusY = (int)RY;

            int posX = radiusX;
            int posY = 0;

            int deltaX = 2 * radiusY * radiusY * posX;
            int deltaY = 2 * radiusX * radiusX * posY;
            int err = (radiusX * radiusX) - (radiusY * radiusY * radiusX) + (radiusY * radiusY) / 4;

            while (deltaY < deltaX)
            {
                ellipse.Add(new Point(centerX + posX, centerY + posY));
                ellipse.Add(new Point(centerX + posX, centerY - posY));
                ellipse.Add(new Point(centerX - posX, centerY + posY));
                ellipse.Add(new Point(centerX - posX, centerY - posY));
                posY++;

                if (err < 0)
                {
                    deltaY += 2 * radiusX * radiusX;
                    err += deltaY + radiusX * radiusX;
                }
                else
                {
                    posX--;
                    deltaY += 2 * radiusX * radiusX;
                    deltaX -= 2 * radiusY * radiusY;
                    err += deltaY - deltaX + radiusX * radiusX;
                }
            }

            err = radiusX * radiusX * (posY * posY + posY)
                + radiusY * radiusY * (posX - 1) * (posX - 1)
                - radiusY * radiusY * radiusX * radiusX;

            while (posX >= 0)
            {
                ellipse.Add(new Point(centerX + posX, centerY + posY));
                ellipse.Add(new Point(centerX + posX, centerY - posY));
                ellipse.Add(new Point(centerX - posX, centerY + posY));
                ellipse.Add(new Point(centerX - posX, centerY - posY));
                posX--;

                if (err > 0)
                {
                    deltaX -= 2 * radiusY * radiusY;
                    err += radiusY * radiusY - deltaX;
                }
                else
                {
                    posY++;
                    deltaY += 2 * radiusX * radiusX;
                    deltaX -= 2 * radiusY * radiusY;
                    err += deltaY - deltaX + radiusY * radiusY;
                }
            }

            return ellipse;
        }
    }
}
