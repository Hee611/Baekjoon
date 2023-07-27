using System;

public class Solution {
    public int[] solution(int[] arr, int[,] queries) {
        int[] answer = new int[arr.Length];
        arr.CopyTo(answer, 0);
        int a = 0;
        
        for(int i = 0; i < queries.GetLength(0); i++){
            a = answer[queries[i, 0]];
            answer[queries[i, 0]] = answer[queries[i, 1]];
            answer[queries[i, 1]] = a;
        }
        
        return answer;
    }
}