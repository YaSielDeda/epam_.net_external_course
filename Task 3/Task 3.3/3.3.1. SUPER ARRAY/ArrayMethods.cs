using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._3._1._SUPER_ARRAY
{
    public class ArrayMethods
    {
        public static void Transform(byte[] arr, Func<byte, byte> action)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = action.Invoke(arr[i]);
            }
        }
        public static void Transform(short[] arr, Func<short, short> action)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = action.Invoke(arr[i]);
            }
        }
        public static void Transform(int[] arr, Func<int, int> action)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = action.Invoke(arr[i]);
            }
        }
        public static void Transform(long[] arr, Func<long, long> action)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = action.Invoke(arr[i]);
            }
        }
        public static void Transform(float[] arr, Func<float, float> action)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = action.Invoke(arr[i]);
            }
        }
        public static void Transform(double[] arr, Func<double, double> action)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = action.Invoke(arr[i]);
            }
        }
        public static void Transform(decimal[] arr, Func<decimal, decimal> action)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = action.Invoke(arr[i]);
            }
        }

        public static byte SumAllElements(byte[] arr)
        {
            byte count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                count += arr[i];
            }

            return count;
        }
        public static short SumAllElements(short[] arr) 
        {
            short count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                count += arr[i];
            }

            return count;
        }
        public static int SumAllElements(int[] arr) => arr.Sum();
        public static long SumAllElements(long[] arr) => arr.Sum();
        public static float SumAllElements(float[] arr) => arr.Sum();
        public static double SumAllElements(double[] arr) => arr.Sum();
        public static decimal SumAllElements(decimal[] arr) => arr.Sum();


        public static double ArrayAverage(byte[] arr) => SumAllElements(arr) / arr.Length;
        public static double ArrayAverage(short[] arr) => SumAllElements(arr) / arr.Length;
        public static double ArrayAverage(int[] arr) => arr.Average();
        public static double ArrayAverage(long[] arr) => arr.Average();
        public static double ArrayAverage(float[] arr) => arr.Average();
        public static double ArrayAverage(double[] arr) => arr.Average();
        public static decimal ArrayAverage(decimal[] arr) => arr.Average();

        public static int FrequentlyValue(byte[] arr) =>
            arr.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .First()
            .Key;
        public static short FrequentlyValue(short[] arr) =>
            arr.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .First()
            .Key;
        public static int FrequentlyValue(int[] arr) =>
            arr.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .First()
            .Key;
        public static long FrequentlyValue(long[] arr) =>
            arr.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .First()
            .Key;
        public static float FrequentlyValue(float[] arr) =>
            arr.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .First()
            .Key;
        public static double FrequentlyValue(double[] arr) =>
            arr.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .First()
            .Key;
        public static decimal FrequentlyValue(decimal[] arr) =>
            arr.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .First()
            .Key;
    }        
}

