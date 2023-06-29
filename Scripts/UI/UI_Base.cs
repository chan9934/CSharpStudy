using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Base : MonoBehaviour
{

    public abstract void Init();

    Dictionary<Type, UnityEngine.Object[]> dicObject = new Dictionary<Type, UnityEngine.Object[]>();
    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        dicObject.Add(typeof(T), objects);
        for (int i = 0; i < names.Length; ++i)
        {
            if (typeof(T) == typeof(GameObject))
            {
                objects[i] = Utill.FindChild(gameObject, names[i], true);
            }
            else
            {
                objects[i] = Utill.FindChild<T>(gameObject, names[i], true);
            }
            if (objects[i] == null)
            {
                Debug.Log($"Fail {names[i]}");
            }
        }

    }

    public T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] _objects = null;
        if (dicObject.TryGetValue(typeof(T), out _objects))
        {
            return _objects[idx] as T;
        }
        return null;
    }

    protected GameObject GetGameObject(int idx)
    {
        return Get<GameObject>(idx);    
    }
    protected Text GetText(int idx)
    {
        return Get<Text>(idx);
    }
    protected Image GetImage(int idx)
    {
        return Get<Image>(idx);
    }
    protected Button GetButton(int idx)
    {
        return Get<Button>(idx);
    }

    public static void BindEvent(GameObject go, Action<PointerEventData>action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_EventHandler evt = Utill.GetOrAddComponent < UI_EventHandler > (go);
        switch(type)
        {
            case Define.UIEvent.Drag:
                evt.OnDragHandler -= action;
                evt.OnDragHandler += action;
                break;
            case Define.UIEvent.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
        }
    }
}
