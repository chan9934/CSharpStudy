using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utill : MonoBehaviour
{
    public static T FindChild<T>(GameObject go, string name, bool recursive = false) where T : UnityEngine.Object
    {
        if(go == null)
        {
            return null;
        }
        if (recursive == false)
        {
            for (int i = 0; i < go.transform.childCount; ++i)
            {

                if (string.IsNullOrEmpty(name) || name == go.transform.GetChild(i).name)
                {
                    return (go.transform.GetChild(i)).GetComponent<T>();
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
}
