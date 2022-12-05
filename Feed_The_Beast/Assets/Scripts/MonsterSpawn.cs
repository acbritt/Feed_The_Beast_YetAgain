using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public bool toggleTap;
    public Board score;

    public int taps;

    public TapEvolve tap;
    public GameObject t;

    public bool stage1;
    public bool stage2;
    public bool stage3;
    public bool stage4;
    public bool stage5;
    public bool stage6;

    //references to the monster game objects
    public GameObject Stage1;
    public GameObject Stage2;
    public GameObject Stage3;
    public GameObject Stage4;
    public GameObject Stage5;
    public GameObject Stage6;

    public bool P_Bar_Stage2;
    public bool P_Bar_Stage3;
    public bool P_Bar_Stage4;
    public bool P_Bar_Stage5;
    public bool P_Bar_Stage6;

    public int MStage2TargetScore;
    public int MStage3TargetScore;
    public int MStage4TargetScore;
    public int MStage5TargetScore;
    public int MStage6TargetScore;

    [SerializeField] FlashImage _flashImage = null;
    

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


        toggleTap = false;

    }

    

    // Update is called once per frame
    void Update()
    {
        // Just for testing

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _flashImage.StartFlash(.25f, .5f, Color.white);
        }


        taps = tap.tapCount;

        if (score.MatchScore >= MStage2TargetScore && stage1 == true )
        {

            // toggleTap = true;

            //UI text setActive function for the "tap me" pop-up?


            Debug.Log("next stage");

            _flashImage.StartFlash(.25f, 1f, Color.white);

            Destroy(Stage1);

            Stage2 = Instantiate(Stage2, new Vector3(1.5f, 3.4f, 1.15f), Quaternion.identity);

            tap.tapCount = 0;

            stage1 = false;

            P_Bar_Stage2 = true;

            /* if(tap.tapCount >= 15)
             {

             }
             */
        }



        if (score.MatchScore >= MStage3TargetScore && stage2 == false)
        {
            _flashImage.StartFlash(.25f, 1f, Color.white);

            Destroy(Stage2);

            Stage2 = Instantiate(Stage3, new Vector3(1.5f, 3.4f, 1.15f), Quaternion.identity);

            stage2 = true;

            P_Bar_Stage2 = false;

            P_Bar_Stage3 = true;

        }

        if (score.MatchScore >= MStage4TargetScore && stage3 == false)
        {
            _flashImage.StartFlash(.25f, 1f, Color.white);

            Destroy(Stage2);

            Stage3 = Instantiate(Stage4, new Vector3(1.5f, 3.4f, 1.40f), Quaternion.identity);

            stage3 = true;

            P_Bar_Stage3 = false;

            P_Bar_Stage4 = true;

        }

        if (score.MatchScore >= MStage5TargetScore && stage4 == false)
        {
            _flashImage.StartFlash(.25f, 1f, Color.white);

            Destroy(Stage3);

            Stage4 = Instantiate(Stage5, new Vector3(1.5f, 3.4f, 1.90f), Quaternion.identity);

            stage4 = true;

            P_Bar_Stage4 = false;

            P_Bar_Stage5 = true;

        }

        if (score.MatchScore >= MStage6TargetScore && stage5 == false)
        {
            _flashImage.StartFlash(.25f, 1f, Color.white);

            Destroy(Stage4);

            Stage5 = Instantiate(Stage6, new Vector3(1.5f, 3.4f, 2.32f), Quaternion.identity);

            stage5 = true;

            P_Bar_Stage5 = false;

            P_Bar_Stage6 = true;

        }

    }
}
