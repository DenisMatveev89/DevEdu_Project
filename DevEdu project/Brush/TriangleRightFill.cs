using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Brush
{
    public class TriangleRightFill : IBrush
    {
        BitmapSingletone sBitmap = BitmapSingletone.GetInstance();
        ConnectPoints cp = new ConnectPoints();
        public void Fill(Point mouse, Color fillColor)
        {
            Color beginColor = sBitmap._tmpBitmap.GetPixel(mouse.X, mouse.Y);
            Point left = new Point(mouse.X, mouse.Y);
            Point right = new Point(mouse.X, mouse.Y);

            while(sBitmap._tmpBitmap.GetPixel(left.X-1, left.Y) == beginColor)
            {
                left.X--;
            }
            while (sBitmap._tmpBitmap.GetPixel(right.X + 1, right.Y) == beginColor)
            {
               right.X++;
            }

            List<Point> linePoints = cp.ConnectTwoPoints(left, right);
            sBitmap.Draw(linePoints, fillColor);

            for(int i = left.X; i <= right.X; i++)
            {
                if (sBitmap._tmpBitmap.GetPixel(i, mouse.Y + 1) == beginColor)
                {
                    Point down = new Point(i, mouse.Y + 1);
                    Fill(down, fillColor);
                }
                if (sBitmap._tmpBitmap.GetPixel(i, mouse.Y - 1) == beginColor)
                {
                    Point up = new Point(i, mouse.Y - 1);
                    Fill(up, fillColor);
                }
            }


           



            //    if(!IsEmpty(currentColor, mouseX, mouseY))
            //    {
            //        return;
            //    }
            //    sBitmap.SetPixel(mouseX, mouseY, fillColor);
            //    Fill(currentColor, fillColor, mouseX - 1, mouseY);
            //    Fill(currentColor, fillColor, mouseX + 1, mouseY);
            //    Fill(currentColor, fillColor, mouseX, mouseY - 1);
            //    Fill(currentColor, fillColor, mouseX, mouseY + 1);
            //}

            //public bool IsEmpty(Color currentColor, int mouseX, int mouseY)
            //{
            //    Color currentPxColor = sBitmap.ColorSelectPoint(mouseX, mouseY);
            //    if (currentColor != currentPxColor)//Ошибка тут
            //    {
            //        return false;
            //    }
            //    return (sBitmap.ColorSelectPoint(mouseX, mouseY) == currentColor);

        }
        
    }
}
