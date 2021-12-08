using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class LockControl : MonoBehaviour
{
    public GameObject door;
    public bool doorOpen;

   //private DoorController _doorController;
    private int[] result, correctCombination;
    
    // Start is called before the first frame update
    private void Start()
    {
        result = new int[] {1, 1, 1};
        correctCombination = new int[] {3, 2, 4};
        MultiLockDoor.Rotated += CheckResults;

        //_doorController = FindObjectOfType<DoorController>();
    }

    private void Update()
    {
        if (doorOpen == true)
        {
            //Moving the door upwards
            door.transform.Translate(Vector3.up * (Time.deltaTime * 5));
        }

        if (door.transform.position.y > 10f)
        {
            //Where the door stops
            doorOpen = false;
            gameObject.SetActive(false);
        }
    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "lock1":
                result[0] = number;
                break;
            
            case "lock2":
                result[1] = number;
                break;
            
            case "lock3":
                result[2] = number;
                break;
        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] &&
            result[2] == correctCombination[2])
        {
            doorOpen = true;
        }
    }
    

    private void OnDestroy()
    {
        MultiLockDoor.Rotated -= CheckResults;

    }
}
