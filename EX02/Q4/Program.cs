// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    const int N = 50_000_000;
    static int[] arr = new int[N];

    static void Main()
    {
        for (int i = 0; i < N; i++)
            arr[i] = i;

        Console.WriteLine("מצב א: כל thread עובד על חצי מערך נפרד");
        RunTest(separateRegions: true);

        Console.WriteLine();
        Console.WriteLine("מצב ב: שני threads עוברים על כל המערך");
        RunTest(separateRegions: false);
        RunTest(separateRegions: false);

        Console.ReadLine();
    }

    static void RunTest(bool separateRegions)
    {
        long sum1 = 0, sum2 = 0;
        var sw = Stopwatch.StartNew();

        Thread t1, t2;

        if (separateRegions)
        {
            t1 = new Thread(() =>
            {
                for (int i = 0; i < N / 2; i++)
                    sum1 += arr[i];
            });

            t2 = new Thread(() =>
            {
                for (int i = N / 2; i < N; i++)
                    sum2 += arr[i];
            });
        }
        else
        {
            t1 = new Thread(() =>
            {
                for (int i = 0; i < N; i += 2)
                    sum1 += arr[i];
            });

            t2 = new Thread(() =>
            {
                for (int i = 1; i < N; i += 2)
                    sum2 += arr[i];
            });
        }

        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();

        sw.Stop();
        Console.WriteLine($"זמן ריצה: {sw.ElapsedMilliseconds} ms, sum={sum1 + sum2}");
    }
}

