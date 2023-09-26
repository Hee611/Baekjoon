using System;

public class Solution {
    public int[] solution(int[] num_list) {
        int[] answer = new int[num_list.Length + 1];
        
        for(int i = 0; i < answer.Length; i++)
            answer[i] = i == answer.Length - 1 ? answer[i] = 0 : answer[i] = num_list[i];
        
        if(num_list[num_list.Length - 1] > num_list[num_list.Length - 2])
            answer[answer.Length - 1] = num_list[num_list.Length - 1] - num_list[num_list.Length - 2];
        else
            answer[answer.Length - 1] = num_list[num_list.Length - 1] * 2;
        
        return answer;
    }
} 