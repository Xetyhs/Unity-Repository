using System.Collections;
using UnityEngine;

public class PowerUpSpawner : Spawner 
{
    [Range(0f, .05f)] public float spawnProbablity;
    [SerializeField] private float inGameSpawnProbablity;
    private int spawnAttempt;

    private const float MAX_SPAWN_INTERVAL = 1f;

    public void Awake()
    {
        if (spawnerData.spawnInterval > MAX_SPAWN_INTERVAL)
            spawnerData.spawnInterval = MAX_SPAWN_INTERVAL;
        
        spawnAttempt = 0;
        InitializePool();
    }

    public override IEnumerator Spawn(int maxSpawnCount, GameObject spawnTarget = null)
    {
        spawnerData.SpawnedCount = 0;
        yield return new WaitForSeconds(spawnerData.spawnDelay);
        while (spawnerData.SpawnedCount < maxSpawnCount)
        {
            spawnAttempt++;
            if (!Utility.ProbablityRandom(inGameSpawnProbablity))
            {
                inGameSpawnProbablity += Random.Range(0.001f, 0.005f) * spawnAttempt;
                yield return new WaitForSeconds(spawnerData.spawnInterval);
                continue;
            }

            spawnAttempt = 0;
            inGameSpawnProbablity = spawnProbablity;
            GameObject enemy = spawnerData.pool.InstantiateFromPool();
            spawnerData.SpawnedCount++;
            Utility.SetSpawnLocation(enemy);
            yield return new WaitForSeconds(spawnerData.spawnInterval);
        }

        yield return null;

    }

    //public override IEnumerator Spawn(int maxSpawnCount, GameObject spawnTarget = null) { yield return spawnerData.Spawn(maxSpawnCount); }
    
    
    
}
