using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectionShield : MonoSingleton<ProtectionShield>
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out Enemy enemyObject))
        {
            Player.Instance.AddKillScore(enemyObject.score);
            ParticleManager.Instance.SpawnParticle(gameObject);
        }
        
    }
}
