using _3._3._1._SUPER_ARRAY;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _3._3_Tests
{
    [TestClass]
    public class ArrayMethodsTests
    {
        [TestMethod]
        public void Create_ArrayMethods_And_Multiply_Every_Element()
        {
            int[] arr = { 1, 2, 3 };

            ArrayMethods<int> arrayMethods = new(arr);
        }
    }
}
