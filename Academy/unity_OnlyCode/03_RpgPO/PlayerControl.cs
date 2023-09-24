// Objects
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefineEnums;

public class PlayerControl : StatBase {
    const float _changeIdleTime = 5;
    [SerializeField] GameObject _weaponObj;

    // 정보형 변수
    CharacterActionState _curruntActState;
    float _movSpeed = 3;
    bool _isAttack;
    float _passTime;

    // 참조형 변수
    Animator _aniController;
    CharacterController _charContoller;

    // UI 참조

    public bool _lieDead {
        get { return _isDead; }
    }

    void Start() {
        InitBase(); // 임시
    }

    void Update() {
        if (_isDead || _isAttack)
            return;

        // _charContoller.Move(모션)
        // 모션 = 방향 * 속도 * 델타타임(중력x), 많은 계산을 내가 할 수 있어서 마음대로 커스텀 가능
        // _charContoller.SimpleMove(속도)
        // 속도 = 방향 * 속도(중력o), 점프 있는걸 만들때 편리
        Vector3 dir = Vector3.zero;

        //if (_charContoller.isGrounded) {
            float mz = Input.GetAxisRaw("Vertical");
            float mx = Input.GetAxisRaw("Horizontal");

            dir = new Vector3(mx, 0, mz);
            
            if(dir != Vector3.zero) {
                float angle = Mathf.Atan2(mx, mz) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, angle, 0);
            }

            //dir.y = Physics.gravity.y * Time.deltaTime;
            Vector3 moveDir = dir + Vector3.up * Physics.gravity.y * Time.deltaTime;

            _charContoller.Move(moveDir.normalized * _movSpeed * Time.deltaTime);

            if (Input.GetButtonDown("Jump")) {
                _isAttack = true;
            }

            // 애니메이션 수정
            ProcAnimation(dir);
        //}

    }

    void ProcAnimation(Vector3 dir) {
        if (_isAttack) {
            ExchangeAniFromAction(CharacterActionState.Attack);
        }
        else {
            if (dir != Vector3.zero) {
                ExchangeAniFromAction(CharacterActionState.Run);
            }
            else {
                ExchangeAniFromAction(CharacterActionState.Idle);
            }
        }
    }

    void IdleAniToType(bool isOn) {
        _aniController.SetBool("IsOn", isOn);
    }

    void AttackTypeToAni(int type) {
        _aniController.SetInteger("AttackType", type);
    }

    void ExchangeAniFromAction(CharacterActionState state) {
        if (_isDead || _curruntActState == state)
            return;

        switch (state) {
            case CharacterActionState.Idle:
            case CharacterActionState.Run:
                _weaponObj.SetActive(false);
                break;
            case CharacterActionState.Attack:
                _weaponObj.SetActive(true);
                break;
        }

        _aniController.SetInteger("AniState", (int)state);
        _aniController.SetTrigger("ChangeAni");

        _curruntActState = state;
    }

    void EndAnimation(int aniKind) {
        int index = Random.Range(1, 3);
        AttackTypeToAni(index);
        _isAttack = false;
    }

    protected override void InitBase() {
        // 참조
        _aniController = GetComponent<Animator>();
        _charContoller = GetComponent<CharacterController>();

        // 초기화
        _weaponObj.SetActive(false);
        _isAttack = false;

        // 임시
        AttackTypeToAni(1);
    }

    protected override bool OnHitting() {
        return false;
    }

    //void ongui() {
    //    if (gui.button(new rect(0, 0, 120, 30), "idle1")) {
    //        exchangeanifromaction(characteractionstate.idle);
    //        idleanitotype(false);
    //    }
    //    if (gui.button(new rect(125, 0, 120, 30), "idle2")) {
    //        exchangeanifromaction(characteractionstate.idle);
    //        idleanitotype(true);
    //    }
    //    if (gui.button(new rect(0, 35, 120, 30), "run")) {
    //        exchangeanifromaction(characteractionstate.run);
    //    }
    //    if (gui.button(new rect(0, 70, 120, 30), "attack1")) {
    //        exchangeanifromaction(characteractionstate.attack);
    //        attacktypetoani(1);
    //    }
    //    if (gui.button(new rect(125, 70, 120, 30), "attack2")) {
    //        exchangeanifromaction(characteractionstate.attack);
    //        attacktypetoani(2);
    //    }
    //    if (gui.button(new rect(0, 105, 120, 30), "die")) {
    //        exchangeanifromaction(characteractionstate.die);
    //    }
    //}
}