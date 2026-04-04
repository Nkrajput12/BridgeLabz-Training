using System;
using System.Diagnostics;

class FibonacciComparison
{
    static void Main(string[]args)
    {
        int n = 35; // 
        Console.WriteLine($"Computing Fibonacci({n}):\n");

        // --- Iterative Approach ---
        Stopwatch sw = Stopwatch.StartNew();
        long iterativeResult = FibonacciIterative(n);
        sw.Stop();
        Console.WriteLine($"Iterative (O(N)): {iterativeResult} | Time: {sw.Elapsed.TotalMilliseconds}ms");

        // --- Recursive Approach ---
        Console.WriteLine("Recursive (O(2^N)) starting...");
        sw.Restart();
        long recursiveResult = FibonacciRecursive(n);
        sw.Stop();
        Console.WriteLine($"Recursive:        {recursiveResult} | Time: {sw.Elapsed.TotalMilliseconds}ms");
    }

    public static long FibonacciRecursive(int n)
    {
        if (n <= 1) return n;
        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    public static long FibonacciIterative(int n)
    {
        if (n <= 1) return n;
        long a = 0, b = 1, sum = 0;
        for (int i = 2; i <= n; i++)
        {
            sum = a + b;
            a = b;
            b = sum;
        }
        return b;
    }
}