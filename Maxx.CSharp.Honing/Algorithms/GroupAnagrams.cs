using Shouldly;

namespace Maxx.CSharp.Honing.Algorithms;
public class GroupAnagrams : IAlgorithm
{
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

    public void Run()
    {
        Execute(new[] { "eat", "tea", "tan", "ate", "nat", "bat" })
            .ShouldBe(new[] { new[] { "eat", "tea", "ate" }, new[] { "tan", "nat" }, new[] { "bat" } });

        Execute(new[] { "" })
            .ShouldBe(new[] { new[] { "" } });

        Execute(new[] { "a" })
            .ShouldBe(new[] { new[] { "a" } });
    }
}
