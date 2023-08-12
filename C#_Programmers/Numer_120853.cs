using System;

public class Solution {
    public int solution(string s) {
        string[] tmp = s.Split(" ");
        int answer = 0;
        
        for(int i = 0; i < tmp.Length; i++)
            answer = tmp[i].ToString() == "Z" ? answer - int.Parse(tmp[i-1]) : answer + int.Parse(tmp[i]);
        
        return answer;
    }
}