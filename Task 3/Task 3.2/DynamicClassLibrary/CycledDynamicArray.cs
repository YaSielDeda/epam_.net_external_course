using System.Collections.Generic;

namespace DynamicClassLibrary
{
    public class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray() : base()
        {

        }
        public CycledDynamicArray(int capacity) : base(capacity)
        {

        }
        public CycledDynamicArray(IEnumerable<T> collection) : base(collection)
        {

        }
        public override IEnumerator<T> GetEnumerator() => new CycledEnumerator<T>(_items);
    }
}
