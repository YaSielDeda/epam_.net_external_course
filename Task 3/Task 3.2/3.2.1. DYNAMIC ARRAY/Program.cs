using System;
using System.Collections.Generic;

namespace _3._2._1._DYNAMIC_ARRAY
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> jopa = new() { 'a', 'b' };
            Console.WriteLine(jopa.Count);      // 2
            Console.WriteLine(jopa.Capacity);   // 4
        }
    }
}
