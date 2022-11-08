using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEvolve : MonoBehaviour
{
    private Vector3 scaleChange;

    public AudioSource tapSound;

    public int tapCount;

    public GameObject M;
    public MonsterSpawn toggle;

    private void Awake()
    {
        scaleChange = new Vector3(2f, 2f, 2f);

        
    }

    private void OnMouseDown()
    {
        M.GetComponent<MonsterSpawn>();

        tapSound.Play();

        transform.localScale += scaleChange;

        tapCount++;

    }

    private void OnMouseUp()
    {
        transform.localScale += -scaleChange;

        if (toggle.toggleTap == true)
        {
            Debug.Log("tap activated");
            
        }
    }


}
