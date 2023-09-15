using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    public float _force = 100; // 힘
    public float _destroyTime = 5; // 삭제 되기까지의 시간
    Rigidbody _rgdb3D; // Rigidbody를 제어하기 위해 선언

    // ✅ 미사일 오브젝트가 유니티 내에서 중력의 영향을 받지 않도록,
    //      유니티 Rigidbody 속성에서 Use Gravity의 체크를 풀어준다.

    void Awake()
    {
        //원래 방법
        //GameObject go = GameObject.Find("MissileObj");
        //_rgdb3D = go.GetComponent<Rigidbody>();

        // 스크립트로 컴포넌트에 액세스해야 하는 경우 GetComponent 함수를 사용하여 수행
        // GetComponent<Rigidbody>() : MissileControl.cs 스크립트가 적용되어 있는 오브젝트의 Rigidbody를 가져온다.
        _rgdb3D = GetComponent<Rigidbody>();

        // AddForce : Rigidbody 에 값만큼의 힘을 부여
        // Vector3.forward : z 축
        // 즉 z 축(앞)으로 100 만큼의 힘을 부여한다.
        _rgdb3D.AddForce(Vector3.forward * _force);

        // Destroy : 지정한 시간이 지난 후 오브젝트를 파괴하는 함수
        // 즉 생성된 오브젝트가 _destroyTime 만큼의 시간이 지나면 파괴된다.
        Destroy(gameObject, _destroyTime);
    }
}
