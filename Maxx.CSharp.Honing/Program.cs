using System.Diagnostics;

namespace Maxx.CSharp.Honing;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Available algorithms:");
        Console.WriteLine(string.Join('\n', AlgorithmFactory.AllAlgorithmNames));

        Console.WriteLine("\nWhich algorithm would you like to run:");
        var algorithmName = Console.ReadLine();
        var algorithm = AlgorithmFactory.GetAlgorithm(algorithmName);

        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var before = GC.GetTotalMemory(false);

        algorithm.Run();

        var after = GC.GetTotalMemory(false);
        stopwatch.Stop();


        Console.WriteLine($"Execution completed without errors: Mem {after - before} bytes. Time: {stopwatch.ElapsedMilliseconds} ms");
    }
}