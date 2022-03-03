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
    
    private static Direction RandomDirection()
    {
        return (Direction) Random.Range(0, 4);
    }
    public static float RandomFloat(float min, float max)
    {
        return Random.Range(min, max);
        //double val = (_random.NextDouble() * (max - min) + min);
        //return (float) val;
    }

    internal static Vector3 RandomInCameraBounds()
    {
        Vector3 outputVector = new Vector3(0f, 0f, 0f);
        switch (RandomDirection())
        {
            case Direction.Up:
                outputVector = new Vector3(RandomFloat(-4.76f, 4.76f), RandomFloat(5.73f, 6f), 0f);
                break;
            case Direction.Left:
                outputVector = new Vector3(RandomFloat(-4.76f, -5f), RandomFloat(5.73f, -5.87f), 0f);
                break;
            case Direction.Down:
                outputVector = new Vector3(RandomFloat(-4.76f, 4.76f), RandomFloat(-5.87f, -6f), 0f);
                break;
            case Direction.Right:
                outputVector = new Vector3(RandomFloat(4.76f, 5f), RandomFloat(5.73f, -5.87f), 0f);
                break;
        }

        return outputVector;
    }

    public static void SetSpawnLocation(GameObject spawnableObject, GameObject spawnAt = null)
    {
        if (spawnableObject == null)
            return;
        
        if (spawnAt == null)
        {
            spawnableObject.transform.position = RandomInCameraBounds();
        }
        else
        {
            spawnableObject.transform.position = spawnAt.transform.position;
        }
        
        
    }
    
    private static float GetRotationAngle(Vector3 rotationVector)
    {
        return Mathf.Atan2(rotationVector.y, rotationVector.x) * Mathf.Rad2Deg;
    }
}
