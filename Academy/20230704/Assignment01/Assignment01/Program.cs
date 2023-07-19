using System;

namespace Assignment01
{
    class Program
    {
        static void Main(string[] args)
        {
            int dan = 0;

            while (true)
            {
                Console.Write("단수를 입력하세요(2~9) : ");
                dan = int.Parse(Console.ReadLine());

                if(dan < 2 || dan > 9)
                    Console.WriteLine("2 ~ 9단까지의 단수만 입력이 가능합니다. 다시 입력해 주세요.");
                else
                {
                    MultiplicationCalculator(dan);
                    break;
                }
            }


            Console.ReadKey();
        }

        static void MultiplicationCalculator(int dan)
        {
            if (dan < 2 || dan > 9)
                Console.WriteLine("2 ~ 9단까지의 단수만 입력이 가능합니다. 다시 입력해 주세요.");
            else
            {
                for (int num = 1; num < 10; num++)
                {
                    Console.Write("{0} X {1} = {2}", dan, num, dan * num);
                    if (num % 3 == 0)
                        Console.Write("\n");
                    else
                        Console.Write("\t");
                }
            }
        }
    }
}
