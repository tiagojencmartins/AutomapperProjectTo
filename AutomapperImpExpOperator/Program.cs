using BenchmarkDotNet.Running;

namespace ImplicitOperator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkDI>();
        }
    }
}