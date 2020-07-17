using DevEdu_project.GetPoints;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.LineW
{
    public class LineWidth : ILineWidth
    {
        ConnectPoints cp = new ConnectPoints();
        public override List<Point> LWidth(Point start, Point end, int width)
        {
            int x1 = start.X;
            int x2 = start.Y;
            int y1 = end.Y;
            int y2 = end.Y;
            List<Point> widthLine = new List<Point>();
            int a, b, l, lx1, lx2, lx3, lx4, ly1, ly2, ly3, ly4;
            a = (x2 - x1); b = (y2 - y1);
            l = (int)Math.Sqrt(100 * ((b * b) + (a * a)));
            lx1 = (5+b * 100 * width / 2 / l+x1 * 10)/ 10;
            ly1 = (5+y1 * 10 - a * 100 * width / 2 / l)/ 10;
            lx2 = (5+b * 100 * width / 2 / l+x2 * 10)/ 10;
            ly2 = (5+y2 * 10 - a * 100 * width / 2 / l)/ 10;
            lx3 = (5+x1 * 10 - b * 100 * (width - (width / 2) - 1) / l)/ 10;
            ly3 = (5+a * 100 * (width - (width / 2) - 1) / l+y1 * 10)/ 10;
            lx4 = (5+x2 * 10 - b * 100 * (width - (width / 2) - 1) / l)/ 10;
            ly4 = (5+a * 100 * (width - (width / 2) - 1) / l+y2 * 10)/ 10;
            widthLine.AddRange(cp.ConnectTwoPoints(new Point (lx1, ly1), new Point(lx2,ly2)));
            widthLine.AddRange(cp.ConnectTwoPoints(new Point (lx2, ly2), new Point(lx3,ly3)));
            widthLine.AddRange(cp.ConnectTwoPoints(new Point (lx3, ly3), new Point(lx4,ly4)));
            widthLine.AddRange(cp.ConnectTwoPoints(new Point (lx4, ly4), new Point(lx1,ly1)));
            return widthLine;
        }
    }
}
