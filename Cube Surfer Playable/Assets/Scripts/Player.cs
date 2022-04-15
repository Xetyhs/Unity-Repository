using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    private GameObject _playerHead;
    private GameObject _stackContainerObj;
    
    // Start is called before the first frame update

    private void Awake()
    {
        _playerHead = GameObject.Find("Head");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseHeight(float height)
    {
        
        //var currentPosition = transform.position;
        Vector3 newPosition = Vector3.up * height;
        _playerHead.transform.position += newPosition;

    }

    public void DecreaseHeight(float height)
    {
        Vector3 newPosition = Vector3.up * height;
        _playerHead.transform.position -= newPosition;
    }

    public void SetContainer(GameObject gameObject)
    {
        _stackContainerObj = gameObject;
    }

    public GameObject GetContainer()
    {
        return _stackContainerObj;
    }
    
     
    
}
