using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static bool Equals(float f1, float f2)
    {
        return Math.Abs(f1 - f2) < 0.0000001f;
    }
    
    public static float GetColliderHeight(Collider collider)
    {
        return collider.bounds.size.y;
    }
}
