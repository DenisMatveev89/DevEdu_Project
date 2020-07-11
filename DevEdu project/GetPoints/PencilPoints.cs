﻿using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu_project.Figure
{
    public class PencilPoints : IGetPoints //Перо
    {
        //В эти конструкторы нужно передавать значения точек из MouseDown, MouswMove, MouseUp
        public Point StartPoint = new Point(0, 0);
        public Point EndPoint = new Point(0, 0);

        List<Point> points = new List<Point>();
        public void Update()
        {
            StartPoint = new Point(0, 0);
        }
        public void Update(Point Start, Point End)
        {
            if (StartPoint == new Point(0, 0))
            {
                StartPoint = Start;
            }
            else
            {
                StartPoint = EndPoint;
            }

            EndPoint = End;
        }

        public List<Point> GetPoints()
        {
            int dx = EndPoint.X - StartPoint.X;
            int dy = EndPoint.Y - StartPoint.Y;
            int steps;
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                steps = Math.Abs(dx);
            }
            else
            {
                steps = Math.Abs(dy);
            }

            float Xinc = dx / (float)steps;
            float Yinc = dy / (float)steps;

            float X;
            float Y;
            if (StartPoint == new Point(0, 0))
            {
                X = EndPoint.X;
                Y = EndPoint.Y;
            }
            else 
            {
                X = StartPoint.X;
                Y = StartPoint.Y;
            }
            for (int i = 0; i <= steps; i++)
            {
                //Добавляем в лист каждую точку, полученную в ходе вычислений
                points.Add(new Point((int)X, (int)Y));
                X += Xinc;
                Y += Yinc;
            }
            
            return points;
        }
    }
}
