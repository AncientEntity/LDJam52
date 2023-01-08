using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Iron : MonoBehaviour
{
    public Text Sell_all;
    public Text Sell;

    public static int cost = 15;

    void Update()
    {
        Sell_all.text = "$" + (GameManager.iron * cost).ToString();
        Sell.text = "$" + cost.ToString();
    }
}
