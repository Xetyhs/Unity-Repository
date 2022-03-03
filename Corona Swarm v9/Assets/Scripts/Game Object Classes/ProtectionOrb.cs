using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectionOrb : Projectile
{
    // Start is called before the first frame update
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
    
    // Collides and throws particles when colliding with Player, Shield and Protection Shield, classic
    protected override void Collide()
    {
        // Protection particle tasarla
        ParticleManager.Instance.SpawnParticle(gameObject);
        gameObject.SetActive(false);
    }
}
