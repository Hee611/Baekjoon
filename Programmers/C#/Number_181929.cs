// https://school.programmers.co.kr/learn/courses/30/lessons/181929

using System;

public class Solution {
    public int solution(int[] num_list) {
        int answer = 0, sn1 = 0, sn2 = 1, mn = 1;
        
        for(int i = 0; i < num_list.Length; i++){
            sn1 += num_list[i];
            mn *= num_list[i];
        }
        
        sn2 = sn1 * sn1;
        answer = sn2 > mn ? 1 : 0;
        
        return answer;
    }
}