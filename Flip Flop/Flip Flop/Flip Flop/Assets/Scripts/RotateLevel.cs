using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevel : MonoBehaviour
{
    private float _leftRightInput = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        _leftRightInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (_leftRightInput == 0)
            return;

        if (_leftRightInput < 0)
        {
            transform.Rotate(Vector3.forward);
        } else if (_leftRightInput > 0)
        {
            transform.Rotate(Vector3.back);
        }
    }
}
