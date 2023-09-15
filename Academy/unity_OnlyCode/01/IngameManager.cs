using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    // 꼭 이렇게 State를 나눌 필요는 없지만 이 방법을 잘 알고나면
    // 인터넷 상에 있는 다른 방법들이 이해하기 쉬워질 것이다.
    public enum eGameState {
        None            = 0,
        Ready,
        Start,
        Play,
        Endding,
        Result
    }

    public MessageWnd _wndMsg;

    // 선언과 동시에 _currentGameState의 값을 None으로 지정
    eGameState _currentGameState = eGameState.None;

    bool _isClear = false;                      // 게임이 Clear가 되었는지 판단
    float _timeCheck = 0;                       // 시간 체크

    static IngameManager _unique;

    public static IngameManager _instance {
        get { return _unique; }
    }

    public eGameState _nowGameState {
        get { return _currentGameState; }
    }

    void Awake() {
        _unique = this;
    }

    void Start() {}

    void Update()
    {
        // EndGame txt 출력 테스트
        // Cancle = ESC
        if(Input.GetButtonDown("Cancel")) {
            //SceneControlMng._instance.StartTitle();
            EndGame(false);
        }

        switch(_currentGameState) {                 // _currentGameState의 내용을 검사
            case eGameState.None:                   // _currentGameState가 None일 때
                ReadyGame();                        // ReayGame() 메서드 실행
                break;
            case eGameState.Ready:                  // _currentGameState가 Ready일 때
                _timeCheck += Time.deltaTime;       // _timeCheck 증가
                if(_timeCheck >= 3)                 // _timeCheck가 3 이상일 때
                    StartGame();                    // StartGame() 메서드 실행
                break;
            case eGameState.Start:                  // _currentGameState가 Start일 때
                _timeCheck += Time.deltaTime;       // _timeCheck 증가
                if(_timeCheck >= 1)                 // _timeCheck가 1 이상일 때
                    PlayGame();                     // PlayGame() 메서드 실행
                break;
        }
    }

    // 각 State가 시작할 때 호출하는 함수를 먼저 만들어두면
    // 프로그래밍 하기가 더 쉬워진다.
    public void ReadyGame() {
        _currentGameState = eGameState.Ready;       // _currentGameState를 Ready로 변경
        _wndMsg.gameObject.SetActive(true);         // _wndMsg의 gameObject를 SetActive(true)를 이용해 활성화
        _wndMsg.SettingText("Ready");               // 화면에 Ready Text를 출력
    }

    public void StartGame() {
        _currentGameState = eGameState.Start;       // _currentGameState를 Start로 변경
        _wndMsg.gameObject.SetActive(true);         // _wndMsg의 gameObject를 SetActive(true)를 이용해 활성화
        _wndMsg.SettingText("Game Start");          // 화면에 Ready Text를 출력
        _timeCheck = 0;                             // _timeCheck 값을 0으로 변경
    }

    public void PlayGame() {
        _currentGameState = eGameState.Play;        // _currentGameState를 Play로 변경
        _wndMsg.gameObject.SetActive(false);        // _wndMsg의 gameObject를 SetActive(false)를 이용해 비활성화
        _timeCheck = 0;                             // _timeCheck 값을 0으로 변경
    }

    public void EndGame(bool isClear) {
        _currentGameState = eGameState.Endding;     // _currentGameState를 Endding로 변경
        _isClear = isClear;                         // _isClear에 받아온 isClear를 넣음
        _wndMsg.gameObject.SetActive(true);         // _wndMsg의 gameObject를 SetActive(true)를 이용해 활성화
        if(_isClear)                                // _isClear가 true일 때
            _wndMsg.SettingText("Clear!");          // Clear! 메시지를 띄움
        else                                        // 그게 아니라면
            _wndMsg.SettingText("Game Over.");      // Game Over. 메시지를 띄움
        _timeCheck = 0;                             // _timeCheck 값을 0으로 변경
    }

    public void ResultGame() {
        _currentGameState = eGameState.Result;      // _currentGameState를 Result로 변경
    }
}