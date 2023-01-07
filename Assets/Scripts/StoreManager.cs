using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{   
    public int drill_mod = 3;
    public int drill_speed_mod = 4;
    public int drill_bit_mod = 6;
    public int drill_eff_mod = 8;




/************************************BUY**************************************/

    //buy drill kep is 1
    public void BuyDrill(){
        bool buy = GameManager.instance.BuyDrill(Drill.cost, 1);
        if(buy){
            Drill.cost = Drill.cost * drill_mod;
            //Change ui to bought
            //change price 
        }else{
            //add ui to cant buy 
            //display how much your missing? 
        }
        return;
    }

    //buy speed key is 2
    public void Buy_Drill_Speed(){
        bool buy = GameManager.instance.BuyDrill(Drill.speed_cost, 2);
        if(buy){
            Drill.speed_cost = Drill.speed_cost * drill_speed_mod;
        }
        
    }

    //buy bit key is 3
    public void Buy_Drill_Bit(){
        bool buy = GameManager.instance.BuyDrill(Drill.bit_cost, 3);
        if(buy){
            Drill.bit_cost = Drill.bit_cost * drill_bit_mod;          
        }

    }

    //buy eff key is 4
    public void Buy_Drill_Eff(){
        bool buy = GameManager.instance.BuyDrill(Drill.eff_cost, 4);
        if(buy){
            Drill.eff_cost = Drill.eff_cost * drill_eff_mod;    
        }

    }


/*********************************SELL****************************************/

    public void SellIron(bool all){
        bool sell = GameManager.instance.SellIron(Iron.cost , all);
        if(sell == true){
            print("selling was successful");
        }else{
            print("selling failed");
        }
    }

    public void SellCore(bool all){
        bool sell = GameManager.instance.SellCore(Cores.cost , all);
    }





/********************************OTHER****************************************/

    public void buy_fail(){

    }
}
