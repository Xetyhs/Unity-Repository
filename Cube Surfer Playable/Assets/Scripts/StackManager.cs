using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoSingleton<StackManager>
{

    [SerializeField] private Transform _stackContainer;
    
    private Transform _previousObject;
    private float _cubeHeight;

    private bool _hasManagerChanged = false;
    // Start is called before the first frame update
    void Start()
    {
        _cubeHeight = transform.localScale.y;
        _previousObject = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetContainer()
    {
        return _stackContainer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Collectable Cube"))
            return;

        AddCube(other);
        
        /*
        Transform otherTransform = other.transform;
        
        if (otherTransform.parent == _cubesContainer)
        {
            Debug.Log("Bu küp tek bir küp");
            AddCube(other.gameObject);
            return;
        }

        Debug.Log("Bu küp " + otherTransform.childCount + " cocuk küplerden oluşan bir küp");
        for(int i = 0; i < otherTransform.childCount; i++)
        {
            Debug.Log("Küp " + i);
            AddCube(otherTransform.GetChild(i).gameObject);
        }*/
            
    }

    private void AddCube(Collider cubeCollider)
    {
        GameObject cube = cubeCollider.gameObject;
        cube.transform.SetParent(_stackContainer);
        
        
        var destinationPosition = _previousObject.localPosition;
        destinationPosition.y += _cubeHeight;
        // Aşağıya koymasını istiyorsan -=, yukarı koymasını istiyorsan +=


        cube.AddComponent<StackCube>();
        cube.transform.localPosition = destinationPosition;
        _previousObject = cube.transform;

        
        _cubeHeight = Utils.GetColliderHeight(cubeCollider);
        Player.Instance.IncreaseHeight(_cubeHeight);
        
    }
    
    public void RemoveCube(Transform cubeTransform)
    {
        GameObject cube = cubeTransform.gameObject;
        cube.transform.SetParent(null);
        
        //Collider cubeCollider = cube.GetComponent<Collider>();
        //_cubeHeight = Utils.GetColliderHeight(cubeCollider);
        if(cubeTransform == _stackContainer)
            Player.Instance.SetContainer(gameObject);

        /*
        _destinationAfterDeletion = _previousObject.localPosition;
        _destinationAfterDeletion.y -= _cubeHeight;


        _previousObject = cube.transform;
        */
        //Player.Instance.DecreaseHeight(_cubeHeight);
        
    }


    /*
    public void ResetManager(GameObject gameObject)
    {
        if (_hasManagerChanged)
            return;
        
        StackManager stackManager = transform.GetComponent<StackManager>();
        stackManager.enabled = false;
        gameObject.AddComponent<StackManager>();
        gameObject.GetComponent<StackManager>().enabled = true;
        _hasManagerChanged = true;
        
        
    }


    public Transform GetPreviousAdded()
    {
        return _previousObject;
    }
    

    */
}
