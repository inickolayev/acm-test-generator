using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace TestGenerator
{
    public class Test
    {
        public IEnumerable<TestLine> TestLines { get; }

        public Test(IEnumerable<TestLine> testLines)
        {
            TestLines = testLines;
        }

        public void WriteToFile(string fileName = "Test:")
        {
            using (var stream = new StreamWriter(fileName))
            {
                foreach(var line in TestLines)
                    stream.WriteLine($"{line}");
            }
        }

        public void WriteToConsole(string testName)
        {
            Console.WriteLine($"{testName}");
            foreach (var line in TestLines)
                Console.WriteLine($"{line}");
        }
    }
}
