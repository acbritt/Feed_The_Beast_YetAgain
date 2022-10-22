using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    public GameObject Popup;

    public void Start()
    {
        Popup.SetActive(false);
    }

    public void OpenPopup ()
    {
        Popup.SetActive(true);
    }
}
