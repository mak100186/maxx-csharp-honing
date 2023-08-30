using BenchmarkDotNet.Attributes;

namespace Maxx.CSharp.Honing.Algorithms;
public class TopKFrequentElements
{
    public IEnumerable<object[]> Data()
    {
        yield return new object[] { new[] { 1, 1, 1, 2, 2, 3 }, 2 };
        yield return new object[] { new[] { 3, 1, 4, 2, 2, 3 }, 2 };
        yield return new object[] { new[] { 1 }, 2 };
    }

    [Benchmark]
    [ArgumentsSource(nameof(Data))]
    public int[] Execute(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var x = nums[i];

            if (dict.ContainsKey(x))
            {
                dict[x] += 1;
            }
            else
            {
                dict.Add(x, 1);
            }
        }

        var count = k >= dict.Count ? dict.Count : k;
        return dict.OrderByDescending(x => x.Value).Take(count).Select(x => x.Key).ToArray();
    }
}
