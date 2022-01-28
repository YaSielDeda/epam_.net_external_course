using DynamicClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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

            DynamicArray<char> da = new(list);

            Assert.AreEqual(list.Count, da.Capacity);
            Assert.AreEqual(list.Count, da.Length);
        }
        [TestMethod]
        public void Create_Char_DynamicArray_With_Provided_Char_Array()
        {
            char[] arr = { 'a', 'b', 'c' };

            DynamicArray<char> da = new(arr);

            Assert.AreEqual(arr.Length, da.Capacity);
            Assert.AreEqual(arr.Length, da.Length);
        }
        [TestMethod]
        public void Create_Char_DynamicArray_WITH_Available_Space_And_Adding_One_Element()
        {
            DynamicArray<char> da = new();

            int defaultCapacity = 8;

            da.Add('a');

            Assert.AreEqual(defaultCapacity, da.Capacity);
            Assert.AreEqual(1, da.Length);
        }
        [TestMethod]
        public void Create_Char_DynamicArray_WITHOUT_Available_Space_And_Adding_One_Element()
        {
            char[] arr = { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a' };

            DynamicArray<char> da = new(arr);

            int increasedCapacity = arr.Length * 2;

            da.Add('a');

            Assert.AreEqual(increasedCapacity, da.Capacity);
            Assert.AreEqual(arr.Length + 1, da.Length);
        }
        [TestMethod]
        public void Create_Char_DynamicArray_With_Elements_And_Adding_IEnumerable_With_Elements()
        {
            DynamicArray<char> da = new(new char[] { 'a', 'b', 'c' });

            int daCapacityBeforeMerge = da.Capacity;

            char[] arr = { 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k' };

            da.AddRange(arr);

            Assert.AreEqual(daCapacityBeforeMerge + arr.Length, da.Capacity);
            Assert.AreEqual(daCapacityBeforeMerge + arr.Length, da.Length);
        }
        [TestMethod]
        public void Create_Char_DynamicArray_WITH_Elements_And_Remove_Existed_Element()
        {
            DynamicArray<char> da = new(new char[] { 'a', 'b', 'c' });

            int expectedCapacity = da.Capacity;
            int expectedLength = da.Length - 1;

            bool isDeleted = da.Remove('a');

            Assert.IsTrue(isDeleted);
            Assert.AreEqual(da.Length, expectedLength);
            Assert.AreEqual(da.Capacity, expectedCapacity);
        }
        [TestMethod]
        public void Create_Char_DynamicArray_WITHOUT_Elements_And_Remove_Existed_Element()
        {
            DynamicArray<char> da = new();

            bool isDeleted = da.Remove('a');

            Assert.IsFalse(isDeleted);
        }
        [TestMethod]
        public void Create_Char_DynamicArray_WITH_Elements_And_Remove_Inexisted_Element()
        {
            DynamicArray<char> da = new(new char[] { 'a', 'b', 'c' });

            bool isDeleted = da.Remove('d');

            Assert.IsFalse(isDeleted);
        }
        [TestMethod]
        public void Create_Char_DynamicArray_WITH_Some_Repeating_Elements_And_Remove_Existed_Element()
        {
            DynamicArray<char> da = new(new char[] { 'a', 'b', 'c', 'b' });

            int expectedCapacity = da.Capacity;
            int expectedLength = da.Length - 1;

            bool isDeleted = da.Remove('b');

            Assert.IsTrue(isDeleted);
            Assert.AreEqual(da.Length, expectedLength);
            Assert.AreEqual(da.Capacity, expectedCapacity);
        }
        [TestMethod]
        public void Create_Empty_Char_DynamicArray_And_Insert_Element()
        {
            DynamicArray<char> da = new();

            bool isInserted = da.Insert('b', 0);

            int defaultCapacity = 8;
            int expectedLength = 1;

            Assert.IsTrue(isInserted);
            Assert.AreEqual(defaultCapacity, da.Capacity);
            Assert.AreEqual(expectedLength, da.Length);
        }
        [TestMethod]
        public void Create_Full_Capacity_Char_DynamicArray_And_Insert_Element_At_The_3rd_Position()
        {
            DynamicArray<char> da = new(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' });

            bool isInserted = da.Insert('z', 3);

            int expectedCapacity = 16;
            int expectedLength = 9;

            Assert.IsTrue(isInserted);
            Assert.AreEqual(expectedCapacity, da.Capacity);
            Assert.AreEqual(expectedLength, da.Length);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Create_Char_DynamicArray_With_Elements_And_Insert_Element_At_Impossible_Position()
        {
            DynamicArray<char> da = new(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' });

            da.Insert('z', 25);
        }
        [TestMethod]
        public void Create_Full_Capacity_Char_DynamicArray_With_Elements_And_Insert_Element_At_The_Beggining()
        {
            DynamicArray<char> da = new(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' });

            bool isInserted = da.Insert('z', 0);

            Assert.IsTrue(isInserted);
        }
        [TestMethod]
        public void Create_Char_DynamicArray_With_Elements_And_Insert_Element_At_The_End()
        {
            DynamicArray<char> da = new(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' });

            bool isInserted = da.Insert('z', da.Length);

            Assert.IsTrue(isInserted);
        }
        [TestMethod]
        public void Create_Char_DynamicArray_With_Elements_And_Passing_Through_Each_Element_By_Foreach()
        {
            char[] charArr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            DynamicArray<char> da = new(charArr);

            int count = 0;

            foreach (var item in da)
            {
                Assert.AreEqual(item, charArr[count]);
                count++;
            }
        }
        [TestMethod]
        public void Create_Full_Capacity_Char_DynamicArray_With_Elements_And_Get_Element_By_Index()
        {
            char[] charArr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            DynamicArray<char> da = new(charArr);

            Assert.AreEqual(da[3], 'd');
        }
        [TestMethod]
        public void Create_Full_Capacity_Char_DynamicArray_With_Elements_And_Set_Element_By_Index()
        {
            char[] charArr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            DynamicArray<char> da = new(charArr);

            da[3] = 'z';

            Assert.AreEqual(da[3], 'z');
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Create_Full_Capacity_Char_DynamicArray_With_Elements_And_Get_Element_By_Outbounded_Index()
        {
            char[] charArr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            DynamicArray<char> da = new(charArr);

            var someChar = da[15];
        }
        [TestMethod]
        public void Create_Full_Capacity_Char_DynamicArray_With_Elements_And_Get_Penultimate_Element()
        {
            char[] charArr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            DynamicArray<char> da = new(charArr);

            Assert.AreEqual(da[-2], 'g');
        }
        [TestMethod]
        public void Create_Full_Capacity_Char_DynamicArray_With_Elements_And_Set_Some_Element_With_Negative_Index()
        {
            char[] charArr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            DynamicArray<char> da = new(charArr);

            da[-5] = 'z';

            Assert.AreEqual(da[-5], 'z');
        }
        [TestMethod]
        public void Create_Full_Capacity_Char_DynamicArray_With_Elements_And_Decrease_Capacity()
        {
            char[] charArr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            DynamicArray<char> da = new(charArr);

            int capacityToChange = 2;

            da.Capacity = capacityToChange;

            Assert.AreEqual(capacityToChange, da.Capacity);
        }
        [TestMethod]
        public void Create_Char_DynamicArray_With_Elements_And_Clone_It()
        {
            char[] charArr = { 'a', 'b', 'c', 'd', 'e' };

            DynamicArray<char> da = new(charArr);

            DynamicArray<char> daCopy = da.Clone() as DynamicArray<char>;

            for (int i = 0; i < da.Length; i++)
                Assert.AreEqual(da[i], daCopy[i]);

            Assert.AreEqual(da.Length, daCopy.Length);
            Assert.AreEqual(da.Capacity, daCopy.Capacity);
        }
        [TestMethod]
        public void Create_Char_DynamicArray_With_Elements_Clone_It_And_Change()
        {
            char[] charArr = { 'a', 'b', 'c', 'd', 'e' };

            DynamicArray<char> da = new(charArr);

            DynamicArray<char> daCopy = da.Clone() as DynamicArray<char>;

            daCopy.Add('z');

            Assert.IsTrue(daCopy.Length > da.Length);
        }
        [TestMethod]
        public void Create_Char_DynamicArray_With_Elements_And_Getting_Array_By_ToArray_Method()
        {
            char[] charArr = { 'a', 'b', 'c', 'd', 'e' };

            DynamicArray<char> da = new(charArr);

            char[] copyOfInnerArray = da.ToArray();

            da.Add('z');

            Assert.IsTrue(da.Length > copyOfInnerArray.Length);
        }
    }
}
