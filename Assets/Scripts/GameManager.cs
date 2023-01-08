using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public static long money = 10000000000;

    //Item levels
    public static int drill_level = 2;
    public static int drill_speed = 2;
    public static int drill_bit   = 2;
    public static int drill_eff   = 2;

    //Ship shit
    public static int ship_speed = 2;
    public static int ship_harvest = 2;
    public static int ship_storage = 2;


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

    public static bool HasMoney(int cost){
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
        }
        return false;
    }

    public bool BuyShip(int cost, int key){
        if(HasMoney(cost) == true){
            AddMoney(-cost);
            switch(key){
                case 1:
                    ship_speed++;
                    break;
                case 2:
                    ship_harvest++;
                    break;
                case 3:
                    ship_storage++;
                    break;
            }
            return true;
        }
        return false;
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
    