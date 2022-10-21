using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{

    public Board score;

    public bool eggSpawned;
    public bool stage2;
    public bool stage3;

    //references to the monster game objects
    public GameObject Egg_model;
    public GameObject MonsterStage2;
    public GameObject MonsterStage3;


    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Board").GetComponent<Board>();

        eggSpawned = false;

        stage2 = false;

        stage3 = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (score.MatchScore >= 50  && eggSpawned == false)
        {
            Destroy(Egg_model);

        }

       



       /* if (score.MatchScore >= 8 && stage2 == false)
        {
            var Monster2 = Instantiate(MonsterStage2, new Vector3(1.5f, 3.4f, 1.15f), Quaternion.identity);
            Debug.Log("Event triggered");
            Destroy(Egg_model);
            Instantiate(Monster2);
            stage2 = true;

            if (score.MatchScore >= 20 && stage3 == false)
            {
                var Monster3 = Instantiate(MonsterStage3, new Vector3(1.5f, 3.4f, 1.15f), Quaternion.identity);
                Destroy(Monster2);
                Instantiate(Monster3);
                stage3 = true;
            }


        }
        */


    }
}
