// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
static void Swap(int[] arr, int i, int j)
{
    int temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
}


static void SwapG<T>(ref T x, ref T y)
{
    T temp = x;
    x = y;
    y = temp;
}

//static void Main()
//{
    int[] arr = { 5, 3, 8, 4, 2 };
    Console.WriteLine("לפני החלפה: " + string.Join(", ", arr));
    Swap(arr, 1, 3);
    Console.WriteLine("אחרי החלפה: " + string.Join(", ", arr));
    Console.ReadLine();


    int x = 5, y = 10;
    SwapG(ref x, ref y);

    string s1 = "hello", s2 = "world";
    SwapG(ref s1, ref s2);


    int[] arr1 = { 1, 2, 3, 4 };
    SwapG(ref arr[0], ref arr[3]); // מחליף בין arr[0] ל-arr[3]


//}


