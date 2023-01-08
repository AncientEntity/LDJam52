using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;


public class Money : MonoBehaviour
{
    public Text MoneyText;
    public Text OreText;
    public Text CoreText;

    void Start(){
        MoneyText.color = Color.white;
        OreText.color = Color.white;
        CoreText.color = Color.white;
    }

    void Update()
    {
        if(GameManager.money <= 10000){
            MoneyText.text = "$" + GameManager.money.ToString();
        }else if(GameManager.money <= 1000000){
            MoneyText.text = "$" + (GameManager.money/1000).ToString() + "K";
        }else{
            MoneyText.text = "$" + (GameManager.money/10000000).ToString() + "Mil";
        }



        OreText.text = "Ores: " + GameManager.iron.ToString();
        CoreText.text = "Cores: " + GameManager.planet_core.ToString();
    }
}
