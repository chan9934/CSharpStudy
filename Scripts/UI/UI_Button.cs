using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    [SerializeField]
    Text _text = null;

    int _score = 0;
    public void OnButtonClicked()
    {
        if(_text != null)
        {
            ++_score;
            _text.text = ($"���� : {_score}");
        }
    }
}
