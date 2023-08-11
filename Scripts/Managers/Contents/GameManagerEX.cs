using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEX
{
    GameObject _player;
    HashSet<GameObject> _monster = new HashSet<GameObject>();

    public GameObject Spawn(Define.WorldObject type, string path, Transform parent = null)
    {
        GameObject go = Managers.Resource.Instantiate(path, parent);

        switch(type)
        {
            case Define.WorldObject.Monster:
                _monster.Add(go); break;
            case Define.WorldObject.Player:
                _player = go; break;
        }
        return go;
    }
    public Define.WorldObject GetWorldObjectType(GameObject go)
    {
        return null;
    }
    public void Despawn(GameObject go)
    {

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
