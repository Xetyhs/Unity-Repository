using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

[Serializable]
public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectPool;
    private GameObject prefab;
    private GameObject[] _prefabs;
    
    [SerializeField] private int poolSize;
    private int poolIndex = 0;
    
    
    public GameObject InstantiateFromPool()
    {
        //if (poolIndex >= objectPool.Count) return null;
        
        
        objectPool[poolIndex].SetActive(true);
        GameObject outputGameObject = objectPool[poolIndex];
        IncrementPoolPos();

        return outputGameObject;
    }
    
    private void IncrementPoolPos()
    { 
        if (poolIndex == objectPool.Count - 1)
        {
            poolIndex = 0;
        }
        else
        {
            poolIndex++;
        }
    }

    private void SetupAll()
    {
        objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject gameObject = InstantiateGameObject(prefab);
            gameObject.SetActive(false);
            objectPool.Add(gameObject);
        }
    }

    private void SetupAllRandom()
    {
        objectPool = new List<GameObject>();
        Random random = new Random();
        
        for (int i = 0; i < poolSize; i++)
        {
            GameObject gameObject = Instantiate(_prefabs[random.Next(_prefabs.Length)], transform, true);
            gameObject.SetActive(false);
            objectPool.Add(gameObject);
        }
    }
    
    public void WakeAllObjectsAs(GameObject _prefab)
    {
        prefab = _prefab;
        SetupAll();
    }
    
    public void WakeAllObjectsAs(params GameObject[] _prefabs)
    {
        if (_prefabs.Length == 1)
        {
            prefab = _prefabs[0];
            SetupAll();
            return;
        }
        
        this._prefabs = _prefabs;
        SetupAllRandom();
    }

    public IEnumerator SleepActiveObjects()
    {
        for (var i = 0; i < poolIndex; i++)
        {
            if (!objectPool[i].activeSelf) continue;
            
            yield return new WaitForSeconds(0.1f);
            objectPool[i].SetActive(false);
        }

        yield return null;
    }
    
    
    public void ShutDownPool()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        DestroyAll();
    }

    public void DestroyAll()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public bool isAliveOnPool()
    {
        bool alive = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeInHierarchy)
            {
                alive = true;
                return alive;
            }
        }

        return alive;
    }

    private GameObject InstantiateGameObject(GameObject gameObject)
    {
        //if (gameObject.CompareTag("Particle"))
          //  return Instantiate(gameObject);
        return Instantiate(prefab, transform, true);

    }
}
