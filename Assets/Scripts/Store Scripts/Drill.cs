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

    public static float Drill_Mining = 0;


    public static int cost = 500;    
    public static int speed_cost = 350;
    public static int bit_cost = 500;
    public static int eff_cost = 400;

    /*
    Drill Level Max = 10: Increases raw (high) drill production for high cost.
    Speed Max = 10: Increases mining speed. Increasing (med) drill production
    Bit Max = 5: Increases *depth* drill can reach, increasing (small) drill production but is a requirment for solar harvesting 
    Eff Max = 10: Takes less solar power to power   
    */



    void Update()
    {
        if(GameManager.drill_level <= 10){
            Drill_Level.text = (GameManager.drill_level).ToString();
            Drill_Buy.text = "$" + cost.ToString();
            if(GameManager.HasMoney(cost) == true){
                Drill_Buy.color = Color.green;
            }else{
                Drill_Buy.color = Color.red;
            }
        }else{
            Drill_Buy.text = "MAX LEVEL";
            Drill_Buy.color = Color.black;
        }

        if(GameManager.drill_speed <= 10){
            Speed_level.text = (GameManager.drill_speed ).ToString();
            Speed_Buy.text = "$" + speed_cost.ToString();
            if(GameManager.HasMoney(speed_cost) == true){
                Speed_Buy.color = Color.green;
            }else{
                Speed_Buy.color = Color.red; 
            }
        }else{
            Speed_Buy.text = "MAX LEVEL";
            Speed_Buy.color = Color.black;
        }


        if(GameManager.drill_bit <= 5){
            Bit_level.text = (GameManager.drill_bit).ToString();
            Bit_Buy.text = "$" + bit_cost.ToString();
            if(GameManager.HasMoney(bit_cost) == true){
                Bit_Buy.color = Color.green;
            }else{
                Bit_Buy.color = Color.red; 
            }    
        }else{
            Bit_Buy.text = "MAX LEVEL";
            Bit_Buy.color = Color.black;
        }
        

        if(GameManager.drill_eff <= 10){
            Eff_level.text = (GameManager.drill_eff).ToString();
            Eff_Buy.text = "$" + eff_cost.ToString();
            if(GameManager.HasMoney(eff_cost) == true){
                Eff_Buy.color = Color.green;
            }else{
                Eff_Buy.color = Color.red; 
            }
        }else{
            Eff_Buy.text = "MAX LEVEL";
            Eff_Buy.color = Color.black;
        }
    }


    public static void update_costs(int key){
        if(key == 1){
            switch(GameManager.drill_level){
                case 2:
                    cost = 1100;
                    return;
                case 3:
                    cost = 2420;
                    return;
                case 4:
                    cost = 5250;
                    return;
                case 5:
                    cost = 11800;
                    return;
                case 6:
                    cost = 25700;
                    return;
                case 7:
                    cost = 57200;
                    return;
                case 8:
                    cost = 89620;
                    return;
                case 9:
                    cost = 112062;
                    return;
                case 10:
                    cost = 157924;
                    return;
            }
        }else if(key == 2){
            switch(GameManager.drill_speed){
                case 2:
                    speed_cost = 735;
                    return;
                case 3:
                    speed_cost = 1544;
                    return;
                case 4:
                    speed_cost = 3241;
                    return;
                case 5:
                    speed_cost = 6807;
                    return;
                case 6:
                    speed_cost = 14294;
                    return;
                case 7:
                    speed_cost = 30018;
                    return;
                case 8:
                    speed_cost = 63038;
                    return;
                case 9:
                    speed_cost = 132380;
                    return;
                case 10:
                    speed_cost = 186250;
                    return;
            }
        }else if(key == 3){
            switch(GameManager.drill_bit){
                case 2:
                    bit_cost = 3250;
                    return;
                case 3:
                    bit_cost = 18875;
                    return;
                case 4:
                    bit_cost = 47438;
                    return;
                case 5:
                    bit_cost = 96424;
                    return;
            }
        }else if(key == 4){
            switch(GameManager.drill_eff){
                case 2:
                    eff_cost = 800;
                    return;
                case 3:
                    eff_cost = 1600;
                    return;
                case 4:
                    eff_cost = 3200;
                    return;
                case 5:
                    eff_cost = 6400;
                    return;
                case 6:
                    eff_cost = 12800;
                    return;
                case 7:
                    eff_cost = 25600;
                    return;
                case 8:
                    eff_cost = 51200;
                    return;
                case 9:
                    eff_cost = 87440;
                    return;
                case 10:
                    eff_cost = 128694;
                    return;
            }
        }
    }
}