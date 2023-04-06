using System;

namespace YetAnotherFlappyBird
{
    internal class Vector2D
    {
        public readonly double x;
        public readonly double y;

        public Vector2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double Distance(Vector2D other)
        {
            return Math.Sqrt(Math.Pow((other.x - x), 2) + Math.Pow((other.y - y), 2));
        }

        public double DistanceToLine(Vector2D start, Vector2D end)
        {
            double A = end.y - start.y;
            double B = start.x - end.x;
            double C = (end.x * start.y) - (start.x * end.y);

            double numerator = Math.Abs((A * x) + (B * y) + C);
            double denominator = Math.Sqrt((A * A) + (B * B));

            return numerator / denominator;
        }
    }
}
