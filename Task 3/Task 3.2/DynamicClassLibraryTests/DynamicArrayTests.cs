using DynamicClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DynamicClassLibraryTests
{
    [TestClass]
    public class DynamicArrayTests
    {
        [TestMethod]
        public void Create_Char_DynamicArray_Without_Parameters()
        {
            DynamicArray<char> da = new();

            int defaultCapacity = 8;
            int defaultLength = 0;

            Assert.AreEqual(defaultCapacity, da.Capacity);
            Assert.AreEqual(defaultLength, da.Length);
        }

        [TestMethod]
        public void Create_Char_DynamicArray_With_Capacity_15_Parameter()
        {
            int providedCapacity = 15;

            DynamicArray<char> da = new(providedCapacity);

            int defaultLength = 0;

            Assert.AreEqual(providedCapacity, da.Capacity);
            Assert.AreEqual(defaultLength, da.Length);
        }

        [TestMethod]
        public void Create_Char_DynamicArray_With_Provided_Char_List()
        {
            List<char> list = new() { 'a', 'b', 'c' };

            int numberOfReserveElements = 5;

            DynamicArray<char> da = new(list);

            Assert.AreEqual(list.Count + numberOfReserveElements, da.Capacity);
            Assert.AreEqual(list.Count, da.Length);
        }
        [TestMethod]
        public void Create_Char_DynamicArray_With_Provided_Char_Array()
        {
            char[] arr = { 'a', 'b', 'c' };

            DynamicArray<char> da = new(arr);
            
            int numberOfReserveElements = 5;

            Assert.AreEqual(arr.Length + numberOfReserveElements, da.Capacity);
            Assert.AreEqual(arr.Length, da.Length);
        }
        //[TestMethod]
        //public void Create_Char_DynamicArray_With_Provided_Char_Collection()
        //{

        //}
    }
}
