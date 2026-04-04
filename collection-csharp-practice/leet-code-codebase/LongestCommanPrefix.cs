public class Solution
{

    public string LongestCommonPrefix(string[] strs)
    {
        // Initialize an empty string to store the longest common prefix.
        string s = "";

        // Iterate through each character position in the first string (strs[0]).
        for (int i = 0; i < strs[0].Length; i++)
        {
            // Iterate through the other strings starting from index 1.
            for (int j = 1; j < strs.Length; j++)
            {

                if (i >= strs[j].Length || strs[j][i] != strs[0][i])
                {
                    // Return the current prefix as the result.
                    return s;
                }
            }
            // Append the current character to the common prefix.
            s += strs[0][i];
        }

        // Return the final common prefix.
        return s;
    }
}