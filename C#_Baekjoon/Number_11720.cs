using System;

namespace Number_11720
{
    class Program
    {
        static void Main(string[] args)
        {
            // 푸는중..
            int count = int.Parse(Console.ReadLine());
            int tmp = 0;

            string[] stringNum = new string[count];
            char[] charNum = new char[count];

            for (int i = 0; i < count; i++)
            {
                stringNum[i] = Console.ReadLine();
            }
            for (int i = 0; i < count; i++)
            {
                charNum[i] += char.Parse(stringNum[i]);
            }

            int[] sumArr = new int[count];

            for (int i = 0; i < sumArr.Length; i++)
            {
                sumArr[i] = 
                tmp += sumArr[i];
            }

            Console.WriteLine(tmp);

            Console.ReadKey();
        }
    }
}
