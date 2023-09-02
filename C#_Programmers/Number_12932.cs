using System;

public class Solution {
    public int[] solution(long n) {
        char[] test = n.ToString().ToCharArray();
        Array.Reverse(test);
        
        int[] answer = new int[test.Length];
        
        for(int i = 0; i < answer.Length; i++)
            answer[i] = test[i] - '0';
        
        return answer;
    }
}