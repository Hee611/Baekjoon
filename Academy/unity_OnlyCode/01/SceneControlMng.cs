using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlMng : MonoBehaviour
{
    static SceneControlMng _unique;

    public enum eLoaddingState {
        none        = 0,
        start,
        ing,
        end
    }

    AsyncOperation _loadProc;
    eLoaddingState _nowLoadState = eLoaddingState.none;

    static public SceneControlMng _instance {
        get { return _unique;  }
    }

    void Awake()
    {
        _unique = this;
        DontDestroyOnLoad(gameObject);
        StartTitle();
    }

    // LoadSceneAsync 관련
    // isDone = 행위가 끝났다
    // progress = 몇 %가 됐다

    void LateUpdate() {
        if(_loadProc != null) {
            // _loadProc(로딩)이 완료되지 않았다면
            if(_loadProc.isDone) {
                _nowLoadState = eLoaddingState.ing;
                // 로딩바 계산
                //_loadProc.progress;
            }
            else { // _loadProc(로딩)이 완료됐다면
                // 로딩바 제거
                _loadProc = null;

                _nowLoadState = eLoaddingState.end;
            }
        }
    }

    public void StartTitle() {
        // StartTitle 로 넘어왔을 때 TITLE에 해당되는 BGM을 0.1f 정도의 사운드로 실행(true)
        SoundManager._instance.PlayBGMSound(SoundManager.eBGMType.TITLE, 0.1f, true);
        
        _nowLoadState = eLoaddingState.start;
        _loadProc = SceneManager.LoadSceneAsync("TitleScene");
        // 멀티 Scene일때 (스테이지 맵이 다르게 만들어질 때 / 인게임 밑에 스테이지 씬이 붙어서 나오는 경우)
        //_loadProc = SceneManager.LoadSceneAsync("TitleScene", LoadSceneMode.Additive);
    }

    public void StartIngame() {
        // StartIngame 로 넘어왔을 때 INGAME에 해당되는 BGM을 0.1f 정도의 사운드로 실행(true)
        SoundManager._instance.PlayBGMSound(SoundManager.eBGMType.INGAME, 0.1f, true);

        _loadProc = SceneManager.LoadSceneAsync("IngameScene");
        // 멀티 Scene일때
        //_loadProc = SceneManager.LoadSceneAsync("IngameScene", LoadSceneMode.Additive);
    }
}