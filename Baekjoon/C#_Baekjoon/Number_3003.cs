using System;

namespace Number_3003
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] chess = new int[] { 1, 1, 2, 2, 2, 8 };
            string[] inputNum = Console.ReadLine().Split(new char[] { ' ' });
            int[] myNum = new int[6];

            for(int i = 0; i < inputNum.Length; i++)
                myNum[i] = int.Parse(inputNum[i]);

            for (int i = 0; i < inputNum.Length; i++)
            {
                Console.Write(chess[i] - myNum[i]);
                if (i != myNum.Length - 1)
                    Console.Write(" ");
            }
            //Console.ReadKey();
        }
    }
}