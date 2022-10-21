using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector2 startTouch, endTouch;

    private Touch touch;

    private IEnumerator startCoroutine;
    private bool coroutine;

    void Start()
    {
        coroutine = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
        }

        if (touch.phase == TouchPhase.Began)
        {
            startTouch = touch.position;
        }

        if (Input.touchCount > 0  &&  touch.phase == TouchPhase.Ended  &&  coroutine)
        {
            endTouch = touch.position;

            if ((endTouch.y > startTouch.y)  &&  (Mathf.Abs(touch.deltaPosition.y)  >  Mathf.Abs(touch.deltaPosition.x)))
                {
                startCoroutine = Go(new Vector3(0f, 0, -0.25f));
                StartCoroutine(startCoroutine);
                }

            else if ((endTouch.y < startTouch.y)  &&  (Mathf.Abs(touch.deltaPosition.y) > Mathf.Abs(touch.deltaPosition.x)))
            {
                startCoroutine = Go(new Vector3(0f, 0, -0.25f));
                StartCoroutine(startCoroutine);
            }

            else if ((endTouch.x < startTouch.x)  &&  (Mathf.Abs(touch.deltaPosition.x) > Mathf.Abs(touch.deltaPosition.y)))
            {
                startCoroutine = Go(new Vector3(-0.25f, 0f, 0f));

            }

            else if ((endTouch.x > startTouch.x) && (Mathf.Abs(touch.deltaPosition.x) > Mathf.Abs(touch.deltaPosition.y)))
            {
                startCoroutine = Go(new Vector3(0.25f, 0f, 0f));

            }
        }
    }


    private IEnumerator Go(Vector3 direction)
    {
        coroutine = false;

        for (int i = 0; i <= 2; i++)
        {
            transform.Translate(direction);
            yield return new WaitForSeconds(0.01f);

        }

        for (int i = 0; i <=2; i++)
        {
            transform.Translate(direction);
            yield return new WaitForSeconds(0.01f);
        }


        transform.Translate(direction);
        coroutine = true;
    }




}
