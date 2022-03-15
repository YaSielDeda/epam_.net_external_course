using _2._1._2._CUSTOM_PAINT.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._2._CUSTOM_PAINT.Entities
{
    public class Rectangle : Shape
    {
        private double _width;
        private double _height;
        public Point CenterPoint { get; set; }
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value < 0)
                    throw new NegativeArgumentException("Width can't be negative!");

                _width = value;
            }
        }
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value < 0)
                    throw new NegativeArgumentException("Height can't be negative!");

                _height = value;
            }
        }
        public Rectangle(Point centerPoint, double width, double height)
        {
            if(width < 0 || height < 0)
                throw new NegativeArgumentException("Params can't be negative!");

            CenterPoint = centerPoint;
            Width = width;
            Height = height;
        }
        public double Square() => Width * Height;
        public override string ToString()
        {
            return $"RECTANGLE {Environment.NewLine}" +
                   $"Center point at {CenterPoint} {Environment.NewLine}" +
                   $"Width = {Width} {Environment.NewLine}" +
                   $"Height = {Height} {Environment.NewLine}" +
                   $"Square = {Square()}";
        }
    }
}
