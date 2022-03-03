using _3._3._2._SUPER_STRING;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._3_Tests
{
    [TestClass]
    public class SuperStringTests
    {
        [TestMethod]
        public void Create_String_With_Only_Russian_Symbols_Returns_Russian()
        {
            string str = "абоба";

            StringMethods stringMethods = new(str);

            Assert.AreEqual(StringType.Russian, stringMethods.DetectTypeOfString());
        }
        [TestMethod]
        public void Create_String_With_Only_Punctuation_Symbols_Returns_Mixed()
        {
            string str = ".@$$@%!";

            StringMethods stringMethods = new(str);

            Assert.AreEqual(StringType.Mixed, stringMethods.DetectTypeOfString());
        }
        [TestMethod]
        public void Create_String_With_Only_English_Symbols_Returns_English()
        {
            string str = "aboba";

            StringMethods stringMethods = new(str);

            Assert.AreEqual(StringType.English, stringMethods.DetectTypeOfString());
        }
        [TestMethod]
        public void Create_Empty_String__Returns_None()
        {
            string str = string.Empty;

            StringMethods stringMethods = new(str);

            Assert.AreEqual(StringType.None, stringMethods.DetectTypeOfString());
        }
        [TestMethod]
        public void Create_Mixed_String_With_Russians_And_English_Symbols_Returns_Mixed()
        {
            string str = "абоба aboba";

            StringMethods stringMethods = new(str);

            Assert.AreEqual(StringType.Mixed, stringMethods.DetectTypeOfString());
        }
        [TestMethod]
        public void Create_Mixed_String_With_Numbers_And_Punctuation_Symbols_Returns_Mixed()
        {
            string str = "14881337228!!!@@#$%!";

            StringMethods stringMethods = new(str);

            Assert.AreEqual(StringType.Mixed, stringMethods.DetectTypeOfString());
        }
    }
}
