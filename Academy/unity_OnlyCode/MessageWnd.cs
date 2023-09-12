using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageWnd : MonoBehaviour
{
    public Text _msgText;

    public void SettingText(string txt) {
        _msgText.text = txt;
    }
}