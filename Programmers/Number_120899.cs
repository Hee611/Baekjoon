using System;
using System.Linq;

public class Solution {
    public int[] solution(int[] array) {
        int[] answer = { array.Max(), array.ToList().IndexOf(array.Max()) };
        return answer;
    }
}