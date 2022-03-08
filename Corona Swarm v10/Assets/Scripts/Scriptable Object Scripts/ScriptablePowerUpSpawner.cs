using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "Power-Up Spawner", menuName = "Power-Up Spawner")]
public class ScriptablePowerUpSpawner : ScriptableSpawner
{
    /*
    [Range(0f, .05f)] public float spawnProbablity;
    [SerializeField] private float inGameSpawnProbablity;
    private int spawnAttempt;

    private const float MAX_SPAWN_INTERVAL = 1f;

    public void Awake()
    {
        if (spawnInterval > MAX_SPAWN_INTERVAL)
            spawnInterval = MAX_SPAWN_INTERVAL;
        
        inGameSpawnProbablity = spawnProbablity;
        spawnAttempt = 0;
    }

    public override IEnumerator Spawn(int maxSpawnCount, GameObject spawnTarget = null)
    {
        SpawnedCount = 0;
        yield return new WaitForSeconds(spawnDelay);
        while (SpawnedCount < maxSpawnCount)
        {
            spawnAttempt++;
            if (!Utility.ProbablityRandom(inGameSpawnProbablity))
            {
                inGameSpawnProbablity += Random.Range(0.001f, 0.005f) * spawnAttempt;
                yield return new WaitForSeconds(spawnInterval);
                continue;
            }

            spawnAttempt = 0;
            inGameSpawnProbablity = spawnProbablity;
            GameObject enemy = pool.InstantiateFromPool();
            SpawnedCount++;
            Utility.SetSpawnLocation(enemy);
            yield return new WaitForSeconds(spawnInterval);
        }

        yield return null;

    }*/
}
