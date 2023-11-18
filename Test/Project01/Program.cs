using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Project01 {
    class Program {
        #region[txt 파일 불러오기]
        static void Main(string[] args) {
            try {
                //string quest = @"C:\\Users\\ncloud24\\Desktop\\My\\Study\\TestProject\\Project01\\문제.txt";
                string quest = @"C:\\Users\\ncloud24\\Desktop\\My\\Study\\TestProject\\Project01\\Data\\Quest.txt";
                //string quest = @"Quest\\Quest.txt";
                string questValue = File.ReadAllText(quest);
                List<string> questionList = new List<string>();
                using(StreamReader reader = new StreamReader(questValue)) {
                    string line;
                    while((line = reader.ReadLine()) != null) {
                        questionList.Add(line);
                    }
                }

                //string view = @"C:\\Users\\ncloud24\\Desktop\\My\\Study\\TestProject\\Project01\\보기.txt";
                string view = @"C:\\Users\\ncloud24\\Desktop\\My\\Study\\TestProject\\Project01\\Data\\View.txt";
                //string view = @"Quest\\View.txt";
                string viewValue = File.ReadAllText(view);
                List<string> viewList = new List<string>();
                using(StreamReader reader = new StreamReader(viewValue)) {
                    string line;
                    while((line = reader.ReadLine()) != null) {
                        viewList.Add(line);
                    }
                }

                //string answer = @"C:\\Users\\ncloud24\\Desktop\\My\\Study\\TestProject\\Project01\\답.txt";
                string answer = @"C:\\Users\\ncloud24\\Desktop\\My\\Study\\TestProject\\Project01\\Data\\Answer.txt";
                //string answer = @"Quest\\Answer.txt";
                string answerValue = File.ReadAllText(answer);
                List<string> answerList = new List<string>();
                using(StreamReader reader = new StreamReader(answerValue)) {
                    string line;
                    while((line = reader.ReadLine()) != null) {
                        answerList.Add(line);
                    }
                }
                #endregion[txt 파일 불러오기]

                bool chkNext = true;
                Random rd = new Random();

                while(chkNext) {
                    int choice = 0;      // 메뉴 선택 번호
                    int questIdxCnt = 0; // 문제 번호 체크
                    int yes = 0, no = 0; // 정답, 오답 체크
                    string my;           // 내가 쓴 답

                    Console.WriteLine("=========================================================");
                    Console.WriteLine("추가된 문제 : 제품 소프트웨어 패키징(필기) / 진위여부 문제 제외");
                    Console.WriteLine("=========================================================");
                    Console.WriteLine("아래에서 원하는 번호를 입력하면 해당 화면으로 넘어갑니다.");
                    Console.WriteLine("=========================================================");
                    Console.WriteLine("1. 문제 풀기");
                    Console.WriteLine("2. 랜덤으로 문제 풀기(중복 있음)");
                    Console.WriteLine("3. 프로그램 종료");
                    Console.WriteLine("=========================================================");
                    Console.Write("선택 : ");
                    // choice 변수에 선택 번호를 저장
                    choice = int.Parse(Console.ReadLine());

                    Console.Clear();

                    switch(choice) {
                        case 1:
                            for(int i = 0; i < questionList.Count; i++) {

                                string viewNum = questionList[i].Substring(questionList[i].Length - 1, 1);

                                if(questionList[i].Contains("[보기]")) {
                                    //Console.WriteLine("viewNum : {0}", viewNum);

                                    string tmp = questionList[i].Replace("[보기]" + viewNum, " \n");

                                    Console.Write("{0}. 문제 : {1}", ++questIdxCnt, tmp);
                                    Console.WriteLine("{0}", viewList[int.Parse(viewNum) - 1].Replace("[들여쓰기]", "\n"));
                                    Console.WriteLine();

                                    Console.Write("답이 뭘까 : ");
                                    my = Console.ReadLine();
                                }
                                else {
                                    Console.WriteLine("{0}. 문제 : {1}", ++questIdxCnt, questionList[i]);
                                    Console.WriteLine();

                                    Console.Write("답이 뭘까 : ");
                                    my = Console.ReadLine();
                                }

                                if(my == answerList[i]) {
                                    yes++;
                                    Console.WriteLine("정답\n확인이 되었다면 아무 키나 눌러서 넘어가세요.");
                                }
                                else {
                                    no++;
                                    Console.WriteLine("틀림 !");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("답 : {0}", answerList[i]);
                                    Console.ResetColor();
                                    Console.WriteLine("확인이 되었다면 아무 키나 눌러서 넘어가세요.");
                                }

                                Console.ReadLine();
                                Console.Clear();
                            }

                            // 문제 마지막 출력 화면
                            Console.WriteLine("정답 수 : {0}, 오답 수 : {1}", yes, no);
                            Console.WriteLine("아무 키를 누르면 메인으로 넘어갑니다.");
                            Console.ReadLine();
                            Console.Clear();
                            yes = 0;
                            no = 0;

                            break;
                        case 2:
                            int randomQ = 0;
                            int questionNum = 0; // 얼만큼 풀거야

                            Console.Write("문제 로테이트 횟수를 정하세요 : ");
                            questionNum = int.Parse(Console.ReadLine());

                            for(int i = 0; i < questionNum; i++) {
                                randomQ = rd.Next(0, questionList.Count);
                                string viewNum = questionList[randomQ].Substring(questionList[randomQ].Length - 1, 1);

                                if(questionList[randomQ].Contains("[보기]")) {
                                    //Console.WriteLine("viewNum : {0}", viewNum);

                                    string tmp = questionList[randomQ].Replace("[보기]" + viewNum, " \n");
                                    //questionList[i] = questionList[i].Substring(0, questionList[i].Length - 4);

                                    Console.Write("{0}. 문제 : {1}", ++questIdxCnt, tmp);
                                    Console.WriteLine("{0}", viewList[int.Parse(viewNum) - 1].Replace("[들여쓰기]", "\n"));
                                    Console.WriteLine();

                                    Console.Write("답이 뭘까 : ");
                                    my = Console.ReadLine();
                                }
                                else {
                                    Console.WriteLine("{0}. 문제 : {1}", ++questIdxCnt, questionList[randomQ]);
                                    Console.WriteLine();

                                    Console.Write("답이 뭘까 : ");
                                    my = Console.ReadLine();
                                }

                                if(my == answerList[randomQ]) {
                                    yes++;
                                    Console.WriteLine("정답\n확인이 되었다면 아무 키나 눌러서 넘어가세요.");
                                }
                                else {
                                    no++;
                                    Console.WriteLine("틀림 !");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("답 : {0}", answerList[randomQ]);
                                    Console.ResetColor();
                                    Console.WriteLine("확인이 되었다면 아무 키나 눌러서 넘어가세요.");
                                }

                                Console.ReadLine();
                                Console.Clear();
                            }

                            // 문제 마지막 출력 화면
                            Console.WriteLine("정답 수 : {0}, 오답 수 : {1}", yes, no);
                            Console.WriteLine("아무 키를 누르면 메인으로 넘어갑니다.");
                            Console.ReadLine();
                            Console.Clear();
                            yes = 0;
                            no = 0;

                            break;
                        case 3:
                            chkNext = false;
                            break;
                    }
                }
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
