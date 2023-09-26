using System;
using System.Linq;

public class Solution {
    public int[] solution(int[] arr, int divisor) {
        int[] answer = arr.Where(i => i % divisor == 0).ToArray();
        if(answer.Length == 0) answer = new int[] { -1 };
        Array.Sort(answer);

        return answer;
    }
}