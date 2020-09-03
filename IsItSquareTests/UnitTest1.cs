using Xunit;
using IsItSquareLib;
using System;

namespace IsItSquareTests
{
    /// <summary>
    /// Test
    /// </summary>
    public class IsItSquareTests
    {
        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void Test1()
        {
            var pointA = new Points();
            var pointB = new Points();
            var pointC = new Points();
            var pointD = new Points();
            pointA.X = 1;
            pointA.Y = 1;
            pointB.X = 1;
            pointB.Y = 4;
            pointC.X = 6;
            pointC.Y = 4;
            GetLastPointClass.GetLastPoint(pointA, pointB, pointC, pointD);
            Console.WriteLine($"Координаты точки D: (x,y) {pointD.X} {pointD.Y}");
        }

        /// <summary>
        /// Test
        /// </summary>
        [Theory]
        [InlineData(1, 1, 1, 4, 6, 4, 6, 1)]
        [InlineData(1, 4, 6, 4, 6, 1, 1, 1)]
        [InlineData(6, 4, 6, 1, 1, 1, 1, 4)]
        [InlineData(6, 1, 1, 1, 1, 4, 6, 4)]

        [InlineData(1, 1, 1, 5, 5, 5, 5, 1)]
        [InlineData(1, 5, 5, 5, 5, 1, 1, 1)]
        [InlineData(5, 5, 5, 1, 1, 1, 1, 5)]
        [InlineData(5, 1, 1, 1, 1, 5, 5, 5)]


        [InlineData(1, 2, 2, 6, 6, 5, 5, 1)]
        [InlineData(2, 6, 6, 5, 5, 1, 1, 2)]
        [InlineData(6, 5, 5, 1, 1, 2, 2, 6)]
        [InlineData(5, 1, 1, 2, 2, 6, 6, 5)]
        public void Test2(float pointA_x, float pointA_y, float pointB_x, float pointB_y, float pointC_x, float pointC_y, float expected_x, float expected_y)
        {
            var pointA = new Points(pointA_x, pointA_y);
            var pointB = new Points(pointB_x, pointB_y);
            var pointC = new Points(pointC_x, pointC_y);
            var pointD = new Points();

            GetLastPointClass.GetLastPoint(pointA, pointB, pointC, pointD);

            Assert.True(pointD.X == expected_x && pointD.Y == expected_y);
        }
    }
}
