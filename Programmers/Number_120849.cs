using System;

public class Solution {
    public string solution(string my_string) {
        string[] mo = { "a", "e", "i", "o", "u" };
        string answer = my_string;
        
        for(int i = 0; i < mo.Length; i++)
            answer = answer.Replace(mo[i], "");
        
        return answer;
    }
}