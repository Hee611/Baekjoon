using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] numbers) {
        List<int> test = new List<int>();
        
        for(int i = 0; i < numbers.Length; i++){
            for(int j = 1; j < numbers.Length; j++){
                if(i != j)
                    test.Add(numbers[i] + numbers[j]);
            }
        }
        
        test.Sort();
        int[] answer = test.ToArray();
        return answer.Distinct().ToArray();
    }
}