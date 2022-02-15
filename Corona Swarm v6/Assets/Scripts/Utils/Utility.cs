using UnityEngine;
using Random = UnityEngine.Random;

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

    public static bool GetRandomness(float probablity)
    {
        if (probablity >= 1f)
        {
            return true;
        } else if (probablity <= 0f)
        {
            return false;
        }
        
        float randomFloat = Random.Range(0, 1);
        if (randomFloat > 1 - probablity)
            return true;
        return false;
    }
}
