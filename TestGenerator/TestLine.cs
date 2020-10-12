using System;

namespace TestGenerator
{
    public class TestLine
    {
        private readonly string _line;

        public TestLine(string line)
        {
            _line = line;
        }

        public override string ToString()
        {
            return _line;
        }
    }
}
