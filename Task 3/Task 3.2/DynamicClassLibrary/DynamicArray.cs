using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DynamicClassLibrary
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>
    {
        private T[] _items;
        private int _capacity;
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
                    throw new ArgumentOutOfRangeException("Capacity can't be less than length, data loss will follow");

                if (_capacity != value)
                {
                    T[] destinationArray = new T[value];
                    Array.Copy(_items, 0, destinationArray, 0, Length);
                    _items = destinationArray;
                    _capacity = value;
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
                _items = Array.Empty<T>();
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

        /// <summary>
        /// DynamicArray constructor, which accepts at input generic IEnumerable collection
        /// </summary>
        /// <param name="collection"></param>
        /// <exception cref="ArgumentNullException">Throws if provided collection is null</exception>
        /// <exception cref="ArgumentException">Throws if provided collection isn't implements ICollection</exception>
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
                _capacity = _length;
                return;
            }
            else
                throw new ArgumentException("Provided collection doesn't implements ICollection interface");
        }

        //4. Метод Add, добавляющий в конец массива один элемент.
        //   При нехватке места для добавления элемента, ёмкость массива должна удваиваться
        public void Add(T element)
        {
            if (Capacity == Length)
            {
                Capacity *= 2;
            }
            _items[_length] = element;
            _length++;
        }
        //5. Метод AddRange, добавляющий в конец массива содержимое коллекции, реализующей интерфейс IEnumerable<T>.
        //   Обратите внимание, метод должен корректно учитывать число элементов в коллекции с тем,
        //   чтобы при необходимости расширения массива делать это только один раз вне зависимости от числа элементов в добавляемой коллекции.

        /// <summary>
        /// Method Adds provided generic IEnumerable collection to DynamicArray inner array
        /// </summary>
        /// <param name="collection"></param>
        /// <exception cref="ArgumentNullException">Throws if provided collection is null</exception>
        /// <exception cref="ArgumentException">Throws if provided collection isn't implements ICollection</exception>
        public void AddRange(IEnumerable<T> collection)
        {
            if (collection is ICollection<T> coll)
            {
                if (coll == null)
                    throw new ArgumentNullException("Provided collection is null");

                if (Capacity - Length < coll.Count)
                    Capacity += coll.Count;

                coll.CopyTo(_items, Length);

                _length = _items.Length;
                _capacity = _length;
            }
            else
                throw new ArgumentException("Provided collection doesn't implements ICollection interface");
        }
        //6. Метод Remove, удаляющий из коллекции указанный элемент.
        //   Метод должен возвращать true, если удаление прошло успешно и false в противном случае.
        //   При удалении элементов реальная ёмкость массива не должна уменьшаться.

        /// <summary>
        /// Method, which removes first from beggining founded element at DynamicArray and returns true, if removal was successfull
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T element)
        {
            if (_items == null)
                //throw new NullReferenceException("No memory allocated for DynamicArray inner array");
                return false;

            if (_items.Length == 0)
                //throw new NullReferenceException("DynamicArray inner array is empty");
                return false;

            int index = Array.IndexOf(_items, element);

            if (index == -1)
                //throw new ArgumentException("DynamicArray inner array doesn't contains provided element");
                return false;

            _items.SetValue(null, index);
            _length--;
            return true;
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
