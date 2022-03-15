using _2._1._2._CUSTOM_PAINT.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._2._CUSTOM_PAINT.Entities
{
    public class Round : Circle
    {
        public Round(Point center, double radius) 
        {
            if (radius < 0)
                throw new NegativeArgumentException("Radius can't be less than 0!");

            CenterPoint = center;
            Radius = radius;
        }
        public override double LengthOfTheCircumscribedCircle() => 2 * Math.PI * Radius;
        public override double Square() => Math.PI * Math.Pow(Radius, 2);
        public override string ToString()
        {
            return $"ROUND {Environment.NewLine}" +
                   $"Center at point {CenterPoint} {Environment.NewLine}" +
                   $"Radius = {Radius} {Environment.NewLine}" +
                   $"Length of the circumscribed circle {LengthOfTheCircumscribedCircle(): #.##} {Environment.NewLine}" +
                   $"Square = {Square(): #.##}";
        }
    }
}
