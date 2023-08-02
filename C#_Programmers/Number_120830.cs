using System;

public class Solution {
    public int solution(int n, int k) {
        int answer = 0, sv = 0;
        
        sv = n / 10;
        
        if(0 < n || n < 1000 || (n/10) <= k || k < 1000) {
            answer = n * 12000;
            
            if(k == 0)
                answer += k * 2000;
            else
                answer += (k - sv) * 2000;
            
            return answer;
        }
        else
            return 0;
    }
}