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

    //public static Drill_Mining = 0;


    public static int cost = 100;           //To allow other files to use this. Change cost here
    public static int speed_cost = 100;
    public static int bit_cost = 100;
    public static int eff_cost = 100;

    void Update()
    {
        Drill_Level.text = (GameManager.drill_level + 1).ToString();
        Drill_Buy.text = "$" + cost.ToString();
        if(GameManager.HasMoney(cost) == true){
            Drill_Buy.color = Color.green;
        }else{
            Drill_Buy.color = Color.red;
        }

        Speed_level.text = (GameManager.drill_speed + 1).ToString();
        Speed_Buy.text = "$" + speed_cost.ToString();
        if(GameManager.HasMoney(speed_cost) == true){
            Speed_Buy.color = Color.green;
        }else{
            Speed_Buy.color = Color.red; 
        }

        Bit_level.text = (GameManager.drill_bit + 1).ToString();
        Bit_Buy.text = "$" + bit_cost.ToString();
        if(GameManager.HasMoney(bit_cost) == true){
            Bit_Buy.color = Color.green;
        }else{
            Bit_Buy.color = Color.red; 
        }


        Eff_level.text = (GameManager.drill_eff + 1).ToString();
        Eff_Buy.text = "$" + eff_cost.ToString();
        if(GameManager.HasMoney(eff_cost) == true){
            Eff_Buy.color = Color.green;
        }else{
            Eff_Buy.color = Color.red; 
        }
    }



}