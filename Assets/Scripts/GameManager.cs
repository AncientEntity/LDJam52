using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public static int money = 1000;

    //Item levels
    public static int drill_level = 0;

    //Materials
    public static int iron = 100;



    private void Awake()
    {
        instance = this;
    }

    public void SetMoney(int i){GameManager.money = i;}

    public void AddMoney(int i){GameManager.money += i;}

    public bool HasMoney(int cost){
        if(money >= cost){
            return true;
        }
        return false;
    }


    //Buying for shop:
    public bool BuyDrill(int cost){
        if(HasMoney(cost) == true){
            AddMoney(-cost);
            drill_level++;
            return true;
        }else{
            return false;
        }
    }

    //Selling for shop:
    public bool SellIron(int cost, bool all){
        if(iron > 0){
            if(all == true){
                AddMoney(cost * iron);
                iron = 0;
            }else{
                AddMoney(cost);
                iron--;
            }
            print("iron = " + iron);
            return true;
        }else{
            return false;
        }
    }

}
    