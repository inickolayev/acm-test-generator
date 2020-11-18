using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGenerator.Extensions;

namespace TestGenerator
{
    public class GeneratorHelper
    {
        public const string LOWER_CASE_ALPHABET = "abcdefghijklmnopqrstuvwxyz";
        public const string UPPER_CASE_ALPHABET = "abcdefghijklmnopqrstuvwxyz";

        public static List<long> GenerateArray(int size, long minValue = long.MinValue, long maxValue = long.MaxValue)
        {
            var arr = new List<long>();
            for (int i = 0; i < size; i++)
            {
                arr.Add(new Random().NextLong(minValue, maxValue));
            }
            return arr;
        }

        public static string GenerateLowerString(int length)
            => GenerateString(length, LOWER_CASE_ALPHABET);

        public static string GenerateUpperString(int length)
            => GenerateString(length, UPPER_CASE_ALPHABET);

        public static string GenerateString(int length, string alphabet)
        {
            var str = string.Join("",
                Enumerable.Range(1, length).Select(i => alphabet[new Random().Next(1, alphabet.Length)])
            );
            return str;
        }

        public static string Shake(string str)
        {
            int l = str.Length;
            var strB = new StringBuilder(str);
            for (int i = 0; i < l; i++)
            {
                if (new Random().NextBool())
                {
                    char tmp = strB[i];
                    strB[i] = strB[new Random().Next(1, l)];
                    strB[new Random().Next(1, l)] = tmp;
                    str = strB.ToString();
                }
            }
            return str;
        }
    }
}
