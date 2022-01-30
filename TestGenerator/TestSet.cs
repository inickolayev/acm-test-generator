using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestGenerator
{
    public class TestSet
    {
        private readonly IEnumerable<Test> _tests;
        
        public TestSet(IEnumerable<Test> tests)
        {
            _tests = tests;
        }

        public void WriteToFiles(string pathName = ".")
            => WriteToFiles(pathName, (test, ind) => $"{ind}.in");

        public void WriteToFiles(string pathName, Func<Test, int, string> getName)
        {
            if (!Directory.Exists(pathName))
                Directory.CreateDirectory(pathName);
            foreach (var (test, ind) in _tests.Select((t, i) => (t, i + 1)))
                test.WriteToFile(Path.Join(pathName, getName(test, ind)));
        }

        public void WriteToConsole(string testSetName = "TestSet:")
        {
            Console.WriteLine($"{testSetName}");
            foreach (var (test, ind) in _tests.Select((t, i) => (t, i)))
                test.WriteToConsole($"Test №{ind}:");
        }
    }
}
