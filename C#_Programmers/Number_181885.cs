using System;
using System.Collections.Generic;

public class Solution {
    public string[] solution(string[] todo_list, bool[] finished) {
        List<string> answer = new List<string>();
        
        for(int i = 0; i < todo_list.Length; i++)
            if(finished[i] == false) answer.Add(todo_list[i]);
        
        return answer.ToArray();
    }
}