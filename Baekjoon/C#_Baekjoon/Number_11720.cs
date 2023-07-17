using System;

namespace Number_11720
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int tmp = 0;

            string stringNum = Console.ReadLine();
            char[] charNum = stringNum.ToCharArray();
            int[] intNum = new int[count];

            for (int i = 0; i < count; i++)
            {
                intNum[i] = charNum[i] - '0';
                tmp += intNum[i];
            }

            Console.WriteLine(tmp);

            //Console.ReadKey();
        }
    }
}
