using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicClassLibrary
{
    public class CycledEnumerator<T> : IEnumerator<T>
    {
        private int position = -1;
        private T[] _items;
        public CycledEnumerator(T[] items) => _items = items;
        public T Current => _items[position];
        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (position < _items.Length - 1)
                position++;
            else
                position %= _items.Length - 1;

            return true;
        }

        public void Reset() => position = -1;
    }
}
