using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StraightLineGetPoints.Tests
{
    class RectangleSquarMoks
    {
       public List<Point> Get(int a)
        {
            switch (a)
            {
                case 1:
                    return new List<Point>()
                    {
                        new Point(1,1),
                        new Point(2,1),
                        new Point(3,1),
                        new Point(4,1),
                        new Point(5,1),
                        new Point(5,1),
                        new Point(5,2),
                        new Point(5,3),
                        new Point(5,4),
                        new Point(5,5),
                        new Point(5,5),
                        new Point(4,5),
                        new Point(3,5),
                        new Point(2,5),
                        new Point(1,5),
                        new Point(1,5),
                        new Point(1,4),
                        new Point(1,3),
                        new Point(1,2),
                        new Point(1,1),
                    };
                case 2:
                    return new List<Point>()
                    {
                        new Point(0,0),
                        new Point(0,0),
                        new Point(0,0),
                        new Point(0,0),
                    };
                case 3:
                    return new List<Point>()
                    {
                        new Point(0,0),
                        new Point(1,0),
                        new Point(2,0),
                        new Point(2,0),
                        new Point(2,1),
                        new Point(2,2),
                        new Point(2,2),
                        new Point(1,2),
                        new Point(0,2),
                        new Point(0,2),
                        new Point(0,1),
                        new Point(0,0),
                        
                    };
                default:
                    return new List<Point>();
            }
        }
    }
}
