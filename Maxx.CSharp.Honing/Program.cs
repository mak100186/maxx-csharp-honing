using BenchmarkDotNet.Running;

namespace Maxx.CSharp.Honing;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Available algorithms:");
        Console.WriteLine(string.Join('\n', AlgorithmFactory.AllAlgorithmNames));

        Console.WriteLine("\nWhich algorithm would you like to run:");
        var algorithmName = Console.ReadLine();


        BenchmarkRunner.Run(AlgorithmFactory.GetAlgorithmTypeByName(algorithmName));
    }
}