using System;

public class Solution {
    public int solution(int[] array, int height) {
        int answer = 0;
        
        for(int i = 0; i < array.Length; i++){
            if(array[i] > height)
                answer++;
        }
        
        return answer;
    }
}