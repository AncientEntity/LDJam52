﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static readonly string[] bodySuffixes = { "A", "B", "C", "D", "E", "F", "G", "H", "I"};

    public static LevelManager instance = null;
    public static int drillsBought = 0;
    public static int shipAmount = 0;
    [Space]
    public GameObject sunPrefab;
    public List<GameObject> bodyPrefabs = new List<GameObject>();
    public string[] possibleBodyNames;
    [Space]
    public Transform[] tradeStations;
    public Transform bodyParent;
    public GameObject[] orbits;
    public RadialSelection selectionRadial;
    public TextMeshProUGUI timeLeftText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI tradeShipButtonText;
    public Image toggleRadial;
    public Image[] drillRadials;
    public int stageMoney { get { return (int)GameManager.money; }set{ GameManager.money = value; } }
    public int shipCostIncrement = 250;

    private List<SpaceBody> solarBodies = new List<SpaceBody>();
    private List<PlayerBuild> playerBuilds { get { return PlayerBuild.all; } }

    private bool isInit = false;
    private Vector2 lastMousePosition = Vector2.zero;
    private SpaceBody currentlyPressed = null;

    private float timeLeft = 5 * 60; //It's in seconds. So 600. The compiler will simplify it to 600 but I like it as 60 * 5 lmao
    private int currentShipPrice = 250;

    private void Awake()
    {
        instance = this;
        drillsBought = 0;
        Summery.starting_money = stageMoney;
    }

    private void Start()
    {
        Init();
        if(stageMoney<500){
            stageMoney = 500;
        }
        shipAmount = 0;
        Drill.update_values();
        Ship.update_values();
    }

    private void Init()
    {
        if (isInit) { return; }
        isInit = true;

        GameObject star = Instantiate(sunPrefab, bodyParent.position, Quaternion.identity);
        star.transform.SetParent(bodyParent);
        SpaceBody starBody = star.GetComponent<SpaceBody>();
        solarBodies.Add(starBody);

        string systemName = possibleBodyNames[Random.Range(0, possibleBodyNames.Length)];
        if (Random.Range(0, 100) <= 20)
        {
            systemName = "" + Random.Range(1000, 100000);
        }

        starBody.bodyName = systemName + " A";

        int r = Random.Range(2, 5);
        for (int i = 0; i < r; i++)
        {
            GameObject body = Instantiate(bodyPrefabs[Random.Range(0,1)], bodyParent.position, Quaternion.identity);
            body.transform.SetParent(bodyParent);
            SpaceBody spaceBody = body.GetComponent<SpaceBody>();
            spaceBody.Init((i + 1.5f), systemName + " " + bodySuffixes[i + 1]);
            solarBodies.Add(spaceBody);
            orbits[i].SetActive(true);
        }



    }

    private void Update()
    {
        CheckPlanetSelect();
        
        timeLeft -= Time.deltaTime;
        timeLeftText.text = "Till Supernova: " + (timeLeft/60f).ToString("F2") +"yrs";
        moneyText.text = "Credits: $"+stageMoney;

        if(timeLeft <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(5);
        }
    }

    private void CheckPlanetSelect()
    {
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(currentMousePosition == lastMousePosition) { return; }

        bool leftClick = Input.GetMouseButtonDown(0);
        bool rightClick = Input.GetMouseButtonDown(1);

        foreach (SpaceBody body in solarBodies)
        {
            if(currentlyPressed != null && currentlyPressed != body) { continue; }

            float dis = Vector2.Distance(body.actualBody.position, currentMousePosition);
            if (dis <= body.collisionRadius)
            {
                if (!body.isHovering)
                {
                    body.OnHover();
                }
                if(leftClick && body.GetType() != typeof(Star)) { currentlyPressed = body;  body.OnPress(); }
            }
            if((body.isPressed && dis > body.collisionRadius*5f) || ((!body.isPressed && dis > body.collisionRadius))) {
                if (body.isHovering)
                {
                    body.OnUnHover();
                }
                if(body.isPressed)
                {
                    body.OnRelease();
                    currentlyPressed = null;
                }
            }
        }
        if (leftClick)
        {
            bool anyShips = false;
            foreach (PlayerBuild build in playerBuilds.ToArray())
            {
                if (build == null) { playerBuilds.Remove(build); continue; }

                float dis = Vector2.Distance(build.transform.position, currentMousePosition);
                if (dis <= build.collisionRadius)
                {
                    build.SetSelected(!build.isSelected);
                    anyShips = true;
                }

            }
            if (!anyShips)
            {
                foreach (PlayerBuild build in playerBuilds)
                {
                    if (build.isSelected)
                    {
                        build.SetSelected(false);
                    }
                }
            }
        }

        if(rightClick && PlayerBuild.selectedBuilds.Count > 0)
        {
            SpaceBody hovering = CheckSpaceBodyHover();
            if(hovering == null)
            {
                Transform foundStation = null;
                foreach(Transform tradeStation in tradeStations)
                {
                    if(Vector2.Distance(tradeStation.position,Camera.main.ScreenToWorldPoint(Input.mousePosition)) <= 0.6f)
                    {
                        foundStation = tradeStation;
                        break;
                    }
                }



                foreach(PlayerBuild select in PlayerBuild.selectedBuilds)
                {
                    if (foundStation == null)
                    {
                        select.DoMove(Camera.main.ScreenToWorldPoint(Input.mousePosition),true);
                    } else if (foundStation != null && select.GetType() == typeof(DeliveryShip))
                    {
                        ((DeliveryShip)select).targetStation = foundStation;
                    }
                }
            } else
            {
                //If planet, if trade station, etc.
                if(hovering.GetType() == typeof(Planet))
                {
                    foreach(PlayerBuild select in PlayerBuild.selectedBuilds.ToArray())
                    {
                        if(select.GetType() == typeof(DeliveryShip))
                        {
                            DeliveryShip s = (DeliveryShip)select;
                            s.targetPlanet = hovering;

                            //s.SetSelected(false);
                            
                        }
                    }
                }
            }
        }

    }


    public SpaceBody CheckSpaceBodyHover()
    {

        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        foreach (SpaceBody body in solarBodies)
        {
            if (currentlyPressed != null && currentlyPressed != body) { continue; }

            float dis = Vector2.Distance(body.actualBody.position, currentMousePosition);
            if (dis <= body.collisionRadius)
            {
                return body;
            }
        }
        return null;
    }

    public void RadialSpecial(int index)
    {
        currentlyPressed.OnRadialPressed(index);
    }

    public void BuyTradeShip(GameObject tradeShip)
    {
        if(stageMoney >= currentShipPrice && shipAmount < 8)
        {
            shipAmount++;
            stageMoney -= currentShipPrice;
            Instantiate(tradeShip, bodyParent.position + new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0f), Quaternion.identity);
            currentShipPrice += shipCostIncrement;
            if(shipAmount == 8){
                tradeShipButtonText.text = "Buy Trade Ship\nMax";
            }else{               
                tradeShipButtonText.text = "Buy Trade Ship\n$" + currentShipPrice;
            }  
        }
    }
}
