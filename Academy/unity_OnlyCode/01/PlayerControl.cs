using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject _objBullet;
    public Transform _posFire;
    public float _waitFireTime = 0.2f;
    public float _movSpeed = 5.0f;

    float _timeCheck = 0;

    void Start() {}

    void Update()
    {
        // nowGameState가 eGameSate의 Play가 아니면 return
        if(IngameManager._instance._nowGameState != IngameManager.eGameState.Play)
            return;

        _timeCheck += Time.deltaTime;
        if(_timeCheck >= _waitFireTime)
        {
            Instantiate(_objBullet, _posFire.position, _posFire.rotation);
            _timeCheck = 0;
            // Ingame Scene에서 총을 발사 할 때 eFFType BUTTON(총사운드가 없음)에 해당되는 사운드를 출력(루프가 아니라 false)
            SoundManager._instance.PlayEFFSound(SoundManager.eEFFType.BUTTON, 1, false);
        }
    }

    void LateUpdate()
    {
        // nowGameState가 eGameSate의 Play가 아니면 return
        if(IngameManager._instance._nowGameState != IngameManager.eGameState.Play)
            return;

        float my = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector2.up * my * Time.deltaTime * _movSpeed);
        transform.position = (transform.position.y >= 4.6f) ? new Vector3(transform.position.x, 4.6f) : transform.position;
    }
}