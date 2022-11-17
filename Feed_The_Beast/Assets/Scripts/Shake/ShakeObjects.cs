using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeObjects : MonoBehaviour
{
    [SerializeField] GameObject[] shakeObjects;
    [SerializeField] float shakeAmount;
    [SerializeField] float shakeDuration;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Shake(shakeObjects);
        }
    }

    private void Shake(GameObject[] shakeObjects)
    {
        foreach(var shakeObject in shakeObjects)
        {
           
        }
    }
}
