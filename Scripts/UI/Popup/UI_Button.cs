using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{

    public enum Buttons
    {
        PointButton
    }
    public enum Texts
    {
        PointText,
        ScoreText
    }

    public enum GameObjects
    {
        TestObject
    }
    public enum Images
    {
        ItemIcon
    }


    int _score = 0;
    private void Start()
    {
        Init();

    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        BindEvent(go, (PointerEventData eventData) => { go.transform.position = eventData.position; }, Define.UIEvent.Drag);
        GetButton((int)Buttons.PointButton).gameObject.BindEvent(OnButtonClick);

    }

    public void OnButtonClick(PointerEventData eventData)
    {
            ++_score;
        GetText((int)Texts.ScoreText).text = $"���� : {_score}";
    }
}
