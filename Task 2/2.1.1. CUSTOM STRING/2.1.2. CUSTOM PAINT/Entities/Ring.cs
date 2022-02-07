using _2._1._2._CUSTOM_PAINT.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._2._CUSTOM_PAINT.Entities
{
    public class Ring : Shape
    {
        public Round InnerRound { get; set; }
        public Round OuterRound { get; set; }
        public Point CenterPoint { get; set; }
        public Ring(Point center, double innerRadius, double outerRadius)
        {
            if (innerRadius > outerRadius)
                throw new ArgumentException("Radius of inner round can't be more than outer round");

            if(innerRadius < 0 || outerRadius < 0)
                throw new NegativeArgumentException("Radius can't be negative!");

            CenterPoint = center;

            InnerRound = new Round(center, innerRadius);
            OuterRound = new Round(center, outerRadius);
        }
        public double LengthOfTheCircumscribedCircle() => InnerRound.LengthOfTheCircumscribedCircle() + OuterRound.LengthOfTheCircumscribedCircle();
        public double Square() => OuterRound.Square() - InnerRound.Square();
        public override string ToString()
        {
            return $"RING {Environment.NewLine}" +
                   $"Center at point {CenterPoint} {Environment.NewLine}" +
                   $"Inner round radius = {InnerRound.Radius} {Environment.NewLine}" +
                   $"Outer round radius = {OuterRound.Radius} {Environment.NewLine}" +
                   $"Sum of lengths of the circumscribed circles {LengthOfTheCircumscribedCircle(): #.##} {Environment.NewLine}" +
                   $"Square = {Square(): #.##}";
        }
    }
}
