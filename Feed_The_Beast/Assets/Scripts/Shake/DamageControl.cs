using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour
{
    [SerializeField]
    private bool shakeCam;
    [SerializeField]
    private bool shakePlayer;
      void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D rayhit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
            if(rayhit.collider != null)
            {
                if (shakeCam)
                {
                    DamageThisObject(Camera.main.gameObject);
                }
                if (shakePlayer)
                {
                    DamageThisObject(rayhit.collider.gameObject);
                }
                
            }
        }

      
        
    }
    private void DamageThisObject(GameObject dmgObject)
    {
        dmgObject.GetComponent<HealthControl>().ShakeMe();
    }
}
