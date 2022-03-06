using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HealOrb : Projectile
{
    private int _healAmount;
    // private WipeEffect

    public int healAmount => _healAmount;
    
    private void OnEnable()
    {
        _healAmount = Random.Range(15, 30);
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
        // Bir heal particle tasarla. Onu burda kullan
        ParticleManager.Instance.SpawnParticle(Player.Instance.gameObject);
    }
    
    
}
