using DevEdu_project.GetPoints;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu_project.Figure
{
<<<<<<< HEAD
    public class Pencil : AFigure //Перо
    {
        public Pencil(Point a, Point b)
        {
            getPoints = new PencilPoints(a,b);
            fill = new Brush.EmptyFill();
        }

        /*   public override List<Point> GetPoints()
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
                   linePoints.Add(new Point((int)X, (int)Y));
                   X += Xinc;
                   Y += Yinc;
               }

               return linePoints;
           }*/
=======
    public class Pencil : AFigure //Карандаш
    {
        //В эти конструкторы нужно передавать значения точек из MouseDown, MouswMove, MouseUp
        public Point _startPoint = new Point(0, 0);
        public Point _endPoint = new Point(0, 0);

        //public Point _startPoint;
        //public Point _endPoint;

        List<Point> _linePoints = new List<Point>();
        
        public void Update()
        {
            _startPoint = new Point(0, 0);
            _linePoints = new List<Point>();
        }
        public void Update(Point Start, Point End)
        {
            if(_startPoint == new Point(0, 0))
            {
                _startPoint = Start;
            }
            else 
            {
                _startPoint = _endPoint;
            }
                 
            _endPoint = End;            
        }       

        public new List<Point> GetPoints()
        {
            int dx = _endPoint.X - _startPoint.X;
            int dy = _endPoint.Y - _startPoint.Y;
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
            if (_startPoint == new Point(0, 0))
            {
                X = _endPoint.X;
                Y = _endPoint.Y;
            }
            else 
            {
                X = _startPoint.X;
                Y = _startPoint.Y;
            }
            for (int i = 0; i <= steps; i++)
            {
                //Добавляем в лист каждую точку, полученную в ходе вычислений
                _linePoints.Add(new Point((int)X, (int)Y));
                X += Xinc;
                Y += Yinc;
            }
            
            return _linePoints;
        }
>>>>>>> Factory
    }
}
