using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowShop : MonoBehaviour
{
    public GameObject Shop;

    public void Start()
    {
        Shop.SetActive(false);
    }

    public void DisplayShop()
    {
        Shop.SetActive(true);
    }

}
