using System.Reflection;

namespace Maxx.CSharp.Honing;

public static class AlgorithmFactory
{
    public static IEnumerable<Type> AllAlgorithmTypes =
        GetTypesInNamespace(Assembly.GetExecutingAssembly(), "Maxx.CSharp.Honing.Algorithms");

    public static IEnumerable<string> AllAlgorithmNames =
        AllAlgorithmTypes.Select(t => t.Name);

    public static Type GetAlgorithmTypeByName(string algorithmName)
    {
        return AllAlgorithmTypes.Single(t => t.Name == algorithmName);
    }

    public static IAlgorithm GetAlgorithm(string algorithmName)
    {
        return (IAlgorithm)Activator
            .CreateInstance(GetAlgorithmTypeByName(algorithmName));
    }

    private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
    {
        return
            assembly.GetTypes()
                .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                .ToArray();
    }
}