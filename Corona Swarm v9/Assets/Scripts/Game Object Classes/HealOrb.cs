using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealOrb : Projectile
{
    private int _healAmount;
    
    public int healAmount => _healAmount;
    
    private void OnEnable()
    {
        _healAmount = Random.Range(15, 30);
        Move();
    }
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") || col.CompareTag("Shield") || col.CompareTag("Protection Shield"))
        {
            Collide();
        }
    }
    
    // Collides and throws particles when colliding with Player, Shield and Protection Shield, classic
    protected override void Collide()
    {
        // Bir heal particle tasarla. Onu burda kullan
        ParticleManager.Instance.SpawnParticle(Player.Instance.gameObject);
        gameObject.SetActive(false);
    }
    
    
}
