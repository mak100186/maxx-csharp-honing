using BenchmarkDotNet.Attributes;

namespace Maxx.CSharp.Honing.Algorithms;

/*
You are given a 0-indexed integer array nums. You have to partition the array into one or more contiguous subarrays.

We call a partition of the array valid if each of the obtained subarrays satisfies one of the following conditions:

The subarray consists of exactly 2, equal elements. For example, the subarray [2,2] is good.
The subarray consists of exactly 3, equal elements. For example, the subarray [4,4,4] is good.
The subarray consists of exactly 3 consecutive increasing elements, that is, the difference between adjacent elements is 1. For example, the subarray [3,4,5] is good, but the subarray [1,3,5] is not.
Return true if the array has at least one valid partition. Otherwise, return false.

 

Example 1:

Input: nums = [4,4,4,5,6]
Output: true
Explanation: The array can be partitioned into the subarrays [4,4] and [4,5,6].
This partition is valid, so we return true.
Example 2:

Input: nums = [1,1,1,2]
Output: false
Explanation: There is no valid partition for this array.
 

Constraints:

2 <= nums.length <= 105
1 <= nums[i] <= 106

 */
public class GetValidPartitionsFromArray
{
    [Benchmark]
    [Arguments(new[] { 4, 4, 4, 5, 6 })]
    [Arguments(new[] { 1, 1, 1, 2 })]
    public bool Execute(int[] num)
    {
        var iterator = 0;

        while (true)
        {
            if (iterator >= num.Length)
            {
                break;
            }

            //slice of 2
            if (Check2(num, iterator) == Result.None)
            {
                //slice of 3
                if (Check3(num, iterator) == Result.None)
                {
                    return false;
                }
                else
                {
                    //matched
                    iterator += 3;
                }
            }
            else
            {
                //matched
                iterator += 2;
            }
        }

        return true;
    }

    private Result Check2(int[] num, int startingIndex)
    {
        return startingIndex + 1 >= num.Length
            ? Result.None
            : num[startingIndex] == num[startingIndex + 1]
                ? Result.TwoEqual
                : Result.None;
    }
    private Result Check3(int[] num, int startingIndex)
    {
        return startingIndex + 2 >= num.Length
            ? Result.None
            : num[startingIndex] == num[startingIndex + 1] && num[startingIndex + 1] == num[startingIndex + 2]
                ? Result.ThreeEqual
                : num[startingIndex + 1] - num[startingIndex] == 1 && num[startingIndex + 2] - num[startingIndex + 1] == 1
                    ? Result.Consecutive
                    : Result.None;
    }
    

    private enum Result
    {
        None, 
        TwoEqual,
        ThreeEqual,
        Consecutive
    }

    private Result IsAnyConditionTrue(int[] num, int startingIndex)
    {
        if (startingIndex + 1 >= num.Length)
        {
            return Result.None;
        }

        if (num[startingIndex] == num[startingIndex + 1])
        {
            return Result.TwoEqual;
        }

        if (startingIndex + 2 >= num.Length)
        {
            return Result.None;
        }

        if (num[startingIndex] == num[startingIndex + 1] && num[startingIndex + 1] == num[startingIndex + 2])
        {
            return Result.ThreeEqual;
        }

        if (num[startingIndex + 1] - num[startingIndex] == 1 && num[startingIndex + 2] - num[startingIndex + 1] == 1)
        {
            return Result.Consecutive;
        }

        return Result.None;
    }
    //private bool Is2Equal(int[] num, int startingIndex)
    //{
    //    if (startingIndex + 1 >= num.Length)
    //    {
    //        return false;
    //    }

    //    return num[startingIndex] == num[startingIndex + 1];
    //}

    //private bool Is3Equal(int[] num, int startingIndex)
    //{
    //    if (startingIndex + 2 >= num.Length)
    //    {
    //        return false;
    //    }

    //    return num[startingIndex] == num[startingIndex + 1] && num[startingIndex + 1] == num[startingIndex + 2];
    //}

    //private bool IsNext3Consecutive(int[] num, int startingIndex)
    //{
    //    if (startingIndex + 2 >= num.Length)
    //    {
    //        return false;
    //    }

    //    return num[startingIndex + 1] - num[startingIndex] == 1 && num[startingIndex + 2] - num[startingIndex + 1] == 1;
    //}
}

public static class Extensions
{
    public static T[] Slice<T>(this T[] source, int index, int length)
    {       
        T[] slice = new T[length];
        Array.Copy(source, index, slice, 0, length);
        return slice;
    }
}