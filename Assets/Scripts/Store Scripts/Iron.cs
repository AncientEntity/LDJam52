using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Iron : MonoBehaviour
{
    public Text Sell_all;
    public Text Sell;
    int iron = 0;
    public int cost = 100;

    void Update()
    {
        iron = GameManager.iron * 100;
        Sell_all.text = iron.ToString();
        Sell.text = cost.ToString();
    }
}
