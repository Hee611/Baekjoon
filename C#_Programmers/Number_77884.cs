using System.Collections.Generic;

public class Solution {
    public int solution(int left, int right) {
        List<int> divisor = new List<int>();
        List<int> dCnt = new List<int>();
        
        int answer = 0, divisorCnt = 0;
        
        for(int i = left; i <= right; i++) {
            divisor.Add(i);
            for(int j = 1; j <= i; j++) 
                if(i % j == 0) divisorCnt++;
            dCnt.Add(divisorCnt);
            divisorCnt = 0;
        }
        
        for(int i = 0; i < divisor.Count; i++)
            answer = dCnt[i] % 2 == 0 ? answer + divisor[i] : answer - divisor[i];
        
        return answer;
    }
}