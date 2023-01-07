using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public static int money = 100000;

    //Item levels
    public static int drill_level = 0;
    public static int drill_speed = 0;
    public static int drill_bit   = 0;
    public static int drill_eff   = 0;


    //Materials
    public static int iron = 100;
    public static int planet_core = 3;



    private void Awake()
    {
        instance = this;
    }


/*******************************Money Managing******************************/

    public void SetMoney(int i){GameManager.money = i;}

    public void AddMoney(int i){GameManager.money += i;}

    public bool HasMoney(int cost){
        if(money >= cost){
            return true;
        }
        return false;
    }


/****************************SHOP BUYING**************************************/
    public bool BuyDrill(int cost, int key){
        if(HasMoney(cost) == true){
            AddMoney(-cost);
            switch(key){
                case 1:
                    drill_level++;
                    break;
                case 2:
                    drill_speed++;
                    break;
                case 3:
                    drill_bit++;
                    break;
                case 4:
                    drill_eff++;
                    break;
            }
            return true;
        }else{
            return false;
        }
    }



/**********************************Shop Selling*************************/
    public bool SellIron(int cost, bool all){
        if(iron > 0){
            if(all == true){
                AddMoney(cost * iron);
                iron = 0;
            }else{
                AddMoney(cost);
                iron--;
            }
            return true;
        }
        return false;
    }

    public bool SellCore(int cost, bool all){
        if(planet_core > 0){
            if(all == true){
                AddMoney(cost * planet_core);
                planet_core = 0;
            }else{
                AddMoney(cost);
                planet_core--;
            }
            return true;
        }
        return false;
    }

}
    