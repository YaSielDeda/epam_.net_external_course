using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._1._GAME.Entities
{
    public class Field
    {
        private int _width;
        private int _height;
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Width can't be less than zero");

                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Height can't be less than zero");

                _height = value;
            }
        }
        public Field(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
