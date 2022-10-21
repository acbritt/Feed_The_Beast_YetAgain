using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
    public int column;
    public int row;

    private GameObject otherDot;

    private Vector3 firstTouchPosition;

    private Vector3 finalTouchPosition;

    public float swipeAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CalculateAngle();
    }



    void CalculateAngle()
    {
        swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x  -  firstTouchPosition.x)  *  180 / Mathf.PI;
        Debug.Log(swipeAngle);

    }


    void MovePieces()
    {
        if (swipeAngle > -45  && swipeAngle  <= 45)
            //right swipe
        {

        }
    }
        
}
