using System;

namespace baekjoon_2754 {
    class Program {
        static void Main(string[] args) {
            string score = Console.ReadLine();

            switch(score) {
                case "A+":
                    Console.Write("4.3");
                    break;
                case "A0":
                    Console.Write("4.0");
                    break;
                case "A-":
                    Console.Write("3.7");
                    break;
                case "B+":
                    Console.Write("3.3");
                    break;
                case "B0":
                    Console.Write("3.0");
                    break;
                case "B-":
                    Console.Write("2.7");
                    break;
                case "C+":
                    Console.Write("2.3");
                    break;
                case "C0":
                    Console.Write("2.0");
                    break;
                case "C-":
                    Console.Write("1.7");
                    break;
                case "D+":
                    Console.Write("1.3");
                    break;
                case "D0":
                    Console.Write("1.0");
                    break;
                case "D-":
                    Console.Write("0.7");
                    break;
                default:
                    Console.Write("0.0");
                    break;
            }

            //Console.ReadKey();
        }
    }
}