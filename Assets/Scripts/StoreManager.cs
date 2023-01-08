using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{  
    public GameObject Buy_Screen;
    public GameObject Upgrade_Screen;  
    public GameObject Sell_Screen;

/************************************BUY**************************************/

    /***DRILL***/
    //buy drill kep is 1
    public void BuyDrill(){
        if(GameManager.drill_level < 10){
            bool buy = GameManager.instance.BuyDrill(Drill.cost, 1);
            if(buy){
                Drill.update_costs(1);
        }
        return;
        }
    }

    //buy speed key is 2
    public void Buy_Drill_Speed(){
        if(GameManager.drill_speed < 10){
            bool buy = GameManager.instance.BuyDrill(Drill.speed_cost, 2);
            if(buy){
                Drill.update_costs(2);
            }
        }
        
    }

    //buy bit key is 3
    public void Buy_Drill_Bit(){
        if(GameManager.drill_bit < 5){
            bool buy = GameManager.instance.BuyDrill(Drill.bit_cost, 3);
            if(buy){
                Drill.update_costs(3);        
            }
        }

    }

    //buy eff key is 4
    public void Buy_Drill_Eff(){
        if(GameManager.drill_eff < 10){
            bool buy = GameManager.instance.BuyDrill(Drill.eff_cost, 4);
            if(buy){
                Drill.update_costs(4);    
            }
        }
    }

    public void Buy_Exctractor(){
        if(GameManager.ext_level == 0 && GameManager.drill_bit == 5){
            GameManager.instance.BuyExt(Cores.ext_cost);
        }
    }

    /****SHIP****/
    //buy speed key is 1
    public void Buy_Ship_Speed(){
        if(GameManager.ship_speed < 10){      
            bool buy = GameManager.instance.BuyShip(Ship.speed_cost, 1);
            if(buy){
                Ship.update_cost(1);
            }
        }
    }

    //buy harvest key is 2
    public void Buy_Ship_Harvest(){
        if(GameManager.ship_harvest < 10){
            bool buy = GameManager.instance.BuyShip(Ship.harvest_cost, 2);
            if(buy){
                Ship.update_cost(2);
            }
        }
    }

    //buy storage key is 3
    public void Buy_Ship_Storage(){
        if(GameManager.ship_storage < 10){
            bool buy = GameManager.instance.BuyShip(Ship.storage_cost, 3);
            if(buy){
                Ship.update_cost(3);   
            }
        }
    }




/*********************************SELL****************************************/

    public void SellIron(bool all){bool sell = GameManager.instance.SellIron(Iron.cost , all);}

    public void SellCore(bool all){bool sell = GameManager.instance.SellCore(Cores.cost , all);}

/********************************OTHER****************************************/

    public void buy_fail(){

    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Buy_Screen.SetActive(false);
            Upgrade_Screen.SetActive(false);
            Sell_Screen.SetActive(false);
        }
    }
}
