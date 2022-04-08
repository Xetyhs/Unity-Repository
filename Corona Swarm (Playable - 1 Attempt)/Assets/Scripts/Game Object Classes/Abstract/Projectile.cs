using DG.Tweening;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    private Tween moveTween;
    protected bool awoken = false;
    [SerializeField] protected float duration;
    [SerializeField] protected Ease moveEasing;
    
    protected void Move()
    {
        moveTween = transform.DOMove(Player.Instance.transform.position, duration).SetEase(moveEasing).SetAutoKill(false);
        moveTween.Play();
    }

    protected bool CollisionConstraints(Collider2D col) => col.CompareTag("Player") || col.CompareTag("Shield") || col.CompareTag("Protection Shield");
    protected abstract void DisableTrigger();
}
