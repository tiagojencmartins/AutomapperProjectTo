using BenchmarkDotNet.Running;

namespace AutomapperProjectTo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkDI>();
        }
    }
}