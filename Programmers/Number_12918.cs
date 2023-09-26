public class Solution {
    public bool solution(string s) {
        int i = 0;
        return s.Length == 4 || s.Length == 6 ? int.TryParse(s, out i) : false;
    }
}