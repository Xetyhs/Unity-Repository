using System.Collections;
using UnityEngine;

public class ParticleSpawner : Spawner
{
    // Start is called before the first frame update
    private void Awake()
    {
        InitializePool();
    }

    //public override IEnumerator Spawn(int maxSpawnCount, GameObject spawnTarget = null) { yield return spawnerData.Spawn(maxSpawnCount, spawnTarget); }
    
    public override IEnumerator Spawn(int maxSpawnCount, GameObject spawnTarget = null)
    {
        if (spawnTarget == null)
            yield break;

        GameObject explosionObject = spawnerData.pool.InstantiateFromPool();
        
        ParticleSystem explosionParticle = Utility.FindWithTag(explosionObject.transform, "Particle").GetComponent<ParticleSystem>();
        
        var particleSystemShape = explosionParticle.shape;
        particleSystemShape.texture = spawnTarget.GetComponent<SpriteRenderer>().sprite.texture;
        Utility.SetSpawnLocation(explosionObject, spawnTarget);

        yield return null;
    }
}
