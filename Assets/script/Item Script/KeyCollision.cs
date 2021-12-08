using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollision : MonoBehaviour
{
    private void OnTriggerStay(Collider pickup)
    {
        if (pickup.CompareTag("Player") && Input.GetKey("f"))
        {
            GameMaster.instance.KeyPickup();
            gameObject.SetActive(false);
        }
    }
}
