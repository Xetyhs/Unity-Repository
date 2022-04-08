using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Particle Spawner", menuName = "Particle Spawner")]
public class ScriptableParticleSpawner : ScriptableSpawner
{
    /*
    public override IEnumerator Spawn(int maxSpawnCount, GameObject spawnTarget = null)
    {
        if (spawnTarget == null)
            yield break;

        GameObject explosionObject = pool.InstantiateFromPool();
        
        ParticleSystem explosionParticle = Utility.FindWithTag(explosionObject.transform, "Particle").GetComponent<ParticleSystem>();
        
        var particleSystemShape = explosionParticle.shape;
        particleSystemShape.texture = spawnTarget.GetComponent<SpriteRenderer>().sprite.texture;
        Utility.SetSpawnLocation(explosionObject, spawnTarget);

        yield return null;
    }*/
}
