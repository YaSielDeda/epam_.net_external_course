using _2._1._2._CUSTOM_PAINT.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._2._CUSTOM_PAINT.Entities
{
    public class Line : Shape
    {
        private double _length;
        private Point _startPoint;
        private Point _endPoint;
        public Point StartPoint
        {
            get
            {
                return _startPoint;
            }
            set
            {
                if (value.X == EndPoint.X && value.Y == EndPoint.Y && Length != 0)
                    throw new ArgumentException("Length can't be more than 0, if start point and end point are located in the same coords!");

                _startPoint = value;
            }
        }
        public Point EndPoint 
        { 
            get 
            {
                return _endPoint;
            }
            set
            {
                if (value.X == StartPoint.X && value.Y == StartPoint.Y && Length != 0)
                    throw new ArgumentException("Length can't be more than 0, if start point and end point are located in the same coords!");

                _endPoint = value;
            }
        }
        public double Length
        {
            get
            {
                return _length;
            }
            set
            {
                if (value < 0)
                    throw new NegativeArgumentException("Length can't be negative");

                _length = value;
            }
        }
        public Line(Point startPoint, Point endPoint, double length)
        {
            if (length < 0)
                throw new NegativeArgumentException("Length can't be negative");

            if((startPoint.X == endPoint.X) && (startPoint.Y == endPoint.Y) && length != 0)
                throw new ArgumentException("Length can't be more than 0, if start point and end point are located in the same coords!");

            Length = length;
            _startPoint = startPoint;
            _endPoint = endPoint;
        }
        public override string ToString()
        {
            return $"LINE {Environment.NewLine}" +
                   $"Start point at {StartPoint} {Environment.NewLine}" +
                   $"End point at {EndPoint} {Environment.NewLine}" +
                   $"Length = {Length}";
        }
    }
}
