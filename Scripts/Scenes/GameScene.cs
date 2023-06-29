using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public override void Clear()
    {
        
    }

    void Start()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
            
        Manager.UI.ShowScenepUI<UI_Inven>();
    }
}
