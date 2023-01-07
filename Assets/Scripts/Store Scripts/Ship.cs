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

    void Update()
    {
        Storage_lvl.text = (GameManager.ship_storage + 1).ToString();
        Storage_Buy.text = "$" + storage_cost.ToString();
        if(GameManager.HasMoney(storage_cost) == true){
            Storage_Buy.color = Color.green;
        }else{
            Storage_Buy.color = Color.red;
        }

        Speed_lvl.text = (GameManager.ship_speed + 1).ToString();
        Speed_Buy.text = "$" + speed_cost.ToString();
        if(GameManager.HasMoney(speed_cost) == true){
            Speed_Buy.color = Color.green;
        }else{
            Speed_Buy.color = Color.red;
        }

        Harvest_lvl.text = (GameManager.ship_harvest + 1).ToString();
        Harvest_Buy.text = "$" + harvest_cost.ToString();   
        if(GameManager.HasMoney(harvest_cost) == true){
            Harvest_Buy.color = Color.green;
        }else{
            Harvest_Buy.color = Color.red;
        }
        

    }
}
