using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cores : MonoBehaviour
{
    public Text Ext_Lvl;
    public Text Ext_Buy;
    public Text Buy_Enabled;

    public Text Sell_all;
    public Text Sell;

    public static int ext_cost = 100000;
    public static int cost = 50000;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.ext_level == 0){
            Ext_Lvl.text = "1";
            if(GameManager.drill_bit == 5){
                //if can buy
                Buy_Enabled.enabled = false;
                Ext_Buy.enabled = true;
                Ext_Buy.text = "$" + ext_cost.ToString();
                if(GameManager.HasMoney(ext_cost) == true){
                    Ext_Buy.color = Color.green;
                }else{
                    Ext_Buy.color = Color.red;
                }
            }else if(GameManager.drill_bit < 5){
                //cant buy
                Buy_Enabled.enabled = true;
                Ext_Buy.enabled = false;
            }
        }else{
            Ext_Buy.enabled = true;
            Buy_Enabled.enabled = false;
            Ext_Buy.text = "MAX LEVEL";
            Ext_Buy.color = Color.black;
        }

        Sell_all.text = "$" + (GameManager.planet_core * cost).ToString();
        Sell.text = "$" + cost.ToString();
        //Sell_all.color = Color.red;
    }

}
