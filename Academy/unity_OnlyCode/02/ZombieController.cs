using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    public enum eActionState {
        IDLE    = 0,
        WALK,
        RUN,
        ATTACK,
        HIT
    }

    public enum eCharacter { // 좀비 성격
        FIERCE  = 0,
        LAZY
    }

    // [SerializeField] 를 이용하면 public과 같이 인스펙터 창에서 수정 가능하도록 변수를 노출 시킨다.
    [SerializeField] float _movSpeed;   // Zombie가 움직이는 속도
    [SerializeField] float _walkSpeed;  // Zombie가 걷는 속도
    [SerializeField] float _limitX = 5;
    [SerializeField] float _limitZ = 5;
    [SerializeField] float _minTime = 2;    // 최소 얼만큼 기다릴건지 (움직이기 전에 idle)
    [SerializeField] float _maxTime = 7;    // 최대 얼만큼 기다릴건지 (움직이기 전에 idle)
    [SerializeField] BoxCollider _damageZone; // DamageZone을 받아옴
    [SerializeField] eCharacter _eCh;

    int _characterStd;

    float _Speed;                       // 적용 시키는 속도?
    float _timeWait;                    // 움직일지 말지를 결정하기 전 가만히(idle) 기다리는 상태의 시간

    eActionState _stateAction;          // 현재 나의 액션

    Animator _ctrlAni;                  // Animator Control

    Vector3 _posTarget;                 // Zombie를 움직이기 위한 Target pos(목표 위치)
    Vector3 _startPos;                  // Zombie가 생성되는 위치

    // 플래그
    bool _isDeath;
    bool _isAttack;
    bool _isSelectAi;

    // 네비게이션
    NavMeshAgent _navAgent;
    
    // 내꺼라면 Awake에서 남의꺼라면 Start에서 얻어온다.
    void Awake() {
        _isDeath = false; // false로 초기화
        _isAttack = false;
        _isSelectAi = false;
        _startPos = _posTarget = transform.position; // _startPos, _posTarget의 위치는 transform.position
        _ctrlAni = GetComponent<Animator>();
        _navAgent = GetComponent<NavMeshAgent>();
        _timeWait = 0; // 0으로 초기화
        _characterStd = 0;
    }

    void Start()
    {
        switch(_eCh) {
            case eCharacter.FIERCE:
                _characterStd = 25;
                break;
            case eCharacter.LAZY:
                _characterStd = 80;
                break;
        }
    }

    void Update() { // 적 크리쳐 ai
        if(_isDeath)
            return;

        switch(_stateAction) {
            case eActionState.IDLE:
                _timeWait -= Time.deltaTime;
                if(_timeWait <= 0) {
                    // 움직일지 기다릴지 다시 선택
                    _isSelectAi = false;
                }
                break;
            case eActionState.WALK:
                if(Vector3.Distance(_posTarget, transform.position) <= 0.1f) {
                    // 다시 선택
                    _isSelectAi = false;
                }
                break;
        }

        ProcessAI();
    }

    void ProcessAI() {
        if(!_isSelectAi) { // 선택이 아직 안됐을 때
            int rd = Random.Range(0, 100); // int Random은 이상과 미만

            if(rd < _characterStd) { // 대기(idle), _characterStd가 설정된 확률로 대기함
                ChangedAction(eActionState.IDLE);
                _timeWait = Random.Range(_minTime, _maxTime);
            }
            else { // 걷기
                ChangedAction(eActionState.WALK);
                _posTarget = GetRandomPos(_startPos, _limitX, _limitZ);
                _navAgent.destination = _posTarget;
            }

            _isSelectAi = true; // 선택이 됨
        }
    }

    Vector3 GetRandomPos(Vector3 center, float limitX, float limitZ) { // 랜덤값으로 지정 범위내에서 움직임
        float rX = Random.Range(-limitX, limitX); // float Random은 이상과 이하
        float rZ = Random.Range(-limitZ, limitZ);

        Vector3 rv = new Vector3(rX, 0, rZ);
        return center + rv;
    }
    
    // 네비게이션 연습 ===
    //void Update()
    //{
    //    if(_isDeath) // _isDeath == true일때
    //        return;

    //    //if(Input.GetButtonDown("Fire1")) { // 방법 1 (마우스 좌클릭)
    //    if(Input.GetMouseButtonDown(0)) { // 방법2 (마우스 좌클릭)
    //        // Floor만 Ray 타겟팅이 가능하도록 설정(할 수 있으나 현재 Zombie에 Collider가 없어서 주석)
    //        // LayerMask lMask = LayerMask.NameToLayer("Floor");

    //        RaycastHit hit;                                             // Ray에 부딪힌 오브젝트를 얻어오는 인자
    //        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);  // 마우스가 클릭된 위치로 Ray를 만든다.
    //        int mask = 1 << LayerMask.NameToLayer("Floor"); // Floor만 클릭되게

    //        // 물리적인 연산을 통해 오브젝트를 알려준다.
    //        if(Physics.Raycast(r, out hit, Mathf.Infinity, mask)) {   // Raycast는 bool형이라, if 문으로 작성하는 것이 좋다.
    //            // hit에 들어온 gameObject 및 좌표를 확인
    //            //Debug.Log(hit.transform.gameObject.ToString() + " : " + hit.point.ToString());

    //            if(_isAttack) // 공격중일때 방향 변경 못하게 막기
    //                return;

    //            _posTarget = hit.point;             // 목표 위치를 hit의 좌표로 설정
    //            transform.LookAt(_posTarget);       // 클릭한 _posTarget의 위치로 좀비의 방향이 돌아감
    //            ChangedAction(eActionState.WALK);   // WALK Animation 실행
    //            _navAgent.destination = _posTarget; // 네비게이션을 이용한 이동 / destination : 종착지
    //        }
    //    }
    //    if(Input.GetMouseButtonDown(1)) { // 우클릭이 되었을 경우
    //        RaycastHit hit;
    //        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        int mask = 1 << LayerMask.NameToLayer("Floor"); // Floor만 클릭되게

    //        if(Physics.Raycast(r, out hit, Mathf.Infinity, mask)) {
    //            _posTarget = hit.point;
    //            transform.LookAt(_posTarget);
    //            ChangedAction(eActionState.RUN);
    //            _navAgent.destination = _posTarget; // 네비게이션을 이용한 이동 / destination : 종착지
    //        }
    //    }

    //    if(_isAttack) // 공격 중일때는 걷지 않음
    //        return;

    //    // Distance = A와 B의 거리를 반환
    //    // A와 B의 거리가 0.1 보다 작거나 같으면 idle 상태로 변환
    //    if(Vector3.Distance(transform.position, _posTarget) <= 0.1f) {
    //        ChangedAction(eActionState.IDLE);
    //    }

    //    // Vector3.Lerp(시작, 끝, 시간)를 통해 마우스 클릭시 Zombie 이동 / 빠르게 가다가 도착지점에 오면 서서히 느려짐
    //    // transform.position = Vector3.Lerp(transform.position, _posTarget, Time.deltaTime);

    //    // Vector3.MoveTowards(현재위치, 목표위치, 속도) 를 이용해 마우스 클릭시 Zombie 이동 / 일정하게 움직임
    //    //transform.position = Vector3.MoveTowards(transform.position, _posTarget, Time.deltaTime * _Speed);

    //}

    void ChangedAction(eActionState state) {
        switch(state) {
            case eActionState.IDLE:
                _stateAction = state;
                _ctrlAni.SetInteger("AniState", (int)_stateAction);
                break;
            case eActionState.WALK:
                if(_stateAction != eActionState.ATTACK) {
                    //_Speed = _walkSpeed;
                    _navAgent.speed = _walkSpeed; // 네비게이션을 사용할때
                    _stateAction = state;
                    _ctrlAni.SetInteger("AniState", (int)_stateAction);
                }
                break;
            case eActionState.RUN:
                if(_stateAction == eActionState.ATTACK) {
                    _isAttack = false;
                    //_Speed = _movSpeed;
                    _navAgent.speed = _movSpeed; // 네비게이션을 사용할때
                    _stateAction = state;
                    _ctrlAni.SetInteger("AniState", (int)_stateAction);
                } else {
                    //_Speed = _movSpeed;
                    _navAgent.speed = _movSpeed; // 네비게이션을 사용할때
                    _stateAction = state;
                    _ctrlAni.SetInteger("AniState", (int)_stateAction);
                }
                break;
            case eActionState.ATTACK:
                if(_stateAction == eActionState.RUN) {
                    _isAttack = true;
                    _stateAction = state;
                    _ctrlAni.SetInteger("AniState", (int)_stateAction);
                }
                break;
            case eActionState.HIT:
                _isDeath = true;
                _stateAction = state;
                _ctrlAni.SetInteger("AniState", (int)_stateAction);
                break;
        }
    }

    void OnGUI() {
        // 글자가 안보여서 GUIStyle 로 수정
        GUIStyle test = new GUIStyle(GUI.skin.textField);
        test.fontSize = 200 / 5;
        test.alignment = TextAnchor.MiddleCenter;

        // 버튼의 함수가 bool형의 자료형을 가진다.
        // 즉, Button이 클릭되었을 때 true
        if(GUI.Button(new Rect(0, 0, 200, 80), "ATTACK", test)) {
            ChangedAction(eActionState.ATTACK);
        }

        if(GUI.Button(new Rect(0, 85, 200, 80), "DEAD", test)) {
            ChangedAction(eActionState.HIT);
        }

        //if(GUI.Button(new Rect(0, 170, 200, 80), "RUN", test)) {
        //    _ctrlAni.SetInteger("AniState", (int)eActionState.RUN);
        //}
    }

    void DamageOn() {
        _damageZone.enabled = true; // Box Collider를 킴
    }

    void DamageOff() {
        _damageZone.enabled = false; // Box Collider를 끔
    }
}