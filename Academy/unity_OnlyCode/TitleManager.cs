using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public Text _txtPush;
    float _tickTime = 0;

    void Start() {
        GameObject go = GameObject.Find("SceneControlManager");
    }

    void Update()
    {
        _tickTime += Time.deltaTime;
        if(_tickTime >= 0.3f)
        {
            _tickTime = 0;
            _txtPush.gameObject.SetActive(!_txtPush.gameObject.activeSelf);
        }

        if(Input.GetButtonDown("Fire1")) {
            // 씬이동
            SceneControlMng._instance.StartIngame();

            // Title Scene에서 클릭할 때 eFFType BUTTON에 해당되는 사운드를 한번만 출력 (루프가 아니라 false)
            SoundManager._instance.PlayEFFSound(SoundManager.eEFFType.BUTTON, 1, false);
        }
    }
}