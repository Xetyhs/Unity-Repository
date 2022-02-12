using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Class <c>Utility</c> contains the utility functions for the game. </summary>
public class Utility : MonoBehaviour
{
    /// <summary> Method <c>FindWithTag</c> finds the first child object of the transform that has the parameter tag. </summary>
    public static Transform FindWithTag(Transform transform, string tag)
    {
        var childCount = transform.childCount;
        Transform output = null;
        for (var i = 0; i < childCount; i++)
        {
            output = transform.GetChild(i);
            if (output.CompareTag(tag))
            {
                return output;
            }
        }

        return output;
    }
}
