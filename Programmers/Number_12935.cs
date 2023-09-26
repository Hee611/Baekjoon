using System.Linq;

public class Solution {
    public int[] solution(int[] arr) {
        int minValue = arr.Min();
        
        int[] answer = arr.Length == 1 ? new int[] { -1 } : arr.Where(i => i != minValue).ToArray();
        
        return answer;
    }
}