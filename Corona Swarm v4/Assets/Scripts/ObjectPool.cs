using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

[Serializable]
public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectPool;
    [SerializeField] private int poolSize;
    [SerializeField] private GameObject prefab;
    private GameObject[] _prefabs;
    
    
    private int poolIndex = 0;

    private void Awake()
    {
        //WakeAllObjects();
    }
    
    // Eklenecekler: Var olan poolun değiştirilmesi
    // Gerekirse var olan objelerin ne olduklarını değiştirme, gerekirse tüm objeleri silerek değiştirme, bir şekilde değiştirme
    
    public GameObject InstantiateFromPool()
    {
        if (poolIndex >= objectPool.Count) return null;
        
        
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

    private void WakeAllObjects()
    {
        objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject gameObject = Instantiate(prefab, transform, true);
            gameObject.SetActive(false);
            objectPool.Add(gameObject);
        }
    }

    public void WakeAllObjectsAs(GameObject _prefab)
    {
        prefab = _prefab;
        WakeAllObjects();
    }

    private void WakeRandomly()
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
    
    public void WakeAllObjectsAs(params GameObject[] _prefabs)
    {
        this._prefabs = _prefabs;
        WakeRandomly();
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

    
}
