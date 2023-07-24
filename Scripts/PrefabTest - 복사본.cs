using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    void Start()
    {
        GameObject Tank = Manager.Resource.Instantiate("Tank");
        Destroy(Tank, 3.0f);
    }

}
