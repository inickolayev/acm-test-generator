using System;

namespace TestGenerator
{
    public class Generator
    {
        private readonly bool _isDebug;

        public Generator(bool isDebug = true)
        {
            _isDebug = isDebug;
        }
        
        public void GenerateTests<TTestsGenerator>(string pathName = ".", bool logToConsole = true)
            where TTestsGenerator : ITestsGenerator
        {
            var setBuilder = new TestSetBuilder(logToConsole);
            var generator = Activator.CreateInstance<TTestsGenerator>();
            generator.GenerateTests(setBuilder);
            var generatedTests = setBuilder.BuildTestSet();
            if (_isDebug)
                generatedTests.WriteToConsole();
            else
                generatedTests.WriteToFiles(pathName);
        }
    }
}