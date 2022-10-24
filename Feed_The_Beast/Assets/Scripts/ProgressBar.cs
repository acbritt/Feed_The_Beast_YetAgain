using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{

    public int maximum;

    public int current;

    public Image mask;

    public Board Board;

    

    // Start is called before the first frame update
    void Start()
    {
        current = 0;

        gameObject.GetComponent<Board>();
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();

        current = Board.MatchScore;
       
    }




    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
