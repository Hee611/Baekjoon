using System;

namespace Number_10988
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr = Console.ReadLine();
            char[] reverseStr = new char[inputStr.Length];
            string test = string.Empty;

            for (int i = 0; i < inputStr.Length; i++)
                reverseStr[i] = inputStr[i];

            Array.Reverse(reverseStr);

            for (int i = 0; i < reverseStr.Length; i++)
                test += reverseStr[i];

            if (inputStr == test)
                Console.WriteLine(1);
            else
                Console.WriteLine(0);

            //Console.ReadKey();
        }
    }
}
