using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cores : MonoBehaviour
{
    public Text Sell_all;
    public Text Sell;

    public static int cost = 666;

    // Update is called once per frame
    void Update()
    {
        Sell_all.text = "$" + (GameManager.planet_core * cost).ToString();
        Sell.text = "$" + cost.ToString();
    }
}
