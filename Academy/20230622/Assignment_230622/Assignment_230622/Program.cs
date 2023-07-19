using System;

namespace Assignment_230622
{
    class Program
    {
        static void Main(string[] args)
        {
            int sm = 0;
            double pt = 0;

            Console.Write("집의 면접(제곱미터)를 입력하세요 : ");
            
            sm = int.Parse(Console.ReadLine());
            pt = (sm / 3.3058);
            
            Console.WriteLine("당신의 집은 {0:F1} 평입니다.", pt);

            if (pt > 34)
            {
                Console.WriteLine("부자시군요!!");
            } else if(pt < 10)
            {
                Console.WriteLine("서민이시군요..");
            }

            Console.ReadKey();
        }
    }
}
