using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LearnCS_Collections
{
    class Program
    {
        static Random _rd = new Random();
        static void Main(string[] args)
        {
            // 연습
            Food fd = new Food();

            // 메뉴 정보가 담길 Dictinary
            Dictionary<string, int> menuDic = new Dictionary<string, int>();

            // 메인메뉴 번호 & 메뉴 가격 & 메뉴 이름
            int mainNum = 0, menuPrice = 0;
            string menuName = "";

            while(true) {
                Console.WriteLine("분식집을 오픈하였습니다.");
                Console.WriteLine("1. 메뉴 추가\n2. 메뉴 삭제\n3. 전체 메뉴 확인\n4. 종료");
                Console.Write("어느 일을 하시겠습니까 : ");

                mainNum = int.Parse(Console.ReadLine());

                // 1. 메뉴 추가
                if(mainNum == 1) {
                    while(true) {
                        Console.Write("메뉴 이름을 입력하세요(q/Q면 종료) : ");
                        menuName = Console.ReadLine();

                        if(menuName == "q" || menuName == "Q") break;

                        Console.Write("메뉴 가격을 입력하세요 : ");
                        menuPrice = int.Parse(Console.ReadLine());

                        fd.MenuAdd(menuDic, menuName, menuPrice);
                    }
                }
                // 2. 메뉴 삭제
                else if(mainNum == 2) { 
                    while(true) {
                        // 전체 메뉴 출력
                        for(int i = 0; i < menuDic.Count; i++) {
                            if(i < menuDic.Count - 1)
                                Console.Write("{0}, ", menuDic.Keys.ToList()[i]);
                            else
                                Console.WriteLine("{0}", menuDic.Keys.ToList()[i]);
                        }

                        if(menuDic.Count == 0) break;

                        Console.Write("삭제할 메뉴 이름을 입력하세요(q/Q면 종료) : ");
                        menuName = Console.ReadLine();

                        if(menuName == "q" || menuName == "Q") break;

                        fd.MenuDelete(menuDic, menuName);
                    }
                }
                // 3. 전체 메뉴 조회
                else if(mainNum == 3) {
                    for(int i = 0; i < menuDic.Count; i++) {
                        if(menuDic.Keys.ToList()[i].Length >= 5)
                            Console.WriteLine("메뉴 : {0}\t{1:#,###}원", menuDic.Keys.ToList()[i], menuDic.Values.ToList()[i]);
                        else
                            Console.WriteLine("메뉴 : {0}\t\t{1:#,###}원", menuDic.Keys.ToList()[i], menuDic.Values.ToList()[i]);
                    }
                }
                // 4. 종료 (+ 먹을 메뉴 선택)
                else if(mainNum == 4) {
                    // 메뉴 선택 & 총 선택 메뉴 개수 & 총 선택 메뉴 가격
                    int choice = 0, totalMenu = 0, totalPrice = 0, exit = 0;

                    while(true) {
                        if(menuDic.Count == 0) { // 추가된 메뉴가 없다면
                            Console.WriteLine("메뉴가 없으므로 프로그램을 종료합니다.");
                            break;
                        }
                        else {
                            for(int i = 0; i < menuDic.Count; i++) {
                                if(menuDic.Keys.ToList()[i].Length >= 3)
                                    Console.WriteLine("{0}. {1}\t\t{2:#,###}", i + 1, menuDic.Keys.ToList()[i], menuDic.Values.ToList()[i]);
                                else
                                    Console.WriteLine("{0}. {1}\t\t\t{2:#,###}", i + 1, menuDic.Keys.ToList()[i], menuDic.Values.ToList()[i]);
                            }

                            exit = menuDic.Count + 1;
                            Console.WriteLine("{0}. 메뉴 선택 종료", exit);
                            if(choice - 1 == exit) break; // 반복문 빠져나옴

                            Console.Write("메뉴를 선택하세요 : ");
                            choice = int.Parse(Console.ReadLine());

                            if(choice - 1 == menuDic.Count) {
                                Console.WriteLine("{0}개의 메뉴를 선택하셨습니다.", totalMenu = totalMenu == 0 ? 0 : totalMenu);

                                if(totalPrice == 0)
                                    Console.WriteLine("모두 {0}원 입니다.", totalPrice);
                                else
                                    Console.WriteLine("모두 {0:#,###}원 입니다.", totalPrice);

                                break;
                            }
                            else {
                                totalMenu++;
                                totalPrice += menuDic.Values.ToList()[choice - 1];
                            }
                        }
                    }
                    if(choice - 1 == exit - 1) break; // 프로그램 종료
                }
                // 초기 선택 화면의 번호들이 아닌 경우
                else Console.WriteLine("선택지에 나와있는 번호를 입력해 주세요.");
            }

            Console.ReadKey();
        }
    }
}