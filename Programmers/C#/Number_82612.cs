using System;

class Solution
{
    public long solution(int price, int money, int count)
    {
        long totalSum = 0, result = 0;
        long[] test = new long[count];
        
        for(int i = 0; i < count; i++)
            test[i] = i == 0 ? price : test[i - 1] + price;
        
        for(int i = 0; i < count; i++)
            totalSum += test[i];
        
        return totalSum - money <= 0 ? 0 : totalSum - money;
    }
}