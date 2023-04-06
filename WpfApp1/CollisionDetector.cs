using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YetAnotherFlappyBird
{
    internal class CollisionDetector
    {
        public CollisionDetector()
        {

        }

        public bool CollidesWithPipeObject(Vector2D playerPosition, PipeObject pipeObject, double playerRadius)
        {
            

            return false;
        }

        private bool IsPositionWithinRect(Vector2D position, Rect rect)
        {
            return position.x >= rect.X && position.x <= rect.X + rect.Width &&
                position.y >= rect.Y && position.y <= rect.Y + rect.Height;
        }

        private bool IsPositionWithinRadiusFromRect(Vector2D position, Rect rect, double radius)
        {
            var lines = Utils.GetRectLines(rect);

            foreach (var line in lines)
            {
                var distance = position.DistanceToLine(line.Item1, line.Item2);
                if (distance <= radius)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
