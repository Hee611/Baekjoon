public class Solution {
    public bool solution(int x) {
        bool answer = true;
        int totalSum = 0;
        
        string xStr = x.ToString();
        char[] xChar = xStr.ToCharArray();
        
        for(int i = 0; i < xChar.Length; i++)
            totalSum += xChar[i] - '0';
        
        answer = x % totalSum == 0 ? true : false;
        
        return answer;
    }
}