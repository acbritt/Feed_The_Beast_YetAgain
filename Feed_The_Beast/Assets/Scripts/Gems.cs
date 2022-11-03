using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Gems : MonoBehaviour
{
    // Start is called before the first frame update

    public Board gem;

    int count;

    public Text gemText;
    void Start()
    {
        count = gem.GemCount;
        gemText.text =  count.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        count = gem.GemCount;
        gemText.text = count.ToString();
    }
}
