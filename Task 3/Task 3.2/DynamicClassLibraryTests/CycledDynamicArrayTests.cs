using DynamicClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicClassLibraryTests
{
    [TestClass]
    class CycledDynamicArrayTests
    {
        [TestMethod]
        public void Create_Char_CycledDynamicArray_And_Getting_Outbounded_Element()
        {
            char[] charArr = { 'a', 'b', 'c' };

            CycledDynamicArray<char> cycledDynamicArray = new(charArr);

            for (int i = 0; i < 50; i++)
            {
                Assert.AreEqual(cycledDynamicArray[i], charArr[i % charArr.Length]);
            }
        }
    }
}
