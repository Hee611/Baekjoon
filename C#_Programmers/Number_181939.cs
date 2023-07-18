using System;

public class Solution {
    public int solution(int a, int b) {
        string strSumAb = a.ToString() + b.ToString();
        string strSumBa = b.ToString() + a.ToString();
        
        int answer = 0;
        
        if(int.Parse(strSumAb) > int.Parse(strSumBa))
            answer = int.Parse(strSumAb);
        else
            answer = int.Parse(strSumBa);
        
        return answer;
    }
}
