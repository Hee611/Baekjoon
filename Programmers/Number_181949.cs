using System;

public class Example
{
    public static void Main()
    {
        String s;

        Console.Clear();
        s = Console.ReadLine();
        
        for(int i = 0; i < s.Length; i++){
            if(Char.IsUpper(s[i]))
                Console.Write(char.ToLower(s[i]));
            else
                Console.Write(char.ToUpper(s[i]));
        }
    }
}