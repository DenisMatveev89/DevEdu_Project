using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.LineWidth
{
    public class ChangeLine : ILineWidth
    {
        public List<Point> LWidth(Point strat, Point end)
        {
            List<Point> width = new List<Point>();



            return width;
        }

        public List<Point> GetWidthPoints(Point strat, Point end, double width)
        {
            FillCirclePoint fs = new FillCirclePoint();
            ConnectPoints cp = new ConnectPoints();

            List<Point> widthPoints = new List<Point>();
            Circle cStrat = new Circle(strat, width);
            widthPoints = fs.FillPoint(cStrat);

            Circle cEnd = new Circle(end, width);
            widthPoints.AddRange(fs.FillPoint(cEnd));

            List<Point> centerLine = cp.ConnectTwoPoints(cStrat._startPoint, cEnd._startPoint);
            widthPoints.AddRange(centerLine);

            //Точки кругов
            List<Point> cS = cStrat.GetPoints();
            List<Point> cE = cEnd.GetPoints();

            Point ds = cStrat._startPoint;
            Point de = cEnd._startPoint;
            double delta = Math.Sqrt(Math.Pow((ds.X - de.X), 2) + (ds.Y - de.Y));

            //bool match = false;

            Point c1 = strat;
            Point a1 = cS[0];
            Point b1 = new Point();

            foreach (Point z in cS)
            {
                b1.X = (c1.X * 2) - z.X;
                b1.Y = (c1.Y * 2) - z.Y;

            }



            Point c2 = end;
            Point a2 = cE[0];
            Point b2 = new Point();
            b2.X = (c2.X * 2) - a2.X;
            b2.Y = (c2.Y * 2) - a2.Y;

            List<Point> dcS = cp.ConnectTwoPoints(a1, a2);
            widthPoints.AddRange(dcS);
            List<Point> dcE = cp.ConnectTwoPoints(b1, b2);
            widthPoints.AddRange(dcE);

            foreach (Point j in cS)
            {
                a1 = j;
                b1.X = (c1.X * 2) - a1.X;
                b1.Y = (c1.Y * 2) - a1.Y;
                foreach (Point z in cE)
                {
                    a2 = z;
                    b2.X = (c2.X * 2) - a2.X;
                    b2.Y = (c2.Y * 2) - a2.Y;

                    double d = Math.Sqrt(Math.Pow((a1.X - a2.X), 2) + (a1.Y - a2.Y));
                    double d2 = Math.Sqrt(Math.Pow((b1.X - b2.X), 2) + (b1.Y - b2.Y));

                    //if ((int)delta == (int)d || (int)delta == (int)d2)
                    if (Math.Abs((int)delta) == Math.Abs((int)d))
                    {
                        dcS = cp.ConnectTwoPoints(a1, a2);
                        widthPoints.AddRange(dcS);
                        dcE = cp.ConnectTwoPoints(b1, b2);
                        widthPoints.AddRange(dcE);
                    }
                }
            }

            //while (i < cS.Count)
            //{
            //    a1 = cS[i];
            //    b1.X = (c1.X * 2) - a1.X;

            //    a2 = cE[i];
            //    b2.X = (c2.X * 2) - a2.X;

            //    double d = Math.Abs(Math.Sqrt(Math.Pow((a1.X - a2.X), 2) + (a1.Y - a2.Y)));
            //    double d2 = Math.Abs(Math.Sqrt(Math.Pow((b1.X - b2.X), 2) + (b1.Y - b2.Y)));

            //    if ((int)delta == (int)d || (int)delta == (int)d2)
            //    {
            //        match = true;                    
            //    }

            //    i++;
            //}


            //int count = 0;

            //for(int c = 0; c < dcS.Count; c++)
            //{
            //    List<Point> nextLine = cp.ConnectTwoPoints(dcS[c], dcE[c]);
            //    widthPoints.AddRange(nextLine);
            //}
            //if(match)
            //{
            //    foreach (Point j in dcS)
            //    {
            //        //double RX = Math.Abs(Math.Sqrt(Math.Pow((end.X - j.X), 2)));
            //        //double RY = Math.Abs(Math.Sqrt(Math.Pow((end.Y - j.Y), 2)));

            //        a1 = j;
            //        b1.X = (c1.X * 2) - a1.X;

            //        foreach (Point z in dcE)
            //        {
            //            a2 = z;
            //            b2.X = (c2.X * 2) - a2.X;

            //            double d = Math.Abs(Math.Sqrt(Math.Pow((a1.X - a2.X), 2) + (a1.Y - a2.Y)));

            //            if ((int)delta == (int)d)
            //            {
            //                List<Point> nextLine = cp.ConnectTwoPoints(j, z);
            //                widthPoints.AddRange(nextLine);
            //            }

            //            //double d = Math.Abs(Math.Sqrt(Math.Pow((j.X - z.X), 2) + (j.Y - z.Y)));
            //            //if ((int)delta == (int)d)
            //            //{
            //            //    List<Point> nextLine = cp.ConnectTwoPoints(j, z);
            //            //    widthPoints.AddRange(nextLine);
            //            //}
            //        }

            //    }
            //}


            //Point x0 = cStrat._startPoint;
            //x0.X = cStrat._startPoint.X + (int)width;

            return widthPoints;
        }
    }
}
