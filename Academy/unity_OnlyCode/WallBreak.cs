using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour

    // 벽에 닿는 미사일을 없애는 방법 + 벽에 닿을 때 발생되는 미사일 충돌 이펙트
{
    // GameObject 클래스를 이용하여 생성할 오브젝트를 지정한다.
    // 아무것도 지정해주지 않고 public을 통해 Unity 내부에서 지정할 수 있게 했다.
    public GameObject _hitEffectObj;

    // OnCollisionEnter 함수 : 두 객체가 충돌될 때 호출되는 함수
    void OnCollisionEnter(Collision other) {
        // 이런 방법도 있다.
        //if(other.gameObject.tag == "Missile")
        //    Destroy(other.gameObject, 0.1f);

        // 이 방법이 더 좋다.
        // CompareTag : 같은 태그인지 판별하는 것 뿐만 아니라,
        //              지정 태그가 리스트에 있는지도 판별한다.
        //              즉, Unity에서 설정한 Tag와 틀리면 에러가 발생한다.
        //              때문에 소스 상에서 오타가 난 부분을 잘 잡을 수 있다.
        // 🔽 만약 Game Object의 태그가 Missile이라면
        if(other.gameObject.CompareTag("Missile")) {
            // other.transform.position : other이 닿은 위치
            // _hitEffectObj.transform.rotation : _hitEffectObj가 가진 고유의 방향
            // _hitEffectObj : _hitEffectObj 가 가진 Effect를 생성
            Instantiate(_hitEffectObj, other.transform.position, _hitEffectObj.transform.rotation);
            
            // other라는 gameObject를 0.1초 후에 삭제
            Destroy(other.gameObject, 0.1f);
        }
    }
}
