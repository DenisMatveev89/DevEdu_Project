using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StraightLineGetPoints.Tests
{
    public class TriangleIsoscelesMoks
    {
        public List<Point> Get(int a)
        {
            switch (a)
            {
                case 1:
                    return new List<Point>()
                    {
                        new Point(6,2),
                        new Point(7,3),
                        new Point(8,4),
                        new Point(9,5),
                        new Point(10,6),
                        new Point(10,6),
                        new Point(9,6),
                        new Point(8,6),
                        new Point(7,6),
                        new Point(6,6),
                        new Point(5,6),
                        new Point(4,6),
                        new Point(3,6),
                        new Point(2,6),
                        new Point(2,6),
                        new Point(3,5),
                        new Point(4,4),
                        new Point(5,3),
                        new Point(6,2),

                    };

                case 2:
                    return new List<Point>()
                    {
                        new Point(5,7),
                        new Point(6,6),
                        new Point(7,5),
                        new Point(8,4),
                        new Point(8,4),
                        new Point(7,4),
                        new Point(6,4),
                        new Point(5,4),
                        new Point(4,4),
                        new Point(3,4),
                        new Point(2,4),
                        new Point(2,4),
                        new Point(3,5),
                        new Point(4,6),
                        new Point(5,7),
                    };

                default:
                    return new List<Point>();
            }
        }
    }
}
