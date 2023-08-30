using BenchmarkDotNet.Attributes;

namespace Maxx.CSharp.Honing.Algorithms;

public class IsSubsequence
{
    [Benchmark]
    [Arguments("abc", "ahbgdc")]
    [Arguments("axc", "ahbgdc")]
    public bool Execute(string s, string t)
    {
        if (s.Length == 0)
        {
            return true;
        }

        if (t.Length < s.Length)
        {
            return false;
        }

        for (short i = 0, j = 0; i < t.Length; i++)
        {
            if (t[i] == s[j]) j++;

            if (j == s.Length) return true;
        }
        return false;
    }
}