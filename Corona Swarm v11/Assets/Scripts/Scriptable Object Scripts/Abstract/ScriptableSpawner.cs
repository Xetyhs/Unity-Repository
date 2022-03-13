using System.Collections;
using UnityEngine;


[CreateAssetMenu(fileName = "Spawner Data", menuName = "Spawner Data")]
public class ScriptableSpawner : ScriptableObject
{
    public ObjectPool pool;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _spawnInterval;
    [SerializeField]
    private int spawnedCount;
    
    public int SpawnedCount
    {
        get => spawnedCount;
        set => spawnedCount = value;
    }

    public float spawnDelay
    {
        get => _spawnDelay;
        set => _spawnDelay = value;
    }

    public float spawnInterval
    {
        get => _spawnInterval;
        set => _spawnInterval = value;
    }
    
    

}