using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    [SerializeField] private PlayerData _playerData;

    private long score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }
    
    void Update()
    {
        LookAtMouse();
    }
    
    private void LookAtMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rotateDirection = mousePosition - transform.position;//transform.position;

        transform.up = rotateDirection;
    }


    public IEnumerator GetProtection(float seconds = 0f)
    {
        _playerData.hasProtection = true;
        if (seconds == 0)
        {
            yield return new WaitForSeconds(3);
        }
        else
        {
            yield return new WaitForSeconds(seconds);
        }
        _playerData.hasProtection = false;
    }

    public IEnumerator Heal(int hp)
    {
        _playerData.SetHealth(hp);
        yield return GetProtection(1.5f);
    }

    // Bunu solid'e uyarla.
    /*public void AddKillScore(int score)
    {
        _playerData.AddScore(score);
    }

    private IEnumerator TakeDamage(int damage)
    {
        _playerData.SetHealth(_playerData.GetHealth() - damage);
        if (_playerData.GetHealth() <= 0)
        {
            _playerData = null;
            yield break;
        }
        yield return GetProtection();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            StartCoroutine(TakeDamage(0));
        }
    }*/
}
