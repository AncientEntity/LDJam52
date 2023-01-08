using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drill : MonoBehaviour
{
    public Text Drill_Level;
    public Text Drill_Buy;
    public Text Drill_Power;

    public Text Speed_level;
    public Text Speed_Buy;
    public Text Speed_Power;

    public Text Bit_level;
    public Text Bit_Buy;
    public Text Bit_Power;

    public Text Eff_level;
    public Text Eff_Buy;
    public Text Eff_Power;

    public static float Drill_Mining = 0;


    public static int cost = 500;    
    public static int speed_cost = 350;
    public static int bit_cost = 500;
    public static int eff_cost = 400;

    public static int lvl_power = 100;
    public static int speed_power = 100;
    public static int bit_power = 100;
    public static int eff_power = 100;

    /*
    Drill Level Max = 10: Increases raw (med) drill production for high cost.
    Speed Max = 10: Increases mining speed. Increasing (high) drill production
    Bit Max = 5: Increases *depth* drill can reach, increasing (med) drill production but is a requirment for solar harvesting 
    Eff Max = 10: Takes less solar power to power, increases power (low) production   
    */



    void Update()
    {
        if(GameManager.drill_level <= 10){
            lvl_power = (100 + 30 * (GameManager.drill_level - 2)); 
            Drill_Level.text = (GameManager.drill_level).ToString();
            Drill_Buy.text = "$" + cost.ToString();
            Drill_Power.text = (lvl_power).ToString() + "% -> " + (lvl_power + 30).ToString() + "%";
            if(GameManager.HasMoney(cost) == true){
                Drill_Buy.color = Color.green;
            }else{
                Drill_Buy.color = Color.red;
            }
        }else{
            lvl_power = (100 + 30 * (GameManager.drill_level -2));
            Drill_Power.text = lvl_power.ToString() + "%";
            Drill_Buy.text = "MAX LEVEL";
            Drill_Buy.color = Color.black;
        }

        if(GameManager.drill_speed <= 10){
            speed_power = 100 + 45 * (GameManager.drill_speed - 2); 
            Speed_level.text = (GameManager.drill_speed ).ToString();
            Speed_Buy.text = "$" + speed_cost.ToString();
            Speed_Power.text = speed_power.ToString() + "% -> " + (speed_power + 45).ToString() + "%";
            if(GameManager.HasMoney(speed_cost) == true){
                Speed_Buy.color = Color.green;
            }else{
                Speed_Buy.color = Color.red; 
            }
        }else{
            speed_power = 100 + 45 * (GameManager.drill_speed - 2); 
            Speed_Power.text = speed_power.ToString() + "%";
            Speed_Buy.text = "MAX LEVEL";
            Speed_Buy.color = Color.black;
        }


        if(GameManager.drill_bit <= 5){
            bit_power = 100 + 50 * (GameManager.drill_bit - 2);
            Bit_level.text = (GameManager.drill_bit).ToString();
            Bit_Buy.text = "$" + bit_cost.ToString();
            Bit_Power.text = bit_power.ToString() + "% -> " + (bit_power + 50).ToString() + "%";
            if(GameManager.HasMoney(bit_cost) == true){
                Bit_Buy.color = Color.green;
            }else{
                Bit_Buy.color = Color.red; 
            }    
        }else{
            bit_power = 100 + 50 * (GameManager.drill_bit - 2);
            Bit_Power.text = bit_power.ToString() + "%";
            Bit_Buy.text = "MAX LEVEL";
            Bit_Buy.color = Color.black;
        }
        

        if(GameManager.drill_eff <= 10){
            eff_power = 100 + 15 * (GameManager.drill_eff - 2);
            Eff_level.text = (GameManager.drill_eff).ToString();
            Eff_Buy.text = "$" + eff_cost.ToString();
            Eff_Power.text = eff_power.ToString() + "% -> " + (eff_power + 15).ToString() + "%";
            if(GameManager.HasMoney(eff_cost) == true){
                Eff_Buy.color = Color.green;
            }else{
                Eff_Buy.color = Color.red; 
            }
        }else{
            eff_power = 100 + 15 * (GameManager.drill_eff - 2);
            Eff_Power.text = eff_power.ToString() + "%";
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