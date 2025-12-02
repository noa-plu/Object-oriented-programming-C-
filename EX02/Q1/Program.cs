using System;

class Program
{
    static void Main()
    {
        long size = 1_000_000; // עדיף long
        long [] arr = null;

        while (true)
        {
            try
            {
                arr = new long[size];
                Console.WriteLine($"הצלחתי להקצות מערך בגודל: {size}");

                checked   // אם הפרויקט מסומן כ-checked זה גם כך checked
                {
                    size *= 2; // כאן יכולה להיות גלישה
                }
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine($"נכשל בהקצאת מערך בגודל: {size} (OutOfMemory)");
                break;
            }
            catch (OverflowException)
            {
                Console.WriteLine($"size גלש מטווח הטיפוס (Overflow), size={size}");
                break;
            }
        }

        Console.WriteLine("סיום.");
        Console.ReadLine();
    }
}
