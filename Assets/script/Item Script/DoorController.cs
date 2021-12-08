using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    //public GameObject key;
    public GameObject door;
    public bool doorOpen;
    
    
    void Update()
    {
        if (doorOpen == true)
        {
            //Moving the door upwards
            door.transform.Translate(Vector3.down * (Time.deltaTime * 5));
        }

        if (door.transform.position.y < -10f)
        {
            //Where the door stops
            doorOpen = false;
            gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        //Door open bool to true
        if (GameMaster.instance.keysCollected > 0)
        {
            doorOpen = true;
            GameMaster.instance.KeyUsed();
            //Debug.Log("yo");
        }
    }
}