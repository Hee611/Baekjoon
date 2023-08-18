using System;
using System.Collections.Generic;

namespace baekjoon_1371 {
    class Program {
        static void Main(string[] args) {
            List<int> num = new List<int>();
            List<int> hol = new List<int>();
            int totalSum = 0;

            for(int i = 0; i < 7; i++)
                num.Add(int.Parse(Console.ReadLine()));

            for(int i = 0; i < num.Count; i++) {
                if(num[i] % 2 != 0) {
                    hol.Add(num[i]);
                    totalSum += num[i];
                }
            }

            hol.Sort();

            if(hol.Count == 0)
                Console.Write(-1);
            else
                Console.WriteLine(totalSum + "\n" + hol[0]);

            //Console.ReadKey();
        }
    }
}