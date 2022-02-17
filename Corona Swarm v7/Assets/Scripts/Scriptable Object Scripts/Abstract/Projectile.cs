using DG.Tweening;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float duration;
    [SerializeField] protected Ease moveEasing;
    //protected ParticleSystem onDestroyParticles;
    // Protected Particle
    // Protected Hasar ???

    public abstract void Move();
    public abstract void Collide();
}
