using Shouldly;

namespace Maxx.CSharp.Honing.Algorithms;
public class TopKFrequentElements : IAlgorithm
{
    public void Run()
    {
        Execute(new[] { 1, 1, 1, 2, 2, 3 }, 2).ShouldBe(new[] { 1, 2 });
        Execute(new[] { 1 }, 2).ShouldBe(new[] { 1 });
    }

    public IList<int> Execute(IList<int> nums, int k)
    {
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < nums.Count; i++)
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
        
        var result = new int[count];
        Array.Copy(dict.Keys.ToArray(), 0, result, 0, count);
        return result;
    }
}
