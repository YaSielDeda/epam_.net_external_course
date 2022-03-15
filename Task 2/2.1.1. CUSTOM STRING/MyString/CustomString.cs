using System;
using System.Linq;

namespace SelfMadeLibrary
{
    public sealed class CustomString
    {
        internal char[] StringChars = { };
        internal const int DefaultCapacity = 16;
        private int _length;
        /// <summary>
        /// The number of not empty (\0) chars
        /// </summary>
        public int Length {
            get
            {
                return _length;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Length can't be  negative!");

                char[] arr = new char[value];
                Array.Copy(StringChars, arr, value);
                StringChars = arr;

                _length = value;
            }
        }
        private int _capacity;
        /// <summary>
        /// The number of CustomString array capacity
        /// </summary>
        public int Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Length can't be  negative!");

                if (value < Length)
                    throw new ArgumentOutOfRangeException("Capacity can't be less than length!");

                if (Capacity != value) 
                {
                    char[] arr = new char[value];
                    Array.Copy(StringChars, arr, 0);
                    StringChars = arr;

                    _capacity = value;
                }
            }
        }
        public char this[int index]
        {
            get => StringChars[index];
            set => StringChars[index] = value;
        }
        public CustomString(string rawString)
        {
            if (rawString.Length > DefaultCapacity)
                Capacity = StringCalculateCapacity(rawString.Length);
            else
                Capacity = DefaultCapacity;

            StringChars = rawString.ToCharArray();
            Length = StringChars.Length;
        }
        private int StringCalculateCapacity(int stringLength) => (stringLength / DefaultCapacity) * DefaultCapacity + DefaultCapacity;
        public CustomString(char[] rawChar)
        {
            if(rawChar.Length > DefaultCapacity)
                Capacity = CharArrayCalculateCapacity(rawChar.Length);
            else
                Capacity = DefaultCapacity;

            Array.Copy(rawChar, StringChars, rawChar.Length);
            Length = StringChars.Where(x => x != '\0').Count();
        }
        private int CharArrayCalculateCapacity(int charArrLength) => (charArrLength / DefaultCapacity) * DefaultCapacity + DefaultCapacity;
        public CustomString(int capacity)
        {
            Length = 0;
            StringChars = new char[capacity];
        }
        public CustomString(int capacity, string rawString)
        {
            if (capacity < rawString.Length)
                throw new ArgumentException("Capacity value can't be less than Length of char array!");

            Length = rawString.Length;

            Capacity = capacity;

            StringChars = rawString.ToCharArray();
            Length = StringChars.Length;
        }
        public CustomString(int capacity, char[] rawChar)
        {
            if (capacity < rawChar.Length)
                throw new ArgumentException("Capacity value can't be less than Length of char array!");

            Length = rawChar.Length;

            Capacity = capacity;

            StringChars = new char[Capacity];
            Array.Copy(rawChar, StringChars, rawChar.Length);
        }
        public CustomString()
        {
            Length = 0;
            StringChars = new char[DefaultCapacity];
        }
        public override string ToString()
        {
            return new string(StringChars);
        }
        /// <summary>
        /// Checks if CustomString is equals with array of chars
        /// </summary>
        /// <param name="charArray"></param>
        /// <returns>bool</returns>
        public bool Equals(char[] charArray)
        {
            if (!(StringChars.Length == charArray.Length))
                return false;

            for (int i = 0; i < charArray.Length; i++)
            {
                if (StringChars[i] != charArray[i])
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Checks if CustomString equals whith string
        /// </summary>
        /// <param name="str"></param>
        /// <returns>bool</returns>
        public bool Equals(string str)
        {
            if (new string(StringChars).Equals(str))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Checks if two CustomString is equals
        /// </summary>
        /// <param name="customString"></param>
        /// <returns>bool</returns>
        public bool Equals(CustomString customString)
        {
            if (Equals(customString.ToString()))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Checks if CustomString contains char
        /// </summary>
        /// <param name="c"></param>
        /// <returns>bool</returns>
        public bool Contains(char c)
        {
            if (StringChars.Contains(c))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Checks if CustomString contains string
        /// </summary>
        /// <param name="s"></param>
        /// <returns>bool</returns>
        public bool Contains(string s)
        {
            if (new string(StringChars).Contains(s))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Checks if CustomString contains another CustomString
        /// </summary>
        /// <param name="customString"></param>
        /// <returns>bool</returns>
        public bool Contains(CustomString customString)
        {
            if (Contains(customString.ToString()))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Removes all elements of CustomString
        /// </summary>
        /// <returns>CustomString</returns>
        public CustomString Clear()
        {
            Length = 0;
            return this;
        }
        /// <summary>
        /// Aggregating two CustomStrings
        /// </summary>
        /// <param name="cs"></param>
        /// <returns>CustomString</returns>
        public CustomString Concat(char[] charArray)
        {
            char[] arr;

            if (charArray.Length + StringChars.Length < DefaultCapacity)
                arr = new char[DefaultCapacity];
            else
                arr = new char[CharArrayCalculateCapacity(charArray.Length + StringChars.Length)];

            for (int i = 0; i < StringChars.Length; i++)
            {
                arr[i] = StringChars[i];
            }
            for (int i = StringChars.Length; i < StringChars.Length + charArray.Length; i++)
            {
                arr[i] = charArray[i - StringChars.Length];
            }
            return new CustomString(arr);
        }
        /// <summary>
        /// Aggregating two CustomStrings
        /// </summary>
        /// <param name="cs"></param>
        /// <returns>CustomString</returns>
        public CustomString Concat(string s)
        {
            char[] arr;

            if (s.Length + StringChars.Length < DefaultCapacity)
                arr = new char[DefaultCapacity];
            else
                arr = new char[StringCalculateCapacity(s.Length + StringChars.Length)];

            return new CustomString(new string(StringChars + s));
        }
        /// <summary>
        /// Aggregating two CustomStrings
        /// </summary>
        /// <param name="cs"></param>
        /// <returns>CustomString</returns>
        public CustomString Concat(CustomString cs)
        {
            return Concat(cs.StringChars);
        }
        /// <summary>
        /// Converting CustomString to array of chars
        /// </summary>
        /// <returns>char[]</returns>
        public char[] ToCharArray()
        {
            return StringChars;
        }
        /// <summary>
        /// Deleting white space - chars from the beginning and ending of string
        /// </summary>
        /// <returns>CustomString</returns>
        public CustomString Trim() 
        {
            return new CustomString(ToString().Trim());
        }
    }
}
