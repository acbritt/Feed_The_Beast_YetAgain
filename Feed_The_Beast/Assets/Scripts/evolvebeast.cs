using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class evolvebeast : MonoBehaviour 
 
{
    private Text Score;
    private int ScoreAmount;
    // Start is called before the first frame update
    void Start()
    {
        ScoreAmount = 0;
        Score = GetComponent<Text>();
    }
    private void Update()
    {
        Score.text = ScoreAmount.ToString();
        
    }

    public void AddScore()
    {
        ScoreAmount += 1;
    }
    
    


}
