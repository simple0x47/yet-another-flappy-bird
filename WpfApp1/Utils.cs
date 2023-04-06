using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YetAnotherFlappyBird
{
    internal class Utils
    {
        public static Tuple<Vector2D, Vector2D>[] GetRectLines(Rect rect)
        {
            Tuple<Vector2D, Vector2D>[] lines = new Tuple<Vector2D, Vector2D>[4];

            lines[0] = new Tuple<Vector2D, Vector2D>(
                new Vector2D(rect.X, rect.Y),
                new Vector2D(rect.X + rect.Width, rect.Y)
            );

            lines[1] = new Tuple<Vector2D, Vector2D>(
                new Vector2D(rect.X + rect.Width, rect.Y),
                new Vector2D(rect.X + rect.Width, rect.Y + rect.Height)
            );

            lines[2] = new Tuple<Vector2D, Vector2D>(
                new Vector2D(rect.X, rect.Y + rect.Height),
                new Vector2D(rect.X + rect.Width, rect.Y + rect.Height)
            );

            lines[3] = new Tuple<Vector2D, Vector2D>(
                new Vector2D(rect.X, rect.Y),
                new Vector2D(rect.X, rect.Y + rect.Height)
            );

            return lines;
        }
    }
}
