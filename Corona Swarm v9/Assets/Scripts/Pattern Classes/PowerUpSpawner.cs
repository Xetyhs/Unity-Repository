using System.Collections;
using UnityEngine;

public class PowerUpSpawner : Spawner
{
    private void Awake()
    {
        InitializePool();
    }

    public override IEnumerator Spawn(int maxSpawnCount, GameObject spawnTarget = null) { yield return spawnerData.Spawn(maxSpawnCount); }
}
