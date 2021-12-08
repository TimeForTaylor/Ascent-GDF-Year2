using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    public HUDcontroller hudController;
    public int keysCollected = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad((instance));
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        //if (Input.GetKey("[")) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); }
        //else if (Input.GetKey("]")) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
    }

    public void KeyPickup()
    {
        keysCollected++;
        hudController.SetKeyUI("x " + keysCollected);
    }

    public void KeyUsed()
    {
        keysCollected--;
        hudController.SetKeyUI("x " + keysCollected);
    }
    
    public void ReStart()
    {
        keysCollected = 0;
        hudController.SetKeyUI("x " + keysCollected);
    }
}
