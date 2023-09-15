using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public enum eActionState {
        IDLE    = 0,
        WALK,
        RUN
    }

    Animator _ctrlAni;

    // 내꺼라면 Awake에서 남의꺼라면 Start에서 얻어온다.
    void Awake() {
        _ctrlAni = GetComponent<Animator>();
    }

    void Start()
    {
    }

    void Update()
    {
    }

    void OnGUI() {
        // 글자가 안보여서 GUIStyle 로 수정
        //GUIStyle test = new GUIStyle(GUI.skin.textField);
        //test.fontSize = 200 / 5;
        //test.alignment = TextAnchor.MiddleCenter;

        // 버튼의 함수가 bool형의 자료형을 가진다.
        // 즉, Button이 클릭되었을 때 true
        if(GUI.Button(new Rect(0, 0, 200, 80), "IDLE"/*, test*/)) {
            _ctrlAni.SetInteger("AniState", (int)eActionState.IDLE);
        }

        if(GUI.Button(new Rect(0, 85, 200, 80), "WALK"/*, test*/)) {
            _ctrlAni.SetInteger("AniState", (int)eActionState.WALK);
        }

        if(GUI.Button(new Rect(0, 170, 200, 80), "RUN"/*, test*/)) {
            _ctrlAni.SetInteger("AniState", (int)eActionState.RUN);
        }
    }
}