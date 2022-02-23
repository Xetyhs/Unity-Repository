using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSpawner : MonoBehaviour
{
    [SerializeField] protected ScriptableSpawner spawnerData;
    // Start is called before the first frame update
    
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

    public void InitializePool()
    {
        spawnerData.pool = Utility.FindWithTag(transform, "Pool").GetComponent<ObjectPool>();
    }
    
    public abstract IEnumerator Spawn(int maxSpawnCount, GameObject spawnTarget = null);
}
