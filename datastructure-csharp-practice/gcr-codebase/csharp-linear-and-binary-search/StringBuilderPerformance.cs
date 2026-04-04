using System;
using System.Diagnostics;
using System.Text;

class StringBuilderPerformance
{
    static void Main(string[] args)
    {
        const int iterations = 100000;

        // ---------------- String Concatenation ----------------
        Stopwatch swString = new Stopwatch();
        swString.Start();

        string result = "";
        for (int i = 0; i < iterations; i++)
        {
            result += "Hello";
        }

        swString.Stop();
        Console.WriteLine($"String concatenation time: {swString.ElapsedMilliseconds} ms");

        // ---------------- StringBuilder ----------------
        Stopwatch swBuilder = new Stopwatch();
        swBuilder.Start();

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < iterations; i++)
        {
            sb.Append("Hello");
        }

        string finalResult = sb.ToString();

        swBuilder.Stop();
        Console.WriteLine($"StringBuilder time: {swBuilder.ElapsedMilliseconds} ms");
    }
}