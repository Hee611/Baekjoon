using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 직접 이동 방식
// 자세한 코멘트는 수업 이후에 달아서 미숙

public class RobotController1 : MonoBehaviour {
    public float _moveSpeed = 5; // 초당 속도
    public float _rotAngle = 120; // 초당 회전 속도

    void Start() {
        Debug.Log(transform.rotation); // 현재 방향을 Console 창에 출력
    }

    // Update is called once per frame
    void Update() {
        //float dx = Input.GetAxisRaw("Horizontal");      // -1(left), 0, 1(right)
        //float dz = Input.GetAxisRaw("Vertical");        // -1(down), 0, 1(up)

        // GetAxis - 가속도가 있음
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");
        float ry = Input.GetAxis("RotLateral");

        {
            // 고전적인 방법?
            //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            //    //Debug.Log("W 키를 눌렀습니다.");
            //    // 현재 위치 + 이동할 거리와 방향 = 도착 위치
            //    //Vector3 dir = new Vector3(0, 0, 1);
            //    dz = 1;
            //    //transform.position += Vector3.forward * _speed * Time.deltaTime;
            //}
            //if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            //    //Debug.Log("W 키를 뗐습니다.");
            //    //transform.position += Vector3.back * _speed * Time.deltaTime;
            //    dz = -1;
            //}
            //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            //    //transform.position += Vector3.left * _speed * Time.deltaTime;
            //    dx = -1;
            //}
            //if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {

            //    dx = 1;
            //}
        }

        {
            //Vector3 dir = transform.rotation * new Vector3(dx, 0, dz);

            // GetAxisRaw
            // 여기서 normalized를 제거하면 대각선으로 이동 시 좀 더 빨라지는 문제점이 있음
            //transform.position += dir.normalized * _moveSpeed * Time.deltaTime;

            // magnitude(거리)와 normalized(정규화) 를 이용한 방법
            //dir = (dir.magnitude > 1) ? dir.normalized : dir;
            //transform.position += dir * _moveSpeed * Time.deltaTime;

            // 회전 (Input Manager 임의 지정 : RotLateral)
            // 앞, 뒤, 좌, 우로 움직이는 것과 마찬가지로 (회전)속도와 시간을 사용
            //float angleY = ry * Time.deltaTime * _rotAngle;
            //transform.rotation *= Quaternion.Euler(0, angleY, 0);
        }

        // 현재 위치
        Vector3 dir = new Vector3(dx, 0, dz);

        // 거리가 1 이상이 되면 대각선이 빨라지는 것을 막기 위해 정규화
        dir = (dir.magnitude > 1) ? dir.normalized : dir;

        // transform.Translate : 상대적인 Vector3 의 방향으로 이동
        transform.Translate(dir * Time.deltaTime * _moveSpeed);

        // transform.Rotate : 게임 오브젝트를 회전 시키기 위한 함수
        transform.Rotate(Vector3.up * ry * Time.deltaTime * _rotAngle);
    }
}
