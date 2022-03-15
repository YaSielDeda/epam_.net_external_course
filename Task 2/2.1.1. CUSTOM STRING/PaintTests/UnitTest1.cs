using _2._1._2._CUSTOM_PAINT.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PaintTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Creating_Round_With_Negative_Radius_ResultFalse()
        {
            bool fail = false;
            try
            {
                var round = new Round(new Point(15, 22), -40);
            }
            catch (Exception)
            {
                fail = true;
            };

            Assert.IsTrue(fail);
        }

        [TestMethod]
        public void Creating_Round_And_Setting_Negative_Radius_ResultFalse()
        {
            var round = new Round(new Point(14, 88), 5);

            bool fail = false;

            try
            {
                round.Radius = -5;
            }
            catch (ArgumentException)
            {
                fail = true;
            }

            Assert.IsTrue(fail);
        }

        [TestMethod]
        public void Creating_Ring_With_Negative_Radius_ResultFalse()
        {
            bool fail = false;
            try
            {
                var ring = new Ring(new Point(15, 22), -40, 50);
            }
            catch (Exception)
            {
                fail = true;
            }

            Assert.IsTrue(fail);
        }

        [TestMethod]
        public void Creating_Ring_And_Setting_Negative_Radius_ResultFalse()
        {
            var ring = new Ring(new Point(15, 22), 40, 50);

            bool fail = false;

            try
            {
                ring.InnerRound.Radius = -40;
            }
            catch (ArgumentException)
            {
                fail = true;
            }

            Assert.IsTrue(fail);
        }
        [TestMethod]
        public void Creating_Line_With_Negative_Length_ResultFalse()
        {
            bool fail = false;
            try
            {
                var line = new Line(new Point(15, 22), new Point(55, -5), -50);
            }
            catch (Exception)
            {
                fail = true;
            }

            Assert.IsTrue(fail);
        }

        [TestMethod]
        public void Creating_Line_And_Setting_Negative_Length_ResultFalse()
        {
            var line = new Line(new Point(15, 22), new Point(55, -5), 50);

            bool fail = false;

            try
            {
                line.Length = -40;
            }
            catch (Exception)
            {
                fail = true;
            }

            Assert.IsTrue(fail);
        }
        [TestMethod]
        public void Creating_Rectangle_With_Negative_Width_ResultFalse()
        {
            bool fail = false;
            try
            {
                var rectangle = new Rectangle(new Point(-5, 56), -5, 5);
            }
            catch (Exception)
            {
                fail = true;
            }

            Assert.IsTrue(fail);
        }
        [TestMethod]
        public void Creating_Rectangle_With_Negative_Height_ResultFalse()
        {
            bool fail = false;
            try
            {
                var rectangle = new Rectangle(new Point(-5, 56), 5, -5);
            }
            catch (Exception)
            {
                fail = true;
            }

            Assert.IsTrue(fail);
        }

        [TestMethod]
        public void Creating_Rectangle_And_Setting_Negative_Width_ResultFalse()
        {
            var rectangle = new Rectangle(new Point(-5, 56), 5, 5);

            bool fail = false;

            try
            {
                rectangle.Width = -40;
            }
            catch (Exception)
            {
                fail = true;
            }

            Assert.IsTrue(fail);
        }
        [TestMethod]
        public void Creating_Rectangle_And_Setting_Negative_Height_ResultFalse()
        {
            var rectangle = new Rectangle(new Point(-5, 56), 5, 5);

            bool fail = false;

            try
            {
                rectangle.Height = -40;
            }
            catch (Exception)
            {
                fail = true;
            }

            Assert.IsTrue(fail);
        }
        [TestMethod]
        public void Creating_Square_With_Negative_Width_ResultFalse()
        {
            bool fail = false;
            try
            {
                var square = new Square(new Point(-5, 56), -5);
            }
            catch (Exception)
            {
                fail = true;
            }

            Assert.IsTrue(fail);
        }

        [TestMethod]
        public void Creating_Square_And_Setting_Negative_Width_ResultFalse()
        {
            var square = new Square(new Point(-5, 56), 5);

            bool fail = false;

            try
            {
                square.Width = -40;
            }
            catch (Exception)
            {
                fail = true;
            }

            Assert.IsTrue(fail);
        }
    }
}
