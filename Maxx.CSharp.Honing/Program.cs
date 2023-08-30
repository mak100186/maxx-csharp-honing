using System.Diagnostics;

namespace Maxx.CSharp.Honing;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Which algorithm would you like to run:");
        Console.WriteLine(string.Join(',', AlgorithmFactory.ExistingAlgorithms));
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