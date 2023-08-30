using Maxx.CSharp.Honing.Algorithms;

namespace Maxx.CSharp.Honing;

public static class AlgorithmFactory
{
    public static List<string> ExistingAlgorithms = new() { nameof(IsSubsequence) };
    public static IAlgorithm GetAlgorithm(string algorithmName)
    {
        return algorithmName switch
        {
            nameof(IsSubsequence) => new IsSubsequence(),
            _ => throw new NotImplementedException(),
        };
    }
}