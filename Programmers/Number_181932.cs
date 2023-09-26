using System;

public class Solution {
    public string solution(string code) {
        string ret = "";
        int mode = 0;
        
        char[] tempChar = code.ToCharArray();
        
        for(int i = 0; i < tempChar.Length; i++){
            if(tempChar[i] == '1'){
                mode = mode == 0 ? 1 : 0;
                continue;
            }
            
            if(mode == 1 && i % 2 == 1){
                ret += tempChar[i].ToString();
            } else if(mode == 0 && i % 2 == 0) {
                ret += tempChar[i].ToString();
            }
        }
        
        if(code == null || code == "1" || ret == "") {
            return "EMPTY";
        }
        
        return ret;
    }
}