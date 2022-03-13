using System.Collections;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    /*public ScriptableSpawner spawnerData;
    private void Awake()
    {
        spawnerData.pool = Utility.FindWithTag(transform, "Pool").GetComponent<ObjectPool>();
    }
    
    public IEnumerator Spawn(int maxSpawnCount = 0, GameObject targetObject = null)
    {
        if(maxSpawnCount < 0)
            yield break;
        
        if (CompareTag("Enemy Spawner"))
        {
            yield return spawnerData.Spawn(maxSpawnCount);
            
        } else if (CompareTag("Particle Spawner"))
        {
            yield return spawnerData.Spawn(maxSpawnCount, targetObject);
        }
        
        yield return null;
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
    }*/
    
    
    
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