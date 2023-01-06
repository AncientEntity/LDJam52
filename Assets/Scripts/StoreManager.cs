using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    int money = GameManager.instance.money;
    public Text 

    public void BuyDrill(int cost)
    {
        bool buy = GameManager.instance.BuyDrill(cost);
        if(buy){
            //Change ui to bought
            //change price 
        }else{
            //add ui to cant buy 
            //display how much your missing? 
        }
    }


    void start()
    {
        ValueText.text = Value.ToString();
    }

}
