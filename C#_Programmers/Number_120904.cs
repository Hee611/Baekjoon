using System;

public class Solution {
    public int solution(int num, int k) {
        int answer = num.ToString().IndexOf(k.ToString()) + 1;
        return answer == 0 ? -1 : answer;
    }
}