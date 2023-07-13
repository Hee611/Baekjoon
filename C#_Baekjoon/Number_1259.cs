using System;

namespace Number_1259
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string inputStrNum = Console.ReadLine();

                int no = 0;
                char[] charNum = inputStrNum.ToCharArray();
                string[] stringNum = new string[charNum.Length];
                string[] reverseNum = new string[charNum.Length];

                for (int i = 0; i < charNum.Length; i++)
                {
                    stringNum[i] += charNum[i];
                    reverseNum[i] += charNum[i];
                }

                Array.Reverse(reverseNum);

                if (inputStrNum == "0")
                    break;
                else
                {
                    for (int i = 0; i < charNum.Length; i++)
                    {
                        if (stringNum[i] != reverseNum[i])
                            no++;
                    }
                }

                if (no > 1)
                    Console.WriteLine("no");
                else
                    Console.WriteLine("yes");
            }
        }
    }
}
// 간단하게 생각하고 간단하게 풀어보도록 노력하기...