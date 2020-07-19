using DevEdu_project.GetPoints;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;

namespace DevEdu_project.LineW
{
    public class LineWidth : ILineWidth
    {
        ConnectPoints cp = new ConnectPoints();

        public override void LWidth(Point startPoint, Point endPoint, int width, Color color)
        {
            int dx = endPoint.X - startPoint.X;//абсолютное значение
            int dy = endPoint.Y - startPoint.Y;
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

            float X = startPoint.X;// кладем пиксель для каждого шага 
            float Y = startPoint.Y;
            for (int i = 0; i <= steps; i++)
            {
                for (int j = -width; j <= width; j++)
                {
                    double d = Math.Sqrt(width * width - j * j);
                    Point tmp = new Point((int)(j + X), (int)(width + Y));                    
                    sBitmap.SetPixel(tmp.X, tmp.Y, color);

                    tmp = new Point((int)(j + X), (int)(-width + Y));                    
                    sBitmap.SetPixel(tmp.X, tmp.Y, color);

                    tmp = new Point((int)(width + X), (int)(j + Y));                    
                    sBitmap.SetPixel(tmp.X, tmp.Y, color);

                    tmp = new Point((int)(-width + X), (int)(width + Y));                    
                    sBitmap.SetPixel(tmp.X, tmp.Y, color);

                    tmp = new Point((int)(j + X), (int)(j + Y));                    
                    sBitmap.SetPixel(tmp.X, tmp.Y, color);

                    tmp = new Point((int)(j + X), (int)(-width + Y));                    
                    sBitmap.SetPixel(tmp.X, tmp.Y, color);

                    tmp = new Point((int)(width + X), (int)(j + Y));                    
                    sBitmap.SetPixel(tmp.X, tmp.Y, color);

                    tmp = new Point((int)(-width + X), (int)(j + Y));                    
                    sBitmap.SetPixel(tmp.X, tmp.Y, color);
                }
                //Добавляем в лист каждую точку, полученную в ходе вычислений
                //linePoints.Add(new Point((int)X, (int)Y));
                X += Xinc;
                Y += Yinc;
            }
        }
     
    }
}
