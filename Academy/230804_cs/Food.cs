using System;
using System.Collections.Generic;

namespace LearnCS_Collections {
    class Food {
        public void MenuAdd(Dictionary<string, int> menuDic, string menuName, int menuPrice) {
            if(menuDic.ContainsKey(menuName)) {
                menuDic[menuName] = menuPrice;
                Console.WriteLine("메뉴가 수정 되었습니다.");
            }
            else {
                menuDic[menuName] = menuPrice;
                Console.WriteLine("메뉴가 등록 되었습니다.");
            }
        }

        public void MenuDelete(Dictionary<string, int> menuDic, string menuName) {
            if(menuDic.ContainsKey(menuName)) {
                menuDic.Remove(menuName);
                Console.WriteLine("메뉴가 삭제 되었습니다.");
            }
            else {
                Console.WriteLine("올바른 값을 입력해 주세요.");
            }
        }
    }
}
