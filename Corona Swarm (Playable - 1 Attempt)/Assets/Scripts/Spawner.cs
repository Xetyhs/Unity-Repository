using System.Collections;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    
    [SerializeField] protected ScriptableSpawner spawnerData;
    private IEnumerator destroySpawnableCoroutine;
    
    // Start is called before the first frame update
    
    public int GetSpawnedCount()
    {
        return spawnerData.SpawnedCount;
    }

    public ScriptableSpawner GetData()
    {
        return spawnerData;
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

    protected void InitializePool()
    {
        spawnerData.pool = Utility.FindWithTag(transform, "Pool").GetComponent<ObjectPool>();
    }

    public void DisableActives()
    {
        destroySpawnableCoroutine = spawnerData.pool.SleepActiveObjects();
        StartCoroutine(destroySpawnableCoroutine);
    }

    
    
    public abstract IEnumerator Spawn(int maxSpawnCount, GameObject spawnTarget = null);
}