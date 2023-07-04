using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inven_Item : UI_Base
{
    enum GameObjects
    {
        ItemIcon,
        ItemNameText
    }

    string _name = null;
   public  void SetInfo(string name)
    {
        _name = name;
    }
    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        GetGameObject((int)GameObjects.ItemNameText).GetComponent<Text>().text = _name;

        GetGameObject((int)GameObjects.ItemIcon).BindEvent((PointerEventData eventData) => { Debug.Log(_name); });

        
    }
}
