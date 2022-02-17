using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoSingleton<ParticleManager>
{
    public Spawner particleSpawner;
    public List<GameObject> explosionParticles;

    private int particleIndex = 0;
    /*--------------------------------------------------------------------*/

    public IEnumerator particleSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        particleSpawner.spawnerData.pool.WakeAllObjectsAs(explosionParticles.ToArray());
    }
    
    public void SpawnParticle(GameObject spawnAt)
    {
        particleSpawn = particleSpawner.Spawn(0, spawnAt);
        StartCoroutine(particleSpawn);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
