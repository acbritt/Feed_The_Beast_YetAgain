using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    //  private TouchControls touchControls;

    public static TouchControls tap;
    //public static Ray tapRay;
    //public RaycastHit tapHit;
    private void Awake()
    {
        tap = new TouchControls();
    }

    private void Update()
    {
        //Debug.Log(tap.Touch.tapInput);
    }

    
    private void OnEnable()
    {
        tap.Enable();
    }

    private void OnDisable()
    {
        tap.Disable();
    }





    private void Start()
    {
        Debug.Log("Start");


        tap.Touch.tapInput.started += context => StartTouch(context);
        tap.Touch.tapInput.canceled += context => EndTouch(context);

    }


    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch Started");
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch Ended");
    }
}



