using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;


public class test : MonoBehaviour
{

    private PlayerInput playerInput;

    public GameObject selector;
    public bool isSelected = true;
   

    // Start is called before the first frame update

        


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        playerInput.onActionTriggered += PlayerInput_onActionTriggered;
    }

    private void Start()
    {
        
    }

    private void PlayerInput_onActionTriggered(InputAction.CallbackContext context)
    {
        Debug.Log(context);

        
    }


    private void OnTouchInput()
    {

    }


   

    // Update is called once per frame
    public void toggleSelector()
    {
        isSelected = !isSelected;
        selector.SetActive(isSelected);
    }
}
