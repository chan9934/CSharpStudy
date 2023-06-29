using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Utill : MonoBehaviour
{
    public static GameObject FindChild(GameObject go, string name, bool recursive = false)
    {
        
        Transform transform = FindChild<Transform>(go, name, recursive);
        if(transform != null)
        {
            return transform.gameObject;
        }
        return null;

    }
    public static T FindChild<T>(GameObject go, string name, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
        {
            return null;
        }
        if (recursive == false)
        {
            for (int i = 0; i < go.transform.childCount; ++i)
            {
                Transform transform = go.transform.GetChild(i);

                if (string.IsNullOrEmpty(name) || name == transform.name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                    {
                        return component;
                    }
                }
            }
        }
        else
        {


            foreach (T component in go.GetComponentsInChildren<T>())
            {

                if (string.IsNullOrEmpty(name) || name == component.name)
                {
                    return component;
                }

            }
        }
        return null;
    }

    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if(component == null)
        {
            component = go.AddComponent<T>();
        }
        return component;
    }
}
