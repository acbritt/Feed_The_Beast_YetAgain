using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawn : MonoBehaviour
{
    // Start is called before the first frame update

    public bool colliding;

    public int spawnTime;

    public Transform SpawnPosition;

    public int spawnCount;

    public GameObject bananaTest;
    public GameObject candyTest;
    public GameObject orangeTest;
    public GameObject appleTest;
    public GameObject blockTest;

    //[SerializeField] private Vector3 spawnPosition;


    void Start()
    {
        spawnCount = 0;

        colliding = false;

        StartCoroutine(SpawnPrefab());

        //SpawnPrefab();
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {

      // if (spawnCount >= 6)
      //  {
      //      colliding = true;
      //  }
      //  else
      //  {
      //     colliding = false;
      //  }
       

        
    }

    IEnumerator SpawnPrefab()
    {
      

        while (colliding == false)
        {
            int prefab = Random.Range(0, 6);

            if (prefab == 1 && colliding == false)
            {
                Instantiate(bananaTest, SpawnPosition.position, Quaternion.identity);
                spawnCount++;
                yield return new WaitForSeconds(spawnTime);

            }

            if (prefab == 2 && colliding == false)
            {
                Instantiate(candyTest, SpawnPosition.position, Quaternion.identity);
                spawnCount++;
                yield return new WaitForSeconds(spawnTime);

            }

            if (prefab == 3 && colliding == false)
            {
                Instantiate(orangeTest, SpawnPosition.position, Quaternion.identity);
                spawnCount++;
                yield return new WaitForSeconds(spawnTime);

            }

            if (prefab == 4 && colliding == false)
            {
                Instantiate(appleTest, SpawnPosition.position, Quaternion.identity);
                spawnCount++;
                yield return new WaitForSeconds(spawnTime);

            }

            if (prefab == 5 && colliding == false)
            {
                Instantiate(blockTest, SpawnPosition.position, Quaternion.identity);
                spawnCount++;
                yield return new WaitForSeconds(spawnTime);

            }





          
        }

        
    }

    


    
}
