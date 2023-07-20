using System;

namespace Assignment01_230626 {
    class Program {
        static Random _rd = new Random();
        static void Main(string[] args) {
            // 변수 선언
            int scoreCnt = 0, maxScore = 0, minScore = 0, totalScore = 0, minCnt = 0;
            float avgNum = 0;

            // 입력
            Console.Write("몇개의 점수를 저장하시겠습니까 : ");
            scoreCnt = int.Parse(Console.ReadLine());

            Console.Write("최소 점수를 입력하세요 : ");
            minScore = int.Parse(Console.ReadLine());

            Console.Write("최대 점수를 입력하세요 : ");
            maxScore = int.Parse(Console.ReadLine());

            // 배열 선언
            int[] scoreArr = new int[scoreCnt];

            for (int i = 0; i < scoreArr.Length; i++) {
                scoreArr[i] = _rd.Next(minScore, maxScore);
                totalScore += scoreArr[i];
                Console.WriteLine("{0}번째 점수 : {1}점", i+1, scoreArr[i]);
            }

            avgNum = (float)totalScore / scoreCnt;

            string text = "";
            // 평균보다 작은 수
            for (int n = 0; n < scoreArr.Length; n++) {
                if (avgNum > scoreArr[n]) {
                    if (text == "") {
                        text += string.Format("{0}번째", n+1);
                    } else {
                        text += string.Format(", {0}번째", n+1);
                    }
                    minCnt++;
                }
            }

            // 1.
            Console.WriteLine("1. 평균 점수는 {0:F1}점이고, 평균점수보다 작은 점수는 {1}개 입니다.", avgNum, minCnt);

            // 2.
            Console.WriteLine("\n2. 평균 점수는 {0:F1}점입니다.", avgNum);
            Console.WriteLine(text);
            Console.WriteLine("평균 점수보다 작은 점수는 {0}개 입니다.", minCnt);

            Console.ReadKey();
        }
    }
}
