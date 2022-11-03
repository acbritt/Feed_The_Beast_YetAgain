using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{

    public bool stage1;
    public bool stage2;
    public bool stage3;
    public bool stage4;
    public bool stage5;
    public bool stage6;


    public int maximum;

    public int current;

    public Image mask;

    public Board Board;

    public MonsterSpawn monster;

    // Start is called before the first frame update
    void Start()
    {
        stage1 = false;

        current = 0;

        gameObject.GetComponent<Board>();

        maximum = monster.MStage2TargetScore;
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();

        //sets the bar to always show the current score
        current = Board.MatchScore;

 //     changes the max value of the progress bar to match the
 //     target score for the next stage:       
        if(monster.P_Bar_Stage2 == true  && stage1 == false)
        {
            //resets bar so the points don't carry over
            Board.MatchScore = 0;

            maximum = monster.MStage3TargetScore;

 //         breaks the update loop so it doesn't 
 //         infinitely reset bar to 0
            stage1 = true;
           
        }

        if (monster.P_Bar_Stage3 == true && stage2 == false)
        {
            Board.MatchScore = 0;
            maximum = monster.MStage4TargetScore;
            stage2 = true;

        }

        if (monster.P_Bar_Stage4 == true && stage3 == false)
        {
            Board.MatchScore = 0;
            maximum = monster.MStage5TargetScore;
            stage3 = true;

        }

        if (monster.P_Bar_Stage5 == true && stage4 == false)
        {
            Board.MatchScore = 0;
            maximum = monster.MStage6TargetScore;
            stage4 = true;

        }

     

    }




    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
