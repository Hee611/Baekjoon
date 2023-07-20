using System;

namespace Assignment02_230622
{
    class Program
    {
        static void Main(string[] args)
        {
            int repeat = 0, insertNum = 0, maxNum = 0, minNum = 0;

            Console.Write("반복 횟수를 입력하세요 : ");
            repeat = int.Parse(Console.ReadLine());

            for(int num = 1; num < repeat + 1; num++)
            {
                insertNum = int.Parse(Console.ReadLine());
                Console.WriteLine("{0}번 정수 : {1}", num, insertNum);

                if (insertNum > maxNum)
                    maxNum = insertNum;
                else if (insertNum < minNum)
                    minNum = insertNum;
            }

            Console.WriteLine("입력한 수 중 가장 큰 수는 {0}입니다.", maxNum);
            Console.WriteLine("입력한 수 중 가장 작은 수는 {0}입니다.", minNum);

            Console.ReadKey();
        }
    }
}
