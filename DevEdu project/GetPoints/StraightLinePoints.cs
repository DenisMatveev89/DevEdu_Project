﻿using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace DevEdu_project.Figure
{
    public class StraightLinePoints: IGetPoints //Линия
    {
        BitmapSingletone sBitmap = BitmapSingletone.GetInstance();
        //В эти конструкторы нужно передавать значения точек из MouseDown, MouswMove, MouseUp
        public Point StartPoint;
        public Point EndPoint;
        public StraightLinePoints() { }

        public List<Point> GetPoints()
        {
            return sBitmap.ConnectTwoPoints(StartPoint, EndPoint);
            #region old version
            //Записываем в этот лист первую точку
            /* linePoints.Add(StartPoint);

             int dx = EndPoint.X - StartPoint.X;//абсолютное значение
             int dy = EndPoint.Y - StartPoint.Y;
             int steps;
             if (StaticBitmap.Abs(dx) > StaticBitmap.Abs(dy))
             {
                 steps = StaticBitmap.Abs(dx); //количество шагов
             }
             else
             {
                 steps = StaticBitmap.Abs(dy);
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
 */
            #endregion 
        }
    }
}