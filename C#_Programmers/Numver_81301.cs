using System;

public class Solution {
    public int solution(string s) {
        string[] number = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        
        for(int i = 0; i < 10; i++)
            s = s.Replace(number[i], i.ToString());
        
        return int.Parse(s);
    }
}