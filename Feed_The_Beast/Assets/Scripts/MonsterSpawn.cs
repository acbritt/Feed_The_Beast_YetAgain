using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{

    public Board score;

    public bool stage1;
    public bool stage2;
    public bool stage3;

    //references to the monster game objects
    public GameObject Stage1;
    public GameObject Stage2;
    public GameObject Stage3;

    public bool P_Bar_Stage2;
    public bool P_Bar_Stage3;

    public int MStage2TargetScore;
    public int MStage3TargetScore;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Board").GetComponent<Board>();

        //toggles the spawn to prevent duplicates from spawning
        stage1 = true;
        stage2 = false;
        stage3 = false;

        // bool to tell the evoluton progress bar when to readjust it's maximum amount
        P_Bar_Stage2 = false;
        P_Bar_Stage3 = false;

        Stage1 = Instantiate(Stage1, new Vector3(1.5f, 3.4f, 1.15f), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (score.MatchScore >= MStage2TargetScore && stage1 == true)
        {
            Destroy(Stage1);

            Stage2 = Instantiate(Stage2, new Vector3(1.5f, 3.4f, 1.15f), Quaternion.identity);

            stage1 = false;

            P_Bar_Stage2 = true;

           

        }



        if (score.MatchScore >= MStage3TargetScore && stage2 == false)
        {
            Destroy(Stage2);

            Stage2 = Instantiate(Stage3, new Vector3(1.5f, 3.4f, 1.15f), Quaternion.identity);

            stage2 = true;

            P_Bar_Stage2 = false;

            P_Bar_Stage3 = true;

        }



    }
}
