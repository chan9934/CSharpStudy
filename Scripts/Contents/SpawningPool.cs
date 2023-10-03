using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawningPool : MonoBehaviour
{
    [SerializeField]
    float _monsterCount = 0;
    [SerializeField]
    float _reverseCount = 0;
    [SerializeField]
    float _keepMonsterCount = 0;
    [SerializeField]
    Vector3 _spawnPos;
    [SerializeField]
    float _spawnRadius = 15.0f;
    [SerializeField]
    float _spawnTime = 5.0f;

    public void AddMonsterCount(int value) { _monsterCount += value; }  
    public void SetKeepMonsterCount(int count) { _keepMonsterCount = count; }
    void Start()
    {
        Managers.Game.OnSpawnEvent -= AddMonsterCount;
        Managers.Game.OnSpawnEvent += AddMonsterCount;
    }

    void Update()
    {
        if(_reverseCount + _monsterCount < _keepMonsterCount)
        {
           
            StartCoroutine("ReverseSpawn");
        }
    }
    IEnumerator ReverseSpawn()
    {
        _reverseCount++;
        yield return new WaitForSeconds(Random.Range(0, _spawnTime));
        GameObject obj = Managers.Game.Spawn(Define.WorldObject.Monster, "Knight");
        Debug.Log($"_monsterCount{_monsterCount}");
        NavMeshAgent nma = obj.GetOrAddComponent<NavMeshAgent>();

        Vector3 randPos;
        while (true)
        {
            Vector3 randDir = Random.insideUnitSphere * Random.Range(0, _spawnRadius);
            randDir.y = 0;
            randPos = _spawnPos + randDir;

            NavMeshPath   path = new NavMeshPath();
            if (nma.CalculatePath(randPos, path))
                break;
        }
        obj.transform.position = randPos;
        _reverseCount--;
    }
}
