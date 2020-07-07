using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StraightLineGetPoints.Tests
{
    public class TriangleEquilateralMoks
    {
        public List<Point> Get(int a)
        {
            switch (a)
            {
                case 1:
                    return new List<Point>()
                    {
                        new Point(6,1),
                        new Point(6,2),
                        new Point(7,3),
                        new Point(7,3),
                        new Point(7,2),
                        new Point(8,1),
                        new Point(8,1),
                        new Point(7,1),
                        new Point(6,1),

                    };
                case 2:
                    return new List<Point>()
                    {
                        new Point(6,6), 
                        new Point(5,7),
                        new Point(4,8),
                        new Point(4,9),
                        new Point(4,9),
                        new Point(5,9),
                        new Point(6,9),
                        new Point(7,9),
                        new Point(7,9),
                        new Point(6,8),
                        new Point(6,7),
                        new Point(5,6),
                    };

                case 3:
                    return new List<Point>()
                    {
                        new Point(4,2),
                        new Point(4,3),
                        new Point(4,4),
                        new Point(4,4),
                        new Point(5,3),
                        new Point(5,3),
                        new Point(4,2),


                    };
                default:
                    return new List<Point>();
            }
        }
    }
}
