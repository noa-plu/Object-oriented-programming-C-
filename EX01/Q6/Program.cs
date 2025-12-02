// See https://aka.ms/new-console-template for more information
using System;

namespace Ex01_Q6
{
    // חלק ב' – structs בגדלים שונים
    struct SmallStruct
    {
        public int X;
    }

    struct MediumStruct
    {
        public int X, Y, Z;
    }

    struct LargeStruct
    {
        public int A, B, C, D, E, F;
    }

    // חלק ג' – מחלקות בגדלים שונים
    class SmallClass
    {
        public int X;
    }

    class LargeClass
    {
        public int A, B, C, D, E, F;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MemoryAllocationExperiment();

            Console.WriteLine();
            Console.WriteLine("לחצי על מקש כלשהו כדי לצאת...");
            Console.ReadKey();
        }

        public static void MemoryAllocationExperiment()
        {

            long baselineMemory = GC.GetAllocatedBytesForCurrentThread();

            // 1. מערך int
            int[] intArray = new int[10000];
            long afterIntArray = GC.GetAllocatedBytesForCurrentThread();

            // 2. מערך double
            double[] doubleArray = new double[10000];
            long afterDoubleArray = GC.GetAllocatedBytesForCurrentThread();

            // 3. מערך string
            string[] stringArray = new string[10000];
            long afterStringArray = GC.GetAllocatedBytesForCurrentThread();

            Console.WriteLine("---- Part A: Primitive arrays ----");
            Console.WriteLine($"Baseline Memory:          {baselineMemory} bytes");
            Console.WriteLine($"Int Array Allocation:     {afterIntArray - baselineMemory} bytes");
            Console.WriteLine($"Double Array Allocation:  {afterDoubleArray - afterIntArray} bytes");
            Console.WriteLine($"String Array Allocation:  {afterStringArray - afterDoubleArray} bytes");
            Console.WriteLine();

            // חלק ב' – מערכים של struct בגדלים שונים
            Console.WriteLine("---- Part B: Struct arrays ----");

            // SmallStruct
            long beforeSmallStruct = GC.GetAllocatedBytesForCurrentThread();
            SmallStruct[] smallStructArray = new SmallStruct[10000];
            long afterSmallStruct = GC.GetAllocatedBytesForCurrentThread();

            // MediumStruct
            long beforeMediumStruct = GC.GetAllocatedBytesForCurrentThread();
            MediumStruct[] mediumStructArray = new MediumStruct[10000];
            long afterMediumStruct = GC.GetAllocatedBytesForCurrentThread();

            // LargeStruct
            long beforeLargeStruct = GC.GetAllocatedBytesForCurrentThread();
            LargeStruct[] largeStructArray = new LargeStruct[10000];
            long afterLargeStruct = GC.GetAllocatedBytesForCurrentThread();

            Console.WriteLine($"SmallStruct[10000] alloc:  {afterSmallStruct - beforeSmallStruct} bytes");
            Console.WriteLine($"MediumStruct[10000] alloc: {afterMediumStruct - beforeMediumStruct} bytes");
            Console.WriteLine($"LargeStruct[10000] alloc:  {afterLargeStruct - beforeLargeStruct} bytes");
            Console.WriteLine("// ככל שה-struct גדול יותר, ההקצאה למערך גדלה בהתאם (value types בתוך המערך).");
            Console.WriteLine();

            // חלק ג' – מערכים של class
            Console.WriteLine("---- Part C: Class arrays ----");

            // קודם רק המערך עצמו (רק רפרנסים, בלי אובייקטים)
            long beforeSmallClassArray = GC.GetAllocatedBytesForCurrentThread();
            SmallClass[] smallClassArray = new SmallClass[10000];
            long afterSmallClassArray = GC.GetAllocatedBytesForCurrentThread();

            long beforeLargeClassArray = GC.GetAllocatedBytesForCurrentThread();
            LargeClass[] largeClassArray = new LargeClass[10000];
            long afterLargeClassArray = GC.GetAllocatedBytesForCurrentThread();

            Console.WriteLine("** Arrays of references only (no objects yet):");
            Console.WriteLine($"SmallClass[10000] array (refs): {afterSmallClassArray - beforeSmallClassArray} bytes");
            Console.WriteLine($"LargeClass[10000] array (refs): {afterLargeClassArray - beforeLargeClassArray} bytes");
            Console.WriteLine("// כאן ההקצאה דומה – המערך עצמו מכיל רק רפרנסים, ללא קשר לגודל המחלקה.");
            Console.WriteLine();

            // עכשיו נאתחל את כל האיברים עם new – יצירת האובייקטים עצמם
            long beforeSmallClassObjects = GC.GetAllocatedBytesForCurrentThread();
            for (int i = 0; i < smallClassArray.Length; i++)
            {
                smallClassArray[i] = new SmallClass();
            }
            long afterSmallClassObjects = GC.GetAllocatedBytesForCurrentThread();

            long beforeLargeClassObjects = GC.GetAllocatedBytesForCurrentThread();
            for (int i = 0; i < largeClassArray.Length; i++)
            {
                largeClassArray[i] = new LargeClass();
            }
            long afterLargeClassObjects = GC.GetAllocatedBytesForCurrentThread();

            Console.WriteLine("** Now allocating the actual objects:");
            Console.WriteLine($"10000 x SmallClass objects: {afterSmallClassObjects - beforeSmallClassObjects} bytes");
            Console.WriteLine($"10000 x LargeClass objects: {afterLargeClassObjects - beforeLargeClassObjects} bytes");
            Console.WriteLine("// כאן רואים שהקצאת האובייקטים עצמם כבר תלויה בגודל המחלקה.");
        }
    }
}
