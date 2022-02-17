using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ExplosionParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticle;
    private Tween _particleAnim;
    private void OnEnable()
    {
        explosionParticle.DOPlay();
    }

    private void Update()
    {
        if(!explosionParticle.isStopped) return;

        explosionParticle.DOKill();
        gameObject.SetActive(false);
    }
}
