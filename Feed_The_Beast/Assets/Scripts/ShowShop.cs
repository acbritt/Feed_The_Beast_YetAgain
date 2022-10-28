using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowShop : MonoBehaviour
{
    public GameObject Shop;
    public GameObject Progressbar;
    public GameObject Shopbutton;

    public void Start()
    {
        Shop.SetActive(false);
        Shopbutton.SetActive(true);
    }

    public void DisplayShop()
    {
        Progressbar.SetActive(false );
        Shopbutton.SetActive(false );
        Shop.SetActive(true);
    }

}
