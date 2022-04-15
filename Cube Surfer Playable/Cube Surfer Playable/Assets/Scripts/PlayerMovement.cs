using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float _horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movementVector = Vector3.forward + Vector3.right * _horizontalInput;
        transform.Translate( movementVector * Time.deltaTime * 3f);
    }
}
