using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : Spawner
{
    // Start is called before the first frame update
    private void Awake()
    {
        InitializePool();
    }

    public override IEnumerator Spawn(int maxSpawnCount, GameObject spawnTarget = null) { yield return spawnerData.Spawn(maxSpawnCount, spawnTarget); }
}
