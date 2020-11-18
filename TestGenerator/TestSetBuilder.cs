using System;
using System.Collections.Generic;

namespace TestGenerator
{
    public class TestSetBuilder
    {
        private readonly List<Test> _tests = new List<Test>();

        public TestBuilder AddTest()
        {
            var testBuilder = new TestBuilder(t =>
            {
                _tests.Add(t);
                return this;
            });
            return testBuilder;
        }

        public TestBuilder AddTest(Func<TestBuilder, TestBuilder> handleTest)
        {
            var testBuilder = new TestBuilder(t =>
            {
                _tests.Add(t);
                return this;
            });
            handleTest(testBuilder);
            return testBuilder;
        }

        public TestSet BuildTestSet()
        {
            return new TestSet(_tests);
        }

        public TestSetBuilder For(int start, int end, Func<int, TestSetBuilder, TestSetBuilder> generateTest)
        {
            for (int i = start; i <= end; i++)
                generateTest(i, this);
            return this;
        }
    }
}
