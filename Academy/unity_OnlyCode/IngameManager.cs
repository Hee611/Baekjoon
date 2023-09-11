using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    void Start() {}

    void Update()
    {
        // Cancle = ESC
        if(Input.GetButtonDown("Cancel")) {
            SceneControlMng._instance.StartTitle();
        }
    }
}
