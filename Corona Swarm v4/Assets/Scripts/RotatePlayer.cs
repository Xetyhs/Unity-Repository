using System;
using UnityEngine;

public class RotatePlayer : MonoSingleton<RotatePlayer>
{
    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
        
        //Debug.Log(Player.Instance);
        
        // Gets mouse position
        // Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // If we subtract object's transform from mouse position, we get the direction vector.
        // Vector3 rotateDirection = mousePosition - transform.position;//transform.position;
        
        // We get angle of the direction vector in degree version.
        //float angle = GetRotationAngle(rotateDirection);
        
        // We set object's rotation as the Vector3.forward with the angle of the vector towards mouse position.
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //_rigidbody2D.rotation = angle;


        //Quaternion nextRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.RotateAround(player.transform.position, nextRotation.eulerAngles, speed * Time.deltaTime);
        //transform.rotation = Quaternion.Slerp(transform.rotation, nextRotation, speed * Time.deltaTime);
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
