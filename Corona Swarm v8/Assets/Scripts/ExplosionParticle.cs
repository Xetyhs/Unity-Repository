using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ExplosionParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticle;
    //private Tween _particleAnimTween later;
    private void OnEnable()
    {
        explosionParticle.gameObject.SetActive(true);
        explosionParticle.Play();
    }

    private void Update()
    {
        if (!explosionParticle.isStopped) return;
        
        //explosionParticle.Stop();
        gameObject.SetActive(false);
    }
    

    
}
