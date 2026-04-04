using System;
using System.Diagnostics; // Required for Stopwatch
using System.IO;          // Required for File operations

class BufferStream
{
    static void Main()
    {
        string sourceFile = "C:\\Users\nkr88\\OneDrive\\Desktop\file.txt";
        string destination = "C:\\Users\nkr88\\OneDrive\\Desktop\\Destination.txt";
        int bufferSize = 4096; // 4KB chunks

        // Create a fake 100MB file to test with
        Console.WriteLine("Creating a 100MB test file... please wait.");
        byte[] dummyData = new byte[1024 * 1024]; // 1MB array
        using (FileStream fs = File.Create(sourceFile))
        {
            for (int i = 0; i < 100; i++) fs.Write(dummyData, 0, dummyData.Length);
        }

        //Measure Normal FileStream
        Stopwatch sw = new Stopwatch();
        sw.Start();
        CopyNormal(sourceFile, destination, bufferSize);
        sw.Stop();
        Console.WriteLine($"Normal FileStream took: {sw.ElapsedMilliseconds} ms");

        //  Measure BufferedStream
        sw.Restart();
        CopyBuffered(sourceFile, destination, bufferSize);
        sw.Stop();
        Console.WriteLine($"BufferedStream took: {sw.ElapsedMilliseconds} ms");
    }

    // Normal Stream
    static void CopyNormal(string source, string dest, int size)
    {
        using (FileStream fsIn = new FileStream(source, FileMode.Open))
        using (FileStream fsOut = new FileStream(dest, FileMode.Create))
        {
            byte[] buffer = new byte[size];
            int bytesRead;
            while ((bytesRead = fsIn.Read(buffer, 0, buffer.Length)) > 0)
            {
                fsOut.Write(buffer, 0, bytesRead);
            }
        }
    }

    // METHOD 2: Buffered Stream
    static void CopyBuffered(string source, string dest, int size)
    {
        using (FileStream fsIn = new FileStream(source, FileMode.Open))
        using (FileStream fsOut = new FileStream(dest, FileMode.Create))
        // We wrap the FileStream inside a BufferedStream
        using (BufferedStream bsIn = new BufferedStream(fsIn))
        using (BufferedStream bsOut = new BufferedStream(fsOut))
        {
            byte[] buffer = new byte[size];
            int bytesRead;
            while ((bytesRead = bsIn.Read(buffer, 0, buffer.Length)) > 0)
            {
                bsOut.Write(buffer, 0, bytesRead);
            }
        }
    }
}