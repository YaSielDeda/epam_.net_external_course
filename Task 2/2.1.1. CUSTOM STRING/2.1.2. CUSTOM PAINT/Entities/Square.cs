using _2._1._2._CUSTOM_PAINT.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._2._CUSTOM_PAINT.Entities
{
    public class Square : Shape
    {
        private double _width;
        public double Width 
        {
            get
            {
                return _width;
            }
            set
            {
                if(value < 0)
                    throw new NegativeArgumentException("Width can't be negative!");

                _width = value;
            }
        }
        public Point CenterPoint { get; set; }
        public Square(Point centerPoint, double width)
        {
            if(width < 0)
                throw new NegativeArgumentException("Width can't be negative!");

            CenterPoint = centerPoint;
            Width = width;
        }
        public double Area() => Math.Pow(Width, 2);
        public override string ToString()
        {
            return $"SQUARE {Environment.NewLine}" +
                   $"Center point at {CenterPoint} {Environment.NewLine}" +
                   $"Width = {Width} {Environment.NewLine}" +
                   $"Area = {Area()}";
        }
    }
}
