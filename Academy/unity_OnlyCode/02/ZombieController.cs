using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public enum eActionState {
        IDLE    = 0,
        WALK,
        RUN,
        ATTACK,
        HIT
    }

    // [SerializeField] 를 이용하면 public과 같이 인스펙터 창에서 수정 가능하도록 변수를 노출 시킨다.
    [SerializeField] float _movSpeed;   // Zombie가 움직이는 속도
    [SerializeField] float _walkSpeed;  // Zombie가 걷는 속도
    float _Speed;                       // 적용 시키는 속도?

    eActionState _stateAction;          // 현재 나의 액션
    Animator _ctrlAni;                  // Animator Control
    Vector3 _posTarget;                 // Zombie를 움직이기 위한 Target pos(목표 위치)

    // 플래그
    bool _isDeath;
    bool _isAttack;
    
    // 내꺼라면 Awake에서 남의꺼라면 Start에서 얻어온다.
    void Awake() {
        _isDeath = false; // false로 초기화
        _isAttack = false; // false로 초기화
        _ctrlAni = GetComponent<Animator>();
        _posTarget = transform.position; // 현재 위치
    }

    void Start()
    {
    }

    void Update()
    {
        if(_isDeath) // _isDeath == true일때
            return;

        //if(Input.GetButtonDown("Fire1")) { // 방법 1 (마우스 좌클릭)
        if(Input.GetMouseButtonDown(0)) { // 방법2 (마우스 좌클릭)
            // Floor만 Ray 타겟팅이 가능하도록 설정(할 수 있으나 현재 Zombie에 Collider가 없어서 주석)
            // LayerMask lMask = LayerMask.NameToLayer("Floor");

            RaycastHit hit;                                             // Ray에 부딪힌 오브젝트를 얻어오는 인자
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);  // 마우스가 클릭된 위치로 Ray를 만든다.
            int mask = 1 << LayerMask.NameToLayer("Floor"); // Floor만 클릭되게

            // 물리적인 연산을 통해 오브젝트를 알려준다.
            if(Physics.Raycast(r, out hit, Mathf.Infinity, mask)) {   // Raycast는 bool형이라, if 문으로 작성하는 것이 좋다.
                // hit에 들어온 gameObject 및 좌표를 확인
                //Debug.Log(hit.transform.gameObject.ToString() + " : " + hit.point.ToString());
                
                if(_isAttack) // 공격중일때 방향 변경 못하게 막기
                    return;

                _posTarget = hit.point;             // 목표 위치를 hit의 좌표로 설정
                transform.LookAt(_posTarget);       // 클릭한 _posTarget의 위치로 좀비의 방향이 돌아감
                ChangedAction(eActionState.WALK);   // WALK Animation 실행
            }
        }
        if(Input.GetMouseButtonDown(1)) { // 우클릭이 되었을 경우
            RaycastHit hit;
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            int mask = 1 << LayerMask.NameToLayer("Floor"); // Floor만 클릭되게

            if(Physics.Raycast(r, out hit, Mathf.Infinity, mask)) {
                _posTarget = hit.point;
                transform.LookAt(_posTarget);
                ChangedAction(eActionState.RUN);
            }
        }

        if(_isAttack) // 공격 중일때는 걷지 않음
            return;

        // Distance = A와 B의 거리를 반환
        // A와 B의 거리가 0.1 보다 작거나 같으면 idle 상태로 변환
        if(Vector3.Distance(transform.position, _posTarget) <= 0.1f) {
            ChangedAction(eActionState.IDLE);
        }

        // Vector3.Lerp(시작, 끝, 시간)를 통해 마우스 클릭시 Zombie 이동 / 빠르게 가다가 도착지점에 오면 서서히 느려짐
        // transform.position = Vector3.Lerp(transform.position, _posTarget, Time.deltaTime);

        // Vector3.MoveTowards(현재위치, 목표위치, 속도) 를 이용해 마우스 클릭시 Zombie 이동 / 일정하게 움직임
        transform.position = Vector3.MoveTowards(transform.position, _posTarget, Time.deltaTime * _Speed);

    }

    void ChangedAction(eActionState state) {
        switch(state) {
            case eActionState.IDLE:
                _stateAction = state;
                _ctrlAni.SetInteger("AniState", (int)_stateAction);
                break;
            case eActionState.WALK:
                if(_stateAction != eActionState.ATTACK) {
                    _Speed = _walkSpeed;
                    _stateAction = state;
                    _ctrlAni.SetInteger("AniState", (int)_stateAction);
                }
                break;
            case eActionState.RUN:
                if(_stateAction == eActionState.ATTACK) {
                    _isAttack = false;
                    _Speed = _movSpeed;
                    _stateAction = state;
                    _ctrlAni.SetInteger("AniState", (int)_stateAction);
                } else {
                    _Speed = _movSpeed;
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
}