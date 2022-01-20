using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoSingleton<Player>
{
    private GameObject _spawnPoint;
    private void Awake()
    {
        _spawnPoint = GameObject.FindWithTag("Spawn Point");
       
        //DontDestroyOnLoad();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = _spawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Killer Object"))
        {
            Destroy(gameObject);
        }

        
        if (col.CompareTag("Score Item"))
        {
            Destroy(col.gameObject);
        }

        if (col.CompareTag("Finish Object"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
