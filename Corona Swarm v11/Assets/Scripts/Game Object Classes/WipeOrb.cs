using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipeOrb : Projectile
{
    [SerializeField] private GameObject wipeOrbExplosion;
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (CollisionConstraints(col))
        {
            gameObject.SetActive(false);
        }
    }

    protected override void DisableTrigger()
    {
        //wipeOrbExplosion.SetActive(true);
        ParticleManager.Instance.SpawnParticle(Player.Instance.gameObject);
        Player.Instance.WipeEnemies();
    }
}
