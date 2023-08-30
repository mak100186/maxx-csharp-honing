using System.Reflection;

using Maxx.CSharp.Honing.Algorithms;

namespace Maxx.CSharp.Honing;

public static class AlgorithmFactory
{
    public static List<string> ExistingAlgorithms = 
        GetTypesInNamespace(Assembly.GetExecutingAssembly(), "Maxx.CSharp.Honing.Algorithms")
        .Select(t => t.Name)
        .ToList();

    public static IAlgorithm GetAlgorithm(string algorithmName)
    {
        var types = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "Maxx.CSharp.Honing.Algorithms");
        var type = types.Single(t => t.Name == algorithmName);

        return (IAlgorithm)Activator.CreateInstance(type);
    }

    private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
    {
        return 
            assembly.GetTypes()
                .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                .ToArray();
    }
}