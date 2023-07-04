using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UI_Button;

public abstract class UI_Base : MonoBehaviour
{

    Dictionary<Type, UnityEngine.Object[]> objects = new Dictionary<Type, UnityEngine.Object[]>();
   

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] _object = new UnityEngine.Object[names.Length];
        objects.Add(typeof(T), _object);
        for (int i = 0; i < names.Length; ++i)
        {
            if (typeof(T) == typeof(GameObject))
            {
                _object[i] = Util.FindChild(gameObject, names[i], true);
            }
            else
            {
                _object[i] = Util.FindChild<T>(gameObject, names[i], true);
            }
            if (_object[i] == null)
            {
                Debug.Log($"Faile{names[i]}");
            }
        }

    }
    public abstract void Init();
   protected Text GetText(int idx)
    {
        return Get<Text>(idx);
    }
    protected Image GetImage(int idx)
    {
        return Get<Image>(idx);
    }
    protected  Button GetButton(int idx)
    {
        return Get<Button>(idx);
    }
    protected GameObject GetGameObject(int idx)
    {
        return Get<GameObject>(idx);
    }

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] _objects = null;
        if (objects.TryGetValue(typeof(T), out _objects) == false)
        {
            return null;
        }
        return _objects[idx] as T;
    }
    public static void BindEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Event_Handler handler = Util.GetOrAddComponent<UI_Event_Handler>(go);

        switch(type)
        {
            case Define.UIEvent.Click:
                handler.OnClickHandler -= action;
                handler.OnClickHandler += action;
                break;
            case Define.UIEvent.Drag:
                handler.OnDragHandler -= action;
                handler.OnDragHandler += action;
                break;

        }
    }
}
