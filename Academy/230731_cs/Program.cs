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
            Dictionary<string, int> menuDic = new Dictionary<string, int>();
            int menuNum = 0, menuPrice = 0;
            string menuName = "";

            while (true) {
                Console.WriteLine("분식집을 오픈하였습니다.");
                Console.WriteLine("1. 메뉴 추가\n2. 메뉴 삭제\n3. 전체 메뉴 확인\n4. 종료");
                Console.Write("어느 일을 하시겠습니까 : ");

                menuNum = int.Parse(Console.ReadLine());

                if (menuNum == 1) { // 메뉴 추가
                    while (true) {
                        Console.Write("메뉴 이름을 입력하세요(q/Q면 종료) : ");
                        menuName = Console.ReadLine();

                        if (menuName == "q" || menuName == "Q") break;

                        Console.Write("메뉴 가격을 입력하세요 : ");
                        menuPrice = int.Parse(Console.ReadLine());

                        if (menuDic.ContainsKey(menuName)) {
                            menuDic[menuName] = menuPrice;
                            Console.WriteLine("메뉴가 수정 되었습니다.");
                        } else {
                            menuDic[menuName] = menuPrice;
                            Console.WriteLine("메뉴가 등록 되었습니다.");
                        }
                    }
                } else if (menuNum == 2) { // 메뉴 삭제 
                    while (true) {
                        // 전체 메뉴 출력
                        int count = menuDic.Count;
                        foreach (string key in menuDic.Keys) {
                            //cnt++;
                            --count;
                            if (count == 0 || menuDic.Count == 1) {
                                Console.WriteLine("{0}", key);
                            } else {
                                Console.Write("{0}, ", key);
                            }
                        }

                        if (menuDic.Count == 0) break;

                        Console.Write("삭제할 메뉴 이름을 입력하세요(q/Q면 종료) : ");
                        menuName = Console.ReadLine();

                        if (menuName == "q" || menuName == "Q") break;

                        if (menuDic.ContainsKey(menuName)) {
                            menuDic.Remove(menuName);
                            Console.WriteLine("메뉴가 삭제 되었습니다.");
                        } else {
                            Console.WriteLine("올바른 값을 입력해 주세요.");
                        }
                    }
                } else if (menuNum == 3) { // 전체 메뉴 조회
                    foreach (string key in menuDic.Keys) {
                        int length = key.Length;
                        if (length >= 5) { // 글자수가 5 이상이면 탭을 한번
                            Console.WriteLine("메뉴 : {0}\t{1:#,###}원", key, menuDic[key]);
                        } else {            // 글자수가 5 미만이면 앞에 탭을 두번
                            Console.WriteLine("메뉴 : {0}\t\t{1:#,###}원", key, menuDic[key]);
                        }
                    }
                } else if (menuNum == 4) { // 종료 + 먹을 메뉴 선택
                    int choice = 0, totalMenu = 0, totalPrice = 0;

                    if (choice == 4) {
                        Console.WriteLine("{0}개의 메뉴를 선택하셨습니다.", totalMenu);
                        break;
                    }

                    while (true) {
                        int cnt = 0;
                        foreach (string key in menuDic.Keys) {
                            int length = key.Length;
                            if (length >= 3) { // 글자수가 3 이상이면 탭을 한번
                                Console.WriteLine("{0}. {1}\t{2:#,###}", ++cnt, key, menuDic[key]);
                            } else {            // 글자수가 3 미만이면 앞에 탭을 두번
                                Console.WriteLine("{0}. {1}\t\t{2:#,###}", ++cnt, key, menuDic[key]);
                            }
                        }
                        Console.WriteLine("{0}. 메뉴 선택 종료", ++cnt);
                        Console.WriteLine("메뉴를 선택하세요 : ");

                        choice = int.Parse(Console.ReadLine());
                        if (choice == menuDic.Count) break;
                        else {
                            totalMenu++;

                        }
                    }
                } else { // 초기 선택 화면의 번호들이 아닌 경우
                    Console.WriteLine("올바른 값을 입력해 주세요.");
                }
            }

            Console.ReadKey();
        }
    }
}