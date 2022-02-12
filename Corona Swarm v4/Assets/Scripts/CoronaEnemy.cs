using System;
using UnityEngine;

public class CoronaEnemy : MonoBehaviour
{
    public Enemy enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy.InitializeComponents(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        enemy.Move(transform, Player.Instance.transform);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") || col.CompareTag("Shield"))
        {
            enemy.Collide(gameObject);
        }
    }
}
