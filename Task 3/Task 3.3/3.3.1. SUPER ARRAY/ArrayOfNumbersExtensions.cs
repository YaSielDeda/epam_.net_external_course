using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._3._1._SUPER_ARRAY
{
    public static class ArrayOfNumbersExtensions
    {
        public static void Transform(this byte[] arr, Func<byte, byte> action)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = action.Invoke(arr[i]);
            }
        }
        public static void Transform(this short[] arr, Func<short, short> action)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = action.Invoke(arr[i]);
            }
        }
        public static void Transform(this int[] arr, Func<int, int> action)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = action.Invoke(arr[i]);
            }
        }
        public static void Transform(this long[] arr, Func<long, long> action)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = action.Invoke(arr[i]);
            }
        }
        public static void Transform(this float[] arr, Func<float, float> action)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = action.Invoke(arr[i]);
            }
        }
        public static void Transform(this double[] arr, Func<double, double> action)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = action.Invoke(arr[i]);
            }
        }
        public static void Transform(this decimal[] arr, Func<decimal, decimal> action)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = action.Invoke(arr[i]);
            }
        }

        public static byte SumAllElements(this byte[] arr)
        {
            byte count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                count += arr[i];
            }

            return count;
        }
        public static short SumAllElements(this short[] arr) 
        {
            short count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                count += arr[i];
            }

            return count;
        }
        public static int SumAllElements(this int[] arr) => arr.Sum();
        public static long SumAllElements(this long[] arr) => arr.Sum();
        public static float SumAllElements(this float[] arr) => arr.Sum();
        public static double SumAllElements(this double[] arr) => arr.Sum();
        public static decimal SumAllElements(this decimal[] arr) => arr.Sum();


        public static double ArrayAverage(this byte[] arr) => SumAllElements(arr) / arr.Length;
        public static double ArrayAverage(this short[] arr) => SumAllElements(arr) / arr.Length;
        public static double ArrayAverage(this int[] arr) => arr.Average();
        public static double ArrayAverage(this long[] arr) => arr.Average();
        public static double ArrayAverage(this float[] arr) => arr.Average();
        public static double ArrayAverage(this double[] arr) => arr.Average();
        public static decimal ArrayAverage(this decimal[] arr) => arr.Average();

        public static int FrequentlyValue(this byte[] arr) =>
            arr.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .First()
            .Key;
        public static short FrequentlyValue(this short[] arr) =>
            arr.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .First()
            .Key;
        public static int FrequentlyValue(this int[] arr) =>
            arr.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .First()
            .Key;
        public static long FrequentlyValue(this long[] arr) =>
            arr.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .First()
            .Key;
        public static float FrequentlyValue(this float[] arr) =>
            arr.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .First()
            .Key;
        public static double FrequentlyValue(this double[] arr) =>
            arr.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .First()
            .Key;
        public static decimal FrequentlyValue(this decimal[] arr) =>
            arr.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .First()
            .Key;
    }        
}

