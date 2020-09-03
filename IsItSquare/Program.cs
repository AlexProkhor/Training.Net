// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace IsItSquare
{
    using System;
    using System.Text;
    using IsItSquareLib;

    /// <summary>
    /// Заданы координаты трех точек на плоскости. Являются ли они вершинами квадрата? Если да, то найти координаты четвертой вершины.
    /// Ввод осуществляется с пробелами "1 2 ".
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main.
        /// </summary>
        public static void Main()
        {
            var pointA = new Points();
            var pointB = new Points();
            var pointC = new Points();
            var pointD = new Points();

            Console.WriteLine("Введите 3 точки:");
            Console.WriteLine("Точка A:");
            string pointСoordinates = Console.ReadLine();
            GetPointCoordinates(pointСoordinates, pointA);

            Console.WriteLine("Точка B:");
            pointСoordinates = Console.ReadLine();
            GetPointCoordinates(pointСoordinates, pointB);

            Console.WriteLine("Точка C:");
            pointСoordinates = Console.ReadLine();
            GetPointCoordinates(pointСoordinates, pointC);
            IsItSquare(pointA, pointB, pointC, pointD);
            Console.WriteLine($"Координаты точки D: (x,y) {pointD.X} {pointD.Y}");
        }

        /// <summary>
        /// Get angle between lines.
        /// </summary>
        /// <param name="pointA"> PointA.</param>
        /// <param name="pointB">PointB.</param>
        /// <param name="pointC">PointC.</param>
        /// <param name="pointD">PointD.</param>
        public static void IsItSquare(Points pointA, Points pointB, Points pointC, Points pointD)
        {
            var lines = new float[6];
            lines = GetLines(pointA, pointB, pointC);

            float cos =
                (float)(((lines[0] * lines[3]) + (lines[1] * lines[4]))
                / Math.Sqrt((lines[0] * lines[0]) + (lines[1] * lines[1]))
                * Math.Sqrt((lines[3] * lines[3]) + (lines[4] * lines[4])));

            if (cos != 0)
            {
                Console.WriteLine("It is not square {0}", cos);
            }
            else
            {
                Console.WriteLine("It is square {0}", cos);
                GetLastPointClass.GetLastPoint(pointA, pointB, pointC, pointD);
            }
        }

        /// <summary>
        /// Get lines from points.
        /// </summary>
        /// <returns>A B C params from line.</returns>
        /// <param name="pointA">PointA.</param>
        /// <param name="pointB">PointB.</param>
        /// <param name="pointC">PointC.</param>
        public static float[] GetLines(Points pointA, Points pointB, Points pointC)
        {
            var lines = new float[6];
            float a = pointA.Y - pointB.Y;
            float b = pointB.X - pointA.X;
            float c = (pointA.X * pointB.Y) - (pointB.X * pointA.Y);

            Console.WriteLine("Уравнение прямых:");
            Console.WriteLine($"{a}x + {b}y + {c} = 0");

            float a1 = pointC.Y - pointB.Y;
            float b1 = pointB.X - pointC.X;
            float c1 = (pointB.X * pointC.Y) - (pointC.X * pointB.Y);

            Console.WriteLine($"{a1}x + {b1}y + {c1} = 0");

            lines[0] = a;
            lines[1] = b;
            lines[2] = c;
            lines[3] = a1;
            lines[4] = b1;
            lines[5] = c1;

            return lines;
        }

        /// <summary>
        /// Separation of points.
        /// </summary>
        /// <param name="pointСoordinates">string point coordinates.</param>
        /// <param name="points"> object.</param>
        public static void GetPointCoordinates(string pointСoordinates, Points points)
        {
            (string xCoordinate, string yCoordinate) sPointsCoordinates;
            string coordinate = null;
            var sBuildPointCoordinate = new StringBuilder(coordinate);
            int i = 0;
            while (pointСoordinates[i] != ' ')
            {
                sBuildPointCoordinate.Append(pointСoordinates[i]);
                i++;
            }

            sPointsCoordinates.xCoordinate = sBuildPointCoordinate.ToString();
            i++;
            sBuildPointCoordinate.Clear();
            while (pointСoordinates[i] != ' ')
            {
                sBuildPointCoordinate.Append(pointСoordinates[i]);
                i++;
            }

            sPointsCoordinates.yCoordinate = sBuildPointCoordinate.ToString();
            GetPoint(points, sPointsCoordinates);
        }

        /// <summary>
        /// String to float.
        /// </summary>
        /// <param name="points">object.</param>
        /// <param name="sPointsCoordinates">string coordinates.</param>
        public static void GetPoint(Points points, (string xCoordinate, string yCoordinate) sPointsCoordinates)
        {
            points.X = float.Parse(sPointsCoordinates.xCoordinate);
            points.Y = float.Parse(sPointsCoordinates.yCoordinate);
        }
    }
}
