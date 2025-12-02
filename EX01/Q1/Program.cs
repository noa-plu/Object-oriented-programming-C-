// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;

namespace Ex1
{
    struct PointStruct
    {
        public int X;
        public int Y;
    }

    class PointClass
    {
        public int X;
        public int Y;
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            //1
            //א
            //a
            Console.WriteLine("== השמה בין משתנים ==");

            PointClass pc1 = new PointClass { X = 1, Y = 2 };
            PointClass pc2 = pc1;   // העתקת רפרנס
            pc2.X = 100;

            Console.WriteLine($"PointClass: pc1.X={pc1.X}, pc1.Y={pc1.Y}, pc2.X={pc2.X}, pc2.Y={pc2.Y}");

            PointStruct ps1 = new PointStruct { X = 1, Y = 2 };
            PointStruct ps2 = ps1;  // העתקת ערך
            ps2.X = 100;

            Console.WriteLine($"PointStruct: ps1.X={ps1.X}, ps1.Y={ps1.Y}, ps2.X={ps2.X}, ps2.Y={ps2.Y}");
            
            //b
            Console.WriteLine("\n== העברה לפונקציות ==");

            PointClass pc3 = new PointClass { X = 5, Y = 5 };
            PointStruct ps3 = new PointStruct { X = 5, Y = 5 };

            ChangeClass(pc3);
            ChangeStruct(ps3);

            Console.WriteLine($"לאחר ChangeClass: pc3.X={pc3.X}, pc3.Y={pc3.Y}");
            Console.WriteLine($"לאחר ChangeStruct: ps3.X={ps3.X}, ps3.Y={ps3.Y}");

            //ב
            Console.WriteLine("\n== שינוי struct בעזרת ref ==");

            ChangeStructByRef(ref ps3);
            Console.WriteLine($"לאחר ChangeStructByRef: ps3.X={ps3.X}, ps3.Y={ps3.Y}");
        }

        static void ChangeClass(PointClass p)
        {
            p.X += 10;   // משנה את אותו אובייקט – reference type
        }

        static void ChangeStruct(PointStruct p)
        {
            p.X += 10;   // משנה עותק מקומי – value type
        }

        static void ChangeStructByRef(ref PointStruct p)
        {
            p.X += 10;   // עכשיו זה משנה את המשתנה המקורי
        }
    }
    }