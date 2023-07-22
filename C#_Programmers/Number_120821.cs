using System;

public class Solution {
    public int[] solution(int[] num_list) {
        int[] answer = new int[num_list.Length];
        Array.Copy(num_list, answer, num_list.Length);
        Array.Reverse(answer);
        return answer;
    }
}