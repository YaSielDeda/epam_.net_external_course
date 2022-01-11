using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._1._GAME.Entities
{
    public class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"X = {X}, Y = {Y}";
        }

        public object Clone()
        {
            return new Point(X, Y);
        }
    }
}
