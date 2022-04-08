using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoSingleton<MenuUI>
{
    [SerializeField] private GameObject _inGameUI;
    public static bool gameRunning = false;
    
    // Start is called before the first frame update

    private void OnEnable()
    {
        gameRunning = false;
        _inGameUI.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        gameRunning = true;
        _inGameUI.gameObject.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            CloseMainMenu();
            WaveManager.Instance.gameObject.SetActive(true);
        }
    }

    public void OpenMainMenu()
    {
        gameObject.SetActive(true);
    }
    
    public void CloseMainMenu()
    {
        gameObject.SetActive(false);
    }
    
}
