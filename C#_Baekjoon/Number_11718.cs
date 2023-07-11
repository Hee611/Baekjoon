using System;

namespace Number_11718
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr;
            int cnt = 0;
            while (cnt < 100)
            {
                Console.WriteLine(inputStr = Console.ReadLine());
                if (inputStr == " ")
                    break;
                cnt++;
            }
            //Console.ReadKey();
        }
    }
}