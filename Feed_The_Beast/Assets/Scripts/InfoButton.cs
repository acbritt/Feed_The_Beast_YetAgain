using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    public GameObject Popup;
    public GameObject Buybutton;

    public void Start()
    {
        Buybutton.SetActive(false);
        Popup.SetActive(false);
    }

    public void OpenPopup ()
    {
        Buybutton.SetActive(true);
        Popup.SetActive(true);
    }
}
