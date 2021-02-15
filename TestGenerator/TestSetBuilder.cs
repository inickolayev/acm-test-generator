using System;
using System.Collections.Generic;

namespace TestGenerator
{
    public class TestSetBuilder
    {
        private readonly List<Test> _tests = new List<Test>();
        private readonly bool _logToConsole;

        public TestSetBuilder(bool logToConsole = true)
        {
            _logToConsole = logToConsole;
        }

        public TestBuilder AddTest()
        {
            var testBuilder = new TestBuilder(t =>
            {
                _tests.Add(t);
                if (_logToConsole)
                    Console.WriteLine($"Finished test #{_tests.Count}");
                return this;
            });
            return testBuilder;
        }

        public TestBuilder AddTest(Func<TestBuilder, TestBuilder> handleTest)
        {
            var testBuilder = new TestBuilder(t =>
            {
                _tests.Add(t);
                if (_logToConsole)
                    Console.WriteLine($"Finished test #{_tests.Count}");
                return this;
            });
            handleTest(testBuilder);
            return testBuilder;
        }

        public TestSet BuildTestSet()
        {
            if (_logToConsole)
                Console.WriteLine($"Finished testset with count = {_tests.Count}");
            return new TestSet(_tests);
        }

        public TestSetBuilder For(int start, int end, Func<int, TestSetBuilder, TestSetBuilder> generateTest)
        {
            for (int i = start; i <= end; i++)
                generateTest(i, this);
            return this;
        }

        public TestSetBuilder EnshureTestCountEquals(int count)
        {
            if (_tests.Count != count)
                throw new Exception($"Count of tests must be {count}, but is {_tests.Count}");
            return this;
        }
    }
}
