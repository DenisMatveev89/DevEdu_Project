﻿using DevEdu_project.Brush;
using DevEdu_project.GetPoints;
using DevEdu_project.LineW;
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
            start = new Point(0, 0);
            end = new Point(0, 0);
            linePoints = new List<Point>();
        }
        BitmapSingletone sBitmap = BitmapSingletone.GetInstance();
        
        List<Point> linePoints;
        Point start;
        Point end;

        public override List<Point> GetPoints()
        {
            //Этим условием мы правильно задаем начальную точку и все последующие точки карандаша
            if (start == new Point(0, 0))
            {
                start = _startPoint;                
            }
            else
            {
                start = end;
            }
            end = _endPoint;

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

        public override void WidthLine()
        {
                if (start == new Point(0, 0))
                {
                    start = _startPoint;
                }
                else
                {
                    start = end;
                }

                end = _endPoint;

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
                    for (int j = -_linewWidth; j <= _linewWidth; j++)
                    {
                        double d = Math.Sqrt(_linewWidth * _linewWidth - j * j);
                        Point tmp = new Point((int)(j + X), (int)(_linewWidth + Y));
                        sBitmap.SetPixel(tmp.X, tmp.Y, _colorLine);
                        linePoints.Add(new Point(tmp.X, tmp.Y));
                        tmp = new Point((int)(j + X), (int)(-_linewWidth + Y));
                        sBitmap.SetPixel(tmp.X, tmp.Y, _colorLine);
                        linePoints.Add(new Point(tmp.X, tmp.Y));
                        tmp = new Point((int)(_linewWidth + X), (int)(j + Y));
                        sBitmap.SetPixel(tmp.X, tmp.Y, _colorLine);
                        linePoints.Add(new Point(tmp.X, tmp.Y));
                        tmp = new Point((int)(-_linewWidth + X), (int)(_linewWidth + Y));
                        sBitmap.SetPixel(tmp.X, tmp.Y, _colorLine);
                        linePoints.Add(new Point(tmp.X, tmp.Y));
                        tmp = new Point((int)(j + X), (int)(j + Y));
                        sBitmap.SetPixel(tmp.X, tmp.Y, _colorLine);
                        linePoints.Add(new Point(tmp.X, tmp.Y));
                        tmp = new Point((int)(j + X), (int)(-_linewWidth + Y));
                        sBitmap.SetPixel(tmp.X, tmp.Y, _colorLine);
                        linePoints.Add(new Point(tmp.X, tmp.Y));
                        tmp = new Point((int)(_linewWidth + X), (int)(j + Y));
                        sBitmap.SetPixel(tmp.X, tmp.Y, _colorLine);
                        linePoints.Add(new Point(tmp.X, tmp.Y));
                        tmp = new Point((int)(-_linewWidth + X), (int)(j + Y));
                        sBitmap.SetPixel(tmp.X, tmp.Y, _colorLine);
                        linePoints.Add(new Point(tmp.X, tmp.Y));
                    }
                    X += Xinc;
                    Y += Yinc;
                }
                sBitmap.Update();
        }

        public override bool IsMouseOnFigure(Point mouse)
        {
            bool check = false;
            //List<Point> pencil = GetPoints();
            foreach (Point i in linePoints)
            {
                if (i == mouse)
                    return check = true;
            }

            return check;
        }

        public override void FillFigure(Point mouse)
        {
            _fill = new EmptyFill();
        }

        public override void Rotate()
        {
            throw new NotImplementedException();
        }

        public override AFigure Move(Point start, Point end, AFigure movingFigure)
        {
            return movingFigure;
        }
    }
}
