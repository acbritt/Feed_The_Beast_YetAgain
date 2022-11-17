using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
    private bool shaking = true;

    [SerializeField]
    private float shakeAmt;

    private void Update()
    {
        if (shaking)
        {
            Debug.Log("This script is being called");
            Vector3 newPos = Random.insideUnitSphere * (Time.deltaTime * shakeAmt);
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;


            transform.position = newPos;
            StartCoroutine(ShakeNow());
        }

    }
    public void ShakeMe()
    {
       // StartCoroutine(ShakeNow());
    }

    IEnumerator ShakeNow()
    {
        
        Vector3 originalPos = transform.position;

        if (shaking == true)
        {
           
            yield return new WaitForSeconds(1.5f);

            transform.position = originalPos;
            shaking = false;
        }
        if (shaking == false)
        {
            yield return new WaitForSeconds(1.5f);

            shaking = true;
        }
        
    }


}
