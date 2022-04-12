using System.Collections;
using UnityEngine;

public class ProjectileSpawner : Spawner
{
    private void Awake()
    {
        InitializePool();
    }

    /*public override IEnumerator Spawn(int maxSpawnCount, GameObject spawnTarget = null)
    {
        yield return spawnerData.Spawn(maxSpawnCount);
    }*/
    
    public override IEnumerator Spawn(int maxSpawnCount, GameObject spawnTarget = null)
    {
        spawnerData.SpawnedCount = 0;
        yield return new WaitForSeconds(spawnerData.spawnDelay);
        while (spawnerData.SpawnedCount < maxSpawnCount)
        {
            GameObject enemy = spawnerData.pool.InstantiateFromPool();
            spawnerData.SpawnedCount++;
            Utility.SetSpawnLocation(enemy);
            yield return new WaitForSeconds(spawnerData.spawnInterval);
        }

        yield return null;
    }
}
