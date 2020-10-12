using System;
using System.Collections.Generic;
using TestGenerator.Extensions;

namespace TestGenerator
{
    public class GeneratorHelper
    {
        public static List<long> GenerateArray(int size, long minValue = long.MinValue, long maxValue = long.MaxValue)
        {
            var arr = new List<long>();
            for (int i = 0; i < size; i++)
            {
                arr.Add(new Random().NextLong(minValue, maxValue));
            }
            return arr;
        }
    }
}
