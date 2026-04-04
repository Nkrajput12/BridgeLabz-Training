public class Solution
{
    public bool IsValid(string s)
    {
        int n = s.Length;
        if (n % 2 != 0) return false;  // Odd length means it can't be valid

        char[] stack = new char[n];  // Use an array instead of Stack<char>
        int top = -1;  // Pointer for stack index

        foreach (char c in s)
        {
            switch (c)
            {
                case '(':
                case '[':
                case '{':
                    stack[++top] = c;  // Push to array
                    break;
                case ')':
                    if (top < 0 || stack[top--] != '(') return false;
                    break;
                case ']':
                    if (top < 0 || stack[top--] != '[') return false;
                    break;
                case '}':
                    if (top < 0 || stack[top--] != '{') return false;
                    break;
            }
        }

        return top == -1;
    }
}