using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{   
    public int Drill_Modifier = 3;




    public void BuyDrill(){
        bool buy = GameManager.instance.BuyDrill(Drill.cost);
        if(buy){
            Drill.cost = Drill.cost * Drill_Modifier;
            //Change ui to bought
            //change price 
        }else{
            //add ui to cant buy 
            //display how much your missing? 
        }
        return;
    }

    public void SellIron(bool all){
        bool sell = GameManager.instance.SellIron(Iron.cost , all);
        if(sell == true){
            print("selling was successful");
        }else{
            print("selling failed");
        }
    }
}
