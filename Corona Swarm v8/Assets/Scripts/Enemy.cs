using System;
using DG.Tweening;
using UnityEngine;

public class Enemy : Projectile
{
    private Tween moveTween;
    [SerializeField] private int score;
    
    private void OnEnable()
    {
        Move();
    }
    
    public override void Move()
    {
        moveTween = transform.DOMove(Player.Instance.transform.position, duration).SetEase(moveEasing).SetAutoKill(false);
        moveTween.Play();
        //transform.position += (target.position - transform.position).normalized * (speed * Time.deltaTime);
        //Rigidbody2D.(Player.Instance.transform.position * speed * Time.deltaTime);

    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Collide();
            
        } else if (col.CompareTag("Shield"))
        {
            //Player.Instance.AddKillScore(score);
            Collide();
        }
    }

    public override void Collide()
    {
        //Instantiate(onDestroyParticles);
        //onDestroyParticles.transform.parent = transform;
        //onDestroyParticles.Play();
        
        ParticleManager.Instance.SpawnParticle(gameObject);
        gameObject.SetActive(false);
    }

    
}
