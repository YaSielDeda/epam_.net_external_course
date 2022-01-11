using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelfMadeLibrary;

namespace CustomStringTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Comparison_Of_CustomString_And_String_ReturnsFalse()
        {
            CustomString customString = new CustomString("Test custom string");

            string str = "String";

            Assert.AreEqual(customString.Equals(str), false);
        }

        [TestMethod]
        public void Comparison_Of_CustomString_And_Array_ReturnsFalse()
        {
            CustomString customString = new CustomString("Test custom string");

            char[] charArr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j' };

            Assert.AreEqual(customString.Equals(charArr), false);
        }

        [TestMethod]
        public void Comparison_Of_Two_Different_CustomStrings_ReturnsFalse()
        {
            CustomString customString1 = new CustomString("Test custom string");

            CustomString customString2 = new CustomString("Test custom adsada string");

            Assert.AreEqual(customString1.Equals(customString2), false);
        }

        public void Comparison_Of_CustomString_And_String_ReturnsTrue()
        {
            CustomString customString = new CustomString("Test custom string");

            string str = "Test custom string";

            Assert.AreEqual(customString.Equals(str), true);
        }

        [TestMethod]
        public void Comparison_Of_CustomString_And_Array_ReturnsTrue()
        {
            CustomString customString = new CustomString("abcdefghj");

            char[] charArr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j' };

            Assert.AreEqual(customString.Equals(charArr), true);
        }

        [TestMethod]
        public void Comparison_Of_Two_Different_CustomStrings_ReturnsTrue()
        {
            CustomString customString1 = new CustomString("Test custom string");

            CustomString customString2 = new CustomString("Test custom string");

            Assert.AreEqual(customString1.Equals(customString2), true);
        }
    }
}
