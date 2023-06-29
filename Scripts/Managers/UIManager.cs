using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Animations;

public class UIManager
{
    int _order = 10;

    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    UI_Scene scene = null;

    public GameObject Root { get {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
            {
                root = new GameObject { name = "@UI_Root" };
            }
            return root;
        } }

    public void SetCanvas(GameObject go, bool order = true)
    {
        Canvas _canvas = Utill.GetOrAddComponent<Canvas>(go);
        _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        _canvas.overrideSorting = true;
            
        if (order)
        {
            _canvas.sortingOrder = _order;
            ++_order;
        }
        else
        {
            _canvas.sortingOrder = 0;
        }
    }

    public T ShowPopupUI<T> (string name = null) where T : UI_Popup
    {
        if(string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }
        GameObject go = Manager.Resource.Instantiate($"UI/Popup/{name}");
        T _popup = Utill.GetOrAddComponent<T>(go);
        _popupStack.Push(_popup);
        go.transform.SetParent(Root.transform);
        return _popup;
    }


    public T ShowScenepUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }
        GameObject go = Manager.Resource.Instantiate($"UI/Scene/{name}");
        T _scene  = Utill.GetOrAddComponent<T>(go);
        scene = _scene;
        
        go.transform.SetParent(Root.transform);
        return _scene;
    }
    public void ClosePopupUI(UI_Popup popup)
    {
        if (_popupStack.Count == 0)
        {
            return;
        }
        if(_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup Failed");
            return;
        }
        ClosePopupUI();
    }
    public void ClosePopupUI()
    {
        if(_popupStack.Count == 0)
        {
            return;
        }
        UI_Popup _popup = _popupStack.Pop();
        GameObject go = _popup.gameObject;
        Manager.Resource.Destroy(go);
        _popup = null;
    }

    public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }
        GameObject go = Manager.Resource.Instantiate($"UI/SubItem/{name}");

        if(parent != null)
        {
            go.transform.SetParent(parent);
        }
        
        return go.GetOrAddComponent<T>();
    }
}
