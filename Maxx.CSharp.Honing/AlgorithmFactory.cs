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
    
    private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
    {
        return
            assembly.GetTypes()
                .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                .Where(t => t is { IsClass: true, IsPublic: true, IsNested: false })
                .ToArray();
    }
}