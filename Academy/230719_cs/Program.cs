using System;

namespace Assignment01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("첫번째 원의 반지름을 입력하세요 : ");
            float one = float.Parse(Console.ReadLine());
            Console.Write("두번째 원의 반지름을 입력하세요 : ");
            float two = float.Parse(Console.ReadLine());
            
            Circle cir = new Circle();

            cir.Calculator(one, two);
            cir.PrintInformation();

            Console.ReadKey();
        }
    }
}
