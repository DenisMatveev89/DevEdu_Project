using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StraightLineGetPoints.Tests
{
    class lineMoks
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
                    };
                case 2:
                    return new List<Point>()
                    {
                        new Point(0,0),
                        new Point(1,0),
                        new Point(2,0),
                        new Point(3,0),
                        new Point(4,0),
                        new Point(5,0),
                    };
                case 3:
                    return new List<Point>()
                    {
                        new Point(0,0),
                    };

                default:
                    return new List<Point>();
            }
        }
    }
}
