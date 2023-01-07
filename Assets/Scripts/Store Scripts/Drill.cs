using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drill : MonoBehaviour
{
    public Text Drill_Level;
    public Text Drill_Buy;

    public Text Speed_level;
    public Text Speed_Buy;

    public Text Bit_level;
    public Text Bit_Buy;

    public Text Eff_level;
    public Text Eff_Buy;


    public static int cost = 100;           //To allow other files to use this. Change cost here
    public static int speed_cost = 100;
    public static int bit_cost = 100;
    public static int eff_cost = 100;

    void Update()
    {
        Drill_Level.text = (GameManager.drill_level + 1).ToString();
        Drill_Buy.text = "$" + cost.ToString();

        Speed_level.text = (GameManager.drill_speed + 1).ToString();
        Speed_Buy.text = "$" + speed_cost.ToString();

        Bit_level.text = (GameManager.drill_bit + 1).ToString();
        Bit_Buy.text = "$" + bit_cost.ToString();


        Eff_level.text = (GameManager.drill_eff + 1).ToString();
        Eff_Buy.text = "$" + eff_cost.ToString();
    }



}