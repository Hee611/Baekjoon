using System;
using System.Linq;

public class Solution {
    public string solution(string s) {
        return String.Concat(s.OrderBy(c => c).Reverse());
    }
}