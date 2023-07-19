using System;

namespace Assignment01_230613
{
    class Program
    {
        static void Main(string[] args)
        {
            #region [1]
            //Console.Write("출생년도를 입력하세요 : ");
            //// 출생년도 입력 받기
            //int year = int.Parse(Console.ReadLine());

            //// 현재 날짜 구하기
            //DateTime today = DateTime.Today;

            //// 현재 날짜의 년도와 입력한 년도를 빼기
            //int age = today.Year - year;

            //Console.WriteLine("당신의 나이는 {0}세 입니다.", age);
            #endregion [1]

            #region [no]
            //Console.Write("출생년도를 입력하세요 : ");

            //int year = int.Parse(Console.ReadLine());

            //Console.WriteLine("당신의 나이는 {0}세 입니다.", 2023 - year);
            #endregion [no]

            #region [2] 
            Console.Write("기준이 되는 정수를 입력하세요 : ");
            // 정수 입력 받기
            int number = int.Parse(Console.ReadLine());

            Console.Write("이동시킬 횟수를 입력하세요 : ");
            // 이동시킬 횟수 입력 받기
            int move = int.Parse(Console.ReadLine());

            // move가 5보다 크다면 << 를 출력
            // move가 5보다 크지 않다면 >> 를 출력
            string sign = move > 5 ? "<<" : ">>";

            // move가 5보다 크다면 number << move를 출력
            // move가 5보다 크지 않다면 number >> move를 출력
            int result = move > 5 ? number << move : number >> move;

            // move가 5보다 클 때 결과 화면 : number << move = 결과값
            // move가 5보다 크지 않을 때 결과 화면 : number >> move = 결과값
            Console.WriteLine("{0} {1} {2} = {3}", number, sign, move, result);

            #endregion [2]

            Console.ReadKey();
        }
    }
}
