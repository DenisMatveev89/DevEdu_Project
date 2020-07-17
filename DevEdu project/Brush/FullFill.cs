using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Brush
{
    public class FullFill : IBrush
    {
        BitmapSingletone sBitmap = BitmapSingletone.GetInstance();
        ConnectPoints cp = new ConnectPoints();
        public override void Fill(Point mouse, Color fillColor, Color colorLine)
        {
            Color beginColor = sBitmap._fillBitmap.GetPixel(mouse.X, mouse.Y);
            Point left = new Point(mouse.X, mouse.Y);
            Point right = new Point(mouse.X, mouse.Y);

            while (left.X - 1 > 0 && sBitmap._fillBitmap.GetPixel(left.X - 1, left.Y) == beginColor && sBitmap._fillBitmap.GetPixel(left.X - 1, left.Y) != colorLine)
            {
                left.X--;
            }
            while (right.X + 1 <= sBitmap._fillBitmap.Width - 1 && sBitmap._fillBitmap.GetPixel(right.X + 1, right.Y) == beginColor && sBitmap._fillBitmap.GetPixel(right.X + 1, right.Y) != colorLine)
            {
                right.X++;
            }
            
            List<Point> linePoints = cp.ConnectTwoPoints(left, right);
            sBitmap.Draw(linePoints, fillColor);

            if (mouse.Y > 0 && mouse.Y < sBitmap._fillBitmap.Height - 1 && mouse.X > 0 && mouse.X < sBitmap._fillBitmap.Width - 1)
            {
                for (int i = left.X; i <= right.X; i++)
                {
                    if (sBitmap._fillBitmap.GetPixel(i, mouse.Y + 1) == beginColor && sBitmap._fillBitmap.GetPixel(i, mouse.Y + 1) != colorLine)
                    {
                        Point down = new Point(i, mouse.Y + 1);
                        Fill(down, fillColor, colorLine);
                    }

                    if (sBitmap._fillBitmap.GetPixel(i, mouse.Y - 1) == beginColor && sBitmap._fillBitmap.GetPixel(i, mouse.Y - 1) != colorLine)
                    {
                        Point up = new Point(i, mouse.Y - 1);
                        Fill(up, fillColor, colorLine);
                    }
                }
            }
            else
            {
                return;
            }


            //if (mouse.Y > 0 && mouse.Y < sBitmap._fillBitmap.Height && mouse.X > 0 && mouse.X < sBitmap._fillBitmap.Width)
            //{
            //    Color beginColor = sBitmap._fillBitmap.GetPixel(mouse.X, mouse.Y);
            //    Point left = new Point(mouse.X, mouse.Y);
            //    Point right = new Point(mouse.X, mouse.Y);

            //    //находим конечные точки влево и вправо
            //    while (sBitmap._fillBitmap.GetPixel(left.X - 1, left.Y) == beginColor && left.X - 1 > 0 && left.X < sBitmap._fillBitmap.Width)
            //    {
            //        left.X--;
            //    }
            //    while (sBitmap._fillBitmap.GetPixel(right.X + 1, right.Y) == beginColor && right.X > 0 && right.X - 1 < sBitmap._fillBitmap.Width)
            //    {
            //        right.X++;
            //    }

            //    List<Point> linePoints = cp.ConnectTwoPoints(left, right);
            //    sBitmap.Draw(linePoints, fillColor);

            //    if (mouse.Y > 0 && mouse.Y < sBitmap._fillBitmap.Height && mouse.X > 0 && mouse.X < sBitmap._fillBitmap.Width)
            //    {
            //        for (int i = left.X; i <= right.X; i++)
            //        {
            //            if (sBitmap._fillBitmap.GetPixel(i, mouse.Y + 1) == beginColor)
            //            {
            //                Point down = new Point(i, mouse.Y + 1);
            //                Fill(down, fillColor);                            
            //            }

            //            if (sBitmap._fillBitmap.GetPixel(i, mouse.Y - 1) == beginColor)
            //            {
            //                Point up = new Point(i, mouse.Y - 1);
            //                Fill(up, fillColor);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //else
            //{
            //    return;
            //}


        }


    }
}
