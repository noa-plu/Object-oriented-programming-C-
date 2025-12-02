// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;

namespace Q7_RecursionStack
{
    struct PointStruct
    {
        public int X;
        public int Y;
    }

    internal class Program
    {
        static int counter = 0;

        static void Recursion()
        {
            int[] arr = new int[10];
            //int[] arr = new int[100];
            //int[] arr = new int[10000];

            PointStruct p1, p2, p3, p4;
            PointStruct p5, p6, p7, p8;

            counter++;
            Console.WriteLine($"counter={counter}");
            Recursion(); 
        }

        static void Main(string[] args)
        {
            Recursion();
        }
    }
}

