using System;
using System.Collections.Generic;
using System.Linq;

namespace TestGenerator
{
    public class TestSetBuilder
    {
        private readonly List<TestBuilder> _testBuilders = new List<TestBuilder>();
        private readonly bool _logToConsole;

        public TestSetBuilder(bool logToConsole = true)
        {
            _logToConsole = logToConsole;
        }

        public TestSetBuilder AddTest()
        {
            var testBuilder = new TestBuilder(t =>
            {
                if (_logToConsole)
                    Console.WriteLine($"Finished test #{_testBuilders.Count}");
                return t;
            });
            _testBuilders.Add(testBuilder);
            return this;
        }

        public TestSetBuilder AddTest(Action<TestBuilder> handleTest)
        {
            var testBuilder = new TestBuilder(t =>
            {
                if (_logToConsole)
                    Console.WriteLine($"Finished test #{_testBuilders.Count}");
                return t;
            });
            handleTest(testBuilder);
            _testBuilders.Add(testBuilder);
            return this;
        }

        public TestSet BuildTestSet()
        {
            if (_logToConsole)
                Console.WriteLine($"Finished testset with count = {_testBuilders.Count}");
            var tests = _testBuilders.Select(tb => tb.BuildTest()).ToArray();
            return new TestSet(tests);
        }

        public TestSetBuilder AddRange(int start, int end, Action<TestSetBuilder> generateTest)
            => AddRange(start, end, (ind, tsb) => generateTest(tsb));

        public TestSetBuilder AddRange(int start, int end, Action<int, TestSetBuilder> generateTest)
        {
            for (int i = start; i <= end; i++)
                generateTest(i, this);
            return this;
        }

        public TestSetBuilder EnshureTestCountEquals(int count)
        {
            if (_testBuilders.Count != count)
                throw new Exception($"Count of tests must be {count}, but is {_testBuilders.Count}");
            return this;
        }
    }
}
