using System;

namespace Number_1152
{
    class Program
    {
        static void Main(string[] args)
        {
            string myStr = Console.ReadLine().Trim();
            string[] arrStr = myStr.Split();
            int length = arrStr.Length;
            
            if (arrStr[0] == "")
                length--;
            else if (arrStr[arrStr.Length - 1] == "")
                length--;

            Console.WriteLine(length);

            //Console.ReadKey();
        }
    }
}