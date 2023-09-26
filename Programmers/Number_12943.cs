public class Solution {
    public int solution(int num) {
        int answer = 0;
        long n = num;
        
        if(n == 1)
            return 0;
        else{
            while(n != 1){
                answer++;
                if(answer == 500)
                    return -1;
                else
                    n = n % 2 == 0 ? n / 2 : (n * 3) + 1;
            }
            return answer;
        }
    }
}