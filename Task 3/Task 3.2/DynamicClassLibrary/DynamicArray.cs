using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicClassLibrary
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>
    {
        private T[] _items;
        private int _capacity;
        private const int NUM_OF_RESERVE_ELEMENTS = 5;
        //9. Свойство Capacity — получение ёмкости: длины внутреннего массива.
        public int Capacity { 
            get 
            {
                return _capacity;
            }
            set 
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Capacity can't be negative");
                if (value < Length)
                    throw new ArgumentOutOfRangeException("Capacity can't be less than length");

                if (_capacity != value)
                {
                    T[] destinationArray = new T[value];
                    Array.Copy(_items, 0, destinationArray, 0, Length);
                    _items = destinationArray;
                }
            } 
        }
        private int _length;
        //8. Свойство Length — получение количества элементов.
        public int Length
        {
            get
            {
                return _length;
            }
        }

        //1. Конструктор без параметров (создаётся массив ёмкостью 8 элементов).
        public DynamicArray()
        {
            _capacity = 8;
            _length = 0;
            _items = new T[Capacity];
        }

        //2. Конструктор с одним целочисленным параметром (создаётся массив указанной ёмкости).
        public DynamicArray(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("Capacity can't be negative");
            if (capacity == 0)
                _items = new T[0];
            else
            {
                _capacity = capacity;
                _length = 0;
                _items = new T[Capacity];
            }
        }

        //3. Конструктор, который в качестве параметра принимает коллекцию,
        //   реализующую интерфейс IEnumerable<T>,
        //   создаёт массив нужного размера и копирует в него все элементы из коллекции.
        public DynamicArray(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("Provided collection is null");

            if (collection is ICollection<T> coll)
            {
                if (coll.Count == 0)
                {
                    _items = Array.Empty<T>();
                    return;
                }
                _items = new T[coll.Count];
                coll.CopyTo(_items, 0);
                _length = coll.Count;
                _capacity = _length + NUM_OF_RESERVE_ELEMENTS;
                return;
            }
            else
                throw new ArgumentException("Provided collection doesn't implements ICollection interface");
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
