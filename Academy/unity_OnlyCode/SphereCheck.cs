using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCheck : MonoBehaviour
{
    public GameObject _effectInObj;
    public GameObject _effectOutObj;

    // 왜 트리거를 쓸까?
    // 흔히 알고 있는 FPS에서 관통하는 총알이 있을 경우 뚫고 나가는 효과를 줄 수 있다.

    void OnTriggerEnter(Collider col) {
        if(col.CompareTag("Missile")) {
            // 미사일이 Sphere에 들어가면 _effectInObj의 이펙트가 생성된다.
            Instantiate(_effectInObj, col.transform.position, _effectInObj.transform.rotation);

        }
    }

    void OnTriggerExit(Collider col) {
        if(col.CompareTag("Missile")) {
            // 미사일이 Sphere에서 나오면 _effectOutObj의 이펙트가 생성된다.
            Instantiate(_effectOutObj, col.transform.position, _effectOutObj.transform.rotation);
        }
    }
}