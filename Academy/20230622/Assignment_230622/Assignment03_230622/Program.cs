using System;
using System.Text.RegularExpressions;

namespace Assignment03_230622
{
    class Program
    {
        static void Main(string[] args)
        {

            #region [정규식]
            //Regex ko = new Regex(@"[가-힣ㄱ-ㅎㅏ-ㅢ]"),
            //      num = new Regex(@"[0-9]"),
            //      smallEng = new Regex(@"[a-z]"),
            //      bigEng = new Regex(@"[A-Z]"),
            //      specialChar = new Regex(@"[[~!@\#$%^&*\()\=+|\\/:;?""<>_\-,.[\]'{}]"),
            //      exitChar = new Regex(@"[qQㅂ]");

            //string inputString = string.Empty;

            //while (true)
            //{
            //    Console.Write("아무 문자나 입력하세요(q/Q/ㅂ -> 종료) : ");
            //    inputString = Console.ReadLine();

            //    if (exitChar.IsMatch(inputString))
            //    {
            //        Console.WriteLine("종료합니다.");
            //        break;
            //    }
            //    else if (ko.IsMatch(inputString))
            //        Console.WriteLine("입력하신 문자는 한글 입니다.");
            //    else if (num.IsMatch(inputString))
            //        Console.WriteLine("입력하신 문자는 숫자 입니다.");
            //    else if (smallEng.IsMatch(inputString))
            //        Console.WriteLine("입력하신 문자는 소문자 입니다.");
            //    else if (bigEng.IsMatch(inputString))
            //        Console.WriteLine("입력하신 문자는 대문자 입니다.");
            //    else if (specialChar.IsMatch(inputString))
            //        Console.WriteLine("입력하신 문자는 특수문자 입니다.");
            //    else
            //        Console.WriteLine("입력하신 문자가 없습니다.");
            //}
            #endregion [정규식]

            char inputChar;
            int ch = 0;

            while (true)
            {
                Console.Write("아무 문자나 입력하세요(q/Q/ㅂ -> 종료) : ");
                inputChar = char.Parse(Console.ReadLine());

                ch = (int)inputChar;
                //Console.WriteLine(exit);

                if (ch == 81 || ch == 113 || ch == 12610)
                {
                    Console.WriteLine("종료합니다.");
                    break;
                }
                else if (ch >= 48 && ch <= 57)
                    Console.WriteLine("입력하신 문자는 숫자입니다.");
                else if (ch >= 65 && ch <= 90)
                    Console.WriteLine("입력하신 문자는 대문자입니다.");
                else if (ch >= 97 && ch <= 122)
                    Console.WriteLine("입력하신 문자는 소문자입니다.");
                else if (ch >= 33 && ch <= 47 || ch >= 58 && ch <= 64 || ch >= 91 && ch <= 96 || ch >= 123 && ch <= 126)
                    Console.WriteLine("입력하신 문자는 특수문자입니다.");
                else if (ch >= 44032 && ch <= 55175)
                    Console.WriteLine("입력하신 문자는 한글입니다.");
            }

                Console.ReadKey();

        }
    }
}
