public class Solution {
    public long solution(long n) {
        long answer = 0;
        
        if(n == 1)
            answer = (n + 1) * (n + 1);
        else {
            for(long i = 0; i < n; i++){
                if(i * i == n){
                    answer = (i + 1) * (i + 1);
                    break;
                } else {
                    answer = -1;
                }
            }
        }
        return answer;
    }
}