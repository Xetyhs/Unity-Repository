using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile Spawner", menuName = "Projectile Spawner")]
public class ScriptableProjectileSpawner : ScriptableSpawner
{
    /*public override IEnumerator Spawn(int maxSpawnCount, GameObject spawnTarget = null)
    {
        SpawnedCount = 0;
        yield return new WaitForSeconds(spawnDelay);
        while (SpawnedCount < maxSpawnCount)
        {
            GameObject enemy = pool.InstantiateFromPool();
            SpawnedCount++;
            Utility.SetSpawnLocation(enemy);
            yield return new WaitForSeconds(spawnInterval);
        }

        yield return null;
    }*/
}
