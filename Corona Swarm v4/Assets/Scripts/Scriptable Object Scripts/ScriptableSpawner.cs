using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

[CreateAssetMenu(fileName = "Spawner", menuName = "Spawner")]
public class ScriptableSpawner : ScriptableObject
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

    private Random _random = new Random();

    
    public IEnumerator Spawn()
    {
        spawnedCount = 0;
        yield return new WaitForSeconds(spawnDelay);
        while (true)
        {
            GameObject enemy = pool.InstantiateFromPool();
            spawnedCount++;
            SetSpawnLocation(enemy);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SetSpawnLocation(GameObject gameObject)
    {
        if (gameObject == null)
            return;
        
        gameObject.transform.position = RandomPosition();
    }

    private enum Direction
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
    }
    private Direction RandomDirection()
    {
        return (Direction) _random.Next(4);
    }
    private float RandomFloat(float min, float max)
    {
        double val = (_random.NextDouble() * (max - min) + min);
        return (float) val;
    }
    private Vector3 RandomPosition()
    {
        Vector3 outputVector = new Vector3(0f, 0f, 0f);
        switch (RandomDirection())
        {
            case Direction.Up:
                outputVector = new Vector3(RandomFloat(-4.76f, 4.76f), RandomFloat(5.73f, 6f), 0f);
                break;
            case Direction.Left:
                outputVector = new Vector3(RandomFloat(-4.76f, -5f), RandomFloat(5.73f, -5.87f), 0f);
                break;
            case Direction.Down:
                outputVector = new Vector3(RandomFloat(-4.76f, 4.76f), RandomFloat(-5.87f, -6f), 0f);
                break;
            case Direction.Right:
                outputVector = new Vector3(RandomFloat(4.76f, 5f), RandomFloat(5.73f, -5.87f), 0f);
                break;
        }

        return outputVector;
    }
    
}