using System;

public class Example
{
    public static void Main()
    {
        // https://school.programmers.co.kr/learn/courses/30/lessons/181944
        String[] s;

        Console.Clear();
        s = Console.ReadLine().Split(' ');

        int a = Int32.Parse(s[0]);
        string check = a % 2 == 0 ? " is even" : " is odd";
        
        Console.Write(a + check);
    }
}