namespace IsItSquareLib
{
    /// <summary>
    /// Coordinates of points.
    /// </summary>
    public class Points
    {
#pragma warning disable CS1591 // Отсутствует комментарий XML для открытого видимого типа или члена
        public Points()
#pragma warning restore CS1591 // Отсутствует комментарий XML для открытого видимого типа или члена
        {
        }

#pragma warning disable CS1591 // Отсутствует комментарий XML для открытого видимого типа или члена
        public Points(float x, float y)
#pragma warning restore CS1591 // Отсутствует комментарий XML для открытого видимого типа или члена
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets or sets x coordinate.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Gets or sets y coordinate.
        /// </summary>
        public float Y { get; set; }
    }

    /// <summary>
    /// Get coordinates of last point.
    /// </summary>
    public class GetLastPointClass
    {

        /// <summary>
        /// Get coordinates of last point.
        /// </summary>
        /// <param name="pointA"> PointA.</param>
        /// <param name="pointB">PointB.</param>
        /// <param name="pointC">PointC.</param>
        /// <param name="pointD">PointD.</param>
        public static void GetLastPoint(Points pointA, Points pointB, Points pointC, Points pointD)
        {
            // Get x coordinate.
            if (pointA.X == pointB.X && pointB.X > pointC.X)//!
            {
                pointD.X = pointC.X;
            }
            else if (pointA.X < pointB.X && pointB.X > pointC.X && pointA.X < pointC.X)//!
            {
                pointD.X = pointB.X - pointC.X;
            }
            else if (pointA.X < pointB.X && pointB.X < pointC.X && pointA.X < pointC.X)//!
            {
                pointD.X = pointC.X - pointA.X;
            }
            else if (pointA.X < pointB.X && pointB.X == pointC.X)//!
            {
                pointD.X = pointA.X;
            }
            else if(pointA.X > pointB.X && pointB.X < pointC.X)//!
            {
                pointD.X = pointA.X - pointB.X + pointC.X;
            }
            else if (pointA.X > pointB.X && pointB.X > pointC.X)//!
            {
                pointD.X = pointA.X - pointB.X + pointC.X;
            }

            //Get Y coordinate.

            if (pointA.Y == pointB.Y && pointB.Y > pointC.Y) //!
            {
                pointD.Y = pointC.Y;
            }
            else if (pointA.Y < pointB.Y && pointB.Y > pointC.Y)//!
            {
                pointD.Y = pointB.Y - pointC.Y;
            }
            else if (pointA.Y > pointB.Y && pointB.Y == pointC.Y)//!
            {
                pointD.Y = pointA.Y;
            }
            else if (pointA.Y > pointB.Y && pointB.Y < pointC.Y)//!
            {
                pointD.Y = pointC.Y + pointA.Y - pointB.Y;
            }
            else if (pointA.Y > pointB.Y && pointB.Y > pointC.Y)//!
            {
                pointD.Y = pointA.Y - (pointB.Y - pointC.Y);
            }
            else if (pointA.Y < pointB.Y && pointB.Y < pointC.Y)//!
            {
                pointD.Y = pointC.Y - pointB.Y + pointA.Y;
            }
        }

    }
}
