using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // 배경음은 하나의 소리만, 효과음은 여러개의 소리가 나올 수 있음.
    // 배경음은 Audio Source가 하나, 효과음은 효과음당 Audio Source를 가져야 함.

    static SoundManager _unique;

    // enum에 들어간 Type 들의 순서와 Unity에서 넣은 사운드의 순서가 동일해야 한다.
    public enum eBGMType {
        TITLE           = 0,
        INGAME
    }

    public enum eEFFType {
        BUTTON          = 0,
        FLY,
        HIT,
        DIE,
        SCORE
    }

    public AudioClip[] _bgmClips;
    public AudioClip[] _effClips;

    AudioSource _bgmPlayer;

    public static SoundManager _instance {
        get { return _unique; }
    }

    void Awake() {
        _unique = this;
        DontDestroyOnLoad(gameObject);
        _bgmPlayer = GetComponent<AudioSource>();
    }

    void Start() { }

    void Update() { }

    public void PlayBGMSound(eBGMType type, float vol, bool loop) {
        _bgmPlayer.clip = _bgmClips[(int)type];         // Unity에서 _bgmClips에 넣은 사운드를 순차적으로 _bgmPlayer에 넣음
        _bgmPlayer.volume = vol;
        _bgmPlayer.loop = loop;

        _bgmPlayer.Play();                              // bgm play
    }

    public void PlayEFFSound(eEFFType type, float vol, bool loop) {
        GameObject go = new GameObject("EffectSound");
        go.transform.parent = transform;
        AudioSource effSoundPlayer = go.AddComponent<AudioSource>();

        effSoundPlayer.clip = _effClips[(int)type];         // Unity에서 _effClips에 넣은 사운드를 순차적으로 _bgmPlayer에 넣음
        effSoundPlayer.volume = vol;
        effSoundPlayer.loop = loop;

        effSoundPlayer.Play();                              // bgm play

        // EffectSound Obj가 5초 있다가 삭제 됨
        Destroy(go, 5);
    }
}