using System;

public class Solution {
    public int solution(int[] array) {
        int answer = 0;
        string str = "";

        for (int i = 0; i < array.Length; i++)
            str += array[i].ToString();
        
        char[] cArray = str.ToCharArray();
                
        for(int i = 0; i < cArray.Length; i++){
            if(cArray[i] - '0' == 7) {
                answer++;
            }
        }
        
        return answer;
    }
}