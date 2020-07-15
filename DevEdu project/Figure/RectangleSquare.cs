﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DevEdu_project.Figure;
using DevEdu_project.GetPoints;

namespace DevEdu_project
{
    public class RectangleSquare : AFigure //Квадрат
    {
        public RectangleSquare()
        {
        }

        public override List<Point> GetPoints()
        {
            ConnectPoints cp = new ConnectPoints();

            Point oneP = _startPoint;
            Point twoP = _startPoint;
            Point threP = _startPoint;
            Point fourP = _startPoint;
            int d;
            List<Point> listPoint = new List<Point>();
            if (_startPoint.X < _endPoint.X && _startPoint.Y < _endPoint.Y)
            {
                d = _endPoint.Y - _startPoint.Y;
                twoP.X = _startPoint.X + d;
                twoP.Y = _startPoint.Y;

                threP.X = twoP.X;
                threP.Y = threP.Y + d;

                fourP.X = threP.X - d;
                fourP.Y = threP.Y;
            }
            if (_startPoint.X > _endPoint.X && _startPoint.Y > _endPoint.Y)
            {
                d = _startPoint.X - _endPoint.X;
                twoP.X = _startPoint.X - d;
                twoP.Y = _startPoint.Y;

                threP.X = twoP.X;
                threP.Y = threP.Y - d;

                fourP.X = threP.X + d;
                fourP.Y = threP.Y;
            }
            if (_startPoint.X > _endPoint.X && _startPoint.Y < _endPoint.Y)
            {
                d = _startPoint.X - _endPoint.X;
                twoP.X = _startPoint.X;
                twoP.Y = _startPoint.Y + d;

                threP.X = twoP.X - d;
                threP.Y = twoP.Y;

                fourP.X = threP.X;
                fourP.Y = threP.Y - d;
            }
            if (_startPoint.X < _endPoint.X && _startPoint.Y > _endPoint.Y)
            {
                d = _endPoint.X - _startPoint.X;
                twoP.X = _startPoint.X + d;
                twoP.Y = _startPoint.Y;

                threP.X = twoP.X;
                threP.Y = threP.Y - d;

                fourP.X = threP.X - d;
                fourP.Y = threP.Y;
            }
            listPoint.AddRange(cp.ConnectTwoPoints(new Point(_startPoint.X, _startPoint.Y), new Point(twoP.X, twoP.Y)));
            listPoint.AddRange(cp.ConnectTwoPoints(new Point(twoP.X, twoP.Y), new Point(threP.X, threP.Y)));
            listPoint.AddRange(cp.ConnectTwoPoints(new Point(threP.X, threP.Y), new Point(fourP.X, fourP.Y)));
            listPoint.AddRange(cp.ConnectTwoPoints(new Point(fourP.X, fourP.Y), new Point(_startPoint.X, _startPoint.Y)));
            return listPoint;
        }

        public override bool IsMouseOnFigure(Point mouse)
        {
            bool check = false;
            Point node1 = _startPoint, node2 = _endPoint;
            if (node1.X <= mouse.X && node1.Y <= mouse.Y && node2.X >= mouse.X && node2.Y >= mouse.Y)
                return check = true;
            else
                return check;
        }
    }
}
