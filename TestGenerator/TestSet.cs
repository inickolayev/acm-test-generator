using System;
using System.Collections;
using System.Collections.Generic;
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

        public void WriteToFiles(Func<Test, int, string> getName)
        {
            foreach (var (test, ind) in _tests.Select((t, i) => (t, i)))
                test.WriteToFile(getName(test, ind));
        }

        public void WriteToConsole(string testSetName = "TestSet:")
        {
            Console.WriteLine($"{testSetName}");
            foreach (var (test, ind) in _tests.Select((t, i) => (t, i)))
                test.WriteToConsole($"Test №{ind}:");
        }
    }
}
