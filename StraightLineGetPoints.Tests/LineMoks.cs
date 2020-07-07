using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StraightLineGetPoints.Tests
{
    class LineMoks
    {
        public List<Point> Get(int a)
        {
            switch (a)
            {
                case 1:
                    return new List<Point>()
                    {
                        new Point(1,1),
                        new Point(1,2),
                        new Point(5,1),
                        new Point(1,7),
                    };

                default:
                    return new List<Point>();
            }
        }
    }
}
