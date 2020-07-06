using NUnit.Framework;
using DevEdu_project;
using System.Drawing;

namespace DevEdu_project_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //[TestCase(new Point(10, 10), new Point(10, 10), new Point[] { 3, 1 }))]
        [Test]
        public void DrawLineTest(Point StartPoint, Point EndPoind, Point[] expected)
        {
            Line line = new Line();
            line.DrawSLine(StartPoint, EndPoind);
            Point[] actual = line.toArray();

            Assert.AreEqual(expected, actual);
        }
    }
}