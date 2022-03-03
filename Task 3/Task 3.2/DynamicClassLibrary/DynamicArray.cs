using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicClassLibrary
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>, ICloneable
    {
        protected T[] _items;
        private int _capacity;
        //9. Свойство Capacity — получение ёмкости: длины внутреннего массива.

        //*2. Возможность ручного изменения значения Capacity с
        //    сохранением уцелевших данных (данные за пределами новой Capacity сохранять не нужно).

        /// <summary>
        /// Property, which represents DynamicArray inner array size
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throws if provided value is negative</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throws if provided is less than Length</exception>
        public int Capacity { 
            get 
            {
                return _capacity;
            }
            set 
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Capacity can't be negative");

                if (_capacity != value)
                {
                    T[] destinationArray = new T[value];

                    if (value < Length)
                    {
                        Array.Copy(_items, 0, _items, 0, value);
                        Length = value;
                    }

                    Array.Copy(_items, 0, destinationArray, 0, Length);
                    _items = destinationArray;
                    _capacity = value;
                }
            } 
        }
        //8. Свойство Length — получение количества элементов.

        /// <summary>
        /// Property which represents number of not empty elements of DynamicArray inner array
        /// </summary>
        public int Length { get; private set; }

        //1. Конструктор без параметров (создаётся массив ёмкостью 8 элементов).

        /// <summary>
        /// Default constructor, which determines Capacity and Length of DynamicArray and allocates memory for inner array
        /// </summary>
        public DynamicArray()
        {
            _capacity = 8;
            Length = 0;
            _items = new T[Capacity];
        }

        //2. Конструктор с одним целочисленным параметром (создаётся массив указанной ёмкости).

        /// <summary>
        /// Constructor, which determines Capacity by provided parameter "capacity", sets Length equal 0, and allocates memory for inner array
        /// </summary>
        /// <param name="capacity"></param>
        /// <exception cref="ArgumentOutOfRangeException">Throws if provided value is negative</exception>
        public DynamicArray(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("Capacity can't be negative");
            if (capacity == 0)
                _items = Array.Empty<T>();
            else
            {
                _capacity = capacity;
                Length = 0;
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
                Length = coll.Count;
                _capacity = Length;
                return;
            }
            else
                throw new ArgumentException("Provided collection doesn't implements ICollection interface");
        }

        //4. Метод Add, добавляющий в конец массива один элемент.
        //   При нехватке места для добавления элемента, ёмкость массива должна удваиваться

        /// <summary>
        /// Method, which adds provided element at the end of DynamicArray inner array
        /// </summary>
        /// <param name="element"></param>
        public void Add(T element)
        {
            if (Capacity == Length)
                DoubleCapacity();

            _items[Length] = element;
            Length++;
        }

        private void DoubleCapacity() => Capacity *= 2;

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

                Length = _items.Length;
                Capacity = Length;
            }
            else
                throw new ArgumentException("Provided collection doesn't implements ICollection interface");
        }
        //6. Метод Remove, удаляющий из коллекции указанный элемент.
        //   Метод должен возвращать true, если удаление прошло успешно и false в противном случае.
        //   При удалении элементов реальная ёмкость массива не должна уменьшаться.

        /// <summary>
        /// Method, which removes first from beggining found element at DynamicArray and returns true, if removal was successfull
        /// </summary>
        /// <param name="item"></param>
        /// <returns><see cref="T:System.Boolean" /> is true, if removal was successfull</returns>
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
            Length--;
            return true;
        }
        //7. Метод Insert, позволяющий добавить элемент в произвольную позицию массива (обратите внимание, может потребоваться расширить массив).
        //   Метод должен возвращать true, если добавление прошло успешно и false в противном случае.
        //   При выходе за границу массива должно генерироваться исключение ArgumentOutOfRangeException.

        /// <summary>
        /// Method inserts provided element at the provided position and returns true, if inserting was successfull
        /// </summary>
        /// <param name="element"></param>
        /// <param name="position"></param>
        /// <returns><see cref="T:System.Boolean" /> is true, if inserting was successfull</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if provided position is out of DynamicArray inner array range</exception>
        public bool Insert(T element, int position)
        {
            if (position < 0 || position > Capacity)
                throw new ArgumentOutOfRangeException("Provided position is out of range of DynamicArray inner array");

            if (Capacity == Length)
                DoubleCapacity();

            if (position < Length)
                Array.Copy(_items, position, _items, position + 1, Length - position);

            _items[position] = element;
            Length++;
            return true;
        }
        //10. Методы, реализующие интерфейсы IEnumerable и IEnumerable<T>.

        /// <summary>
        /// Enumerator, which can be used for collection enumeration
        /// </summary>
        /// <returns>Interface <see cref="T:System.Collections.IEnumerator" /> , which can be used for collection enumeration</returns>
        public virtual IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        //*3. Реализовать интерфейс ICloneable для создания копии массива.

        /// <summary>
        /// Creates copy of this DynamicArray
        /// </summary>
        /// <returns><see cref="DynamicClassLibrary.DynamicArray<T>" /></returns>
        public object Clone() => MemberwiseClone();

        //11. Индексатор, позволяющий работать с элементом с указанным номером.
        //    При выходе за границу массива должно генерироваться исключение ArgumentOutOfRangeException.

        //*1. Доступ к элементам с конца при использовании отрицательного индекса (−1: последний, −2: предпоследний и т.д.).

        /// <summary>
        /// Indexator for DynamicArray
        /// </summary>
        /// <param name="index"></param>
        /// <returns>T</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if provided position is out of DynamicArray inner array range</exception>
        public T this [int index]
        {
            get
            {
                if (Math.Abs(index) > Length)
                    throw new ArgumentOutOfRangeException("Provided index is out of array range");

                if (index >= 0)
                    return _items[index];
                else
                    return _items[^Math.Abs(index)];
            }
            set
            {
                if (Math.Abs(index) > Length)
                    throw new ArgumentOutOfRangeException("Provided index is out of array range");

                if (index >= 0)
                    _items[index] = value;
                else
                    _items[^Math.Abs(index)] = value;
            }
        }

        //*4. Добавить метод ToArray, возвращающий новый массив (обычный),
        //    содержащий все содержащиеся в текущем динамическом массиве объекты.

        /// <summary>
        /// Returns copy of DynamicArray inner array
        /// </summary>
        /// <returns><see cref="System.Array" /></returns>
        public T[] ToArray()
        {
            T[] arr = new T[Length];
            Array.Copy(_items, arr, Length);
            return arr;
        }
    }
}
