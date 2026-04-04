public class Solution
{
    public int LengthOfLastWord(string s)
    {
        int len = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == ' ' && len > 0)
                return len;
            else if (s[i] != ' ')
                len++;
        }

        return len;
    }
}
