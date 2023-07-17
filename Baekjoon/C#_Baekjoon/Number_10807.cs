using System;

namespace Number_10807
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCount, cnt = 0;
            string numSelect;

            numCount = int.Parse(Console.ReadLine());

            string numStr;
            numStr = Console.ReadLine();

            string[] numInput = numStr.Split(new char[] { ' ' });

            numSelect = Console.ReadLine();

            for(int i = 0; i < numInput.Length; i++)
            {
                if (numSelect.Equals(numInput[i]))
                    cnt++;
            }

            Console.WriteLine(cnt);

            //Console.ReadKey();
        }
    }
}
