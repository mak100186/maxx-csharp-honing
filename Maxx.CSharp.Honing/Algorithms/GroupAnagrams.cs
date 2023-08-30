using BenchmarkDotNet.Attributes;

namespace Maxx.CSharp.Honing.Algorithms;
public class GroupAnagrams
{
    public IEnumerable<object[]> Data()
    {
        yield return new object[] { new[] { "eat", "tea", "tan", "ate", "nat", "bat" } };
        yield return new object[] { new[] { "" } };
        yield return new object[] { new[] { "a" } };
    }
    
    [Benchmark]
    [ArgumentsSource(nameof(Data))]
    public IList<IList<string>> Execute(string[] strs)
    {
        var dictionary = new Dictionary<string, IList<string>>();

        foreach (var str in strs)
        {
            var charArray = str.ToCharArray();
            Array.Sort(charArray);
            var key = new string(charArray);

            if (dictionary.ContainsKey(key))
            {
                dictionary[key].Add(str);
            }
            else
            {
                dictionary.Add(key, new List<string>() { str });
            }
        }

        return dictionary.Values.ToList();
    }
}
