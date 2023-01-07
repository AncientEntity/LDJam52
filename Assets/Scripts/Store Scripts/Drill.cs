using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drill : MonoBehaviour
{
    public Text Drill_Level;
    public Text Buy;
    int drill = 0;
    public static int cost = 100;

    void Update()
    {
        drill = GameManager.drill_level + 1;
        Drill_Level.text = drill.ToString();
        Buy.text = "$" + cost.ToString();
    }
}