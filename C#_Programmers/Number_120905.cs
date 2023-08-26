using System;
using System.Linq;

public class Solution {
    public int[] solution(int n, int[] numlist) {
        int[] answer = numlist.Where(i => i % n == 0).ToArray();
        return answer;
    }
}