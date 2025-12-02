// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        const int N = 100_000_000;
        int[] arr = new int[N];

        // אתחול כדי שהמערך באמת יהיה בזיכרון
        for (int i = 0; i < N; i++)
            arr[i] = i;

        long sum = 0;
        var sw = new Stopwatch();

        // 1. גישה רציפה
        sw.Start();
        for (int i = 0; i < N; i++)
            sum += arr[i];
        sw.Stop();
        Console.WriteLine($"גישה רציפה: {sw.ElapsedMilliseconds} ms, sum={sum}");

        // 2. גישה מרוחקת (stride גדול)
        sum = 0;
        sw.Restart();
        int stride = 1024; // נבקר כל 1024 איברים
        for (int i = 0; i < N; i += stride)
            sum += arr[i];
        sw.Stop();
        Console.WriteLine($"גישה מרוחקת: {sw.ElapsedMilliseconds} ms, sum={sum}");

        Console.ReadLine();
    }
}

