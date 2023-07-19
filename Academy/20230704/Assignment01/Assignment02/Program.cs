using System;

namespace Assignment02
{
    class Program
    {
        static void Main(string[] args)
        {
            float cm, kg;

            Console.Write("키를 입력하세요(cm) : ");
            cm = float.Parse(Console.ReadLine());

            Console.Write("몸무게를 입력하세요(kg) : ");
            kg = float.Parse(Console.ReadLine());

            BMI(cm, kg);

            Console.ReadKey();
        }

        static void BMI(float cm, float kg)
        {
            float m = cm / 100;
            float bmi = kg / (m * m);

            string strBmi;
            if (bmi > 29)
                strBmi = "고도비만";
            else if (bmi >= 25 && bmi < 30)
                strBmi = "경도비만";
            else if (bmi >= 23 && bmi < 25)
                strBmi = "과체중";
            else if (bmi >= 18.5 && bmi < 23)
                strBmi = "정상체중";
            else
                strBmi = "저체중";

            Console.WriteLine("당신은 키 {0:F1}cm에 몸무게 {1:F1}kg으로 {2}입니다.", cm, kg, strBmi);
        }
    }
}
