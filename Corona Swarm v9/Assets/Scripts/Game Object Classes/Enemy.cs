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
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") || col.CompareTag("Shield") || col.CompareTag("Protection Shield"))
        {
            Collide();
        }
    }

    // Collides and throws particles when colliding with Player, Shield and Protection Shield. Also adding score to player.
    protected override void Collide()
    {
        ParticleManager.Instance.SpawnParticle(gameObject);
        
        // bu doğru mu öğren
        Player.Instance.AddKillScore(_score);
        gameObject.SetActive(false);
    }

    
}
