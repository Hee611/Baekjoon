using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 추가 공부 필요

public class RobotController2 : MonoBehaviour {
    // 픽킹 이동 방식
    public float _moveSpeed = 5;
    public float _rotAngle = 180;

    Vector3 _goalPos;
    Quaternion _goalRot;

    void Update() {
        // if (Input.GetMouseButtonDown(0)) {           // 0: 마우스 좌버튼, 1: 마우스 우버튼, 2: 마우스 중버튼

        if (Input.GetButtonDown("Fire1")) {             // 1: 마우스 좌버튼, 2: 마우스 우버튼, 3: 마우스 중버튼
            RaycastHit rHit;        // Collider, point 중요
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int lMask = 1 << LayerMask.NameToLayer("Floor") | 1 << LayerMask.NameToLayer("Field");

            if (Physics.Raycast(ray, out rHit, Mathf.Infinity, lMask)) {
                //Debug.Log(rHit.point);
                //transform.position = rHit.point;
                _goalPos = rHit.point;

                //Vector3 dir = _goalPos - transform.position;
                //transform.rotation = Quaternion.LookRotation(dir);

                // 위에 주석 내용을 간단하게
                //transform.LookAt(_goalPos);
                _goalRot = Quaternion.LookRotation(_goalPos - transform.position);
            }
        }

        //if ((_goalPos - transform.position).magnitude <= 0.1f)
        //    transform.position = _goalPos;
        //else {
        //    Vector3 dir = _goalPos - transform.position;
        //    transform.position += dir.normalized * Time.deltaTime * _moveSpeed;
        //}

        // 위에 if문을 간단하게
        transform.position = Vector3.MoveTowards(transform.position, _goalPos, Time.deltaTime * _moveSpeed); // 일반적
        // transform.position = Vector3.Lerp(transform.position, _goalPos, Time.deltaTime * _moveSpeed); // 도착하기 전에 느려짐

        transform.rotation = Quaternion.RotateTowards(transform.rotation, _goalRot, Time.deltaTime * _rotAngle); // 일반적
        //transform.rotation = Quaternion.Slerp(transform.rotation, _goalRot, Time.deltaTime * _rotAngle);

        //if ((_goalPos - transform.position).magnitude <= 0.1f)
        //    transform.position = _goalPos;
        //else {
        //    _goalRot = Quaternion.LookRotation(_goalPos - transform.rotation);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, _goalRot, Time.deltaTime * _rotAngle);
        //}
    }
}
