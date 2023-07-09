using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Scene
    {
        UnKnown,
        Login,
        Game,
        Lobby
    }
    public enum UIEvent
    {
        Click,
        Drag
    }
    public enum MouseEvent
    {
        Press,
        Click,
    }

    public enum CameraMode
    {
        QuarterView,
    }
}
