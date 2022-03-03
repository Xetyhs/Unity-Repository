using System.Collections;
using UnityEngine;


public abstract class ScriptableSpawner : ScriptableObject
{
    public ObjectPool pool;
    [SerializeField] protected float spawnDelay;
    [SerializeField] protected float spawnInterval;

    [SerializeField]
    private int spawnedCount;
    public int SpawnedCount
    {
        get => spawnedCount;
        set => spawnedCount = value;
    }

    public abstract IEnumerator Spawn(int maxSpawnCount, GameObject spawnTarget = null);



}