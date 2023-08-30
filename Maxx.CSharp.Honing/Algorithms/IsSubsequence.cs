using Shouldly;

namespace Maxx.CSharp.Honing.Algorithms;

public class IsSubsequence : IAlgorithm
{
    public void Run()
    {
        Execute("abc", "ahbgdc").ShouldBe(true);
        Execute("axc", "ahbgdc").ShouldBe(false);
    }

    private bool Execute(string s, string t)
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