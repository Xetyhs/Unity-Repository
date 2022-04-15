using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Vector3 _cameraInitialPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        _cameraInitialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _player.transform.position + _cameraInitialPosition, Time.deltaTime);
    }
    
}
