using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._2._CUSTOM_PAINT.Entities
{
    public abstract class Circle : Shape
    {
        public Point CenterPoint { get; set; }
        private double _radius;
        public double Radius {
            get 
            {
                return _radius;
            }
            set 
            {
                if (value < 0)
                    throw new ArgumentException("Radius can't be negative");

                _radius = value;
            } 
        }
        abstract public double LengthOfTheCircumscribedCircle();
        abstract public double Square();
    }
}
