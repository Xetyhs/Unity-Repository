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
    
    
    // Collides and throws particles when colliding with Player, Shield and Protection Shield, classic
    protected override void DisableTrigger()
    {
        // Protection particle tasarla
        ParticleManager.Instance.SpawnParticle(gameObject);
    }
}
