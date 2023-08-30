using BenchmarkDotNet.Attributes;

namespace Maxx.CSharp.Honing.Algorithms;
public class FindMedianSortedArrays
{
    [Benchmark]
    [Arguments(new[] { 1, 3 }, new[] { 2 })]
    [Arguments(new[] { 1, 3 }, new[] { 2, 4 })]
    public double Execute(int[] front, int[] back)
    {
        int[] combined = new int[front.Length + back.Length];
        Array.Copy(front, combined, front.Length);
        Array.Copy(back, 0, combined, front.Length, back.Length);

        Array.Sort(combined);

        if (combined.Length == 1)
        {
            return combined[0];
        }

        if (combined.Length % 2 == 0) //even
        {
            var leftIndex = combined.Length / 2 - 1;
            var rightIndex = combined.Length / 2;

            return (combined[leftIndex] + combined[rightIndex]) / 2.0f;
        }
        else
        {
            var midIndex = (combined.Length - 1) / 2;
            return combined[midIndex];
        }
    }
}
