using System;
using DG.Tweening;
using UnityEngine;

public class Enemy : Projectile
{
    [SerializeField] private int _score;
    [SerializeField] private int _damage;
    public int damage => _damage;
    public int score => _score;

    private void OnEnable()
    {
        Move();
    }

    private void OnDisable()
    {
        if (!awoken)
        {
            awoken = true;
            return;
        }

        if(Utility.GameActiveSelf()) DisableTrigger();

    }

    // Eğer exceptionu çözemezsen, direkt olarak DeathTrigger yerine Collide yaz, base classta. ve 34. satıra Collide(); yapıştır.
    // İlave olarak OnDisable'ı kapat.
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (CollisionConstraints(col))
        {
            gameObject.SetActive(false);
        }
    }

    // Collides and throws particles when colliding with Player, Shield and Protection Shield. Also adding score to player.
    protected override void DisableTrigger()
    {
        ParticleManager.Instance.SpawnParticle(gameObject);
        
        // bu doğru mu öğren
        Player.Instance.AddKillScore(_score);
    }

    
}
