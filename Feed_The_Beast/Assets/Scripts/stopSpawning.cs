using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopSpawning : MonoBehaviour
{
   // public bool spaceFull;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");
        //spaceFull = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        
        if (other.gameObject.tag == "topCollider1")
        {
            //spaceFull = true;
            GameObject.Find("spawner1").GetComponent<itemSpawn>().colliding = true;
            Debug.Log("entered");
        }

        if (other.gameObject.tag == "topCollider2")
        {
            //spaceFull = true;
            GameObject.Find("spawner2").GetComponent<itemSpawn>().colliding = true;
            Debug.Log("entered");
        }

        if (other.gameObject.tag == "topCollider3")
        {
            //spaceFull = true;
            GameObject.Find("spawner3").GetComponent<itemSpawn>().colliding = true;
            Debug.Log("entered");
        }

        if (other.gameObject.tag == "topCollider4")
        {
            //spaceFull = true;
            GameObject.Find("spawner4").GetComponent<itemSpawn>().colliding = true;
            Debug.Log("entered");
        }

        if (other.gameObject.tag == "topCollider5")
        {
            //spaceFull = true;
            GameObject.Find("spawner5").GetComponent<itemSpawn>().colliding = true;
            Debug.Log("entered");
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "topCollider1")
        {
            //spaceFull = true;
            GameObject.Find("spawner1").GetComponent<itemSpawn>().colliding = false;
            Debug.Log("exited");

        }


        if (other.gameObject.tag == "topCollider2")
        {
            //spaceFull = true;
            GameObject.Find("spawner2").GetComponent<itemSpawn>().colliding = false;
            Debug.Log("exited");

        }

        if (other.gameObject.tag == "topCollider3")
        {
            //spaceFull = true;
            GameObject.Find("spawner3").GetComponent<itemSpawn>().colliding = false;
            Debug.Log("exited");

        }

        if (other.gameObject.tag == "topCollider4")
        {
            //spaceFull = true;
            GameObject.Find("spawner4").GetComponent<itemSpawn>().colliding = false;
            Debug.Log("exited");

        }

        if (other.gameObject.tag == "topCollider5")
        {
            //spaceFull = true;
            GameObject.Find("spawner5").GetComponent<itemSpawn>().colliding = false;
            Debug.Log("exited");

        }


    }



}
