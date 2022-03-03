using DG.Tweening;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    private Tween moveTween;
    [SerializeField] protected float duration;
    [SerializeField] protected Ease moveEasing;
    protected void Move()
    {
        moveTween = transform.DOMove(Player.Instance.transform.position, duration).SetEase(moveEasing).SetAutoKill(false);
        moveTween.Play();
    }
    protected abstract void Collide();
}
