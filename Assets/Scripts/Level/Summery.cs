using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summery : MonoBehaviour
{
    public Text Money;
    public Text Spent;
    public Text Made;
    public Text Ore;



    public static int starting_money = 0;       //set
    public static int money_made = 0;           //set
    public static int ore_mined = 0;            //set
    public static int drills_bought = 0;        //set
    public static int ships_bought = 0;

    int predicted_money = 0;


    // Update is called once per frame
    void Update()
    {
        predicted_money = money_made + starting_money;
        Money.text = "$" + (GameManager.money).ToString();
        Spent.text = "$" + (predicted_money - GameManager.money).ToString();
        Made.text = "$" + (GameManager.money - starting_money).ToString();
        Ore.text = (ore_mined).ToString();
    }
}
