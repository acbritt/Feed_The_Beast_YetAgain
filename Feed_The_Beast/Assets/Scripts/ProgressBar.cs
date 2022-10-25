using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{

    public bool resetToZero;


    public int maximum;

    public int current;

    public Image mask;

    public Board Board;

    public MonsterSpawn monster;

    // Start is called before the first frame update
    void Start()
    {
        resetToZero = false;

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
        if(monster.P_Bar_Stage2 == true  && resetToZero == false)
        {
            //resets bar so the points don't carry over
            Board.MatchScore = 0;

            maximum = monster.MStage3TargetScore;

 //         breaks the update loop so it doesn't 
 //         infinitely reset bar to 0
            resetToZero = true;
           
        }
       
    }




    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
