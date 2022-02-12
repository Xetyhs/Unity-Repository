using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{
    public ScriptableSpawner spawnerData;
    private void Awake()
    {
        spawnerData.pool = Utility.FindWithTag(transform, "Pool").GetComponent<ObjectPool>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(spawnerData.Spawn());
    }

    public IEnumerator Spawn()
    {
        spawnerData.SpawnedCount = 0;
        yield return spawnerData.Spawn();
    }

    public int GetSpawnedCount()
    {
        return spawnerData.SpawnedCount;
    }

    public void UpdateSpawnables(params GameObject[] list)
    {
        spawnerData.pool.DestroyAll();
        spawnerData.pool.WakeAllObjectsAs(list);
    }

    public bool AreEnemiesAlive()
    {
        return spawnerData.pool.isAliveOnPool();
    }
}