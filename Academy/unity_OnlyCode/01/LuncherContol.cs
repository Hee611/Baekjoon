using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuncherContol : MonoBehaviour
{
    public GameObject _prefabMissileObj;
    // GameObject 클래스를 이용하여 생성할 오브젝트를 지정한다.
    // 아무것도 지정해주지 않고 public을 통해 Unity 내부에서 지정할 수 있게 했다.

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { // 만약에 스페이스바를 누르면
            // Instrantiate 함수 : 게임 오브젝트(Prefab)를 복제해서 생성할 수 있는 함수
            // 사용법 : Instantiate(GameObj 복제할 대상, Vector3 지정할 위치, Quaternion 지정할 방향);
            Instantiate(_prefabMissileObj, transform.position, transform.rotation);
            
            // Hierarchy에 있는 A 오브젝트에 LuncherContol.cs 스크립트를 적용했다고 가정하면,
            // transform.position은 A의 위치, transform.rotation은 A의 방향이 된다.
            // 즉, A가 위치한 곳의 바라보는 방향으로 _prefabMissileObj를 복제해서 생성한다.
        }
    }
}
