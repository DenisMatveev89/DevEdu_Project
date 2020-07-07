using DevEdu_project;
using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using Rectangle = DevEdu_project.Rectangle;

namespace StraightLineGetPoints.Tests
{
    public class Tests
    {
        static IFigure Figure;
        [SetUp]
        public void Setup()
        {
        }
        [TestCase(1, 1, 1, 5, 5)]
        [TestCase(2, 0, 0, 0, 0)]
        [TestCase(3, 0, 0, 2, 2)]
        public void RectangleGetPointsTest(int i, int x1, int y1, int x2, int y2)
        {
            
            Figure = new Rectangle(x1, y1, x2, y2);
            
            RectangleMoks rectMocks = new RectangleMoks();
            
            List<Point> Exp = rectMocks.Get(i);
            List<Point> Act = Figure.GetPoints();

            CollectionAssert.AreEqual(Exp, Act);
        }
        [TestCase(1, 1, 1, 5, 5)]
        [TestCase(2, 0, 0, 0, 0)]
        [TestCase(3, 0, 0, 2, 2)]
        public void RectangleSquarGetPointsTest(int i, int x1, int y1, int x2, int y2)
        {

            Figure = new RectangleSquar(x1, y1, x2, y2);

            RectangleSquarMoks squarMocks = new RectangleSquarMoks();

            List<Point> Exp = squarMocks.Get(i);
            List<Point> Act = Figure.GetPoints();

            CollectionAssert.AreEqual(Exp, Act);
        }
    }
}
