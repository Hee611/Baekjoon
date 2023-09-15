using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
// 애니메이션 적용
{
    Animator _aniCtrl;

    void Awake() {
        _aniCtrl = GetComponent<Animator>();
    }

    void Start() {}

    void Update()
    {
        // 스페이스 바를 누르면
        if(Input.GetKey(KeyCode.Space)) {
            // IsRun을 false로 변경
            _aniCtrl.SetBool("IsRun", false);
            // IsAttack을 true로 변경
            _aniCtrl.SetBool("IsAttack", true);
        }
        // 스페이스 바를 떼면
        else {
            // IsAttack을 false로 변경
            _aniCtrl.SetBool("IsAttack", false);
            // 만약 W키를 누르고 있다면
            if(Input.GetKey(KeyCode.W)) {
                // IsRun을 true로 변경
                _aniCtrl.SetBool("IsRun", true);
            }
            // 만약 W키를 누르지 않고 있다면
            else {
                // IsRun을 false로 변경
                _aniCtrl.SetBool("IsRun", false);
            }
        }
    }
}
