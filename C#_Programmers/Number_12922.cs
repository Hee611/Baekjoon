public class Solution {
    public string solution(int n) {
        string[] answerArr = new string[n];
        string answer = "";
        
        for(int i = 0; i < answerArr.Length; i++){
            if(i % 2 == 0)
                answerArr[i] = "수";
            else
                answerArr[i] = "박";
            answer += answerArr[i];
        }
        
        return answer;
    }
}