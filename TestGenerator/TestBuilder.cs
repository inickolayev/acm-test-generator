using System;
using System.Collections.Generic;
using System.Linq;

namespace TestGenerator
{
    public class TestBuilder
    {
        private readonly Func<Test, Test> _onBuild;
        private readonly List<TestLine> _testLines = new List<TestLine>();

        private TestBuilder _forBuilder;
        private int _forStart;
        private int _forEnd;

        public TestBuilder(Func<Test, Test> onBuild)
        {
            _onBuild = onBuild;
        }
        
        public Test BuildTest()
            => _onBuild(new Test(_testLines));

        public TestBuilder AddNumbers(params int[] nums)
        {
            _testLines.Add(new TestLine(string.Join(' ', nums)));
            return this;
        }

        public TestBuilder AddNumbers(params long[] nums)
        {
            _testLines.Add(new TestLine(string.Join(' ', nums)));
            return this;
        }

        public TestBuilder AddObjects(params object[] args)
        {
            _testLines.Add(new TestLine(string.Join(' ', args)));
            return this;
        }

        public TestBuilder GenerateNumber(long minValue = long.MinValue, long maxValue = long.MaxValue)
            => GenerateNumbers(1, minValue, maxValue);

        public TestBuilder GenerateNumbers(int size, long minValue = long.MinValue, long maxValue = long.MaxValue)
        {
            _testLines.Add(new TestLine(
                string.Join(' ', GeneratorHelper.GenerateNumbers(size, minValue, maxValue)))
            );
            return this;
        }

        public TestBuilder AddStrings(params string[] strs)
        {
            _testLines.Add(new TestLine(string.Join(' ', strs)));
            return this;
        }

        public TestBuilder GenerateString(int length, string alphabet)
        {
            var str = string.Join("",
                Enumerable.Range(1, length).Select(i => alphabet[new Random().Next(1, alphabet.Length)])
            );
            _testLines.Add(new TestLine(str));
            return this;
        }

        public TestBuilder AddRange(int start, int end, Action<TestBuilder> generateTest)
            => AddRange(start, end, (ind, tsb) => generateTest(tsb));

        
        public TestBuilder AddRange(int start, int end, Action<int, TestBuilder> generateTest)
        {
            for (int i = start; i <= end; i++)
                generateTest(i, this);
            return this;
        }
    }
}
