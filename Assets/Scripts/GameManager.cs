using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public static int money = 0;
    public static int drill_level = 0;


    private void Awake()
    {
        instance = this;
    }

    public void SetMoney(int i) {GameManager.money = i;}
    public void AddMoney(int i) {GameManager.money += i;}

    public bool HasMoney(int cost)
    {
        if(money >= cost){
            return true;
        }
        return false;
    }

    public bool BuyDrill(int cost)
    {
        if(HasMoney(cost)){
            AddMoney(-cost);
            drill_level++;
            return true;
        }else{
            return false;
        }
    }

}
    