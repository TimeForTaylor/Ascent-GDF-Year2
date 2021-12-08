using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathDamage : MonoBehaviour
{
    //public HUDcontroller hudController;
    private void OnTriggerEnter(Collider death)
    {
        if (death.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("Touched");
            GameMaster.instance.ReStart();
            Death();
        }
    }

    void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
