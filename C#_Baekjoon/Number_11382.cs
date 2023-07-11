using System;

namespace Number_11382
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputNumStr = Console.ReadLine().Split();

            long a = long.Parse(inputNumStr[0]);
            long b = long.Parse(inputNumStr[1]);
            long c = long.Parse(inputNumStr[2]);

            Console.WriteLine(a + b + c);

            //Console.ReadKey();
        }
    }
}