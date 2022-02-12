using UnityEngine;

public abstract class Projectile : ScriptableObject
{
    public float speed;
    public GameObject projectileModel;
    
    public abstract void Move(Transform transform, Transform target);
    public abstract void Collide(GameObject collidingObject);
}
