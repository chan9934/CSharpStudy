using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    
    enum Buttons
    {
        PointButton
    }
    enum Texts
    {
        PointText,
        ScoreText
    }
    enum GameObjects
    {
        TextObject
    }
    enum Images
    {
        ItemIcon
    }
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
        //GetText((int)(Texts.ScoreText)).text = "test";
        Bind<Image>(typeof(Images));
        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        BindEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
        GetButton((int)(Buttons.PointButton)).gameObject.BindEvent(OnButtonClicked);
    }

  
    int _score = 0;
    public void OnButtonClicked(PointerEventData data)
    {
        Debug.Log("asdf");
            ++_score;
        GetText((int)Texts.ScoreText).text = $"Á¡¼ö {_score}";


    }
}
