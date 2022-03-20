using _3._3._1._SUPER_ARRAY;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Task_3._3_Tests
{
    [TestClass]
    public class ArrayMethodsTests
    {
        [TestMethod]
        public void Create_Array_And_Multiply_Every_Element()
        {
            double[] arr = { 15, 333, 8797, 13215, 5533 };

            double[] arrCopy = new double[arr.Length];

            Array.Copy(arr, arrCopy, arr.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(arrCopy[i] * 2, arr[i]);
            }
        }
        [TestMethod]
        public void Create_Array_And_Sum_All_Elements()
        {
            short[] arr = { 1, 2, 3 };

            int expectedSum = 6;
        }
        [TestMethod]
        public void Create_Array_And_Find_Frequently_Value()
        {
            float[] arr = { 1.5f , 2.3f , 3.1f, 2.3f, 1.5f, 1.5f };

            float expectedNum = 1.5f;
        }
    }
}
