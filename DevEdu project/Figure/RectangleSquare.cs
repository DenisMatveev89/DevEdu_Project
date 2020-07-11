using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DevEdu_project.Figure;

namespace DevEdu_project
{
    public class RectangleSquare:AFigure //Квадрат
    {
        BitmapSingletone sBitmap = BitmapSingletone.GetInstance();
        //В эти конструкторы нужно передавать значения точек из MouseDown, MouswMove, MouseUp
        
        public RectangleSquare() { }        

        public RectangleSquare(int x1, int y1, int x2, int y2)
        {
            this._startPoint.X = x1;
            this._startPoint.Y = y1;
            this._endPoint.X = x2;
            this._endPoint.Y = y2;
        }

        public new List<Point> GetPoints()
        {
            #region old version
            //int dy = dx;
            // int d = dx; //длина диагонали

            /*float Xinc = dx / (float)d;//приращение для каждого шага 
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
            }*/
            #endregion
            List<Point> listPoint = new List<Point>();
            int d = _endPoint.X - _startPoint.X;//длина одной стороны, все остальные равны ей
            int X0 = _startPoint.X;
            int Y0 = _startPoint.Y;
            int X1 = _endPoint.X;
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y0), new Point(X1, Y0)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y0+d), new Point(X1, Y0+d)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y0), new Point(X0, Y0+d)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X0+d, Y0), new Point(X0+d, Y0+d)));
            return listPoint;
        }
    }
}
