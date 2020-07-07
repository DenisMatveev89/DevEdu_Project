using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StraightLineGetPoints.Tests
{
    public class TriangleRightMoks
    {
        public List<Point> Get(int a)
        {
            switch (a)
            {
                case 1:
                    return new List<Point>()
                    {
                        new Point(1,2),
                        new Point(2,3),
                        new Point(3,4),
                        new Point(4,5),
                        new Point(5,6),
                        new Point(6,7),
                        new Point(6,7),
                        new Point(5,7),
                        new Point(4,7),
                        new Point(3,7),
                        new Point(2,7),
                        new Point(1,7),
                        new Point(1,7),
                        new Point(1,6),
                        new Point(1,5),
                        new Point(1,4),
                        new Point(1,3),
                        new Point(1,2),                        
                    };

                case 2:
                    return new List<Point>()
                    {
                        new Point(6,3),
                        new Point(5,2),
                        new Point(4,1),
                        new Point(3,0),
                        new Point(3,1),
                        new Point(4,1),
                        new Point(5,1),
                        new Point(6,1),
                        new Point(6,1),
                        new Point(6,2),
                        new Point(6,3),

                    };
                case 3:
                    return new List<Point>()
                    {
                        new Point(3,1),
                        new Point(2,2),
                        new Point(1,3),
                        new Point(1,3),
                        new Point(2,3),
                        new Point(3,3),
                        new Point(3,3),
                        new Point(3,2),
                        new Point(3,1),


                    };
                default:
                    return new List<Point>();
            }
        }
    }
}
