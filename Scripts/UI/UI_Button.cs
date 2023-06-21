using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> objects = new Dictionary<Type, UnityEngine.Object[]>();

    int _score = 0;

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

    public void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        
        GetText((int)Texts.ScoreText).text = "test";
    }

    void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] _object = new UnityEngine.Object[names.Length];
        objects.Add(typeof(T), _object);
        for(int i = 0; i < names.Length; ++i)
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
    Text GetText(int idx)
    {
        return Get<Text>(idx);
    }
    Image GetImage(int idx)
    {
        return Get<Image>(idx);
    }
    Button GetButton(int idx)
    {
        return Get<Button>(idx);
    }

    T Get<T> (int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] _objects = null;
        if(objects.TryGetValue(typeof(T), out _objects) == false)
        {
            return null;
        }
        return _objects[idx] as T;
    }
    public void OnButtonClick()
    {
            ++_score;
    }
}
