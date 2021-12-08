using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLockDoor : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };

    private bool coroutineAllowed;

    private int numberShown;

    public float yRotate;

    // Start is called before the first frame update
    private void Start()
    {
        coroutineAllowed = true;
        numberShown = 1;
    }

    private void OnMouseDown()
    {
        if (coroutineAllowed)
        {
            StartCoroutine("RotateWheel");
        }
    }

    private IEnumerator RotateWheel()
    {
        coroutineAllowed = false;

        for (int i = 0; i < 10; i++)
        {
            transform.Rotate(0f, yRotate, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        coroutineAllowed = true;
        numberShown += 1;

        if (numberShown > 4)
        {
            numberShown = 1;
        }

        Rotated(name, numberShown);
    }
}
