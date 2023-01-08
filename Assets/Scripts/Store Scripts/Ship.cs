using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public Text Storage_lvl;
    public Text Storage_Buy;

    public Text Speed_lvl;
    public Text Speed_Buy;

    public Text Harvest_lvl;
    public Text Harvest_Buy;

    public static int storage_cost = 100;
    public static int speed_cost = 100;
    public static int harvest_cost = 100;

    /*
    storage Max 10: increases storage ammount of ships (max x500%)
    Speed Max 10: increases raw flying speed of ships (max x500%)
    Harvest Max 10: increases how fast ship picks up resourses from planet (max x500%)
    */




    void Update()
    {
        if(GameManager.ship_storage <= 10){
            Storage_lvl.text = (GameManager.ship_storage).ToString();
            Storage_Buy.text = "$" + storage_cost.ToString();
            if(GameManager.HasMoney(storage_cost) == true){
                Storage_Buy.color = Color.green;
            }else{
                Storage_Buy.color = Color.red;
            }
        }else{
            Storage_Buy.text = "MAX LEVEL";
            Storage_Buy.color = Color.black;
        }

        if(GameManager.ship_speed <= 10){
            Speed_lvl.text = (GameManager.ship_speed ).ToString();
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

        if(GameManager.ship_harvest <= 10){
            Harvest_lvl.text = (GameManager.ship_harvest).ToString();
            Harvest_Buy.text = "$" + harvest_cost.ToString();   
            if(GameManager.HasMoney(harvest_cost) == true){
                Harvest_Buy.color = Color.green;
            }else{
                Harvest_Buy.color = Color.red;
            }
        }else{
            Harvest_Buy.text = "MAX LEVEL";
            Harvest_Buy.color = Color.black;
        }
        

    }
}
