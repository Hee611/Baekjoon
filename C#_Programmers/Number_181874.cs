using System;

public class Solution {
    public string solution(string myString) {
        char[] test = myString.ToLower().ToCharArray();
        string answer = "";
        
        for(int i = 0; i < test.Length; i++)
            answer += test[i] == 'a' ? test[i].ToString().ToUpper() : test[i].ToString();
        
        return answer;
    }
}