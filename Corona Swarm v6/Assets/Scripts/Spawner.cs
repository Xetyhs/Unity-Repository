using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ScriptableSpawner spawnerData;
    private void Awake()
    {
        spawnerData.pool = Utility.FindWithTag(transform, "Pool").GetComponent<ObjectPool>();
    }

    // Start is called before the first frame update
   

    public IEnumerator Spawn(int maxSpawnCount)
    {
        yield return spawnerData.Spawn(maxSpawnCount);
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