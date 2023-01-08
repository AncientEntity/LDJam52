using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    //All text outputs
    public Text Storage_lvl;
    public Text Storage_Buy;
    public Text Storage_Power;

    public Text Speed_lvl;
    public Text Speed_Buy;
    public Text Speed_Power;

    public Text Harvest_lvl;
    public Text Harvest_Buy;
    public Text Harvest_Power; 

    //cost of upgrades (scaling)
    public static int storage_cost = 400;
    public static int speed_cost = 250;
    public static int harvest_cost = 500;

    //% power of each upgrade (storage is just raw ammount it can carry)
    public static int storage_amm = 1;
    public static int speed_power = 100;
    public static int harvest_power = 100;

    //Incrementations of each upgrade
    int storage_inc = 2;
    int speed_inc = 35;
    int harvest_inc = 35;

    /*
    storage Max 10: increases storage ammount of ships (max x500%)
    Speed Max 10: increases raw flying speed of ships (max x500%)
    Harvest Max 10: increases how fast ship picks up resourses from planet (max x500%)
    */




    void Update()
    {
        if(GameManager.ship_storage < 10){
            storage_amm =  storage_amm + (GameManager.ship_storage) + 1;
            Storage_lvl.text = (GameManager.ship_storage + 1).ToString();
            Storage_Buy.text = "$" + storage_cost.ToString();
            Storage_Power.text = storage_amm.ToString() + "T -> " + ((storage_amm + storage_inc).ToString()) + "T"; 
            if(GameManager.HasMoney(storage_cost) == true){
                Storage_Buy.color = Color.green;
            }else{
                Storage_Buy.color = Color.red;
            }
        }else{
            storage_amm = 64;
            Storage_Power.text = storage_amm.ToString() + "T";
            Storage_Buy.text = "MAX LEVEL";
            Storage_Buy.color = Color.black;
        }

        if(GameManager.ship_speed < 10){
            speed_power = 100 + speed_inc * (GameManager.ship_speed - 1);
            Speed_lvl.text = (GameManager.ship_speed + 1).ToString();
            Speed_Buy.text = "$" + speed_cost.ToString();
            Speed_Power.text = speed_power.ToString() + "% -> " + (speed_power + speed_inc).ToString() + "%";
            if(GameManager.HasMoney(speed_cost) == true){
                Speed_Buy.color = Color.green;
            }else{
                Speed_Buy.color = Color.red;
            }
        }else{
            speed_power = 100 + speed_inc * (GameManager.ship_speed - 1);
            Speed_Power.text = speed_power.ToString() + "%";
            Speed_Buy.text = "MAX LEVEL";
            Speed_Buy.color = Color.black;
        }

        if(GameManager.ship_harvest < 10){
            harvest_power = 100 + harvest_inc * (GameManager.ship_harvest - 1);
            Harvest_lvl.text = (GameManager.ship_harvest + 1).ToString();
            Harvest_Buy.text = "$" + harvest_cost.ToString(); 
            Harvest_Power.text = harvest_power.ToString() + "% -> " + (harvest_power + harvest_inc).ToString() + "%" ; 
            if(GameManager.HasMoney(harvest_cost) == true){
                Harvest_Buy.color = Color.green;
            }else{
                Harvest_Buy.color = Color.red;
            }
        }else{
            harvest_power = 100 + harvest_inc * (GameManager.ship_harvest - 1);
            Harvest_Power.text = harvest_power.ToString() + "%";
            Harvest_Buy.text = "MAX LEVEL";
            Harvest_Buy.color = Color.black;
        }
    }

    public static void update_cost(int key){
        if(key == 1){
            //speed is key 1
            switch(GameManager.ship_speed){
                case 2:
                    speed_cost = 718;
                    return;
                case 3:
                    speed_cost = 1471;
                    return;
                case 4:
                    speed_cost = 3015;
                    return;
                case 5:
                    speed_cost = 6181;
                    return;
                case 6:
                    speed_cost = 12672;
                    return;
                case 7:
                    speed_cost = 25977;
                    return;
                case 8:
                    speed_cost = 53253;
                    return;
                case 9:
                    speed_cost = 109169;
                    return;      
            }
        }else if(key == 2){
            //harvest is key 2
            switch(GameManager.ship_harvest){
                case 2:
                    harvest_cost = 975;
                    return;
                case 3:
                    harvest_cost = 1901;
                    return;
                case 4:
                    harvest_cost = 3707;
                    return;
                case 5:
                    harvest_cost = 7229;
                    return;
                case 6:
                    harvest_cost = 14098;
                    return;
                case 7:
                    harvest_cost = 27490;
                    return;
                case 8:
                    harvest_cost = 53605;
                    return;
                case 9:
                    harvest_cost = 104531;
                    return;
            }

        }else if(key == 3){
            //storage is key 3
            switch(GameManager.ship_storage){
                case 2:
                    storage_cost = 840;
                    return;
                case 3:
                    storage_cost = 1764;
                    return;
                case 4:
                    storage_cost = 3704;
                    return;
                case 5:
                    storage_cost = 7779;
                    return;
                case 6:
                    storage_cost = 16336;
                    return;
                case 7:
                    storage_cost = 34306;
                    return;
                case 8:
                    storage_cost = 72043;
                    return;
                case 9:
                    storage_cost = 151291;
                    return;

            }
        }
    }
}
