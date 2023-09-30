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
    //float _jumpPower = 10;
    bool _isAttack;
    float _passTime;
    bool _isOn;

    // 참조형 변수
    Animator _aniController;
    CharacterController _charContoller;
    //Rigidbody _rdbd;

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

        Move();
        //Jump();
    }

    void Move() {
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

        //if (Input.GetButtonDown("Jump")) {
        if(Input.GetMouseButtonDown(0)) {
            _isAttack = true;
        }

        // 애니메이션 수정
        ProcAnimation(dir);
        //}
    }

    /*void Jump() {
        if(Input.GetButtonDown("Jump")) {
            ExchangeAniFromAction(CharacterActionState.Jump);
            _rdbd.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            _passTime = 0;
        }
    }*/

    void ProcAnimation(Vector3 dir) {
        if (_isAttack) {
            ExchangeAniFromAction(CharacterActionState.Attack);
            _passTime = 0;
        }
        else {
            if (dir != Vector3.zero) {
                ExchangeAniFromAction(CharacterActionState.Run);
                _passTime = 0;
            }
            else {
                ExchangeAniFromAction(CharacterActionState.Idle);
                // 1. 특정 시간이 지나면 애니메이션 전환 (IDLE) / 2번에서도 씀
                _passTime += Time.deltaTime;
                Debug.Log((int)_passTime);

                if(_passTime >= _changeIdleTime) {
                    if(_isOn) {
                        _isOn = false;
                        IdleAniToType(_isOn);
                        ExchangeAniFromAction(CharacterActionState.Idle);
                    }
                    else {
                        _isOn = true;
                        IdleAniToType(_isOn);
                        ExchangeAniFromAction(CharacterActionState.Idle);
                    }
                    _passTime = 0;
                }

                /*if(_passTime >= _changeIdleTime) {
                    ExchangeAniFromAction(CharacterActionState.Idle);

                    int rd = Random.Range(0, 100);
                    if(_passTime >= _changeIdleTime) {
                        // 2. 특정 확률이 되면 애니메이션 전환 (IDLE)
                        if(rd < 50)
                            IdleAniToType(false);
                        else
                            IdleAniToType(true);
                        _passTime = 0;
                    }
                }*/
            }
        }
    }

    void IdleAniToType(bool isOn) {
        _aniController.SetBool("IsOn", isOn);
        _aniController.SetTrigger("ChangeAni");
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
            case CharacterActionState.Jump:
                _weaponObj.SetActive(false);
                break;
            case CharacterActionState.Attack:
                if(_isAttack)
                    _weaponObj.SetActive(true);
                else
                    _weaponObj.SetActive(false);
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
        //_rdbd = GetComponent<Rigidbody>();

        // 초기화
        _weaponObj.SetActive(false);
        _isAttack = false;
        _passTime = 0;
        _isOn = false;

        // 임시
        AttackTypeToAni(1);
    }

    protected override bool OnHitting() {
        return false;
    }
}