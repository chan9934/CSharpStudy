using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    enum GameObjects
    {
        GridPannel
    }
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        GameObject gridPannel = GetGameObject((int)(GameObjects.GridPannel));
        foreach(Transform children in gridPannel.transform)
        {
            Managers.Resource.Destroy(children.gameObject);
        }
        for(int i = 0; i < 8; ++i)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_Inven_Item>(gridPannel.transform).gameObject;
            
            UI_Inven_Item invenItem = item.GetOrAddComponent<UI_Inven_Item>();
            invenItem.SetInfo($"¹«±â {i}¹ø");
            
        }
    }
}
