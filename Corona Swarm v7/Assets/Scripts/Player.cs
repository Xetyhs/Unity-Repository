using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}
    
    void Update()
    {
        LookAtMouse();
    }
    
    // Returns the multiplication of tan y/x and radian to degree conversion constant. 
    private float GetRotationAngle(Vector3 rotationVector)
    {
        return Mathf.Atan2(rotationVector.y, rotationVector.x) * Mathf.Rad2Deg;
    }

    private void LookAtMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rotateDirection = mousePosition - transform.position;//transform.position;

        transform.up = rotateDirection;
    }
}
