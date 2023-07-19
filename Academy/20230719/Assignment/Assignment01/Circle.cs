using System;

namespace Assignment01
{
    public class Circle
    {
        float _rediusOne, _rediusTwo, _areaOne, _areaTwo, _circumferenceOne, _circumferenceTwo;

        public void Calculator(float radiusOne, float radiusTwo)
        {
            _rediusOne = radiusOne;
            _rediusTwo = radiusTwo;

            _areaOne = (radiusOne * radiusOne) * 3.14f;
            _areaTwo = (radiusTwo * radiusTwo) * 3.14f;

            _circumferenceOne = (radiusOne * 2) * 3.14f;
            _circumferenceTwo = (radiusTwo * 2) * 3.14f;
        }

        public void PrintInformation()
        {
            Console.WriteLine("첫번째 원의 반지름은 {0}이고, 면적[{1:F2}], 둘레[{2:F0}]입니다.", _rediusOne, _areaOne, _circumferenceOne);
            Console.WriteLine("두번째 원의 반지름은 {0}이고, 면적[{1:F2}], 둘레[{2:F0}]입니다.", _rediusTwo, _areaTwo, _circumferenceTwo);

            Console.WriteLine("첫번째 원의 면적 [{0:F2}]이 두번째 원의 면적 [{1:F2}]보다 {2}다.", _areaOne, _areaTwo, _areaOne < _areaTwo ? "작" : _areaOne > _areaTwo ? "크" : "같");
        }
    }
}
