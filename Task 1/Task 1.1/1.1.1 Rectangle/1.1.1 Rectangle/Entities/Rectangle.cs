using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._1_Rectangle.Entities
{
    public class Rectangle
    {
        private int a;
        private int b;

        public Rectangle(int a, int b)
        {
            if (a <= 0)
                throw new ArgumentException("a can't be equal or less than 0");
            else
                this.a = a;

            if (b <= 0)
                throw new ArgumentException("b can't be equal or less than 0");
            else
                this.b = b;
        }
        public int Square => a * b;
    }
}
