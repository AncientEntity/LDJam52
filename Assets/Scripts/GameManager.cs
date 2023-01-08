using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public static int money
    {
        get
        {
            if(_money == -1)
            {
                _money = PlayerPrefs.GetInt("Money",500);
            }
            return _money;
        }
        set
        {
            PlayerPrefs.SetInt("Money", value);
            PlayerPrefs.Save();
            _money = value;
        }
    }
    private static int _money = -1;

    //Item levels
    public static int drill_level
    {
        get
        {
            if (_drill_level == -1)
            {
                _drill_level = PlayerPrefs.GetInt("DrillLevel", 1);
            }
            return _drill_level;
        }
        set
        {
            PlayerPrefs.SetInt("DrillLevel", value);
            PlayerPrefs.Save();
            _drill_level = value;
        }
    }
    private static int _drill_level = -1;

    public static int drill_speed
    {
        get
        {
            if (_drill_speed == -1)
            {
                _drill_speed = PlayerPrefs.GetInt("drill_speed", 1);
            }
            return _drill_speed;
        }
        set
        {
            PlayerPrefs.SetInt("drill_speed", value);
            PlayerPrefs.Save();
            _drill_speed = value;
        }
    }
    private static int _drill_speed = -1;

    public static int drill_bit
    {
        get
        {
            if (_drill_bit == -1)
            {
                _drill_bit = PlayerPrefs.GetInt("drill_bit", 1);
            }
            return _drill_bit;
        }
        set
        {
            PlayerPrefs.SetInt("drill_bit", value);
            PlayerPrefs.Save();
            _drill_bit = value;
        }
    }
    private static int _drill_bit = -1;


    public static int drill_eff
    {
        get
        {
            if (_drill_eff == -1)
            {
                _drill_eff = PlayerPrefs.GetInt("drill_eff", 1);
            }
            return _drill_eff;
        }
        set
        {
            PlayerPrefs.SetInt("drill_eff", value);
            PlayerPrefs.Save();
            _drill_eff = value;
        }
    }
    private static int _drill_eff = -1;

    public static int drill_cost = 250;
    public static int iron = 0;

    //Ship levels

    public static int ship_speed
    {
        get
        {
            if (_ship_speed == -1)
            {
                _ship_speed = PlayerPrefs.GetInt("ship_speed", 1);
            }
            return _ship_speed;
        }
        set
        {
            PlayerPrefs.SetInt("ship_speed", value);
            PlayerPrefs.Save();
            _ship_speed = value;
        }
    }
    private static int _ship_speed = -1;

    public static int ship_harvest
    {
        get
        {
            if (_ship_harvest == -1)
            {
                _ship_harvest = PlayerPrefs.GetInt("ship_harvest", 1);
            }
            return _ship_harvest;
        }
        set
        {
            PlayerPrefs.SetInt("ship_harvest", value);
            PlayerPrefs.Save();
            _ship_harvest = value;
        }
    }
    private static int _ship_harvest = -1;

    public static int ship_storage
    {
        get
        {
            if (_ship_storage == -1)
            {
                _ship_storage = PlayerPrefs.GetInt("ship_storage", 1);
            }
            return _ship_storage;
        }
        set
        {
            PlayerPrefs.SetInt("ship_storage", value);
            PlayerPrefs.Save();
            _ship_storage = value;
        }
    }
    private static int _ship_storage = -1;


    //Extractor
    public static int ext_level = 0;

    //Materials
    public static int planet_core
    {
        get
        {
            if (_planet_core == -1)
            {
                _planet_core = PlayerPrefs.GetInt("Cores", 0);
            }
            return _planet_core;
        }
        set
        {
            PlayerPrefs.SetInt("Cores", value);
            PlayerPrefs.Save();
            _planet_core = value;
        }
    }
    private static int _planet_core = -1;



    private void Awake(){instance = this;}

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
                    drill_cost += 125;
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

    public void BuyExt(int cost){
        if(HasMoney(cost) == true){
            AddMoney(-cost);
            ext_level = 1;
        }
    }


/**********************************Shop Selling*************************/
    public bool SellIron(int cost, bool all){
        throw new System.NotImplementedException();
        //if(iron > 0){
        //    if(all == true){
        //        AddMoney(cost * iron);
        //        iron = 0;
        //    }else{
        //        AddMoney(cost);
        //        iron--;
        //    }
        //    return true;
        //}
        //return false;
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