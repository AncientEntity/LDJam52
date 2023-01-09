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
    public Text Drills;
    public Text Ships;



    public static int starting_money = 0;       //set
    public static int money_made = 0;           //set
    public static int cores_made = 0;
    public static int ore_mined = 0;            //set
    public static int drills_bought = 0;        //set
    public static int ships_bought = 0;


    // Update is called once per frame
    void Update()
    {
        Money.text = "$" + (GameManager.money).ToString();
        Spent.text = "$" + ((GameManager.money + money_made - starting_money)).ToString();
        Made.text = "$" + money_made.ToString();
        Ore.text = ore_mined.ToString();
        Drills.text = drills_bought.ToString();
        Ships.text = ships_bought.ToString();
    }
}
