using BenchmarkDotNet.Running;

namespace JsonBenchmark
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<JsonBench>();
        }
    }
}